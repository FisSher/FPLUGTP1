using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;
using BE;
using Mapper;

namespace Negocio
{
    public class BLLEmpleadoMedico : IGestor<BEEmpleadoMedico>
    {
        MPPEmpleadoMedico mPPEmpleadoMedico;

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

        #endregion
       
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
