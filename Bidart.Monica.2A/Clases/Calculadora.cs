using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clases
{
    /// <summary>
    /// Opera matemáticamente dos objetos del tipo Numero
    /// según se lo indique.
    /// </summary>
    public class Calculadora
    {
        /// <summary>
        /// Método que realiza calculos con los dos objetos del tipo Numero,
        /// realizando la operación especificada en el parámetro operador.
        /// </summary>
        /// <param name="numero1"> Es el primer objeto para operar. </param>
        /// <param name="numero2"> Es el segundo objeto para operar. </param>
        /// <param name="operador"> Es la operación a realizar con los objetos </param>
        /// <returns> Si todo ok: Retorna el valor resultante de la operación realizada
        /// y cero en caso de division errónea (división por cero). </returns>
        public static double Operar(Numero numero1,Numero numero2,string operador)
        {
            double resultado = 0;
            operador = ValidarOperador(operador);
            switch(operador)
            {
                case "+":
                    resultado = numero1.GetNumero() + numero2.GetNumero();
                    break;
                case "-":
                    resultado = numero1.GetNumero() - numero2.GetNumero();
                    break;
                case "*":
                    resultado = numero1.GetNumero() * numero2.GetNumero();
                    break;
                case "/":
                    if(numero2.GetNumero() == 0)
                    {
                        return resultado;
                    }
                    else
                    {
                        resultado = numero1.GetNumero() / numero2.GetNumero();
                    }
                    break;
                default:
                    break;
            }
            return resultado;
        }
        /// <summary>
        /// Valida que el string pasado como parámetro sea válido
        /// </summary>
        /// <param name="operador"> Es el operador a validar. </param>
        /// <returns> El operador validado o "+" en caso contrario </returns>
        public static string ValidarOperador(string operador)
        {
            if(operador == "-" || operador == "*" || operador == "/")
            {
                return operador;
            }
            return "+"; // Retorna mas(+) en caso que no sea uno de los otros operadores y si no es uno válido
        }
    }
}
