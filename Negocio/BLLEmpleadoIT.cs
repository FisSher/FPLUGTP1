using Abstraccion;
using BE;
using Mapper;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class BLLEmpleadoIT : IGestor<BEEmpleadoIT>
    {
        private MPPEmpleadoIT mPPEmpleadoIT;

        public BLLEmpleadoIT()
        {
            mPPEmpleadoIT = new MPPEmpleadoIT();
        }

        #region unused
        //No va a ser fisica.
        public bool Baja(BEEmpleadoIT Objeto)
        {
            throw new NotImplementedException();
        }
        #endregion

        public bool BajaLogica(BEEmpleadoIT bEEmpleadoIT)
        {
            return mPPEmpleadoIT.BajaLogica(bEEmpleadoIT);
        }

        public bool Guardar(BEEmpleadoIT bEEmpleadoIT)
        {
            return mPPEmpleadoIT.Guardar(bEEmpleadoIT);
        }

        public List<BEEmpleadoIT> ListarTodo()
        {
            return mPPEmpleadoIT.ListarTodo();
        }
    }
}