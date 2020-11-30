using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Intenta guardar archivo XML, ante un errror lanzara una excepcion
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>true si pudo guardar, false en caso contrario</returns>
        public bool Guardar(string archivo, T datos)
        {
            XmlTextWriter writer = null;
            try
            {
                writer = new XmlTextWriter(archivo, Encoding.UTF8);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, datos);

                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
               
            }
            finally
            {
                if (!object.ReferenceEquals(writer, null))
                    writer.Close();
            }
            
        }
        /// <summary>
        /// Intenta leer un archivo XML y dessearializarlo para guardarlo como dato del tipo T
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>devuelve true si pudo ser leido, de lo contrario lanzara una excepcion</returns>
        public bool Leer(string archivo, out T datos)
        {
            XmlTextReader writer = null;
            try
            {
                writer = new XmlTextReader(archivo);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                datos = (T)serializer.Deserialize(writer);
                writer.Close();

                return true;
            }
            catch (Exception e )
            {
                datos = default(T);
                throw new ArchivosException(e);
                
            }
            finally
            {
                if (!object.ReferenceEquals(writer, null))
                    writer.Close();
            }

        }
         
        
    }
}
