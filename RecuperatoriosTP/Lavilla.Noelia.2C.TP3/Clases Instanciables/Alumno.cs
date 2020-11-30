using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        #region Campos
        public enum EEstadoCuenta { AlDia, Deudor, Becado };
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto de Alumno
        /// </summary>
        public Alumno()
        {

        }
        /// <summary>
        /// Constructor de alumno que recibe los parametros id, nombre, apellido, dni, nacionalidad y claseQueToma, utiliza constructor de su clase base
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        /// <summary>
        /// Constructor de Alumno que ademas de recibir nombre apellido, id, dni, nacionalidad y clase que toma recibe el estado de cuenta. Utiliza el constructor de alumno
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Métodos

        /// <summary>
        /// retornará la cadena "TOMA CLASE DE " junto al nombre de la clase que toma
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"TOMA CLASE DE: {this.claseQueToma}");
            return sb.ToString();
        }

        /// <summary>
        /// retorna cadena con datos del alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder datosAlumno = new StringBuilder();
            datosAlumno.AppendLine(base.MostrarDatos());
            datosAlumno.AppendLine($"ESTADO DE CUENTA: {this.estadoCuenta}");
            datosAlumno.AppendLine(this.ParticiparEnClase());
            return datosAlumno.ToString();
        }
        /// <summary>
        /// Sobreescritura del metodo ToString()
        /// </summary>
        /// <returns>cadena con datos del alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }


        #endregion

        #region Sobrecargas
        /// <summary>
        /// Sobrecarga del operador ==, retorna true si el Alumno toma esa clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>true si el alumno toma la clase con la cual estan comparando y su estado de cuenta no es deudor</returns>
        public static bool operator == (Alumno a, Universidad.EClases clase)
        {
            if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// Sobrecarga del operador !=, retorna true si el Alumno no toma esa clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>true si el alumno no toma la clase con la cual estan comparandor</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma != clase )
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion
    }
}
