using System.Windows;

namespace Mfc2Mvvm.Shell
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private void Application_OnStartup(object sender, StartupEventArgs eventArgs)
        {
            new Bootstrapper().Run();
        }
    }
}