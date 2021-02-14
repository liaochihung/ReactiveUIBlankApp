using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using ReactiveUIBlankApp.WinFormShell.Views;
using WeifenLuo.WinFormsUI.Docking;

namespace ReactiveUIBlankApp.WinFormShell
{
    public partial class Form1 : Form
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public Form1()
        {
            InitializeComponent();

            //dockPanel1.AllowEndUserDocking = false;

            //FormDock frmDocument = new FormDock() {TabText = "Document"};
            //frmDocument.Show(this.dockPanel1, DockState.Document);

            //FormDock frmDockRight = new FormDock() {TabText = "DockRight"};
            //frmDockRight.Show(this.dockPanel1, DockState.DockRight);

            //FormDock frmDockBottom = new FormDock() {TabText = "Dock Bottom"};
            //frmDockBottom.Show(this.dockPanel1, DockState.DockBottom);

            //FormDock frmDockTop = new FormDock() {TabText = "Dock Top"};
            //frmDockTop.Show(this.dockPanel1, DockState.DockTop);

            HeaderView header = new HeaderView();
            //header.Parent = pnlHeader;
            //header.Show();

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

        private void metroTile1_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this, "WARNING", "MESSAGE BOX", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }
}
