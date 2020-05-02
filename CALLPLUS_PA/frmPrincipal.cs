using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CALLPLUS_PA.BLL;

namespace CALLPLUS_PA
{
    public partial class frmPrincipal : Form
    {
        private int childFormNumber = 1;
        private int idInstancia;
        private int idLicenca;
        private string banco;
        private string processo;
        private string cliente;
        private string versao;

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, [Out] StringBuilder lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetWindowTextLength(IntPtr hWnd);

        public frmPrincipal(string cliente, string processo, int idLicenca, int idInstancia, string banco)
        {
            InitializeComponent();

            try
            {
                //new InstanciaBLO().AtualizarVersaoRobo(idInstancia, processo, Program.version.ToString());
            }
            catch (Exception)
            {

            }

            this.versao = Program.version.ToString();
            this.Text = Text + "" + Program.version.ToString();
            this.banco = banco;
            this.idLicenca = idLicenca;
            this.idInstancia = idInstancia;
            this.processo = processo;
            this.cliente = cliente;

            backgroundWorker1.RunWorkerAsync();

            AbrirInstancia();
        }

        private void AbrirInstancia()
        {
            if (idLicenca != 0)
            {
                if (processo == "CLA_MIG")
                {
                    if (banco != "")
                    {
                        Form childForm = new frmInputClaroMigracaoWM(idInstancia, cliente, banco);
                        childForm.MdiParent = this;
                        childForm.Show();
                    }
                }
            }            
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = mnuBarra.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void AbrirInstanciaClaroOnline(object sender, EventArgs e)
        {
            //Form childForm = new frmInstanciaClaroOnLineAxWeb(childFormNumber);
            //childForm.MdiParent = this;
            //childForm.Text += " (Instância " + childFormNumber + ")";
            //childForm.Show();

            //childFormNumber++;
        }

        private void AbrirInstanciaClaroMigracao(object sender, EventArgs e)
        {
            //Form childForm = new frmInputClaroMigracaoWM(childFormNumber);
            //childForm.MdiParent = this;
            //childForm.Text += " (Instância " + childFormNumber + ")";
            //childForm.Show();

            //childFormNumber++;
        }

        private void AbrirInstanciaClaroAquisicao(object sender, EventArgs e)
        {
            MessageBox.Show("A automação escolhida não está disponível!", "Aviso do Sistema");
        }

        private void AbrirInstanciaVivo360(object sender, EventArgs e)
        {
            MessageBox.Show("A automação escolhida não está disponível!", "Aviso do Sistema");
        }

        private void ExibirBibliotecaDeAjuda(object sender, EventArgs e)
        {
            MessageBox.Show("A biblioteca de ajuda não está disponível!", "Aviso do Sistema");
        }

        private void ExibirSobreSistema(object sender, EventArgs e)
        {
            MessageBox.Show("As informações sobre o sistema não estão disponíveis!", "Aviso do Sistema");
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        public static string GetWindowTextRaw(IntPtr hwnd)
        {
            // Allocate correct string length first
            int length = (int)SendMessage(hwnd, 100, IntPtr.Zero, IntPtr.Zero);
            StringBuilder sb = new StringBuilder(length + 1);
            SendMessage(hwnd, 50, (IntPtr)sb.Capacity, sb);
            return sb.ToString();
        }

        public static string GetText(IntPtr hWnd)
        {
            // Allocate correct string length first
            int length = GetWindowTextLength(hWnd);
            StringBuilder sb = new StringBuilder(length + 1);
            GetWindowText(hWnd, sb, sb.Capacity);
            return sb.ToString();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                System.Threading.Thread.Sleep(2000);
                
                IntPtr hwnd = FindWindow("Internet Explorer_TridentDlgFrame", "Erro de Script");
                if (hwnd != new IntPtr(0))
                {
                    string msg = GetWindowTextRaw(hwnd);
                    msg = GetText(hwnd);

                    uint message = 0x0010;
                    SendMessage(hwnd, message, IntPtr.Zero, IntPtr.Zero);
                }

                hwnd = FindWindow(null, "Alerta de Segurança");
                if (hwnd != new IntPtr(0))
                {
                    string msg = GetWindowTextRaw(hwnd);

                    msg = GetText(hwnd);

                    IntPtr hwndC = FindWindowEx(hwnd, IntPtr.Zero, "Button", "&Sim");
                    uint message = 0xf5;
                    SendMessage(hwndC, message, IntPtr.Zero, IntPtr.Zero);
                }

                hwnd = FindWindow(null, "Security Alert");
                if (hwnd != new IntPtr(0))
                {
                    string msg = GetWindowTextRaw(hwnd);

                    msg = GetText(hwnd);

                    IntPtr hwndC = FindWindowEx(hwnd, IntPtr.Zero, "Button", "&Yes");
                    uint message = 0xf5;
                    SendMessage(hwndC, message, IntPtr.Zero, IntPtr.Zero);
                }

                hwnd = FindWindow(null, "Erro de Script");
                if (hwnd != new IntPtr(0))
                {
                    string msg = GetWindowTextRaw(hwnd);

                    msg = GetText(hwnd);

                    IntPtr hwndC = FindWindowEx(hwnd, IntPtr.Zero, "Button", "&Sim");
                    uint message = 0xf5;
                    SendMessage(hwndC, message, IntPtr.Zero, IntPtr.Zero);
                }

                hwnd = FindWindow(null, "Script Error");
                if (hwnd != new IntPtr(0))
                {
                    string msg = GetWindowTextRaw(hwnd);

                    msg = GetText(hwnd);

                    IntPtr hwndC = FindWindowEx(hwnd, IntPtr.Zero, "Button", "&Yes");
                    uint message = 0xf5;
                    SendMessage(hwndC, message, IntPtr.Zero, IntPtr.Zero);
                }

                hwnd = FindWindow(null, "Mensagem da página da web");
                if (hwnd != new IntPtr(0))
                {
                    string msg = GetWindowTextRaw(hwnd);

                    msg = GetText(hwnd);

                    IntPtr hwndC = FindWindowEx(hwnd, IntPtr.Zero, "Button", "Cancelar");

                    if (hwndC != new IntPtr(0))
                    {
                        uint message = 0xf5;
                        SendMessage(hwndC, message, IntPtr.Zero, IntPtr.Zero);
                    }
                    else
                    {
                        hwndC = FindWindowEx(hwnd, IntPtr.Zero, "Button", "OK");
                        uint message = 0xf5;
                        SendMessage(hwndC, message, IntPtr.Zero, IntPtr.Zero);
                    }

                    //break;
                }

                hwnd = FindWindow(null, "Message from webpage");
                if (hwnd != new IntPtr(0))
                {
                    string msg = GetWindowTextRaw(hwnd);

                    msg = GetText(hwnd);

                    IntPtr hwndC = FindWindowEx(hwnd, IntPtr.Zero, "Button", "Cancel");

                    if (hwndC != new IntPtr(0))
                    {
                        uint message = 0xf5;
                        SendMessage(hwndC, message, IntPtr.Zero, IntPtr.Zero);
                    }
                    else
                    {
                        hwndC = FindWindowEx(hwnd, IntPtr.Zero, "Button", "OK");
                        uint message = 0xf5;
                        SendMessage(hwndC, message, IntPtr.Zero, IntPtr.Zero);
                    }

                    //break;
                }

                hwnd = FindWindow(null, "Web Browser");
                if (hwnd != new IntPtr(0))
                {
                    string msg = GetWindowTextRaw(hwnd);

                    msg = GetText(hwnd);

                    IntPtr hwndC = FindWindowEx(hwnd, IntPtr.Zero, "Button", "&Yes");

                    if (hwndC != new IntPtr(0))
                    {
                        uint message = 0xf5;
                        SendMessage(hwndC, message, IntPtr.Zero, IntPtr.Zero);
                    }
                    else
                    {
                        hwndC = FindWindowEx(hwnd, IntPtr.Zero, "Button", "&Yes");
                        uint message = 0xf5;
                        SendMessage(hwndC, message, IntPtr.Zero, IntPtr.Zero);
                    }

                    //break;
                }

                hwnd = FindWindow(null, "Navegador da Web");
                if (hwnd != new IntPtr(0))
                {
                    string msg = GetWindowTextRaw(hwnd);

                    msg = GetText(hwnd);

                    IntPtr hwndC = FindWindowEx(hwnd, IntPtr.Zero, "Button", "&Sim");

                    if (hwndC != new IntPtr(0))
                    {
                        uint message = 0xf5;
                        SendMessage(hwndC, message, IntPtr.Zero, IntPtr.Zero);
                    }
                    else
                    {
                        hwndC = FindWindowEx(hwnd, IntPtr.Zero, "Button", "&Sim");
                        uint message = 0xf5;
                        SendMessage(hwndC, message, IntPtr.Zero, IntPtr.Zero);
                    }

                    //break;
                }
            }
        }

        private void btnAnaliseDeCredito_Click(object sender, EventArgs e)
        {
            //Form childForm = new frmAnaliseCreditoWA(childFormNumber);
            //childForm.MdiParent = this;
            //childForm.Text += " (Instância " + childFormNumber + ")";
            //childForm.Show();

            //childFormNumber++;
        }
    }
}
