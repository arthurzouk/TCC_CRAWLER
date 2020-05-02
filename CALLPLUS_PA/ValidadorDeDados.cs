using CALLPLUS_PA.BLL;
using CALLPLUS_PA.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CALLPLUS_PA
{
    public class ValidadorDeDados
    {
        public static bool ValidarDadosDaVenda(frmInputClaroMigracaoWM frmInterno, EF.BuscarVendaParaRegistro_Result venda, DadosParaRegistro _dadosParaRegistro, int idProcesso)
        {
            //*******************************************Recebe PlanoDaVenda para utilização*******************************************
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    frmInterno.PlanoDaVenda = new InstanciaBLO().SelecionarPlanoDaVenda(idProcesso, frmInterno.venda.plano.ToUpper().Trim());
                    if (frmInterno.PlanoDaVenda != null)
                    {
                        break;
                    }
                    else
                    {
                        _dadosParaRegistro.DefinirDiagnostico(12, "Plano inválido: " + frmInterno.venda.plano, venda);
                        return false;
                    }

                }
                catch { }
            }

            if (frmInterno.PlanoDaVenda == null)
            {
                _dadosParaRegistro.DefinirDiagnostico(13, "Falha ao consultar base dados para obter marcações de plano e promoção", venda);
                return false;
            }

            try
            {
                if (venda.cpf.Contains(",") && venda.cpf.Contains("E") && venda.cpf.Contains("+"))
                {
                    var antesDaVirgula = venda.cpf.Split(',')[0];
                    var entreAViruglaeoE = venda.cpf.Split(',')[1].Split('E')[0];
                    var depoisDoMais = int.Parse(venda.cpf.Split('+')[1]);
                    var cpf = antesDaVirgula + entreAViruglaeoE;
                    var zeros = ("").PadRight(depoisDoMais - entreAViruglaeoE.Length, '0');
                    venda.cpf = cpf + zeros;
                }

            }
            catch (Exception)
            {
            }

            venda.cpf = venda.cpf.Replace(".", "").Replace("-", "").Trim().PadLeft(11, '0');

            if (!ValidadorDeDados.validarCPF(venda.cpf))
            {
                _dadosParaRegistro.DefinirDiagnostico(30, "CPF Inválido", venda);
                return false;
            }

            long msisdn = 0;
            //Criar um método para chamar a classe de ValidadorDeDados para verificar qualquer tipo de dado(MSISDN)
            if (!long.TryParse(venda.msisdn.Trim(), out msisdn)
                || (venda.msisdn.ToString().Length < 10 || venda.msisdn.ToString().Length > 11)
                || venda.msisdn.ToString().Substring(0, 1) == "0"
                || long.Parse(venda.msisdn.Trim()) == long.Parse(venda.cpf.Trim()))
            {
                _dadosParaRegistro.DefinirDiagnostico(5, "MSISDN Inválido", venda);
                return false;
            }

            venda.cep = venda.cep.Trim().Replace(".", "").Replace("-", "").PadLeft(8, '0');
            long cepValidar = 0;

            if (venda.cep.Trim() == ""
                || (!long.TryParse(venda.cep, out cepValidar) || venda.cep.Length != 8))
            {
                _dadosParaRegistro.DefinirDiagnostico(12, "CEP inválido", venda);
                return false;
            }


            int[] DDDs = { 11, 12, 13, 14, 15, 16, 17, 18, 19,
                           21, 22, 24, 27, 28,
                           31, 32, 33, 34, 35, 37, 38,
                           41, 42, 43, 44, 45, 46, 47, 48, 49,
                           51, 53, 54, 55,
                           61, 62, 63, 64, 65, 66, 67, 68, 69,
                           71, 73, 74, 75, 77, 79,
                           81, 82, 83, 84, 85, 86, 87, 88, 89,
                           91, 92, 93, 94, 95, 96, 97, 98, 99
                         };

            int DDD = Int32.Parse(venda.msisdn.ToString().Substring(0, 2));
            int cont = 0;

            string telString = venda.msisdn.ToString();

            char primeiroNumeroTel = telString[2];

            if (DDDs.Contains(DDD))
            {
                if (venda.msisdn.ToString().Length == 10)
                {
                    _dadosParaRegistro.DefinirDiagnostico(29, "Erro Tamanho MSISDN", venda);
                    return false;
                }
            }
            else
            {
                if (venda.msisdn.ToString().Length == 11)
                {
                    _dadosParaRegistro.DefinirDiagnostico(29, "Erro Tamanho MSISDN", venda);
                    return false;
                }
            }

            for (int i = 2; i < telString.Length; i++)
            {

                if (primeiroNumeroTel == telString[i])
                {
                    cont++;
                }
                else break;
            }

            if (cont == (telString.Length - 2))
            {
                _dadosParaRegistro.DefinirDiagnostico(12, "telefone incorreto para os telefones nos formatos 99999999999", venda);
                return false;
            }

            venda.nomeMae = RemoverAcentos(venda.nomeMae);

            venda.nomeMae = venda.nomeMae.Replace(".", "").Replace(",", "").Replace("-", "").Replace(":", "").Replace(";", "");

            bool invalido = false;

            foreach (char c in venda.nomeMae.ToCharArray())
            {
                if (!Char.IsLetter(c) && c != ' ')
                {
                    invalido = true;
                    break;
                }
            }

            venda.nomeMae = venda.nomeMae.Replace("  ", " ");

            string[] nomeSeparado = venda.nomeMae.Split(' ');

            if (venda.nomeMae.Trim() == "" || venda.nomeMae.Contains("  ") || nomeSeparado.Length < 2 || venda.nomeMae.Length < 4 || invalido)
            {
                _dadosParaRegistro.DefinirDiagnostico(12, "Nome da mãe inválido.", venda);
                return false;
            }

            long telRes = 0;

            if (venda.telResidencial == "")
            {
                venda.telResidencial = venda.msisdn;
            }

            if (venda.telRecado == "" || venda.telRecado == "0")
            {
                venda.telRecado = venda.telResidencial;
            }

            if (!long.TryParse(venda.telResidencial, out telRes) || venda.telResidencial == "")
            {
                _dadosParaRegistro.DefinirDiagnostico(12, "Telefone Residencial inválido", venda);
                return false;
            }

            long telRec = 0;

            if (!long.TryParse(venda.telRecado, out telRec) || venda.telRecado == "")
            {
                _dadosParaRegistro.DefinirDiagnostico(12, "Telefone Recado inválido", venda);
                return false;
            }

            if (venda.telResidencial.ToString().Length < 10)
            {
                string zeros = "";

                for (int j = 0; j < 10 - venda.telResidencial.ToString().Length; j++)
                {
                    zeros += "0";
                }

                venda.telResidencial = venda.telResidencial.ToString() + zeros;
            }

            if (venda.telRecado.ToString().Length < 10)
            {
                string zeros = "";

                for (int j = 0; j < 10 - venda.telRecado.ToString().Length; j++)
                {
                    zeros += "0";
                }

                venda.telRecado = venda.telRecado.ToString() + zeros;
            }

            venda.telResidencial = venda.telResidencial.ToString().Substring(0, 10);
            venda.telRecado = venda.telRecado.ToString().Substring(0, 10);

            if (venda.telResidencial == venda.telRecado)
            {
                int ultimoDigito = int.Parse(venda.telRecado.ToString().Substring(venda.telRecado.ToString().Length - 1, 1));

                if (ultimoDigito == 9)
                    ultimoDigito = 0;
                else
                    ultimoDigito = ultimoDigito + 1;

                string novoTel = venda.telRecado.ToString().Substring(0, venda.telRecado.ToString().Length - 1) + ultimoDigito.ToString();

                venda.telRecado = novoTel;
            }

            venda.nome = RemoverAcentos(venda.nome);

            venda.nome = venda.nome.Replace(".", "").Replace(",", "").Replace("-", "").Replace(":", "").Replace(";", "");

            invalido = false;

            foreach (char c in venda.nome.ToCharArray())
            {
                if (!Char.IsLetter(c) && c != ' ')
                {
                    invalido = true;
                    break;
                }
            }

            venda.nome = venda.nome.Replace("  ", " ");

            nomeSeparado = venda.nome.Split(' ');

            if (venda.nome.Trim() == "" || venda.nome.Contains("  ") || nomeSeparado.Length < 2 || venda.nome.Length < 4 || invalido)
            {
                _dadosParaRegistro.DefinirDiagnostico(12, "Nome do Cliente inválido", venda);
                return false;
            }


            int banco = 0;
            long agencia = 0;
            long conta = 0;

            int[] bancos = { 1, 001, 422, 756, 748, 237, 104, 399, 341, 389, 33 };

            ValidarBanco(venda);

            if (venda.banco.Trim() != "")
            {
                if (!int.TryParse(venda.banco, out banco)
                    || venda.banco.Length > 3
                    || !bancos.Contains(int.Parse(venda.banco)))
                {
                    _dadosParaRegistro.DefinirDiagnostico(12, "Banco inválido", venda);
                    return false;
                }

                venda.agencia = venda.agencia.Replace("-", "");
                venda.conta = venda.conta.Replace("-", "");

                if (!long.TryParse(venda.agencia, out agencia)
                    || venda.agencia.Length > 8)
                {
                    _dadosParaRegistro.DefinirDiagnostico(12, "Agência inválida", venda);
                    return false;
                }

                if (!long.TryParse(venda.conta, out conta)
                    || venda.conta.Length > 12)
                {
                    _dadosParaRegistro.DefinirDiagnostico(12, "Conta inválida", venda);
                    return false;
                }
            }

            int vencimentoValidar = 0;

            if (!int.TryParse(venda.vencimento, out vencimentoValidar))
            {
                _dadosParaRegistro.DefinirDiagnostico(12, "Vencimento inválido", venda);
                return false;
            }

            try
            {
                string[] vetLogradouro = venda.logradouro.Split(' ');
                //string tipoLogradouroUsado1 = venda.logradouro.Split(' ')[0].ToString();
                //string tipoLogradouroUsado2 = venda.logradouro.Split(' ')[1].ToString();

                _dadosParaRegistro.tipoLogradouro = new InstanciaBLO().BuscarTipoLogradouro(vetLogradouro[0].ToUpper(), vetLogradouro[1]);

                if (string.IsNullOrEmpty(_dadosParaRegistro.tipoLogradouro))
                {
                    _dadosParaRegistro.tipoLogradouro = "RUA";
                    _dadosParaRegistro.logradouro = venda.logradouro;
                }
                else
                {
                    for (int i = 0; i < vetLogradouro.Length; i++)
                    {
                        if (venda.logradouro.ToUpper().Contains(_dadosParaRegistro.tipoLogradouro.ToUpper()))
                        {
                            if (_dadosParaRegistro.tipoLogradouro.ToUpper() != vetLogradouro[i].ToUpper())
                            {
                                _dadosParaRegistro.logradouro += vetLogradouro[i] + " ";
                            }
                        }
                        else if (i > 0)
                        {
                            _dadosParaRegistro.logradouro += vetLogradouro[i] + " ";
                        }
                    }
                    //_dadosParaRegistro.logradouro = venda.logradouro.ToUpper().Replace(tipoLogradouroUsado1.ToUpper(), "").Trim();
                }
            }
            catch (Exception ex)
            {
                _dadosParaRegistro.tipoLogradouro = "RUA";
                _dadosParaRegistro.logradouro = venda.logradouro;
            }

            if (_dadosParaRegistro.logradouro == "Não foi marcado")
            {
                _dadosParaRegistro.DefinirDiagnostico(12, "Logradouro inválido: " + venda.logradouro, venda);
                return false;
            }

            return true;
        }

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

        public static string RemoverAcentos(string texto)
        {
            string comAcentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
            string semAcentos = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

            for (int i = 0; i < comAcentos.Length; i++)
            {
                texto = texto.Replace(comAcentos[i].ToString(), semAcentos[i].ToString());
            }
            return texto;
        } // Fim RemoverAcentos

        internal static string ValidarEmail(string cliente, BuscarVendaParaRegistro_Result venda, DadosParaRegistro dadosParaRegistro)
        {
            if (cliente == "ALIANCA")
            {
                string[] verificarInformouEmail = venda.email.Split('+');

                if (verificarInformouEmail.Length == 2)
                {
                    if (verificarInformouEmail[0] == "SIM")
                    {
                        try
                        {
                            MailAddress m = new MailAddress(venda.email);

                            return verificarInformouEmail[1];
                        }
                        catch (Exception)
                        {
                            dadosParaRegistro.DefinirDiagnostico(12, "email inválido: " + verificarInformouEmail[1], venda);
                        }
                    }
                    else
                    {
                        dadosParaRegistro.emailMarcado = "Não informado pelo cliente";
                    }
                }
                else
                {
                    dadosParaRegistro.DefinirDiagnostico(12, "Formato incorreto do campo e-mail. Favor verificar e-mail da venda.", venda);
                }
            }
            //Acrescimo da actionline na regra solicitado pelo lucas via e-mail. 31/05/2019
            else //if (cliente == "ACTIONLINE")
            {
                if (!string.IsNullOrEmpty(venda.email.Trim()))
                {
                    string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

                    System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex(strRegex);

                    if (re.IsMatch(venda.email))
                    {
                        string[] emailParte = venda.email.Split('@');

                        if (emailParte[0].Length > 2)
                        {
                            string[] email2 = emailParte[1].Split('.');

                            if (email2[0].Length > 1)
                            {
                                return venda.email;
                            }
                        }
                    }

                    dadosParaRegistro.DefinirDiagnostico(12, "email inválido: " + venda.email, venda);
                }
                else
                {
                    dadosParaRegistro.emailMarcado = "Não informado pelo cliente";
                }
            }
            //else
            //{
            //    string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
            //                      @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
            //                      @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            //    System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex(strRegex);

            //    if (re.IsMatch(venda.email))
            //    {
            //        string[] emailParte = venda.email.Split('@');

            //        if (emailParte[0].Length > 2)
            //        {
            //            string[] email2 = emailParte[1].Split('.');

            //            if (email2[0].Length > 1)
            //            {
            //                return venda.email;
            //            }
            //        }
            //    }
            //}

            return string.Empty;
        }

        private static void ValidarBanco(BuscarVendaParaRegistro_Result venda)
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
    }
}
