using System;
using System.Threading;
using AllAuth.Lib.ServerAPI;

namespace AllAuth.Desktop
{
    internal sealed class SendEntrySecretsMessageReceivedEventArgs : EventArgs
    {
        public DeviceToDeviceMessages.SendEntrySecrets Message { get; }
        public bool MessageHandledSuccessfully { get; set; }

        public SendEntrySecretsMessageReceivedEventArgs(DeviceToDeviceMessages.SendEntrySecrets message)
        {
            Message = message;
        }
    }

    internal sealed class SendSecretShareMessageHandler
    {
        public DeviceToDeviceMessages.SendEntrySecrets Reply { get; private set; }

        private readonly string _originalMessageIdentifier;
        private bool _replyReceived;

        private bool _processedSuccessfully;

        private readonly AutoResetEvent _waitForReply = new AutoResetEvent(false);
        private readonly AutoResetEvent _waitForReplyProcess = new AutoResetEvent(false);

        private const int Timeout = 120000;

        public SendSecretShareMessageHandler(Sync syncClient, string originalMessageIdentifier)
        {
            _originalMessageIdentifier = originalMessageIdentifier;
            syncClient.SendSecretShareMessageReceived += OnSendSecretShareMessageReceived;
        }

        public bool WaitForReply()
        {
            _waitForReply.WaitOne(Timeout);
            return _replyReceived;
        }

        private void OnSendSecretShareMessageReceived(object sender, SendEntrySecretsMessageReceivedEventArgs args)
        {
            if (args.Message.OriginalMessageIdentifier != _originalMessageIdentifier)
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
