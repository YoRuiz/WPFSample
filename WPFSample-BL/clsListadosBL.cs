using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSample
{
    public class clsListadosBL
    {
        public List<clsPersona> listarBL()
        {
            List<clsPersona> lista = new List<clsPersona>();
            clsListadosDAL listado = new clsListadosDAL();
            lista = listado.getListadoPersonasDAL();
            return lista;
        }
    }
}
