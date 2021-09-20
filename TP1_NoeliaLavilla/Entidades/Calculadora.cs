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
        /// <returns> char operadorValidado </returns>
        private static char ValidarOperador(char operador)
        {
            char operadorValidado;

            if (!(operador == '+' || operador == '-' || operador == '/' || operador == '*'))
            {
                operadorValidado = '+';
            }
            else
            {
                operadorValidado = operador;
            }

            return operadorValidado;
        }

        /// <summary>
        ///  Utiliza el metodo ValidarOperador para validar el operador recibido por parametro. Realiza la operación solicitada 
        ///  entre los numeros recibidos y devuelve su resultado
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado;

            operador = ValidarOperador(operador);

            switch (operador)
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado = num1 - num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
                case '*':
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