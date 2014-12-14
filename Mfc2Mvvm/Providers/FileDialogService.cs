using System.ComponentModel.Composition;
using Mfc2Mvvm.Contracts;
using Microsoft.Win32;

namespace Mfc2Mvvm.Providers
{
    [Export(typeof (IFileDialogService))]
    internal sealed class FileDialogService : IFileDialogService
    {
        public string OpenFileDialog(string fileName, string defaultExtension, string filter)
        {
            var openFileDialog = new OpenFileDialog
            {
                FileName = fileName,
                DefaultExt = defaultExtension,
                Filter = filter
            };

            return openFileDialog.ShowDialog() == true ? openFileDialog.FileName : null;
        }
    }
}