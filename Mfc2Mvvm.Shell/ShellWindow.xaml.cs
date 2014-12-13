using System.ComponentModel.Composition;

namespace Mfc2Mvvm.Shell
{
    /// <summary>
    ///     Interaction logic for ShellWindow.xaml
    /// </summary>
    [Export(typeof (ShellWindow))]
    public partial class ShellWindow
    {
        public ShellWindow()
        {
            InitializeComponent();
        }
    }
}