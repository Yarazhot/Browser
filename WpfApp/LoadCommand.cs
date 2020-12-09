using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;

namespace WpfApp
{
    public class LoadCommand : ICommand
    {
        private event Action<string> renewList;

        public LoadCommand(Action<string> action)
        {
            renewList += action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            var openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "d:\\",
                Filter = "DLL files (*.dll)|*.dll",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (!openFileDialog.ShowDialog().Value) return;
            filePath = openFileDialog.FileName;
            renewList?.Invoke(filePath);
        }

        public event EventHandler CanExecuteChanged;
    }
}
