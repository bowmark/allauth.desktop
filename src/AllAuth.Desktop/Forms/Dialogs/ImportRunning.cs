﻿using System;
using System.Threading.Tasks;

namespace AllAuth.Desktop.Forms.Dialogs
{
    internal partial class ImportRunning : Templates.FormDialog
    {
        public bool Success { get; private set; }

        private readonly Controller.ImportTypes _importType;
        private readonly string _importFilePath;
        
        public ImportRunning(Controller controller, Controller.ImportTypes importType, string importFilePath)
        {
            InitializeComponent();

            Controller = controller;
            _importType = importType;
            _importFilePath = importFilePath;

            StartLoadingAnimation(lblLoadingImage);
        }
        
        private async void ImportRunning_Shown(object sender, EventArgs e)
        {
            var success = false;
            await Task.Run(() =>
            {
                success = Controller.ImportProcess(_importType, _importFilePath);
            });

            Success = success;
            Close();
        }
    }
}
