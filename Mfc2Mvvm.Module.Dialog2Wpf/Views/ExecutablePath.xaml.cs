using System.ComponentModel.Composition;
using Mfc2Mvvm.Module.Dialog2Wpf.ViewModels;
using Microsoft.Practices.Prism.Mvvm;

namespace Mfc2Mvvm.Module.Dialog2Wpf.Views
{
    /// <summary>
    ///     Interaction logic for ExecutablePath.xaml
    /// </summary>
    [Export]
    public partial class ExecutablePath : IView
    {
        [Import]
        public ExecutablePathViewModel ViewModel
        {
            set { DataContext = value; }
        }

        public ExecutablePath()
        {
            InitializeComponent();
        }
    }
}