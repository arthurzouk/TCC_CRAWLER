using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CALLPLUS_PA.DAL;
using CALLPLUS_PA.EF;

namespace CALLPLUS_PA.BLL
{
    public class InstanciaBLO
    {
        public int Add(Instancia item)
        {
            return new InstanciaDAO().Add(item);
        }

        public int Editar(Instancia item)
        {
            return new InstanciaDAO().Editar(item);
        }

        public void Apagar(Instancia item)
        {
            new InstanciaDAO().Apagar(item);
        }

        public EF.Instancia BuscarPorId(int id)
        {
            return new InstanciaDAO().BuscarPorId(id);
        }

        public void AtualizarVersaoRobo(int idInstancia, string processo, string versao)
        {
            new InstanciaDAO().AtualizarVersaoRobo(idInstancia, processo, versao);
        }

        public EF.BuscarVendaParaRegistro_Result MIG_BuscarVendaParaRegistro(int idInstancia, bool crivada, bool verificacao, int operacao, string banco)
        {
            return new InstanciaDAO().MIG_BuscarVendaParaRegistro(idInstancia, crivada, verificacao, operacao, banco);
        }
        public EF.SelecionarPlanoDaVenda_Result SelecionarPlanoDaVenda(int Processo, string Plano)
        {
            return new InstanciaDAO().SelecionarPlanoDaVenda(Processo, Plano);
        }
        public List<VerificaDuplicidadeDeRegistro_Result> VerificaDuplicidadeDeRegistro(int idInstancia, int idVenda, int operacao, string banco, int produto, bool deletar)
        {
            return new InstanciaDAO().VerificaDuplicidadeDeRegistro(idInstancia, idVenda, operacao, banco, produto, deletar);
        }

        public void MIG_FinalizarRegistroDaInstancia(long idVenda, int idInstancia, int idStatus, string campo01, string campo02, string campo03,
             string campo04, string campo05, string campo06, string campo07, string campo08, string campo09, string campo10,
             string campo11, string campo12, string campo13, string campo14, string campo15, string campo16, string campo17,
             string campo18, string campo19, string campo20, string campo21, string campo22, string campo23, string campo24,
             string campo25, string campo26, string campo27, string campo28, string campo29, string campo30, string campo31, string campo32,
             string COMTA, string COMTAAcessado, string ServidorClaro, string VersaoRobo, int operacao,
             string campo33, string descricao, string msisdn, string banco, int posicao)
        {
            new InstanciaDAO().MIG_FinalizarRegistroDaInstancia(idVenda, idInstancia, idStatus, campo01, campo02, campo03,
             campo04, campo05, campo06, campo07, campo08, campo09, campo10,
             campo11, campo12, campo13, campo14, campo15, campo16, campo17,
             campo18, campo19, campo20, campo21, campo22, campo23, campo24,
             campo25, campo26, campo27, campo28, campo29, campo30, campo31, campo32, COMTA, COMTAAcessado,
             ServidorClaro, VersaoRobo, operacao, campo33, descricao, msisdn, banco, posicao);
        }

        public void AtualizarMensagemDoStatus(string mensagem, int etapa)
        {
            new InstanciaDAO().AtualizarMensagemDoStatus(mensagem, etapa);
        }

        public APP_ATUALIZAR_DIA_VENCIMENTO_FATURA_Result APP_ATUALIZAR_DIA_VENCIMENTO_FATURA(bool verificar, string diaVencimento, string fechamentoFatura)
        {
            return new InstanciaDAO().APP_ATUALIZAR_DIA_VENCIMENTO_FATURA(verificar, diaVencimento, fechamentoFatura);
        }

        public void FinalizarInstancia(int idInstancia)
        {
            new InstanciaDAO().FinalizarInstancia(idInstancia);
        }

        public List<ListarResultadoDaInstancia_Result> ListarResultadoDaInstancia(int idInstancia)
        {
            return new InstanciaDAO().ListarResultadoDaInstancia(idInstancia);
        }

        public List<ListarMensagemDoStatus_Result> ListarMensagemDoStatus(int idEtapa)
        {
            return new InstanciaDAO().ListarMensagemDoStatus(idEtapa);
        }

        public EF.BuscarLicencaPAM_Result BuscarLicenca(int id)
        {
            return new InstanciaDAO().BuscarLicenca(id);
        }

        public List<int?> ListarInstanciaInativa(string servidor)
        {
            return new InstanciaDAO().ListarInstanciaInativa(servidor);
        }

        public List<ListarLicencaSemInstancia_Result> ListarLicencaSemInstancia(string servidor)
        {
            return new InstanciaDAO().ListarLicencaSemInstancia(servidor);
        }

        public EF.BuscarDadosDaInstancia_Result BuscarDadosDaInstancia(int id)
        {
            return new InstanciaDAO().BuscarDadosDaInstancia(id);
        }

        public string BuscarTipoLogradouro(string tipoCRM, string tipoCRM2)
        {
            return new InstanciaDAO().BuscarTipoLogradouro(tipoCRM, tipoCRM2);
        }
    }
}
