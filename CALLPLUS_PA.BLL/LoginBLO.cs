using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CALLPLUS_PA.DAL;
using CALLPLUS_PA.EF;

namespace CALLPLUS_PA.BLL
{
    public class LoginBLO
    {
        public int Add(Login item)
        {
            return new LoginDAO().Add(item);
        }

        public int Editar(Login item)
        {
            return new LoginDAO().Editar(item);
        }

        public void Apagar(Login item)
        {
            new LoginDAO().Apagar(item);
        }

        public EF.Login BuscarPorId(int id)
        {
            return new LoginDAO().BuscarPorId(id);
        }

        public EF.Login BuscarLoginDisponivel(int idProcesso, int idInstancia, string banco)
        {
            return new LoginDAO().BuscarLoginDisponivel(idProcesso, idInstancia, banco);
        }

        public EF.Login BuscarLoginEspecifico(int idProcesso, int idInstancia, string banco, string COMTA)
        {
            return new LoginDAO().BuscarLoginEspecifico(idProcesso, idInstancia, banco, COMTA);
        }

        public List<ListarLogin_Result> Listar(int idProcesso, bool ativo)
        {
            return new LoginDAO().Listar(idProcesso, ativo);
        }

    }
}
