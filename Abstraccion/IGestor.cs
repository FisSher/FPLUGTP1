using System.Collections.Generic;

namespace Abstraccion
{
    public interface IGestor<T> where T : IEntidad
    {
        bool Guardar(T Objeto);

        bool Baja(T Objeto);

        List<T> ListarTodo();

        bool BajaLogica(T Objeto);

        T ListarObjeto(T Objeto);
    }
}