using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapper;
using BE;
using Abstraccion;

namespace Negocio
{
    public class BLLPuesto : IGestor<BEPuesto>
    {

        MPPPuesto mPPPuesto;
        public BLLPuesto()
        {
            mPPPuesto = new MPPPuesto();
        }

        public bool Baja(BEPuesto oBEPuesto)
        {
            return mPPPuesto.Baja(oBEPuesto);
        }

        public bool BajaLogica(BEPuesto Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BEPuesto oBEPuesto)
        {
            return mPPPuesto.Guardar(oBEPuesto);
        }

        public List<BEPuesto> ListarTodo()
        {
            return mPPPuesto.ListarTodo();
        }
    }
}
