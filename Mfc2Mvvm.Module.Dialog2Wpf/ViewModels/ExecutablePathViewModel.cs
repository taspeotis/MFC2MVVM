using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using Mfc2Mvvm.Contracts;
using Mfc2Mvvm.ViewModels;
using Microsoft.Practices.Prism.Commands;

namespace Mfc2Mvvm.Module.Dialog2Wpf.ViewModels
{
    [Export]
    public sealed class ExecutablePathViewModel : BaseViewModel
    {
        private readonly IFileDialogService _fileDialogService;

        [ImportingConstructor]
        public ExecutablePathViewModel(IFileDialogService fileDialogService)
        {
            _fileDialogService = fileDialogService;

            Browse = new DelegateCommand(BrowseCommand);
        }

        private void BrowseCommand()
        {
            var executablePath = _fileDialogService.OpenFileDialog(
                "MFCApplication1.exe", ".exe", "Applications (*.exe)|*.exe");

            if (!String.IsNullOrWhiteSpace(executablePath))
                ExecutablePath = executablePath;
        }

        public string ExecutablePath { get; set; } = @"C:\Temp\Application.exe";

        public ICommand Browse { get; }
    }
}