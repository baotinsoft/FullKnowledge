using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forex
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmSJC frm = new frmSJC();
            if (Convert.ToInt32(args[0]) == 1)
                frm.exit = true;
            else
                frm.exit = false;
            Application.Run(frm);
        }
    }
}
