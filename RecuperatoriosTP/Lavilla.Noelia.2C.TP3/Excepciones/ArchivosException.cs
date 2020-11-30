using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException :Exception
    {
        /// <summary>
        /// Se lanzarà esta excepcion en el caso de que hubiese sucedido un error a la hroa de guardar o leer un archivo
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException)
            : base("Error en archivo", innerException)
        {
        }
    }
}
