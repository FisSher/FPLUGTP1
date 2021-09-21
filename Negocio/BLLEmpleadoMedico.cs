using Abstraccion;
using BE;
using Mapper;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class BLLEmpleadoMedico : IGestor<BEEmpleadoMedico>
    {
        private MPPEmpleadoMedico mPPEmpleadoMedico;

        public BLLEmpleadoMedico()
        {
            mPPEmpleadoMedico = new MPPEmpleadoMedico();
        }

        #region unused

        //No lo voy a aplicar por delete
        public bool Baja(BEEmpleadoMedico Objeto)
        {
            throw new NotImplementedException();
        }

        #endregion unused

        public bool BajaLogica(BEEmpleadoMedico bEEmpleadoMedico)
        {
            return mPPEmpleadoMedico.BajaLogica(bEEmpleadoMedico);
        }

        public bool Guardar(BEEmpleadoMedico bEEmpleadoMedico)
        {
            return mPPEmpleadoMedico.Guardar(bEEmpleadoMedico);
        }

        public BEEmpleadoMedico ListarObjeto(BEEmpleadoMedico Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BEEmpleadoMedico> ListarTodo()
        {
            return mPPEmpleadoMedico.ListarTodo();
        }
    }
}