using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException:Exception
    {
        private static string mensajeBase = "El valor de DNI no es valido";

        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// invocando a base 
        /// </summary>
        public DniInvalidoException():base()
        { }
        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// invocando a base y asignándole el mensaje
        /// de error de la excepción 
        /// </summary>
        public DniInvalidoException(Exception e):base(e.Message)
        { }
        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// invocando a base y asignándole un mensaje 
        /// de error que será escrito al momento 
        /// de lanzar la excepción
        /// </summary>
        public DniInvalidoException(string message):base(message)
        { }
        /// <summary>
        /// Inicializa una nueva instancia de la clase invocando a
        /// base y asignándole un mensaje de error que será escrito 
        /// al momento de lanzar la excepciónconcatenado con el
        /// mensajeBase predeterminado y la referencia al error interno
        /// que causa la excepción.
        /// </summary>
        public DniInvalidoException(string message,Exception e):base(mensajeBase+message,e)
        { }
    }
}
