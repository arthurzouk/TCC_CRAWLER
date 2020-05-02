using CALLPLUS_PA.BLL;
using CALLPLUS_PA.EF;
using mshtml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CALLPLUS_PA
{
    class FluxoProcessoInstancia
    {

        public static void ExecutarFluxoProcessoInstancia(AxSHDocVw.AxWebBrowser browser, frmInputClaroMigracaoWM frmInterno, BuscarDadosDaInstancia_Result _instancia, int idProcesso)
        {
            browser.Navigate("about:blank");
            frmInterno.HabilitarDesabilitarMenu(false);

            while (PodeExecutar(frmInterno, frmInterno._dadosParaRegistro, _instancia))
            {
                if (frmInterno.banco == "CARREFOUR")
                {
                    FluxoCarrefour.ExecutarFluxoCarrefour(browser, frmInterno);
                }
                else if (frmInterno.banco == "BH")
                {
                    FluxoExtra.ExecutarFluxoBH(browser, frmInterno);
                }
            }

            //FECHA A INSTANCIA SEELA ESTIVER INATIVA
            frmInterno.Close();
        }

        private static bool PodeExecutar(frmInputClaroMigracaoWM frmInterno, DadosParaRegistro _dadosParaRegistro, BuscarDadosDaInstancia_Result _instancia)
        {
            frmInterno.AtualizarDadosDaTela(_instancia, _dadosParaRegistro, "Verificando se instancia está ativa para executar", false);
#if DEBUG
            return true;
#else
            bool executar;

            try
            {
                _instancia = new InstanciaBLO().BuscarDadosDaInstancia(frmInterno.idInstanciaPAM);

                executar = _instancia.ativo;

            }
            catch (Exception e)
            {
                executar = true;
            }

            return executar;
#endif
        }

        public static bool AcessarSistemaClaro(AxSHDocVw.AxWebBrowser browser, string url, frmInputClaroMigracaoWM frmInterno, DadosParaRegistro _dadosParaRegistro)
        {
            browser.Navigate(url);

            frmInterno.waitTillLoad(browser);

            return VerificadorDoSistema.VerificarCarregamentoDeTelas(browser, frmInterno, _dadosParaRegistro, null, "LOGONFORM", "", 0, "Tela de Login", false);
        }

        private static void ExecutarFluxoDeRegistro(AxSHDocVw.AxWebBrowser browser, frmInputClaroMigracaoWM frmInterno, BuscarDadosDaInstancia_Result _instancia, DadosParaRegistro _dadosParaRegistro, int idProcesso)
        {
            try
            {
                //Veriica se há algum dado inválido na venda
                frmInterno.AtualizarDadosDaTela(_instancia, _dadosParaRegistro, "Validando dados da Venda", false);
                if (ValidadorDeDados.ValidarDadosDaVenda(frmInterno, frmInterno.venda, _dadosParaRegistro, idProcesso))
                {
                    frmInterno.AtualizarDadosDaTela(_instancia, _dadosParaRegistro, "Iniciando fluxo de input da Venda", false);
                    //FluxoProcessoClaro.ExecutarFluxoProcessoClaro(browser, frmInterno, frmInterno.venda, _instancia, _dadosParaRegistro);
                }
            }
            catch (Exception ex)
            {
                _dadosParaRegistro.DefinirDiagnostico(1, "Exceção de código. " + _dadosParaRegistro.etapaDoProcesso, frmInterno.venda);
                _dadosParaRegistro.promocaoMarcada = ex.Message;

                if (ex.InnerException != null)
                {
                    frmInterno.AtualizarDadosDaTela(_instancia, _dadosParaRegistro, ex.InnerException.Message.Length > 100 ? ex.InnerException.Message.Substring(0, 100) : ex.InnerException.Message, true);
                }
                else
                {
                    frmInterno.AtualizarDadosDaTela(_instancia, _dadosParaRegistro, ex.Message.Length > 100 ? ex.Message.Substring(0, 100) : ex.Message, true);
                }
            }
            finally
            {
                frmInterno.AtualizarDadosDaTela(_instancia, _dadosParaRegistro, "Finalizando registro", false);

                FinalizarRegistro(idProcesso, frmInterno, frmInterno.venda, _dadosParaRegistro, _instancia);

                frmInterno.AtualizarDadosDaTela(_instancia, _dadosParaRegistro, "Registro Finalizado", false);
            }
        }

        private static bool BuscarVendaParaRegistro(frmInputClaroMigracaoWM frmInterno, BuscarDadosDaInstancia_Result _instancia, DadosParaRegistro _dadosParaRegistro, int idProcesso)
        {
            List<VerificaDuplicidadeDeRegistro_Result> concorrencia = null;
            List<VerificaDuplicidadeDeRegistro_Result> deletar = null;

            try
            {
                frmInterno.AtualizarDadosDaTela(_instancia, _dadosParaRegistro, "Buscando venda para registro", false);

                frmInterno.venda = new InstanciaBLO().MIG_BuscarVendaParaRegistro(_instancia.id, false, false, idProcesso, frmInterno.banco);
            }
            catch (Exception ex)
            {
                frmInterno.venda = null;
            }

            if (frmInterno.venda != null)
            {
                //Verifica se mais de uma instancia pegou a mesma venda para tratar ao mesmo tempo
                frmInterno.AtualizarDadosDaTela(_instancia, _dadosParaRegistro, "Realizando controle de concorrencia", false);
                for (int i = 0; i < 3; i++)
                {
                    concorrencia = new InstanciaBLO().VerificaDuplicidadeDeRegistro(_instancia.id, Convert.ToInt32(frmInterno.venda.ID), idProcesso, frmInterno.banco, Convert.ToInt32(frmInterno.venda.produto), false);

                    #region metodo com Lambda
                    if (concorrencia.Count > 1)
                    {
                        var instanciaAtual = concorrencia.FirstOrDefault(x => x.idInstancia == _instancia.id);
                        var existeInstanciaMaisAntiga = concorrencia.Any(x => x.dataInicio < instanciaAtual.dataInicio && x.idInstancia != instanciaAtual.idInstancia);

                        if (existeInstanciaMaisAntiga)
                        {
                            //Fazer deletar o registro da instancia e fazer a instancia pegar a próxima venda.
                            frmInterno.AtualizarDadosDaTela(_instancia, _dadosParaRegistro, "Registro duplicado. Registro mais novo sendo apagado.", true);

                            try
                            {
                                deletar = new InstanciaBLO().VerificaDuplicidadeDeRegistro(_instancia.id, Convert.ToInt32(frmInterno.venda.ID), idProcesso, frmInterno.banco, Convert.ToInt32(frmInterno.venda.produto), true);
                                frmInterno.venda = null;
                            }
                            catch (Exception)
                            {

                            }

                            break;
                        }
                    }
                    #endregion

                    Thread.Sleep(500);
                }
            }

            return frmInterno.venda != null;
        }

        private static void FinalizarRegistro(int idProcesso, frmInputClaroMigracaoWM frmInterno, BuscarVendaParaRegistro_Result venda, DadosParaRegistro _dadosParaRegistro, BuscarDadosDaInstancia_Result _instancia)
        {
            try
            {
                if (_dadosParaRegistro.status == 1)
                {

                }

                new InstanciaBLO().MIG_FinalizarRegistroDaInstancia(
                                venda.ID, _instancia.id, _dadosParaRegistro.status, _dadosParaRegistro.protocolo, _dadosParaRegistro.autorizacao,
                                venda.rg, _dadosParaRegistro.rgMarcado,
                                venda.cpf, _dadosParaRegistro.cpfMarcado,
                                venda.vencimento, _dadosParaRegistro.vencimentoMarcado,
                                _dadosParaRegistro.tipoPagamento, _dadosParaRegistro.dadosBancarios, _dadosParaRegistro.codigoBanco, _dadosParaRegistro.dadosBancariosMarcados,
                                venda.faturaDigital, _dadosParaRegistro.faturaDigitalMarcada,
                                venda.plano, _dadosParaRegistro.planoMarcado, _dadosParaRegistro.promocaoMarcada,
                                venda.dataNascimento, _dadosParaRegistro.nascimentoMarcado,
                                venda.nomeMae, _dadosParaRegistro.nomeMaeMarcado,
                                venda.email, _dadosParaRegistro.emailMarcado, _dadosParaRegistro.smsNovidadeMarcado,
                                venda.cep, _dadosParaRegistro.cepMarcado,
                                venda.telResidencial, _dadosParaRegistro.telefoneContatoMarcado,
                                _dadosParaRegistro.tipoLogradouro, _dadosParaRegistro.tipoLogradouroMarcado,
                                _dadosParaRegistro.enderecoCompleto, _dadosParaRegistro.enderecoCompletoMarcado,
                                _dadosParaRegistro.COMTA, _dadosParaRegistro.COMTAAcessado,
                                _dadosParaRegistro.ServidorClaro, _dadosParaRegistro.VersaoRobo,
                                idProcesso, venda.statusVenda,
                                _dadosParaRegistro.descricao, venda.msisdn, frmInterno.banco, int.Parse(venda.produto)
                            );
            }
            catch (Exception)
            {
                //Conferir processo de envio de e-mail
                Enviar_Email("arthur.vieira@hmbtecnologia.com.br", "matheus.coutinho@hmbtecnologia.com.br", /*"daniel.moreno@hmbtecnologia.com.br",*/ "ROBO - Cliente: " + frmInterno.cliente + " Migracao", _dadosParaRegistro.descricao);
            }
        }

        public static void FinalizarInstancia(frmInputClaroMigracaoWM frmInterno, BuscarDadosDaInstancia_Result _instancia, int idProcesso)
        {
            try
            {
                if (_instancia != null)
                {
                    Instancia i = new Instancia();
                    i.id = _instancia.id;
                    i.ativo = false;
                    i.dataCriacao = _instancia.dataCriacao;
                    i.idCriadoPor = _instancia.idCriadoPor;
                    i.idLogin = _instancia.idLogin;
                    i.idLicenca = _instancia.idLicenca;

                    new InstanciaBLO().Editar(i);
                }

                if (frmInterno.venda != null && frmInterno._dadosParaRegistro != null)
                {
                    frmInterno.AtualizarDadosDaTela(_instancia, frmInterno._dadosParaRegistro, "Finalizando registro", false);

                    FinalizarRegistro(idProcesso, frmInterno, frmInterno.venda, frmInterno._dadosParaRegistro, _instancia);

                    frmInterno.AtualizarDadosDaTela(_instancia, frmInterno._dadosParaRegistro, "Registro Finalizado", false);
                }
            }
            catch (Exception ex)
            {

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
    }
}
