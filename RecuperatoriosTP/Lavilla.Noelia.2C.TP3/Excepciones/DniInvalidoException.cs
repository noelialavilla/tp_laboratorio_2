using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Se lanza esta excepcion en el caso de recibir un DNI cuyo formato sea invalido 
    /// </summary>
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException()
            : base("Se ha ingresado un DNI invalido") { }
        
        public DniInvalidoException(Exception e)
            : base("Se ha ingresado un DNI invalido", e) { }
       
        public DniInvalidoException(string message)
            : base(message) { }
        
        public DniInvalidoException(string message, Exception e)
            : base(message, e) { }
        
    }
}
