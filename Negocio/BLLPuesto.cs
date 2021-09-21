using Abstraccion;
using BE;
using Mapper;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class BLLPuesto : IGestor<BEPuesto>
    {
        private MPPPuesto mPPPuesto;

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

        public BEPuesto ListarObjeto(BEPuesto Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BEPuesto> ListarTodo()
        {
            return mPPPuesto.ListarTodo();
        }
    }
}