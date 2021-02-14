using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HeaderModule.ViewModels;
using LoginModule.ViewModels;
using ReactiveUI;

namespace ReactiveUIBlankApp.WinFormShell.Views
{
    public partial class HeaderView : UserControl, IViewFor<HeaderViewModel>
    {
        public HeaderView()
        {
            InitializeComponent();

            ViewModel = new HeaderViewModel();
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (HeaderViewModel)value;
        }

        public HeaderViewModel ViewModel { get; set; }
    }
}
