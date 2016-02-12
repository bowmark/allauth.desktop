using System;
using System.Threading;
using AllAuth.Lib.ServerAPI;

namespace AllAuth.Desktop
{
    internal sealed class VerifyDeviceKeysResponseReceivedEventArgs : EventArgs
    {
        public DeviceMessages.VerifyDeviceKeysResponse Message { get; }
        public bool MessageHandledSuccessfully { get; set; }

        public VerifyDeviceKeysResponseReceivedEventArgs(DeviceMessages.VerifyDeviceKeysResponse message)
        {
            Message = message;
        }
    }

    internal sealed class VerifyDeviceKeysResponseHandler
    {
        public DeviceMessages.VerifyDeviceKeysResponse Reply { get; private set; }

        private readonly string _nonce;
        private bool _replyReceived;

        private bool _processedSuccessfully;

        private readonly AutoResetEvent _waitForReply = new AutoResetEvent(false);
        private readonly AutoResetEvent _waitForReplyProcess = new AutoResetEvent(false);

        private const int Timeout = 120000;

        public VerifyDeviceKeysResponseHandler(Sync syncClient, string nonce)
        {
            _nonce = nonce;
            syncClient.VerifyDeviceKeysResponseReceived += OnVerifyDeviceKeysResponseReceived;
        }

        public bool WaitForReply()
        {
            _waitForReply.WaitOne(Timeout);
            return _replyReceived;
        }

        private void OnVerifyDeviceKeysResponseReceived(object sender, VerifyDeviceKeysResponseReceivedEventArgs args)
        {
            if (args.Message.Nonce != _nonce)
                return;

            _replyReceived = true;
            Reply = args.Message;
            _waitForReply.Set();
            _waitForReplyProcess.WaitOne(Timeout);

            args.MessageHandledSuccessfully = _processedSuccessfully;
        }

        public void MarkAsProcessed(bool success)
        {
            _processedSuccessfully = success;
            _waitForReplyProcess.Set();
        }
    }
}
