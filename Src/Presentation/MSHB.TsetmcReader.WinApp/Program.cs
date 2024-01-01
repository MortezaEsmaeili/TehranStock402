using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSHB.TsetmcReader.WinApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location)).Count() > 1)
            {
                MessageBox.Show("برنامه مشابهی در حال اجراست، لطفا ابتدا آن را بسته و سپس اقدام به باز کردن برنامه جدید کنید...", "خطای برنامه", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Application.Run(new frmMain());
        }
    }
}
