using mshtml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CALLPLUS_PA
{
    class FluxoExtra
    {
        public struct itemDaLista
        {
            public string nome;
            public string preco;
        }

        public static void ExecutarFluxoBH(AxSHDocVw.AxWebBrowser browser, frmInputClaroMigracaoWM frmInterno)
        {
            try
            {
                browser.Navigate(System.Configuration.ConfigurationManager.AppSettings.Get("urlBH"));

                IHTMLElement txtPesquisa = null;
                IHTMLElement btnPesquisa = null;

                List<itemDaLista> listaDeItemsPesquisados = new List<itemDaLista>();

                if (VerificadorDoSistema.VerificarCarregamentoDeTelas(browser, frmInterno, frmInterno._dadosParaRegistro, null, "NOVIDADES", "", 0, "Primeira Etapa", false))
                {
                    for (int i = 0; i < 5; i++)
                    {
                        txtPesquisa = ((mshtml.HTMLDocument)browser.Document).getElementsByName("s").item(0);

                        foreach (IHTMLElement item in txtPesquisa.parentElement.children)
                        {
                            if (item.tagName == "BUTTON")
                            {
                                btnPesquisa = item;
                            }
                        }

                        if (VerificadorDoSistema.VerificarInsercaoElementoHtml(browser, frmInterno, frmInterno._dadosParaRegistro, frmInterno.venda, txtPesquisa, "detergente", i, "PESQUISA", false))
                        {
                            //_dadosParaRegistro.cpfMarcado = txtCpf.getAttribute("value");

                            btnPesquisa.click();
                            Application.DoEvents();
                            break;
                        }
                    }

                    if (VerificadorDoSistema.VerificarCarregamentoDeTelas(browser, frmInterno, frmInterno._dadosParaRegistro, null, "IMPULSE-PRODUCT-CARD PRODUCT", "", 0, "Resultado da pesquisa", false))
                    {
                        //string innerHTML = produto.innerHTML;
                        //string innerText = produto.innerText;
                        string nomeDoProduto = string.Empty;
                        string precoDoProduto = string.Empty;
                        itemDaLista auxiliar = new itemDaLista();

                        List<IHTMLElement> links = null;

                        foreach (IHTMLElement a in ((mshtml.HTMLDocument)browser.Document).getElementsByTagName("A"))
                        {
                            if (a.innerText.ToUpper().Contains("DETERGENTE"))
                            {
                                links.Add(a);
                            }
                        }

                        foreach (IHTMLElement item in links)
                        {

                        }

                        if (!string.IsNullOrEmpty(nomeDoProduto) && !string.IsNullOrEmpty(precoDoProduto))
                        {
                            auxiliar.nome = nomeDoProduto;
                            auxiliar.preco = precoDoProduto;

                            listaDeItemsPesquisados.Add(auxiliar);
                        }

                    }
                    else
                    {

                    }
                }
                else
                {

                }



                while (true)
                {
                    browser.Silent = true;
                    frmInterno.waitTillLoad(browser);
                    browser.Silent = false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
