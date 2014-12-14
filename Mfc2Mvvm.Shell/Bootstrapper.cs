using System.ComponentModel.Composition.Hosting;
using System.Windows;
using Microsoft.Practices.Prism.MefExtensions;

namespace Mfc2Mvvm.Shell
{
    internal sealed class Bootstrapper : MefBootstrapper
    {
        private new ShellWindow Shell => (ShellWindow) base.Shell;

        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();

            var assembly = typeof (ShellWindow).Assembly;
            var assemblyCatalog = new AssemblyCatalog(assembly);

            AggregateCatalog.Catalogs.Add(assemblyCatalog);

            var directoryCatalog = new DirectoryCatalog(".", "Mfc2Mvvm*.dll");

            AggregateCatalog.Catalogs.Add(directoryCatalog);
        }

        protected override DependencyObject CreateShell()
        {
            return Container.GetExportedValue<ShellWindow>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            var currentApplication = Application.Current;

            currentApplication.MainWindow = Shell;
            currentApplication.MainWindow.Show();
        }
    }
}
