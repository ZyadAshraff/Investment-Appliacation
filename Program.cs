using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvestApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var loginForm = new Form1();

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MainForm(AuthManager.CurrentUser));
            }
        }
    }
}
