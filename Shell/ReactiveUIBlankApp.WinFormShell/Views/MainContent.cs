using ReactiveUI;
using ReactiveUIBlankApp.WinFormShell.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReactiveUIBlankApp.WinFormShell.Views
{
    public partial class MainContentView : UserControl, IViewFor<MainContentViewModel>
    {
        public MainContentView()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                d(this.OneWayBind(ViewModel, vm => vm.ViewTitle, v => v.labelViewTitle.Text));
            });
        }

        public MainContentViewModel ViewModel { get; set; }
        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (MainContentViewModel)value;
        }
    }
}
