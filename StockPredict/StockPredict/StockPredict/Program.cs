using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StockPredict
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
            //Application.Run(new frmViewInfo_DurPerPrice());
            int funcs = Convert.ToInt32(args[0]);
            
            switch (funcs)
            {
                case 0: // get data with manual/Schedule Tasks
                    bool isTask = Convert.ToInt32(args[1]) == 1 ? true : false;
                    int days = Convert.ToInt32(args[2]);
                    bool isAll = Convert.ToInt32(args[3]) == 1 ? true : false;
                    Application.Run(new frmInputData(isTask, days, isAll));
                    break;
            }
            
        }
    }
}