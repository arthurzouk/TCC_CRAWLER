using mshtml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CALLPLUS_PA
{
    class FluxoCarrefour
    {
        public struct itemDaLista
        {
            public string nome;
            public string preco;
        }

        public static void ExecutarFluxoCarrefour (AxSHDocVw.AxWebBrowser browser, frmInputClaroMigracaoWM frmInterno)
        {
            try
            {
                browser.Navigate(System.Configuration.ConfigurationManager.AppSettings.Get("urlCARREFOUR"));

                IHTMLElement txtPesquisa = null;
                IHTMLElement btnPesquisa = null;

                List<itemDaLista> listaDeItemsPesquisados = new List<itemDaLista>();

                if (VerificadorDoSistema.VerificarCarregamentoDeTelas(browser, frmInterno, frmInterno._dadosParaRegistro, null, "O QUE VOCÊ ESTÁ PROCURANDO", "", 0, "Primeira Etapa", false))
                {
                    for (int i = 0; i < 5; i++)
                    {
                        txtPesquisa = ((mshtml.HTMLDocument)browser.Document).getElementById("js-site-search-input");

                        if (VerificadorDoSistema.VerificarInsercaoElementoHtml(browser, frmInterno, frmInterno._dadosParaRegistro, frmInterno.venda, txtPesquisa, "detergente", i, "PESQUISA", false))
                        {
                            //_dadosParaRegistro.cpfMarcado = txtCpf.getAttribute("value");
                            break;
                        }
                    }

                    if (txtPesquisa != null && txtPesquisa.parentElement != null)
                    {
                        foreach (IHTMLElement item in txtPesquisa.parentElement.children)
                        {
                            if (item.tagName == "BUTTON")
                            {
                                btnPesquisa = item;

                                btnPesquisa.click();
                                Application.DoEvents();

                                break;
                            }
                        }
                    }

                    if (VerificadorDoSistema.VerificarCarregamentoDeTelas(browser, frmInterno, frmInterno._dadosParaRegistro, null, "NEEMU-PRODUCTS-CONTAINER", "", 0, "Resultado da pesquisa", false))
                    {
                        IHTMLElement listaDeProdutos = null;

                        foreach (IHTMLElement item in ((mshtml.HTMLDocument)browser.Document).getElementsByTagName("UL"))
                        {
                            if (item.outerHTML != null && item.outerHTML.ToUpper().Contains("NEEMU-PRODUCTS-CONTAINER"))
                            {
                                listaDeProdutos = item;
                                break;
                            }
                        }

                        if (listaDeProdutos != null)
                        {
                            foreach (IHTMLElement produto in listaDeProdutos.children)
                            {
                                if (produto.tagName == "LI")
                                {
                                    string innerHTML = produto.innerHTML;
                                    string innerText = produto.innerText;
                                    string nomeDoProduto = string.Empty;
                                    string precoDoProduto = string.Empty;
                                    itemDaLista auxiliar = new itemDaLista();

                                    foreach (IHTMLElement infoDoProduto in produto.children)
                                    {
                                        if (infoDoProduto.outerHTML != null && infoDoProduto.outerHTML.ToUpper().Contains("NM-PRODUCT-INFO"))
                                        {
                                            foreach (IHTMLElement tituloDoProduto in infoDoProduto.children)
                                            {
                                                if (tituloDoProduto.tagName == "H2")
                                                {
                                                    nomeDoProduto = tituloDoProduto.innerText;
                                                }
                                                else if (tituloDoProduto.outerHTML != null && tituloDoProduto.outerHTML.ToUpper().Contains("NM-AVAILABLE"))
                                                {
                                                    foreach (IHTMLElement oferta in tituloDoProduto.children)
                                                    {
                                                        if (oferta.outerHTML != null && oferta.outerHTML.ToUpper().Contains("NM-OFFER"))
                                                        {
                                                            foreach (IHTMLElement detalheDaOferta in oferta.children)
                                                            {
                                                                if (detalheDaOferta.outerHTML != null && detalheDaOferta.outerHTML.ToUpper().Contains("NM-PRICE-CONTAINER"))
                                                                {
                                                                    precoDoProduto = detalheDaOferta.innerText.Replace("\r", "").Replace("\n", "");
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                    }

                                    if (!string.IsNullOrEmpty(nomeDoProduto) && !string.IsNullOrEmpty(precoDoProduto))
                                    {
                                        auxiliar.nome = nomeDoProduto;
                                        auxiliar.preco = precoDoProduto;

                                        listaDeItemsPesquisados.Add(auxiliar);
                                    }

                                }
                            }
                        }
                        else
                        {

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
