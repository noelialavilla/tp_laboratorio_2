using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;

namespace ClasesAbstractas
{
    public abstract class Persona
    {
        #region Campos
        public enum ENacionalidad { Argentino, Extranjero };
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region Propiedades
        /// <summary>
        /// propiedad que permite realizar la obtención del atributo apellido y la asignación
        /// del mismo mediante un valor obtenido por parametro que previamente se validará
        /// </summary>
        public string Apellido {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// propiedad que permite realizar la obtención del atributo DNI y la asignación
        /// del mismo mediante un valor obtenido por parametro que previamente se validará
        /// </summary>
        public int DNI {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }
        /// <summary>
        /// propiedad que permite realizar la obtención del atributo nombre y la asignación
        /// del mismo mediante un valor obtenido por parametro que previamente se validará
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// propiedad que permite realizar la obtención del atributo nacionalidad y la asignación
        /// del mismo mediante un valor obtenido por parametro
        /// </summary>
        public ENacionalidad Nacionalidad {
            get
            {
                return this.nacionalidad;
            }
            set 
            {
                this.nacionalidad = value;
            }
        }

       /// <summary>
       /// setea el atributo DNI mediante un valor string recibido que se validará
       /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// constructor por defecto de persona
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        ///  constructor de persona que recibe parametros nombre, apellido y nacionalidad
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// constructor de persona que recibe parametros nombre, apellido, dni y nacionalidad
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
           : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// constructor de persona que recibe parametros nombre, apellido, dni en formato string y nacionalidad
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
           : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Métodos

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"NOMBRE COMPLETO: {this.Apellido}, {this.Nombre} ");
            sb.AppendLine($"NACIONALIDAD: {this.Nacionalidad}");
            if (this.DNI != 0)
            {
                sb.AppendLine($"DNI: {this.DNI}");
            }
            return sb.ToString();

        }
        /// <summary>
        /// Verifica que el dni proporcionado este entre los valores permitidos, de no ser asi lanza un DniInvalidoException. Luego verifica que el nro de dni sea compatible
        /// con la nacionalidad de la persona, de no ser asi lanza una NacionalidadInvalidaException
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (dato < 1 || dato > 99999999)
            {
                throw new DniInvalidoException();
            }

                if (nacionalidad == ENacionalidad.Argentino && (dato >= 90000000 && dato <= 99999999)
                || nacionalidad == ENacionalidad.Extranjero && (dato >= 1 && dato <= 89999999))
            {
                return dato;
            }
            else
            {
                throw new NacionalidadInvalidaException();
            }
        }
        /// <summary>
        /// Verifica que el DNI proporcionado en formato string sea valido para su conversion a Int, en ese caso utiliza el validador que verifica que el dni sea compatible con la
        /// nacionalidad. Caso contrario lanza DniInvalidoException
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            if (!(int.TryParse(dato, out int intDni)))
            {
                throw new DniInvalidoException("El DNI ingresado es incorrecto. Solo debe ingresar numeros.");
            }

            return this.ValidarDni(nacionalidad, intDni);

        }

        /// <summary>
        /// Valida que el string recibido solo contenga letras y que sea una cadena mayor a 2 caracteres
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            string cadenaValidada = "^[a-zA-Z]+$"; 
            if(dato==string.Empty || dato.Length<2 || !Regex.IsMatch(dato, cadenaValidada))
            {
                dato = string.Empty;
            }

            return dato;
        }

        #endregion
    }
}
