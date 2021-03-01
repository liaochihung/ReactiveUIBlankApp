using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUIBlankApp.WinFormShell.ViewModels
{
    public class MainContentViewModel : ReactiveObject, IRoutableViewModel
    {
        public MainContentViewModel()
        {
            ViewTitle = "Main Content View";
        }
        private string _viewTitle;

        public string ViewTitle
        {
            get => _viewTitle;
            set => this.RaiseAndSetIfChanged(ref _viewTitle, value);
        }

        public IScreen HostScreen { get; protected set; }
        public string UrlPathSegment { get; protected set; }
    }
}
