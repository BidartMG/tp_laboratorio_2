using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clases
{
    /// <summary>
    /// Clase que valida y contiene los operandos.
    /// </summary>
    public class Numero
    {
        #region Fields

        private double numero;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto,inicializa el único atributo
        /// en cero (0).
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// Constructor parametrizado.Recibe un numero en formato
        /// de string,lo valida y setea en el atributo numero el
        /// valor del mismo si es válido,sino queda en cero por 
        /// default.
        /// </summary>
        /// <param name="numero"> Es el número a validar y cargar </param>
        public Numero(string numero):this()
        {
            this.SetNumero(numero);
        }
        /// <summary>
        /// Constructor parametrizado.Recibe un numero y lo carga
        /// en el atributo numero.
        /// </summary>
        /// <param name="numero"> Es el número a ser cargado </param>
        public Numero(double numero):this()
        {
            this.numero = numero;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Método que retorna el valor del atributo privado numero 
        /// perteneciente al objeto Numero.
        /// </summary>
        /// <returns></returns>
        public double GetNumero()
        {
            return this.numero;
        }     
       /// <summary>
       /// Método que setea un valor pasado como argumento en el
       /// atributo privado numero del objeto Numero.
       /// </summary>
       /// <param name="numero"> Es el numero a setear. </param>
        private void SetNumero(string numero)
        {
            double numeroValido = ValidarNumero(numero);
            if(numeroValido != 0)
            {
                this.numero = numeroValido;
            }
        }
        /// <summary>
        /// Método que valida que un numero en formato string pasado 
        /// como parámetro sea válido.
        /// </summary>
        /// <param name="numeroString"> Es el número a validar </param>
        /// <returns> Si es válido: El string del argumento como un numero double,
        /// y en caso de no serlo: retorna 0 </returns>
        private static double ValidarNumero(string numeroString)
        {
            double numeroValido;
            if(double.TryParse(numeroString,out numeroValido))
            {
                return numeroValido;
            }
            return 0; // Si no es válido retorna 0
        }

#endregion

    }
}
