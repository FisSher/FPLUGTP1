using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Presentacion
{
    public class ValidacionesRegex
    {

        public bool ValidarAlfanumerico(string texto) 
        {
            return Regex.IsMatch(texto, "^([a-zA-Z0-9]+$)");
        }

        public bool ValidarSoloNumero(string texto)
        {
            return Regex.IsMatch(texto,"^([0-9]+$)");
        }

        public bool ValidarSoloLetras(string texto)
        {
            return Regex.IsMatch(texto, "^([a-zA-Z]+$)");
        }

        public bool ValidarSoloMayus(string texto)
        {
            return Regex.IsMatch(texto, "^([A-Z]+$)");
        }
        public bool ValidarSoloMinus(string texto)
        {
            return Regex.IsMatch(texto, "^([a-z]+$)");
        }

    }
}
