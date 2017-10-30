using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    public class Dulce : Producto
    {
    #region "Constructores"

        /// <summary>
        /// Constructor parametrizado que invoca al constructor base pasándole los argumentos recibidos
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigo"></param>
        /// <param name="color"></param>
        public Dulce(EMarca marca, string codigo, ConsoleColor color):base(codigo,marca,color)
        {
        }

        #endregion

    #region "Properties"

        /// <summary>
        /// Sobrecarga de la propiedad de solo lectura heredada
        /// Los dulces tienen 80 calorías
        /// </summary>
        public override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }

        #endregion

    #region "Methods"

        /// <summary>
        /// Sobrecarga del método heredado Mostrar()
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("CALORIAS : "+ this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

#endregion

    }
}
