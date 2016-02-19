using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AllAuth.Desktop.Common.Models;
using AllAuth.Lib;
using AllAuth.Lib.APIs;
using AllAuth.Lib.ServerAPI;
using AllAuth.Lib.ServerAPI.Requests.Authenticated;
using ZXing;

namespace AllAuth.Desktop.Forms.Dialogs
{
    internal partial class SetupOtpDeviceLink : Templates.FormDialogWithTitle
    {
        public bool Success { get; private set; }

        private readonly ApiClient _apiClient;
        private readonly ServerAccount _serverAccount;
        private readonly CryptoKey _cryptoKey;

        private string _loginRequestIdentifier;

        private Thread _checkthread;
        private bool _checkThreadStop;

        private bool _formClosed;

        private bool _loadingAnimationRunning;

        public SetupOtpDeviceLink(Controller controller, ApiClient apiClient, 
            ServerAccount serverAccount, CryptoKey cryptoKey)
        {
            InitializeComponent();

            Controller = controller;
            _apiClient = apiClient;
            _serverAccount = serverAccount;
            _cryptoKey = cryptoKey;

            _loadingAnimationRunning = true;
            ImageAnimator.Animate(lblQrCode.Image, AnimateLoader);
            
            txtOtpDeviceLinkCode.Visible = Program.AppEnvDebug;
        }

        private async void SetupOtpDeviceLink_Load(object sender, EventArgs e)
        {
            _loginRequestIdentifier = await GetLoginIdentifier();

            if (_loginRequestIdentifier == null)
            {
                Invoke((MethodInvoker) delegate
                {
                    MessageBox.Show(@"There was an unknown error registering mobile device with the server");
                    Close();
                });
                return;
            }

            var linkCode = new LinkCodeRegisterInitialOtpDevice(_serverAccount.HttpsEnabled,
                    _serverAccount.ServerHost, _serverAccount.ServerPort, _serverAccount.ServerApiVersion,
                    _loginRequestIdentifier, _serverAccount.EmailAddress,
                    _cryptoKey.PublicKeyPemHash, false);
            var linkCodeString = linkCode.ToString();

            Logger.Verbose("Attempting to link to second device with code: " + linkCodeString);

            // The -1 on the dimensions is due to an issue in Mono where the image won't show
            // unless it is smaller than the label (rather than the same size)
            var barcodeWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Margin = 0,
                    Height = lblQrCode.Height - 1,
                    Width = lblQrCode.Height - 1
                }
            };

            ImageAnimator.StopAnimate(lblQrCode.Image, AnimateLoader);
            _loadingAnimationRunning = false;

            var barcodeBitmap = barcodeWriter.Write(linkCodeString);
            lblQrCode.Image = barcodeBitmap;

            _checkthread = new Thread(CheckLink);
            _checkthread.Start();
            
            txtOtpDeviceLinkCode.Text = linkCodeString;
        }

        private void AnimateLoader(object sender, EventArgs args)
        {
            if (!_loadingAnimationRunning)
                return;
            ImageAnimator.UpdateFrames();
            lblQrCode.Invalidate();
        }

        private async Task<string> GetLoginIdentifier()
        {
            var deviceRegisterRequest = new InitiateDeviceLogin();
            try
            {
                var deviceRegisterResponse = await deviceRegisterRequest.GetResponseAsync(_apiClient);
                return deviceRegisterResponse.LoginRequestIdentifier;
            }
            catch (RequestException)
            {
                return null;
            }
        }

        private void CheckLink()
        {
            var setupSuccessful = false;
            var startTime = DateTime.UtcNow;
            var limitTime = startTime.AddSeconds(900);

            while (limitTime > DateTime.UtcNow)
            {
                if (_checkThreadStop)
                    break;
                
                setupSuccessful = Controller.ServerCheckOtpDeviceSetup(
                    _serverAccount, _loginRequestIdentifier);

                if (setupSuccessful)
                    break;

                Thread.Sleep(2000);
            }
            
            if (!setupSuccessful)
            {
                if (_checkThreadStop && !_formClosed)
                    MessageBox.Show(@"Attempt to link device to server account timed out.");
            }

            Success = setupSuccessful;
            
            if (!_formClosed)
                Invoke((MethodInvoker) Close);
        }

        private void SetupOtpDeviceLink_FormClosing(object sender, FormClosingEventArgs e)
        {
            _formClosed = true;
            _checkThreadStop = true;
        }
    }
}
