using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UIWindows
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

            UIConexao objfrmConn = new UIConexao();
            objfrmConn.ShowDialog();

            if (objfrmConn.bConn)
            {
                Application.Run(new UIPrincipal(objfrmConn.tbo));
                
            }
        }
    }
}
