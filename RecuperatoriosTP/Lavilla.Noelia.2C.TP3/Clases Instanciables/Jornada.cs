using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }
          
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto, instancia la lista de alumnois
        /// </summary>
        public Jornada()
        {
            alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.instructor = instructor;
            this.clase = clase;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// recibe una jornada y guarda sus datos en un archivo de texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>true si pudo guardarlso</returns>
        public static bool Guardar(Jornada jornada)
        {
            string locationFile = AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt";

            Texto txt = new Texto();

            return txt.Guardar(locationFile, jornada.ToString());
        }

        /// <summary>
        /// lee el archivo de jornada y devuelve un string con sus datos, en caso de no encontrar el archivo devuelve cadena vacia
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            string locationFile = AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt";
            string retorno;
            Texto txt = new Texto();
            if (txt.Leer(locationFile, out retorno))
            {
                return retorno;
            }
            else
            {
                return string.Empty;
            }

        }
        /// <summary>
        /// overrride del toStirng()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder jornadaData = new StringBuilder();
            
            jornadaData.AppendLine("JORNADA: ");
            jornadaData.AppendLine($"CLASE DE {this.Clase} POR {this.Instructor.ToString()}");
            jornadaData.AppendLine("ALUMNOS: ");
            foreach (Alumno alu in this.Alumnos)
            {
                jornadaData.AppendLine(alu.ToString());
            }
            jornadaData.AppendLine("<------------------------------------------->");
            return jornadaData.ToString();
        }

        #endregion
        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del operador == para comparacion entre jornada y alumno
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>True si el alumno se encuentra en la lista de alumno de la jornada</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno alumno in j.Alumnos)
            {
                if (alumno == a)
                {
                    return true;
                }
            }
            return false;

        }

        /// <summary>
        /// Sobrecarga del operador != para comparacion entre jornada y alumno
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>devuelve true si el alumno no se encuentra inscripto en la jornada</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Sobrecarga operador + para suma entre jornada y alumno
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>devuelve la jornada con el alumno inscripto si este no se encontraba inscripto</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }
        #endregion

    }
}
