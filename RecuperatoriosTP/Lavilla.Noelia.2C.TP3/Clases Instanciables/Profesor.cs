using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public class Profesor : Universitario
    {
        #region Campos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor estatico para incicializar el atributo random solamente
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor por defecto sin param
        /// </summary>
        public Profesor() { }

        /// <summary>
        /// Constructor parametrizado que inicializa clases del dia y le asigna valores a traves del metodo _randomClases
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) 
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// asigna dos clases al azar
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
               
                this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(1, 4));
            }

        }
     
        /// <summary>
        /// muestra todos los datos del profesor utilizando mostrardatos de la clase base 
        /// 
        /// </summary>
        /// <returns>string con los datos del profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder datosProfe = new StringBuilder();
            datosProfe.AppendFormat(base.MostrarDatos());
            datosProfe.AppendFormat(this.ParticiparEnClase());
            return datosProfe.ToString();
        }
        /// <summary>
        /// guarda en un string las clases que dicta el profesor
        /// </summary>
        /// <returns> string con la ionfo sobre las clases que dicta el prof</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder datosClase = new StringBuilder();
            datosClase.AppendLine("CLASES DEL DIA: ");
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                datosClase.AppendFormat(clase.ToString() + "\n");
            }
            return datosClase.ToString();
        }
        /// <summary>
        /// Hace públicos los datos del profesor
        /// </summary>
        /// <returns>Retorna string con todos los datos del profesor.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// sobrecarga operador == para comparacion entre profesor y clase
        /// </summary>
        /// <returns>Retorna true si el profesor dicta la clase comparada,falso caso contrario </returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            
            foreach (Universidad.EClases c in i.clasesDelDia)
            {
                if (clase == c)
                {
                    return true;
                    
                }
            }
            return false;
        }
        /// <summary>
        /// sobrecarga operador != para comparacion entre profesor y clase
        /// </summary>
        /// <returns>true si el profesor no dicta esa clase.</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion

    }
}
