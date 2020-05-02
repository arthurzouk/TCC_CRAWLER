using CALLPLUS_PA.BLL;
using CALLPLUS_PA.EF;
using mshtml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CALLPLUS_PA
{
    class VerificadorDoSistema
    {
        private static int velocidade = 300000;

        public static bool VerificarCarregamentoDeTelas(AxSHDocVw.AxWebBrowser browser, frmInputClaroMigracaoWM frmInterno, DadosParaRegistro _dadosParaRegistro, BuscarVendaParaRegistro_Result venda, string palavraDeBusca, string palavraChave, int etapa, string tituloTela, bool contemAvisoSite)
        {
            int contador = 0;
            try
            {
                IHTMLElement verificador = null;

                while (contador < 200)
                {
                    contador++;

                    verificador = ((mshtml.HTMLDocument)browser.Document).documentElement;

                    browser.Silent = true;
                    frmInterno.waitTillLoad(browser);
                    browser.Silent = false;

                    if (tituloTela == "Pre Analise"
                        && verificador.innerHTML != null
                           && !verificador.innerHTML.ToUpper().Contains("REPROVAR")
                            && verificador.innerHTML.ToUpper().Contains(palavraDeBusca))
                    {
                        return true;
                    }
                    else if (tituloTela != "Pre Analise" && verificador.innerHTML != null && verificador.innerHTML.ToUpper().Contains(palavraDeBusca))
                    {
                        return true;
                    }
                    else
                    {
                        if (tituloTela != "Primeira Etapa" || contador > 10)
                        {
                            if (!VerificarInterrupcaoFluxo(browser, _dadosParaRegistro, frmInterno, venda, tituloTela, contemAvisoSite, palavraChave, etapa))
                            {
                                return false;
                            }
                        }
                    }

                    Thread.Sleep(1000);
                    verificador = ((mshtml.HTMLDocument)browser.Document).documentElement;
                }

                _dadosParaRegistro.DefinirDiagnostico(13, "Tempo de espera estourado para carregar a tela " + tituloTela, venda);
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static bool VerificarInterrupcaoFluxo(AxSHDocVw.AxWebBrowser browser, DadosParaRegistro _dadosParaRegistro, frmInputClaroMigracaoWM frmInterno, BuscarVendaParaRegistro_Result venda, string tituloTela, bool contemAvisoSite, string palavraChave, int etapa)
        {
            IHTMLElement verificador = ((mshtml.HTMLDocument)browser.Document).documentElement;


            if (verificador.innerHTML.ToUpper().Contains("LOGONFORM"))
            {
                if (tituloTela != "Primeira Etapa")
                {
                    _dadosParaRegistro.DefinirDiagnostico(41, "Perda de sessão para a tela " + tituloTela, venda);
                }

                return false;
            }
            if (verificador.innerHTML.ToUpper().Contains("ERRO AO EFETUAR O LOGON"))
            {
                _dadosParaRegistro.DefinirDiagnostico(41, "Perda de sessão para a tela " + tituloTela, venda);
                return false;
            }
            else if (tituloTela == "LogarSistemaClaro")
            {
                IHTMLElement txtCpf = ((mshtml.HTMLDocument)browser.Document).getElementById("cpf");
                IHTMLElement txtMsisdn = ((mshtml.HTMLDocument)browser.Document).getElementById("msisdn");

                IHTMLElement txtUsuario = ((mshtml.HTMLDocument)browser.Document).getElementById("j_username");
                IHTMLElement txtSenha = ((mshtml.HTMLDocument)browser.Document).getElementById("j_password");

                if (string.IsNullOrEmpty(txtUsuario.getAttribute("value"))
                    && string.IsNullOrEmpty(txtSenha.getAttribute("value")))
                {
                    _dadosParaRegistro.DefinirDiagnostico(13, "Não é possível carregar a página da Web após realizar o login " + tituloTela, venda);
                    return false;
                }

                //if ((txtCpf.innerHTML == null || !txtCpf.innerHTML.ToUpper().Contains("cpf")) && (txtMsisdn.innerHTML == null || !txtMsisdn.innerHTML.ToUpper().Contains("msisdn")))
                //{
                //    _dadosParaRegistro.DefinirDiagnostico(13, "Não é possível carregar a página da Web após realizar o login " + tituloTela, venda);
                //    return false;
                //}
                //else
                //{
                //    return true;
                //}
            }
            else if (verificador.innerHTML.ToUpper().Contains("ESTA PÁGINA NÃO PODE SER EXIBIDA"))
            {
                _dadosParaRegistro.DefinirDiagnostico(41, "Esta página não pode ser exibida ao tentar carregar a tela " + tituloTela, venda);
                return false;
            }
            else if (verificador.innerText.ToUpper().Contains("ERRO TECNICO"))
            {
                _dadosParaRegistro.DefinirDiagnostico(13, "Erro técnico | " + ((mshtml.HTMLDocument)browser.Document).documentElement.innerText.Split(':')[3].Replace(" \r\n\r\nCopyright © Claro 2017 - v14.2.0Anchor Version", ""), venda);
                return false;
            }
            else if (verificador.innerHTML.ToUpper().Contains("HTTP 404 - NÃO ENCONTRADO"))
            {
                _dadosParaRegistro.DefinirDiagnostico(13, "Não é possível localizar a página da Web ao tentar carregar a tela " + tituloTela, venda);
                return false;
            }
            else if (verificador.innerHTML.ToUpper().Contains("JAVA.LANG."))
            {
                _dadosParaRegistro.DefinirDiagnostico(18, "WM apresnetou mensagem de ERRO JAVA ao tentar acessar a tela " + tituloTela, venda);
                return false;
            }
            else if (verificador.innerHTML.ToUpper().Contains("ERRO INTERNO"))
            {
                _dadosParaRegistro.DefinirDiagnostico(18, "WM apresnetou mensagem de ERRO INTERNO ao tentar acessar a tela " + tituloTela, venda);
                return false;
            }
            else if (verificador.innerHTML.ToUpper().Contains("FATAL"))
            {
                _dadosParaRegistro.DefinirDiagnostico(18, "WM apresnetou mensagem de ERRO FATAL ao tentar acessar a tela " + tituloTela, venda);
                return false;
            }
            else if (verificador.innerHTML.ToUpper().Contains("ERRO AO PESQUISAR O DEALER"))
            {
                //Captura erro Dealer
                if (((mshtml.HTMLDocument)browser.Document).getElementsByTagName("table").length > 0)
                {
                    if (((mshtml.HTMLDocument)browser.Document).getElementsByTagName("table").item(0).InnerText != null)
                    {
                        if (((mshtml.HTMLDocument)browser.Document).getElementsByTagName("table").item(0).InnerText.Contains("Erro ao pesquisar o Dealer"))
                        {
                            string mensagem = ((mshtml.HTMLDocument)browser.Document).getElementsByTagName("table").item(0).InnerText;
                            string descricao = mensagem.Length > 200 ? mensagem.Substring(0, 200) : mensagem;

                            _dadosParaRegistro.DefinirDiagnostico(2, descricao, venda);
                            return false;
                        }
                    }
                }
            }
            else if (contemAvisoSite && verificador.innerHTML.ToUpper().Contains(palavraChave))
            {
                ConsultarMensagemDoStatus(browser, _dadosParaRegistro, venda, palavraChave, etapa);

                if (_dadosParaRegistro.status != 1)
                {
                    return false;
                }
            }
            else if (verificador.innerText.ToUpper().Contains("O SISTEMA NÃO CONSEGUIU RECUPERAR AS INFORMAÇÕES NECESSÁRIAS PARA CALCULAR A MULTA DO CLIENTE"))
            {
                _dadosParaRegistro.DefinirDiagnostico(13, "O Sistema não conseguiu recuperar as informações necessárias para calcular a multa do cliente", venda);
                return false;
            }
            else if (verificador.innerText.ToUpper().Contains("HTTP 400 BAD REQUEST"))
            {
                //FluxoProcessoInstancia.AcessarSistemaClaro(browser, "https://migracaob.claro.com.br/migracao/login.jsp", frmInterno, _dadosParaRegistro);

                FluxoProcessoInstancia.ExecutarFluxoProcessoInstancia(browser, frmInterno, frmInterno._instancia, frmInterno.GetOperacao);

                // return false;
            }

            return true;
        }

        //Metodo que por meio do banco consulta a mensagem da venda
        public static void ConsultarMensagemDoStatus(AxSHDocVw.AxWebBrowser browser, DadosParaRegistro _dadosParaRegistro, BuscarVendaParaRegistro_Result venda, string palavraChave, int etapa)
        {
            bool segundoTD = false;
            IHTMLElementCollection colecaoTD = null;
            IHTMLElement td = null;
            string mensagem = "";

            segundoTD = false;

            try
            {
                colecaoTD = ((mshtml.HTMLDocument)browser.Document).getElementsByTagName("TD");

                for (int t = 0; t < colecaoTD.length; t++)
                {
                    td = colecaoTD.item(t);

                    if (td.innerText != null)
                    {
                        if (td.innerText.ToUpper().Contains(palavraChave))
                        {
                            if (palavraChave == "JUSTIFICATIVA")
                            {
                                mensagem = td.parentElement.innerText;
                                break;
                            }
                            else if (segundoTD)
                            {
                                mensagem = td.innerText.Replace("Aviso:", "");
                                break;
                            }

                            segundoTD = true;
                        }
                    }
                }

                if (mensagem.Replace(" ", "") != string.Empty)
                {
                    List<ListarMensagemDoStatus_Result> list = new InstanciaBLO().ListarMensagemDoStatus(etapa);

                    foreach (ListarMensagemDoStatus_Result item in list)
                    {
                        if (mensagem.ToUpper().Contains(item.mensagem.ToUpper()))
                        {
                            _dadosParaRegistro.DefinirDiagnostico(item.idStatusDoRegistro, mensagem, venda);
                            break;
                        }
                    }

                    //Metodo Novo de inserção de mensagem no banco
                    if (_dadosParaRegistro.status == 1)
                    {

                        //new InstanciaBLO().AtualizarMensagemDoStatus(mensagem, etapa);
                        new InstanciaBLO().AtualizarMensagemDoStatus(mensagem, 1);
                        _dadosParaRegistro.DefinirDiagnostico(43, mensagem, venda);
                    }
                }

                else
                {
                    _dadosParaRegistro.DefinirDiagnostico(13, etapa == 2 ? "Mensagem de JUSTIFICATIVA não encontrada!" : "Mensagem de AVISO não encontrada!", venda);
                }
            }
            catch (Exception ex)
            {
                _dadosParaRegistro.DefinirDiagnostico(13, "Erro de exceção de código ao tentar consultar na base de dados o aviso ou justificativa de reprovação do WM. Por favor avisar ao fornecedor.", venda);
                _dadosParaRegistro.promocaoMarcada = ex.StackTrace;
            }
        }

        public static bool VerificarInsercaoElementoHtml(AxSHDocVw.AxWebBrowser browser, frmInputClaroMigracaoWM frmInterno, DadosParaRegistro _dadosParaRegistro, BuscarVendaParaRegistro_Result venda,
            IHTMLElement campoHTML, string elementoAtribuido, int contador, string nomeCampo, bool onchange)
        {
            if (campoHTML != null)
            {
                campoHTML.setAttribute("value", elementoAtribuido);

                if (onchange)
                {
                    ((HTMLSelectElement)campoHTML).FireEvent("onchange");
                    frmInterno.waitTillLoad(browser);

                    try
                    {
                        if (campoHTML.getAttribute("value") == elementoAtribuido)
                        {
                            return true;
                        }
                        else if (contador == 4)
                        {
                            _dadosParaRegistro.DefinirDiagnostico(13, "Não preencheu o conteúdo do campo " + nomeCampo + " no site da Claro", venda);
                        }
                    }
                    catch
                    {
                        return true;
                    }
                }
                else
                {
                    Application.DoEvents();
                    //waitTillLoad(browser, frmInterno, frmPopup);

                    if (campoHTML.getAttribute("value") == elementoAtribuido)
                    {
                        return true;
                    }
                    else if (contador == 4)
                    {
                        _dadosParaRegistro.DefinirDiagnostico(13, "Não preencheu o conteúdo do campo " + nomeCampo + " no site da Claro", venda);
                    }
                }

            }
            else if (contador == 4)
            {
                _dadosParaRegistro.DefinirDiagnostico(13, "veio nulo o campo " + nomeCampo + " no Site da Claro", venda);
            }

            return false;
        }
    }
}
