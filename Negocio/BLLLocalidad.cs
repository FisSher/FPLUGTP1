using Abstraccion;
using BE;
using Mapper;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class BLLLocalidad : IGestor<BELocalidad>
    {
        public BLLLocalidad()
        {
            oMMLocalidad = new MPPLocalidad();
        }

        private MPPLocalidad oMMLocalidad;

        public bool Baja(BELocalidad Objeto)
        {
            return oMMLocalidad.Baja(Objeto);
        }

        public bool BajaLogica(BELocalidad Objeto)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BELocalidad Objeto)
        {
            return oMMLocalidad.Guardar(Objeto);
        }

        public BELocalidad ListarObjeto(BELocalidad Objeto)
        {
            throw new NotImplementedException();
        }

        public List<BELocalidad> ListarTodo()
        {
            return oMMLocalidad.ListarTodo();
        }
    }
}