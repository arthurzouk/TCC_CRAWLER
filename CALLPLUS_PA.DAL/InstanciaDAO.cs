using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CALLPLUS_PA.EF;
using System.Data.Objects;
using System.Transactions;

namespace CALLPLUS_PA.DAL
{
    public class InstanciaDAO
    {
        private CALLPLUS_Entities context = new CALLPLUS_Entities();

        public int Add(Instancia item)
        {
            try
            {
                context.AddToInstancia(item);
                context.SaveChanges();
                return item.id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int Editar(Instancia item)
        {
            try
            {
                context.Instancia.Attach(item);
                context.ObjectStateManager.ChangeObjectState(item, System.Data.EntityState.Modified);
                context.SaveChanges();
                return item.id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Apagar(Instancia item)
        {
            try
            {
                context.ObjectStateManager.ChangeObjectState(item, System.Data.EntityState.Deleted);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Instancia BuscarPorId(int id)
        {
            try
            {
                Instancia q = (from c in context.Instancia
                           where c.id == id
                           orderby c.id
                           select c).FirstOrDefault();
                return q;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AtualizarVersaoRobo(int idInstancia, string processo, string versao)
        {
            try
            {
                context.CommandTimeout = 3600;
                context.AtualizarVersaoRobo(idInstancia, processo, versao);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public void MIG_FinalizarRegistroDaInstancia(long idVenda, int idInstancia, int idStatus, string campo01, string campo02, string campo03,
             string campo04, string campo05, string campo06, string campo07, string campo08, string campo09, string campo10,
             string campo11, string campo12, string campo13, string campo14, string campo15, string campo16, string campo17,
             string campo18, string campo19, string campo20, string campo21, string campo22, string campo23, string campo24,
             string campo25, string campo26, string campo27, string campo28, string campo29, string campo30, string campo31, string campo32,
             string COMTA, string COMTAAcessado, string ServidorClaro, string VersaoRobo, int operacao,
             string campo33, string descricao, string msisdn, string banco, int posicao)
        {
            try
            {
                context.CommandTimeout = 3600;
                context.MIG_FinalizarRegistroDaInstancia(idVenda, idInstancia, idStatus, campo01, campo02, campo03,
             campo04, campo05, campo06, campo07, campo08, campo09, campo10,
             campo11, campo12, campo13, campo14, campo15, campo16, campo17,
             campo18, campo19, campo20, campo21, campo22, campo23, campo24,
             campo25, campo26, campo27, campo28, campo29, campo30, campo31, campo32, COMTA, COMTAAcessado,
             ServidorClaro, VersaoRobo, operacao, campo33, descricao, msisdn, banco, posicao);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AtualizarMensagemDoStatus(string mensagem, int etapa)
        {
            try
            {
                context.CommandTimeout = 3600;
                context.AtualizarMensagemDoStatus(mensagem, etapa);
            }
            catch (Exception ex)
            {
                
                throw;
            }            
        }

        public APP_ATUALIZAR_DIA_VENCIMENTO_FATURA_Result APP_ATUALIZAR_DIA_VENCIMENTO_FATURA(bool verificar, string diaVencimento, string fechamentoFatura)
        {
            try
            {
                context.CommandTimeout = 3600;
                APP_ATUALIZAR_DIA_VENCIMENTO_FATURA_Result q = context.APP_ATUALIZAR_DIA_VENCIMENTO_FATURA(verificar,diaVencimento, fechamentoFatura).FirstOrDefault();

                return q;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void FinalizarInstancia(int idInstancia)
        {
            try
            {
                context.CommandTimeout = 3600;
                context.FinalizarInstancia(idInstancia);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public BuscarVendaParaRegistro_Result MIG_BuscarVendaParaRegistro(int idInstancia, bool crivado, bool verificacao, int operacao, string banco)
        {
            try
            {
                context.CommandTimeout = 120;
                BuscarVendaParaRegistro_Result q = context.MIG_BuscarVendaParaRegistro(idInstancia, crivado, verificacao, operacao, banco).FirstOrDefault();

                return q;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public SelecionarPlanoDaVenda_Result SelecionarPlanoDaVenda(int Processo, string Plano)
        {
            try
            {
                context.CommandTimeout = 120;
                SelecionarPlanoDaVenda_Result q = context.SelecionarPlanoDaVenda(Processo, Plano).FirstOrDefault();

                return q;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<VerificaDuplicidadeDeRegistro_Result> VerificaDuplicidadeDeRegistro(int idInstancia, int idVenda, int operacao, string banco, int produto, bool deletar)
        {
            try
            {
                context.CommandTimeout = 120;
                var q = context.VerificaDuplicidadeDeRegistro(idInstancia, idVenda, operacao, banco, produto, deletar).ToList<VerificaDuplicidadeDeRegistro_Result>();

                return q;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ListarResultadoDaInstancia_Result> ListarResultadoDaInstancia(int idInstancia)
        {
            try
            {
                var q = context.ListarResultadoDaInstancia(idInstancia).ToList<ListarResultadoDaInstancia_Result>();

                return q;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ListarMensagemDoStatus_Result> ListarMensagemDoStatus(int idEtapa)
        {
            try
            {
                var q = context.ListarMensagemDoStatus(idEtapa).ToList<ListarMensagemDoStatus_Result>();

                return q;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public BuscarLicencaPAM_Result BuscarLicenca(int id)
        {
            try
            {
                context.CommandTimeout = 3600;
                BuscarLicencaPAM_Result q = context.BuscarLicencaPAM(id).FirstOrDefault();

                return q;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<int?> ListarInstanciaInativa(string servidor)
        {
            try
            {
                var q = context.ListarInstanciaInativa(servidor).ToList();

                return q;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ListarLicencaSemInstancia_Result> ListarLicencaSemInstancia(string servidor)
        {
            try
            {
                var q = context.ListarLicencaSemInstancia(servidor).ToList<ListarLicencaSemInstancia_Result>();

                return q;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public BuscarDadosDaInstancia_Result BuscarDadosDaInstancia(int id)
        {
            try
            {
                context.CommandTimeout = 3600;
                BuscarDadosDaInstancia_Result q = context.BuscarDadosDaInstancia(id).FirstOrDefault();

                return q;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string BuscarTipoLogradouro(string tipoCRM, string tipoCRM2)
        {
            string q = "";
            string logradouro = tipoCRM + " " + tipoCRM2;

            if ((tipoCRM != null && tipoCRM2 != null) || (tipoCRM != "" && tipoCRM2 != ""))
            {
                q = (from c in context.TiposLogradouro
                     where c.Nome == tipoCRM || c.NomeAbre == tipoCRM
                     select c.Nome).FirstOrDefault();

                if (string.IsNullOrEmpty(q))
                {
                    q = (from c in context.TiposLogradouro
                         where c.Nome.Contains(logradouro)
                         select c.Nome).FirstOrDefault();
                }
            }

            return q;
        }
    }
}
