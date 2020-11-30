using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Campos
        private int legajo;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de Universitario por defecto
        /// </summary>
        public Universitario()
        { }

        /// <summary>
        /// Constructor de universitario que utiliza el constructor de su base(Persona) y agrega el legajo
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre, apellido,dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Sobreescribe el Equals para que devuelva true solo si el objeto con el que comparamos es del tipo universitario
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Universitario;
        }

        /// <summary>
        /// Utilizando MostarDatos() de la base muestra los datos del universitario
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder;
            sb.AppendLine(base.ToString());
            sb.AppendLine($"LEGAJO NÚMERO: {this.legajo}");
            return sb.ToString();

        }
        /// <summary>
        /// Metodo abstracto que será implementada en las clases herederas
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        #endregion

        #region Sobrecargas
        /// <summary>
        /// retorna true solo si los objetos a comparar son del tipo universitario y tienen en comun el nro de legajo o su nro de dni
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator == (Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2) && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI);
        }
        /// <summary>
        /// retorna true solo si los objetos a comparar no son del tipo universitario o no tienen en comun el nro de legajo o su nro de dni
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator != (Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
