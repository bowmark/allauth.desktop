using System;
using System.Drawing;
using System.Windows.Forms;

namespace AllAuth.Desktop.Forms.Templates
{
    internal partial class FormDialog : Form
    {
        protected Controller Controller;

        private bool _loadingAnimationRunning;
        private Label _loadingAnimationLabel;

        protected FormDialog()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }
        
        private void FormDialogTemplate_Load(object sender, System.EventArgs e)
        {
            Activate();
            Font = UiStyle.DefaultFont;
        }

        protected void StartLoadingAnimation(Label imageToAnimate)
        {
            if (_loadingAnimationRunning)
                return;

            _loadingAnimationLabel = imageToAnimate;
            _loadingAnimationRunning = true;
            ImageAnimator.Animate(_loadingAnimationLabel.Image, AnimateImage);
        }

        protected void StopLoadingAnimation()
        {
            if (!_loadingAnimationRunning)
                return;

            ImageAnimator.StopAnimate(_loadingAnimationLabel.Image, AnimateImage);
            _loadingAnimationRunning = false;
            _loadingAnimationLabel = null;
        }

        private void AnimateImage(object sender, EventArgs eventArgs)
        {
            if (!_loadingAnimationRunning)
                return;

            ImageAnimator.UpdateFrames();
            _loadingAnimationLabel.Invalidate();
        }

        private void FormDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_loadingAnimationRunning)
            {
                ImageAnimator.StopAnimate(_loadingAnimationLabel.Image, AnimateImage);
                _loadingAnimationRunning = false;
                _loadingAnimationLabel = null;
            }
        }
    }
}
