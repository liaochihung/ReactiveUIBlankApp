using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveUIBlankApp.WinFormShell.ViewModels
{
    public class ShellViewModel : ReactiveObject, IScreen
    {
        public ShellViewModel()
        {
            Router = new RoutingState();
            ApplicationTitle = "ReactiveUI Blank App";

            //ShowMainContentCommand = ReactiveCommand.Create(ShowMainContent);
            Router
                .NavigateAndReset
                .Execute(new MainContentViewModel())
                .Subscribe();
        }

        private void ShowMainContent()
        {
            //Router
            //    .Navigate
            //    .Execute(new MainViewModel())
            //    .Subscribe();
        }

        private void GoBack()
        {
            if (Router.NavigationStack.Count <= 0)
                return;

            Router
                .NavigateBack
                .Execute()
                .Subscribe();
        }

        public RoutingState Router { get; }

        private string _applicationTitle;
        public string ApplicationTitle
        {
            get => _applicationTitle;
            set => this.RaiseAndSetIfChanged(ref _applicationTitle, value);
        }

        //public ReactiveCommand ShowMainContentCommand { get; }
        //public ReactiveCommand GoBackCommand { get; }
    }
}
