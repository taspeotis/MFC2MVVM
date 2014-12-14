using System.ComponentModel.Composition;
using Mfc2Mvvm.Module.Dialog2Wpf.Views;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace Mfc2Mvvm.Module.Dialog2Wpf
{
    [ModuleExport(typeof (Dialog2WpfModule))]
    public sealed class Dialog2WpfModule : IModule
    {
        private readonly IRegionManager _regionManager;

        [ImportingConstructor]
        public Dialog2WpfModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("Start", typeof (ExecutablePath));
        }
    }
}