using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Archivos
{
    public class Texto :IArchivo<string>
    {
        /// <summary>
        /// guarda string en archivo de texto
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>true si pudo guardar, lanza excepcion en caso contrario</returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(archivo, true))
                {
                    file.WriteLine(datos);
                }

                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// lee datos del archivo y los guarda en variable datos
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns> true si pudo leer, lanza excepcion en caso contrario</returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader(archivo))
                {
                    datos = file.ReadToEnd();
                }

                return true;
            }
            catch (Exception e)
            {
                datos = "";
                throw new ArchivosException(e);
            }
        }
    }
}
