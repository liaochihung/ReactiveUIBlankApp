using ReactiveUI;
using ReactiveUIBlankApp.WinFormShell.ViewModels;
using ReactiveUIBlankApp.WinFormShell.Views;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReactiveUIBlankApp.WinFormShell
{
    public class Bootstrapper
    {
        public Bootstrapper()
        {
            ConfigureServices();
        }

        private void ConfigureServices()
        {
            Locator.CurrentMutable.Register(() => new FormShellView(), typeof(IViewFor<ShellViewModel>));
            Locator.CurrentMutable.Register(() => new MainContentView(), typeof(IViewFor<MainContentViewModel>));
        }

        public void Run()
        {
            var vm = new ShellViewModel();
            Locator.CurrentMutable.RegisterConstant(vm, typeof(IScreen));

            var view = ViewLocator.Current.ResolveView(vm);
            view.ViewModel = vm;

            Application.Run((Form)view);
        }

    }
}
