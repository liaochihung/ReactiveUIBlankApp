using ReactiveUI;
using ReactiveUIBlankApp.WinFormShell.ViewModels;
using ReactiveUIBlankApp.WinFormShell.Views;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Windows.Forms;


namespace ReactiveUIBlankApp.WinFormShell
{
    public partial class FormShellView : Form, IViewFor<ShellViewModel>
    {
        public string language = Properties.Settings.Default.Language;

        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public ShellViewModel ViewModel { get; set; }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel=(ShellViewModel)value;
        }

        public FormShellView()
        {
            InitializeComponent();

            // get current cultureinfo string from common language project
            var str = ReactiveUIBlankApp.Language.Resource.Sample;

            Language.Apply(this, language);

            //var header = new HeaderView();
            //pnlTop.Controls.Clear();
            //pnlTop.Controls.Add(header);

            _logger.Debug("form1 constructure.");

            this.WhenActivated(d =>
            {
                // Bind router
                d(this.OneWayBind(ViewModel, vm => vm.Router, v => v.routedControlHost.Router));

                // Bind properties
                d(this.OneWayBind(ViewModel, vm => vm.ApplicationTitle, v => v.Text));

                // Bind commands
                //d(this.BindCommand(ViewModel, vm => vm.ShowHomeCommand, v => v.btHome));
                //d(this.BindCommand(ViewModel, vm => vm.ShowAboutCommand, v => v.btAbout));
                //d(this.BindCommand(ViewModel, vm => vm.ShowContactCommand, v => v.btContact));
                //d(this.BindCommand(ViewModel, vm => vm.GoBackCommand, v => v.btGoBack));
            });
        }


        private void button1_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm();
            loginForm.ShowDialog();

            loginForm.Dispose();
            loginForm = null;
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Language = "en-US";
            Properties.Settings.Default.Save();

            Language.Apply(this, Properties.Settings.Default.Language);
        }

        private void traditionalChineseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Language = "zh-TW";
            Properties.Settings.Default.Save();

            Language.Apply(this, Properties.Settings.Default.Language);
        }
    }
}
