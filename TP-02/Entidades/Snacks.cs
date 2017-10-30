using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    public class Snacks:Producto
    {
    #region " Constructores"

        /// <summary>
        /// Constructor parametrizado que invoca al constructor de la clase padre pasándole los argumentos recibidos
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="codigo"></param>
        /// <param name="color"></param>
        public Snacks(EMarca marca, string codigo, ConsoleColor color)
            : base(codigo, marca, color)
        {
        }

        #endregion

    #region "Properties"

        /// <summary>
        /// Implementación de la propiedad heredada
        /// Los snacks tienen 104 calorías
        /// </summary>
        public override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }

        #endregion

    #region "Methods"

        /// <summary>
        /// Sobreescritura del método heredado Mostrar()
        /// Retorna una cadena con los valores de los atributos heredados
        /// y los propios
        /// </summary>
        /// <returns></returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("CALORIAS : "+ this.CantidadCalorias);// Recibe las calorías a través de su propiedad
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

#endregion

    }
}
