using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_I_Calculadora
{
    /// <summary>
    /// Clase Numero: Valida y contiene los operandos
    /// posee los métodos y constructores.
    /// </summary>
    class Numero
    {
        // Atributo
        private double numero;

        // 
        public double GetNumero()
        {
            return this.numero;
        }

        // Constructores

        /// <summary>
        /// Constructor por defecto
        /// Inicializa el atributo de clase: numero en cero(0)
        /// </summary>
        public Numero()
        {
            //this.numero = 0; Preguntar si corresponde como está
            this.SetNumero("0");
        }

        /// <summary> 
        /// Constructor parametrizado que invoca al constructor por defecto,
        /// Valida el string recibido y lo carga en el miembro numero de 
        /// la clase. 
        /// </summary>
        /// <param name="numero"> string a validar y cargar</param>
        public Numero(string numero) : this()
        {
            this.SetNumero(numero);
        }

        /// <summary>
        /// Constructor parametrizado que invoca al constructor por defecto e 
        /// inicializa el miembro de clase: numero.
        /// </summary>
        /// <param name="numero"> Es el número que se va a asignar
        /// al miembro de Clase  </param>
        public Numero(double numero):this()
        {
            this.numero = numero;
        }


        // Métodos
        /// <summary>
        /// Recibe un string a validar, si es valido lo retorna
        /// como un numero double y en caso contrario retorna cero (0).
        /// </summary>
        /// <param name="numeroString"> Es el string a validar y retornar </param>
        /// <returns> El string validado como un numero double si todo OK o cero (0) en caso
        /// de error. </returns>
        private static double ValidarNumero(string numeroString)
        {
            double retornoNumero;
            if( !double.TryParse(numeroString,out retornoNumero))
            {
                return 0;
            }
            else
            {
                return retornoNumero;
            }            
        }

        /// <summary>
        /// Recibe un string, lo valida y lo setea en el miembro numero de la 
        /// clase.
        /// </summary>
        /// <param name="numero"> Es el string a validar y setear </param>
        private void SetNumero(string numero)
        {
            double numeroDouble = Numero.ValidarNumero(numero);
            this.numero = numeroDouble;
        }
    }
}
