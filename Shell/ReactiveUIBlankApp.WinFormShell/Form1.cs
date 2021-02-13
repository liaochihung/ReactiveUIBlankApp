using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReactiveUIBlankApp.WinFormShell.Views;

namespace ReactiveUIBlankApp.WinFormShell
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm();
            loginForm.ShowDialog();

            loginForm.Dispose();
            loginForm = null;
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this, "WARNING", "MESSAGE BOX", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }
}
