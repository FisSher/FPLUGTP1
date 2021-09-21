using Abstraccion;
using BE;
using Mapper;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class BLLSucursal : IGestor<BESucursal>
    {
        private MPPSucursal mPPSucursal;

        public BLLSucursal()
        {
            mPPSucursal = new MPPSucursal();
        }

        public bool Baja(BESucursal bESucursal)
        {
            return mPPSucursal.Baja(bESucursal);
        }

        public bool BajaLogica(BESucursal Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BESucursal bESucursal)
        {
            return mPPSucursal.Guardar(bESucursal);
        }

        public bool Sucursal_Empleado(BESucursal bESucursal, BEEmpleado empleado)
        {
            return mPPSucursal.Sucursal_Empleado(bESucursal, empleado);
        }

        public bool Quitar_Sucursal_Empleado(BESucursal bESucursal, BEEmpleado empleado)
        {
            return mPPSucursal.Quitar_Sucursal_Empleado(bESucursal, empleado);
        }

        public BESucursal ListarObjeto(BESucursal Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BESucursal> ListarTodo()
        {
            return mPPSucursal.ListarTodo();
        }
    }
}