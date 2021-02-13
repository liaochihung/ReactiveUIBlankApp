using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginModule.ViewModels;
using ReactiveUI;

namespace ReactiveUIBlankApp.WinFormShell.Views
{
    public partial class LoginForm : Form, IViewFor<LoginViewModel>
    {
        public LoginForm()
        {
            InitializeComponent();

            ViewModel = new LoginViewModel();

            this.Bind(ViewModel, x => x.IsUserLogin, x => x.rdoUser.Checked);
            this.Bind(ViewModel, x => x.User, x => x.txtAccount.Text);
            this.Bind(ViewModel, x => x.Password, x => x.txtPassword.Text);

            this.BindCommand(ViewModel, x => x.LoginCommand, x => x.btnLogin);
            this.BindCommand(ViewModel, x => x.ResetCommand, x => x.btnReset);

            this.OneWayBind(ViewModel, x => x.IsUserLogin, x => x.txtAccount.Enabled);
            this.OneWayBind(ViewModel, x => x.IsUserLogin, x => x.txtPassword.Enabled);

        }

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (LoginViewModel)value; }
        }

        public LoginViewModel ViewModel { get; set; }


    }
}
