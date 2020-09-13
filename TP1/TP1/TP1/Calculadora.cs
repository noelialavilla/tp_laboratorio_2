using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Valida que el operador recibido sea +, -, / o*. Caso contrario retornará +.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns> string operadorStr </returns>
        private static string ValidarOperador(char operador)
        {
            string operadorStr;

            if (!(operador == '+' || operador == '-' || operador == '/' || operador == '*'))
            {
                operadorStr = "+";
            }
            else
            {
                operadorStr = operador.ToString();
            }

            return operadorStr;
        }

        /// <summary>
        ///  Utiliza el metodo ValidarOperador para validar el operador recibido por parametro. Realiza la operación solicitada 
        ///  entre los numeros recibidos y devuelve su resultado
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado;
            
            operador = ValidarOperador(operador[0]);

            switch (operador)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                default:
                    resultado = 0;
                    break;
            }


            return resultado;
        }

    }
}

