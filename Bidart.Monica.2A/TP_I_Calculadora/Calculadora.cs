using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_I_Calculadora
{
    /// <summary>
    /// Clase Calculadora: Opera matemáticamente dos objetos del tipo Numero
    /// según se le indique
    /// </summary>
    class Calculadora
    {
        /// <summary>
        /// Recibe por parámetro dos objetos del tipo Numero y un string que indica 
        /// la operacion matemática a realizar.Retornando un double con el valor 
        /// obtenido tra la operación.
        /// </summary>
        /// <param name="numero1"> Primer objeto para operar </param>
        /// <param name="numero2"> Segundo objeto para operar </param>
        /// <param name="operador"> String que define el tipo de operación matemática 
        /// a realizar </param>
        /// <returns> double El resultado de la operación matemática </returns>
        public static double Operar(Numero numero1, Numero numero2,string operador)
        {
            double retornoNumero = 0;

            switch(operador)
            {
                case "+":                    
                    retornoNumero = numero1.GetNumero() + numero2.GetNumero();
                    break;
                case "-":
                    retornoNumero = numero1.GetNumero() - numero2.GetNumero();
                    break;
                case "*":
                    retornoNumero = numero1.GetNumero() * numero2.GetNumero();
                    break;
                case "/":                    
                    if (numero2.GetNumero() == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        retornoNumero = numero1.GetNumero() / numero2.GetNumero();
                    }
                    break;
                default:
                    break;

            }
            return retornoNumero;// Borrar luego, es para que no de error
        }

        /// <summary>
        /// Recibe un string y valida que sea un operador válido para realizar
        /// las operaciones matemáticas
        /// </summary>
        /// <param name="operador"> Es el string a validar. </param>
        /// <returns> Otro string que es valido si todo OK o "+" en caso de error. </returns>
        public string ValidarOperador(string operador)
        {
            if(operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                return operador;
            }
            else
            {
                return "+";
            }
            
        }
    }
}
