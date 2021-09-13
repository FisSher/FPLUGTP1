using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraccion
{    public interface IGestor<T> where T : IEntidad
    {
        bool Guardar(T Objeto);
        bool Baja(T Objeto);
        List<T> ListarTodo();
        bool BajaLogica(T Objeto);


        //No creo usarlo por ahora
        //T ListarObjeto(T Objeto);
    }
}
