using CALLPLUS_PA.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CALLPLUS_PA.DAL
{
    public class ProcessoDoWindowsDaInstanciaDAO
    {
        private CALLPLUS_Entities context = new CALLPLUS_Entities();

        //public int Add(ProcessoDoWindowsDaInstancia item)
        //{
        //    try
        //    {
        //        context.AddToProcessoDoWindowsDaInstancia(item);
        //        context.SaveChanges();

        //        return item.id;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public int Editar(ProcessoDoWindowsDaInstancia item)
        //{
        //    try
        //    {
        //        context.ProcessoDoWindowsDaInstancia.Attach(item);
        //        context.ObjectStateManager.ChangeObjectState(item, System.Data.EntityState.Modified);
        //        context.SaveChanges();
        //        return item.id;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public IList<ProcessoDoWindowsDaInstancia> ObtemTodos()
        //{
        //    try
        //    {
        //        return context.ProcessoDoWindowsDaInstancia.ToList();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //public IList<ProcessoDoWindowsDaInstancia> ObtemTodosAtivos()
        //{
        //    try
        //    {
        //        return context.ProcessoDoWindowsDaInstancia.Where(x => x.theEndTime == null).ToList();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //public ProcessoDoWindowsDaInstancia ObtemPorId(int id)
        //{
        //    try
        //    {
        //        return context.ProcessoDoWindowsDaInstancia.FirstOrDefault(x => x.id == id);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        //public ProcessoDoWindowsDaInstancia ObtemPorInstancia_Processo(int idInstancia, int idProcesso)
        //{
        //    try
        //    {
        //        return context.ProcessoDoWindowsDaInstancia.FirstOrDefault(x => x.idInstancia == idInstancia && x.pid == idProcesso);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //public ProcessoDoWindowsDaInstancia ObtemPorProcesso(int idProcesso)
        //{
        //    try
        //    {
        //        return context.ProcessoDoWindowsDaInstancia.FirstOrDefault(x => x.pid == idProcesso);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //public ProcessoDoWindowsDaInstancia ObtemPorInstancia(int idInstancia)
        //{
        //    try
        //    {
        //        return context.ProcessoDoWindowsDaInstancia.FirstOrDefault(x => x.idInstancia == idInstancia
        //                                                                     && x.theEndTime == null);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public ServidorDeInstanciaDoRobo ObtemServidorPorId(int id)
        {
            try
            {
                return context.ServidorDeInstanciaDoRobo.FirstOrDefault(x => x.id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ServidorDeInstanciaDoRobo ObtemServidorPeloNome(string nome)
        {
            try
            {
                return context.ServidorDeInstanciaDoRobo.FirstOrDefault(x => x.nome.Equals(nome));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
