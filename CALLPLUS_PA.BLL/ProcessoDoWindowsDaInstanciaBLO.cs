using CALLPLUS_PA.DAL;
using CALLPLUS_PA.EF;
using System.Collections.Generic;

namespace CALLPLUS_PA.BLL
{
    public class ProcessoDoWindowsDaInstanciaBLO
    {
        //public int Add(ProcessoDoWindowsDaInstancia item)
        //{
        //    return new ProcessoDoWindowsDaInstanciaDAO().Add(item);
        //}

        //public int Editar(ProcessoDoWindowsDaInstancia item)
        //{
        //    return new ProcessoDoWindowsDaInstanciaDAO().Editar(item);
        //}

        //public IList<ProcessoDoWindowsDaInstancia> ObtemTodos()
        //{
        //    return new ProcessoDoWindowsDaInstanciaDAO().ObtemTodos();
        //}
        //public IList<ProcessoDoWindowsDaInstancia> ObtemTodosAtivos()
        //{
        //    return new ProcessoDoWindowsDaInstanciaDAO().ObtemTodosAtivos();
        //}
        //public ProcessoDoWindowsDaInstancia ObtemPorId(int id)
        //{
        //    return new ProcessoDoWindowsDaInstanciaDAO().ObtemPorId(id);
        //}
        //public ProcessoDoWindowsDaInstancia ObtemPorInstancia_Processo(int idInstancia, int idProcesso)
        //{
        //    return new ProcessoDoWindowsDaInstanciaDAO().ObtemPorInstancia_Processo(idInstancia, idProcesso);
        //}
        //public ProcessoDoWindowsDaInstancia ObtemPorProcesso(int idProcesso)
        //{
        //    return new ProcessoDoWindowsDaInstanciaDAO().ObtemPorProcesso(idProcesso);
        //}
        //public ProcessoDoWindowsDaInstancia ObtemPorInstancia(int idInstancia)
        //{
        //    return new ProcessoDoWindowsDaInstanciaDAO().ObtemPorInstancia(idInstancia);
        //}

        public ServidorDeInstanciaDoRobo ObtemServidorPorId(int id)
        {
            return new ProcessoDoWindowsDaInstanciaDAO().ObtemServidorPorId(id);
        }
        public ServidorDeInstanciaDoRobo ObtemServidorPeloNome(string nome)
        {
            return new ProcessoDoWindowsDaInstanciaDAO().ObtemServidorPeloNome(nome);
        }
    }
}
