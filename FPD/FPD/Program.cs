using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPD
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form_Main());
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form_Main(args[0].ToString()));
            }

        }
    }
}
