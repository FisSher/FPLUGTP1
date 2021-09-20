using Abstraccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace Mapper
{
    public class MPPEmpleadoIT : IGestor<BEEmpleadoIT>
    {
        public MPPEmpleadoIT()
        {
            oDatos = new Acceso();
        }

        private Acceso oDatos;
        public bool Baja(BEEmpleadoIT Objeto)
        {
            throw new NotImplementedException();
        }

        public bool BajaLogica(BEEmpleadoIT Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BEEmpleadoIT Objeto)
        {
            throw new NotImplementedException();
        }

        public BEEmpleadoIT ListarObjeto(BEEmpleadoIT Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BEEmpleadoIT> ListarTodo()
        {
            throw new NotImplementedException();
        }
    }
}
