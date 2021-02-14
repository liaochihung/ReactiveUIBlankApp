using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReactiveUIBlankApp.WinFormShell
{
    public class Language
    {
        public static void Apply(Form Form, string Language)
        {
            if (string.IsNullOrEmpty(Language))
                return;

            if (Form == null)
                throw new ArgumentNullException("form");

            System.Globalization.CultureInfo info;
            try
            {
                info = new System.Globalization.CultureInfo(Language);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Thread.CurrentThread.CurrentUICulture = info; //變更文化特性
            ComponentResourceManager Manager = null;
            try
            {
                Manager = new ComponentResourceManager(Form.GetType());
                Manager.ApplyResources(Form, "$this");

                foreach (Control Ctrl in Form.Controls)
                {
                    ApplyLanguage(Ctrl, Manager);
                }
            }
            finally
            {
                Manager = null;
            }
        }

        private static void ApplyLanguage(Control Ctrl, ComponentResourceManager Manager)
        {
            if (Ctrl is MenuStrip)
            {
                MenuStrip menu = Ctrl as MenuStrip;
                Manager.ApplyResources(Ctrl, Ctrl.Name);

                foreach (ToolStripItem item in menu.Items)
                {
                    ApplyLanguage(item, Manager);
                }
            }
            else if (Ctrl is ToolStrip)
            {
                ToolStrip menu = Ctrl as ToolStrip;
                Manager.ApplyResources(Ctrl, Ctrl.Name);

                foreach (ToolStripItem item in menu.Items)
                {
                    ApplyLanguage(item, Manager);
                }
            }
            else
            {
                Manager.ApplyResources(Ctrl, Ctrl.Name);
                foreach (Control item in Ctrl.Controls)
                {
                    ApplyLanguage(item, Manager);
                }
            }
        }
        private static void ApplyLanguage(ToolStripItem Ctrl, ComponentResourceManager Manager)
        {
            Manager.ApplyResources(Ctrl, Ctrl.Name);
            var menu = Ctrl as ToolStripMenuItem;

            if (menu == null)
                return;

            foreach (ToolStripItem item in menu?.DropDownItems)
            {
                ApplyLanguage(item, Manager);
            }
        }
    }
}
