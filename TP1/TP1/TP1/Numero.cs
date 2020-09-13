using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;
        /// <summary>
        /// Accede al atributo privado numero de la clase Numero y le asigna el valor recibido 
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }
        /// <summary>
        /// Constructor vacio, asigna 0 al atributo privado numero de la clase Numero
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// Constructor de Numero que recibe el valor del atributo numero de la clase Numero en formato double y lo asigna 
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Constructor de Numero que recibe el valor del atributo numero de la clase Numero en formato string y lo asgina utilizando el metodo SetNumero 
        /// </summary>
        /// <param name="strNumero"></param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        //Validaciones 

        /// <summary>
        /// Comprueba que el valor recibido sea numérico, y lo retornará en formato double. Caso contrario, retornará 0.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns> double nroParseado </returns>
        public double ValidarNumero(string strNumero)
        {
            if (!double.TryParse(strNumero, out double nroParseado))
            {
                nroParseado = 0;
            }

            return nroParseado;
        }

        /// <summary>
        ///  Valida que el string ingresado por parametros sea binario. Si lo es, retorna true, si no, retorna false
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        private static bool EsBinario(string binario)
        {
            foreach (char caracter in binario)
            {
                if (caracter != '1' && caracter != '0')
                {
                    return false;
                }
            }
            return true;
        }

        //Sobrecargas de operadores

        /// <summary>
        /// Sobrecarga del operador suma (+), recibe dos elemnentos de la clase Numero, devuelve la suma de sus atributos "numero"
        /// </summary>
        /// <param name="nro1"></param>
        /// <param name="nro2"></param>
        /// <returns> suma entre los atributos "numero" de los objetos recibidos </returns>
        public static double operator +(Numero nro1, Numero nro2)
        {

            return nro1.numero + nro2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador resta (-), recibe dos elementos de la clase Numero, devuelve la resta de sus atributos "numero"
        /// </summary>
        /// <param name="nro1"></param>
        /// <param name="nro2"></param>
        /// <returns> resta entre los atributos "numero" de los objetos recibidos </returns>
        public static double operator -(Numero nro1, Numero nro2)
        {

            return nro1.numero - nro2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador division (/), recibe dos elementos de la clase Numero, devuelve la division de sus atributos "numero". 
        /// Valida que el divisor sea distinto 0. Caso contrario retornara de resultado el menor valor posible del tipo double
        /// </summary>
        /// <param name="nro1"></param>
        /// <param name="nro2"></param>
        /// <returns></returns>
        public static double operator /(Numero nro1, Numero nro2)
        {
            if (nro2.numero == 0)
            {
                return double.MinValue;
            }

            return nro1.numero / nro2.numero;
        }

        /// <summary>
        /// Sobrecarga del operador multiplicacion (*), recibe dos elementos de la clase Numero, devuelve la multiplicación de sus atributos "numero".
        /// </summary>
        /// <param name="nro1"></param>
        /// <param name="nro2"></param>
        /// <returns>devuelve la multiplicacion de los atributos "numero" de los objetos recibidos </returns>
        public static double operator *(Numero nro1, Numero nro2)
        {

            return nro1.numero * nro2.numero;
        }


        //Conversiones
        /// <summary>
        /// Validará que se trate de un binario y luego convertirá ese número binario a decimal, en caso de ser posible.Caso
        /// contrario retornará "Valor inválido".
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public string BinarioDecimal(string binario)
        {
            string conversion = "Valor inválido";
            int valorDecimal = 0;
            if (EsBinario(binario))
            {
                for (int i = 0; i < binario.Length; i++)
                {
                    if (binario[i] == '1')
                    {
                        if (i == 0)
                        {
                            valorDecimal += 1;
                        }
                        else
                        {
                            valorDecimal += (int)Math.Pow(2, i);
                        }
                    }
                }
                conversion = valorDecimal.ToString();
            }
            return conversion;
        }

        /// <summary>
        /// recibe un numero decimal del tipo double y lo convierte a binario, en caso de no poder realizarlo devuelve una cadena informandolo
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>string conversion del decimal en binario o si no lo pudo realizar una cadena informativa</returns>
        public string DecimalBinario(double numero)
        {
            string conversion = "Valor inválido";

            if (numero == 0)
            {
                conversion = "0";
            }
            else if (numero > 0)
            {
                conversion = "";
                while (numero > 0)
                {
                    if (numero % 2 == 0)
                    {
                        conversion = "0" + conversion;
                    }
                    else
                    {
                        conversion = "1" + conversion;
                    }
                    numero = (int)(numero / 2);
                }

            }

            return conversion;
        }

        /// <summary>
        /// recibe una cadena, valida si se trata de un numero en binario, de ser asi devuelve ese mismo numero. Caso contrario utiliza el metodo
        /// DecimalBinario() que recibe un double para realizar la conversion
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public string DecimalBinario(string numero)
        {
            string conversion;

            if (EsBinario(numero))
            {
                conversion = numero;
            }
            else
            {
                double.TryParse(numero, out double numeroDouble);

                conversion = DecimalBinario(numeroDouble);

            }
            return conversion;
        }



    }
}
