using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException:Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// excepción invocando a base y asignándole un
        /// mensaje de error 
        /// </summary>
        public NacionalidadInvalidaException():base("La nacionalidad no se condice con el numero de DNI")
        { }
        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// excepción invocando a base y asignándole un
        /// mensaje de error que será escrito al momento 
        /// de lanzar la excepción
        /// </summary>
        public NacionalidadInvalidaException(string message):base(message)
        { }
    }
}
