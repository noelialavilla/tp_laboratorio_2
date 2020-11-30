using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Se lanza al recibir un DNI cuyo nro no se correspodne con su nacionalidad
    /// </summary>
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException(string message) : base(message)
        {
        }
       
        public NacionalidadInvalidaException() : this("El numero de DNI no es compatible con su nacionalidad")
        {
        }
       
    }
}
