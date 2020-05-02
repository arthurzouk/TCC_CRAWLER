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
    public class LoginDAO
    {
        private CALLPLUS_Entities context = new CALLPLUS_Entities();

        public int Add(Login item)
        {
            try
            {
                context.AddToLogin(item);
                context.SaveChanges();
                return item.id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int Editar(Login item)
        {
            try
            {
                context.Login.Attach(item);
                context.ObjectStateManager.ChangeObjectState(item, System.Data.EntityState.Modified);
                context.SaveChanges();
                return item.id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Apagar(Login item)
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

        public Login BuscarPorId(int id)
        {
            try
            {
                Login q = (from c in context.Login
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

        public Login BuscarLoginDisponivel(int idProcesso, int idInstancia, string banco)
        {
            try
            {
                context.CommandTimeout = 3600;
                Login q = context.BuscarLoginDisponivel(idProcesso, idInstancia, banco).FirstOrDefault();

                return q;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Login BuscarLoginEspecifico(int idProcesso, int idInstancia, string banco, string COMTA)
        {
            try
            {
                context.CommandTimeout = 3600;
                Login q = context.BuscarLoginEspecifico(idProcesso, idInstancia, banco, COMTA).FirstOrDefault();

                return q;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<ListarLogin_Result> Listar(int idProcesso, bool ativo)
        {
            try
            {
                var q = context.ListarLogin(idProcesso, ativo).ToList<ListarLogin_Result>();

                return q;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
