using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CALLPLUS_PA
{
    static class Program
    {
        public readonly static Version version = Assembly.GetEntryAssembly().GetName().Version;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
#if DEBUG
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new frmPrincipal("ALIANCA", "CLA_MIG", 3, 314, "EXTRA"));
                Application.Run(new frmPrincipal("ALIANCA", "CLA_MIG", 3, 314, "BH"));
#else


                string[] args = Environment.GetCommandLineArgs();
                if (args.Count() == 2)
                {
                    string[] parms = args[1].Split('|');

                    string cliente = parms[0];
                    string processo = parms[1];
                    string banco = parms[2];
                    int idLicenca = Int32.Parse(parms[3]);
                    int idInstancia = Int32.Parse(parms[4]);

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new frmPrincipal(cliente, processo, idLicenca, idInstancia, banco));
                }
                else
                {
                    MessageBox.Show("Você não pode executar esse programa.");
                }

#endif
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
