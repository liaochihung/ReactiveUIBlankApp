using ReactiveUIBlankApp.WinFormShell.Views;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Windows.Forms;


namespace ReactiveUIBlankApp.WinFormShell
{
    public partial class FormMain : Form
    {
        public string language = Properties.Settings.Default.Language;

        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public FormMain()
        {
            InitializeComponent();

            // get current cultureinfo string from common language project
            var str = ReactiveUIBlankApp.Language.Resource.Sample;

            Language.Apply(this, language);

            var header = new HeaderView();
            pnlTop.Controls.Clear();
            pnlTop.Controls.Add(header);

            _logger.Debug("form1 constructure.");
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
