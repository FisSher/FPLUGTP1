using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;
using BE;
using DAL;

namespace Mapper
{
    public class MPPEmpleadoMedico : IGestor<BEEmpleadoMedico>
    {

        public MPPEmpleadoMedico()
        {
            oDatos = new Acceso();
        }

        private Acceso oDatos;
        public bool Baja(BEEmpleadoMedico Objeto)
        {
            throw new NotImplementedException();
        }

        public bool BajaLogica(BEEmpleadoMedico Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BEEmpleadoMedico Objeto)
        {
            throw new NotImplementedException();
        }

        public BEEmpleadoMedico ListarObjeto(BEEmpleadoMedico Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BEEmpleadoMedico> ListarTodo()
        {
            throw new NotImplementedException();
        }
    }
}
