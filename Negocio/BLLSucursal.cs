using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Abstraccion;
using Mapper;

namespace Negocio
{
    public class BLLSucursal : IGestor<BESucursal>
    {

        MPPSucursal mPPSucursal;
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

        public List<BESucursal> ListarTodo()
        {
            return mPPSucursal.ListarTodo();
        }
    }
}
