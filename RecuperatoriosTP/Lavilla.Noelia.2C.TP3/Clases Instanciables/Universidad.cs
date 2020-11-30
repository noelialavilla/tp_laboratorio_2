using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    public class Universidad
    {
        #region Campos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD };
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        public List<Jornada> Jornada
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
       

        /// <summary>
        /// Indexador para acceder a una jornada en especifico a traves de su indice
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                return this.Jornada[i];
            }
            set
            {
                this.Jornada[i] = value;
            }
        }

        #endregion
        #region Constructor
        public Universidad()
        {
            profesores = new List<Profesor>();
            alumnos = new List<Alumno>();
            jornada = new List<Jornada>();

        }
        #endregion
        #region Metodos
        /// <summary>
        /// recibe un objeto del tipo universidad y guarda sus datos en un archivo del tipo XML
        /// </summary>
        /// <param name="uni"></param>
        /// <returns> true si pudo guardar, lanza excepcion en caso contrario</returns>
        public static bool Guardar(Universidad uni)
        {
            string fileLocation = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "Universidad.xml");
            Xml<Universidad> xmlFile = new Xml<Universidad>();

            return xmlFile.Guardar(fileLocation, uni);

        }

        /// <summary>
        ///  lee de un archivo xml datos con los cuales instancia una universidad
        /// </summary>
        /// <returns>devuelve la universidad creada</returns>
        public static Universidad Leer()
        {
            string fileLocation = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "Universidad.xml");
            Xml<Universidad> xmlFile = new Xml<Universidad>();
            xmlFile.Leer(fileLocation, out Universidad uniCreada);

            return uniCreada;
        }
        /// <summary>
        /// retorna string con los datos de la universidad recibida
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>string con datos de la universiadad recibida</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder uniData = new StringBuilder();
            foreach(Jornada j in uni.Jornada)
            {
                uniData.AppendLine(j.ToString());
            }
            return uniData.ToString();

        }
        /// <summary>
        /// Muestra los datos que recibe de MostrarDatos()
        /// </summary>
        /// <returns>string con los datos de la universidad</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// devuelve true si el alumno se encuentra en la universidad, false en caso contrario
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>true si alumno esta en la universiadd, false caso contrario</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
           
            foreach (Alumno alu in g.Alumnos)
            {
                if (alu == a)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Sobrecarga !=, devuelve true si el alumno no se encuentra en la universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>devuelve true si el alumno no se encuentra en esa universidad, falso en caso contrario</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Sobrecarga == para cuando se compara universidad con profesor
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Profesor</param>
        /// <returns>devuelve true si el profesor da clases en esa unviersada, false en caso contrario</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor profe in g.Instructores)
            {
                if (profe == i)
                {
                    return true;
                }
            }
            return false; ;
        }

        /// <summary>
        /// sobrecarga != para comparacion entre universidad y profesor
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Profesor</param>
        /// <returns>devuelve true si el profesor no enseña en esa universaida</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Sobrecarga == para comparacion entre universidad y clase
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Clase</param>
        /// <returns> devuelve profesor de la universidad que pueda dar esa clase, si no hay lanza excepcion</returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor profe in g.Instructores)
            {
                if (profe==clase)
                {
                    return profe;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Sobrecarga != para cuando compara unviersidad con clase
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Clase</param>
        /// <returns>devuelve profesor que no pueda dar esa clase</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor profe in g.profesores)
            {
                if (profe!=clase)
                {
                    return profe;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// Sobrecarga + para cuando suma alumno a universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>universidad con alumno agregado o lanza una excepcion si el alumno ya se encuentra en la misma</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
                return u;
            }
            throw new AlumnoRepetidoException();
        }


        /// <summary>
        /// Sobrecarga + para suma entre universidad y profesor
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Profesor</param>
        /// <returns>Universidad con el profesor agregado</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.Instructores.Add(i);
            }
            return u;
        }

        /// <summary>
        /// Genera jornada asignandole un profesor
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>universidad con la jornada agregada</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor prof;
            prof = g == clase;
            Jornada nuevaJornada = new Jornada(clase, prof);
            foreach (Alumno alu in g.Alumnos)
            {
                if (alu == clase)
                {
                    nuevaJornada = nuevaJornada + alu;
                }
            }
            g.Jornada.Add(nuevaJornada);
            return g;
        }
        #endregion
    }
}
