using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2017
{
    public class Leche : Producto
    {
    #region "Enumerados" 

        public enum ETipo { Entera, Descremada }

#endregion

    #region "Fields"

        ETipo _tipo;
        #endregion

    #region "Constructores"

        /// <summary>
        /// Constructor parametrizado que invoca al constructor de la clase padre
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        public Leche(EMarca marca, string codigo, ConsoleColor color)
            : base(codigo, marca, color)
        {
            _tipo = ETipo.Entera;
        }

        /// <summary>
        /// Sobrecarga del constructor que invoca al constructor por default pasándole los argumentos necesarios
        /// y sobreescribiendo el atributo _tipo con el valor recibido por parámetro
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigo"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Leche(EMarca marca,string codigo,ConsoleColor color,ETipo tipo):this(marca,codigo,color)
        {
            this._tipo = tipo;
        }

        #endregion

    #region " Properties"

        /// <summary>
        /// Propiedad de solo lectura que sobreescribe a la heredada
        /// Las leches tienen 20 calorías
        /// </summary>
        public override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        #endregion

    #region "Methods"

        /// <summary>
        /// Sobrecarga del método heredado Mostrar()
        /// </summary>
        /// <returns> Un nuevo string con los datos completos del producto más los que corresponden a su tipo </returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("CALORIAS : "+ this.CantidadCalorias);
            sb.AppendLine("TIPO : " + this._tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

#endregion

    }
}
