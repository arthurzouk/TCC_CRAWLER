using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using mshtml;
using CALLPLUS_PA.BLL;
using CALLPLUS_PA.EF;
using System.Runtime.InteropServices;
using System.Timers;
using System.Net.Mail;
using System.Net;

namespace CALLPLUS_PA
{
    //Form que recebe os dados do CRM
    public partial class frmInputClaroMigracaoWM : Form
    {
        #region Variaveis
        public DadosParaRegistro _dadosParaRegistro;
        public const int operacao = 3;
        public int GetOperacao { get { return operacao; } }
        public string banco;
        public string cliente;
        public int idInstanciaPAM;
        public string popupStatus;
        public bool abriuPopUp;
        public bool popUpFechado;
        public bool formPopUpEncerrado;

        private int velocidade = 900000;
        public bool rodando = false;
        public EF.Login login;
        public EF.BuscarVendaParaRegistro_Result venda;
        public EF.SelecionarPlanoDaVenda_Result PlanoDaVenda;
        public EF.BuscarDadosDaInstancia_Result _instancia;


        #endregion
        #region Importar DLLs
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        #endregion
        #region Construtor
        //Inicialiador do Form de acordo com o número de identificação da instância
        public frmInputClaroMigracaoWM(int idInstancia, string cliente, string banco)
        {
            InitializeComponent();

            //Set a data de inicio da instância igual a data da maquina;
            lblDataInicio.Text = "Data Início: " + DateTime.Now; ;

            idInstanciaPAM = idInstancia;
            this.cliente = cliente;
            this.banco = banco;

            backgroundWorker1.RunWorkerCompleted += btnIniciar_Click;
            backgroundWorker1.RunWorkerAsync();

            //dgStatus.DataSource = new InstanciaBLO().ListarResultadoDaInstancia(0);
        }
        #endregion
        #region Metodos relacionados a View
        private void wbVisualizacao_NewWindow3(object sender, AxSHDocVw.DWebBrowserEvents2_NewWindow3Event e)
        {
            //abriuPopUp = true;

            //frmPopUpInputMigracao frmWB;
            //frmWB = new frmPopUpInputMigracao(cliente, this, venda);

            //frmWB.axWebBrowser1.RegisterAsBrowser = true;
            //e.ppDisp = frmWB.axWebBrowser1.Application;
            //frmWB.Visible = true;
        }
        private void frmInputClaroMigracaoWM_FormClosing(object sender, FormClosingEventArgs e)
        {
            FluxoProcessoInstancia.FinalizarInstancia(this, _instancia, operacao);
        }
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                FluxoProcessoInstancia.ExecutarFluxoProcessoInstancia(wbVisualizacao, this, _instancia, operacao);
            }
            catch (Exception ex)
            {
#if !DEBUG
                if (_dadosParaRegistro != null)
                {
                    _dadosParaRegistro.planoMarcado = ex.Message;
                    _dadosParaRegistro.promocaoMarcada = ex.StackTrace;
                }

                if (_instancia != null)
                {
                    this.Text = "CLA_MIG - Instancia |" + _instancia.id + "| - Banco(" + banco + ") - Licença (" + _instancia.idLicenca + ") - PARADO";
                }

                if (tsMenuClaro != null)
                {
                    if (tsMenuClaro.Items.Count > 0)
                        HabilitarDesabilitarMenu(true);
                }

                if (ex.InnerException != null)
                {
                    lblStatus.ForeColor = Color.Red;

                    if (ex.InnerException.Message.Length > 100)
                    {
                        lblStatus.Text = ex.InnerException.Message.Substring(0, 100);
                    }
                    else
                    {
                        lblStatus.Text = ex.InnerException.Message;
                    }
                }
                else
                {
                    lblStatus.ForeColor = Color.Red;

                    if (ex.Message.Length > 100)
                    {
                        lblStatus.Text = ex.Message.Substring(0, 100);
                    }
                    else
                    {
                        lblStatus.Text = ex.Message;
                    }
                }

                if (_instancia != null && _instancia.ativo)
                {
                    FluxoProcessoInstancia.FinalizarInstancia(this, _instancia, operacao);
                }

                Thread.Sleep(60000);
                this.Close();
#endif
            }
        }
        private void frmInputClaroMigracaoWM_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        internal void AtualizarDadosDaTela(BuscarDadosDaInstancia_Result _instancia, DadosParaRegistro _dadosParaRegistro, string mensagem, bool erro)
        {
            try
            {
                //Dados variaveis
                if (_dadosParaRegistro != null)
                {
                    _dadosParaRegistro.etapaDoProcesso = mensagem;
                }

                if (_instancia != null)
                {
                    AtualizarDgStatus(_instancia.id);
                }

                if (venda != null)
                {
                    lblProduto.Text = "MSISDN: " + venda.msisdn;
                    lblMarca.Text = "CPF: " + venda.cpf;
                }

                lblStatus.ForeColor = erro ? Color.Red : Color.Blue;
                lblStatus.Text = mensagem;

                //Dados fixos
                labUrl.Text = System.Configuration.ConfigurationManager.AppSettings.Get("urlWM");
                lblUltimaAcao.Text = "Última Ação: " + DateTime.Now;
            }
            catch (Exception ex)
            {
                //Apenas para não travar por não ter conseguido atualizar os dados da tela.
                //Analisar se isso pode gerar problemas futuramente. (13/07/2019)
            }

            Application.DoEvents();
            //VerificadorDoSistema.waitTillLoad(wbVisualizacao);
        }

        public void waitTillLoad(AxSHDocVw.AxWebBrowser webBrControl)
        {
            try
            {
                SHDocVw.tagREADYSTATE loadStatus;

                //wait till beginning of loading next page 

                int waittime = velocidade;

                int counter = 0;

                while ((wbVisualizacao.ReadyState != SHDocVw.tagREADYSTATE.READYSTATE_COMPLETE)
                    && (wbVisualizacao.ReadyState != SHDocVw.tagREADYSTATE.READYSTATE_INTERACTIVE))
                {
                    Application.DoEvents();
                }

                while (true)
                {
                    loadStatus = webBrControl.ReadyState;

                    Application.DoEvents();

                    if ((counter > waittime) || (loadStatus == SHDocVw.tagREADYSTATE.READYSTATE_UNINITIALIZED) || (loadStatus == SHDocVw.tagREADYSTATE.READYSTATE_LOADING) || (loadStatus == SHDocVw.tagREADYSTATE.READYSTATE_INTERACTIVE))
                    {
                        break;
                    }

                    counter++;
                }

                //wait till the page get loaded.

                counter = 0;

                while (true)
                {
                    loadStatus = webBrControl.ReadyState;

                    Application.DoEvents();

                    if ((loadStatus == SHDocVw.tagREADYSTATE.READYSTATE_COMPLETE 
                        || loadStatus == SHDocVw.tagREADYSTATE.READYSTATE_INTERACTIVE
                        ) && webBrControl.Busy != true)
                    {
                        break;
                    }

                    counter++;
                }
            }
            catch (Exception ex)
            {

            };
        }
        #endregion
        #region Metodos privados
        public void HabilitarDesabilitarMenu(bool valor)
        {
            ToolStripItem ts = tsMenuClaro.Items[0];
            ((ToolStripButton)ts).Enabled = valor;
        }

        public void AtualizarDgStatus(int idInstancia)
        {
            try
            {
                dgStatus.DataSource = new InstanciaBLO().ListarResultadoDaInstancia(idInstancia);

                int count = 0;

                for (int i = 0; i < dgStatus.Rows.Count; i++)
                {
                    count += int.Parse(dgStatus.Rows[i].Cells[1].Value.ToString());
                }

                lblCount.Text = count.ToString();
            }
            catch (Exception)
            {
                //Apenas para não travar o processo por não atualizar o processo da instancia
            }
        }
        #endregion
        #region Metodos estaticos
        public static bool validarCPF(string CPF) //OK
        {
            int[] mt1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mt2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string TempCPF;
            string Digito;
            int soma;
            int resto;

            CPF = CPF.Trim();
            CPF = CPF.Replace(".", "").Replace("-", "");

            if (CPF == "11111111111" || CPF == "22222222222" || CPF == "33333333333" || CPF == "44444444444" || CPF == "55555555555"
                || CPF == "66666666666" || CPF == "77777777777" || CPF == "88888888888" || CPF == "99999999999" || CPF == "00000000000")
            {
                return false;
            }

            if (CPF.Length != 11)
                return false;

            TempCPF = CPF.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(TempCPF[i].ToString()) * mt1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            Digito = resto.ToString();
            TempCPF = TempCPF + Digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(TempCPF[i].ToString()) * mt2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            Digito = Digito + resto.ToString();

            return CPF.EndsWith(Digito);
        }
        public void ValidarBanco()
        {
            if (venda.banco == "")
            {
                return;
            }
            if (venda.banco == "-1")
            {
                venda.banco = "";
            }
            else if (venda.banco.ToUpper().Contains("BANCO DO BRASIL"))
            {
                venda.banco = "001";
            }
            else if (venda.banco.ToUpper().Contains("BANRISUL"))
            {
                venda.banco = "041";
            }
            else if (venda.banco.ToUpper().Contains("CAIXA"))
            {
                venda.banco = "104";
            }
            else if (venda.banco.ToUpper().Contains("BRADESCO"))
            {
                venda.banco = "237";
            }
            else if (venda.banco.ToUpper().Contains("ITAU"))
            {
                venda.banco = "341";
            }
            else if (venda.banco.ToUpper().Contains("MERCANTIL DO BRASIL"))
            {
                venda.banco = "389";
            }
            else if (venda.banco.ToUpper().Contains("SANTANDER"))
            {
                venda.banco = "033";
            }
        }
        public string TipoBanco()
        {
            if (venda.banco == "-1" || venda.banco == "")
            {
                return "";
            }
            else if (venda.banco == "001")
            {
                return "BANCO DO BRASIL";
            }
            else if (venda.banco == "041")
            {
                return "BANRISUL";
            }
            else if (venda.banco == "104")
            {
                return "CAIXA";
            }
            else if (venda.banco == "237")
            {
                return "BRADESCO";
            }
            else if (venda.banco == "341")
            {
                return "ITAU";
            }
            else if (venda.banco == "389")
            {
                return "MERCANTIL DO BRASIL";
            }
            else if (venda.banco == "033")
            {
                return "SANTANDER";
            }
            else
            {
                return venda.banco;
            }
        }
        private static void Enviar_Email(string remetente, string destinario, string assunto, string enviaMensagem)
        {
            MailMessage mensagemEmail = new MailMessage(remetente, destinario, assunto, enviaMensagem);

            using (var smtp = new SmtpClient("smtp.gmail.com"))
            {
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;

                smtp.Credentials = new NetworkCredential("faleconoscoalfacontactcenter@gmail.com", "*s3nh43m@il17!");

                try
                {
                    smtp.Send(mensagemEmail);
                }
                catch (Exception e)
                {

                }
            }
        }
        #endregion
    }
}
