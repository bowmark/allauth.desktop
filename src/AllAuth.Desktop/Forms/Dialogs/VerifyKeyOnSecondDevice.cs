using System;
using System.Threading;
using System.Windows.Forms;
using AllAuth.Desktop.Common.Models;
using AllAuth.Lib;
using AllAuth.Lib.Crypto;
using ZXing;

namespace AllAuth.Desktop.Forms.Dialogs
{
    internal partial class VerifyKeyOnSecondDevice : Templates.FormDialogWithTitle
    {
        public bool Success { get; private set; }

        private bool _processedByDevice;

        private readonly int _serverAccountId;
        private readonly int _cryptoKeyId;
        private readonly string _nonce;
        
        private Thread _checkthread;
        private bool _checkThreadStop;
        private bool _formClosed;

        public VerifyKeyOnSecondDevice(Controller controller, int serverAccountId, 
            int cryptoKeyId, string nonce)
        {
            InitializeComponent();

            Controller = controller;
            _serverAccountId = serverAccountId;
            _cryptoKeyId = cryptoKeyId;
            _nonce = nonce;

            var accountSettings = Model.ServerAccounts.Get(_serverAccountId);
            var cryptoKey = Model.CryptoKeys.Get(_cryptoKeyId);
            var linkedCryptoKey = Model.CryptoKeys.Get(accountSettings.LinkedDeviceCryptoKeyId);

            lblKeyCode.Text =
                linkedCryptoKey.PublicKeyPemHash.Substring(0, 7) + "\r\n\r\n" +
                cryptoKey.PublicKeyPemHash.Substring(0, 7);
        }

        private void VerifyKeyOnSecondDevice_Load(object sender, EventArgs e)
        {
//            var barcodeWriter = new BarcodeWriter
//            {
//                Format = BarcodeFormat.QR_CODE,
//                Options = new ZXing.Common.EncodingOptions
//                {
//                    Margin = 0,
//                    Height = lblQrCode.Height,
//                    Width = lblQrCode.Height
//                }
//            };
//
//            Logger.Verbose("Verify key with second device code: " + _publicKeyHash);
//            var barcodeBitmap = barcodeWriter.Write(_publicKeyHash);
//            lblQrCode.Image = barcodeBitmap;

            _checkthread = new Thread(CheckLink);
            _checkthread.Start();
        }

        private void CheckLink()
        {
            var syncInstance = Controller.GetSyncServerInstance(_serverAccountId);

            var messageHandler = new VerifyDeviceKeysResponseHandler(
                Controller.GetSyncServerInstance(_serverAccountId), _nonce);

            // Give the sync process a kick up the arse
            syncInstance.ProcessMessagesOnly();

            var replyReceived = messageHandler.WaitForReply();
            
            // Tell the sync process to go back to normal duties
            syncInstance.ProcessMessagesOnlyStop();

            if (!replyReceived)
            {
                MessageBox.Show(@"Device verification timed out");
                if (!_formClosed)
                    Invoke((MethodInvoker) Close);
                return;
            }

            var secretShareMessage = messageHandler.Reply;

            if (!secretShareMessage.Verified)
            {
                MessageBox.Show(@"Device verification denied.");
                if (!_formClosed)
                    Invoke((MethodInvoker)Close);
                return;
            }

            // Verify the signature against the public key we have for it.
            var account = Model.ServerAccounts.Get(_serverAccountId);
            var linkedClientCryptoKey = Model.CryptoKeys.Get(account.LinkedDeviceCryptoKeyId);
            var signatureVerified = AsymmetricCryptoUtil.VerifySignature(
                _nonce, messageHandler.Reply.NonceSigned, linkedClientCryptoKey.PublicKeyPem);

            if (!signatureVerified)
            {
                MessageBox.Show(@"Device verification failed.");
                messageHandler.MarkAsProcessed(false);
                if (!_formClosed)
                    Invoke((MethodInvoker)Close);
                return;
            }

            messageHandler.MarkAsProcessed(true);
            
            Model.CryptoKeys.Update(linkedClientCryptoKey.Id, new CryptoKey {Trust = true});

            Controller.UpdateHomePage();

            if (!_formClosed)
                Invoke((MethodInvoker) Close);
        }

        private void VerifyKeyOnSecondDevice_FormClosing(object sender, FormClosingEventArgs e)
        {
            _formClosed = true;
            if (!_checkThreadStop)
                _checkThreadStop = true;
        }
    }
}
