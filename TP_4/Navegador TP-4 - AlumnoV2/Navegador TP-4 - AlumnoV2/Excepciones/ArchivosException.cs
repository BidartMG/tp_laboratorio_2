using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException:Exception
    {
        /// <summary>
        /// Inicializa una nueva instancia de la excepciòn
        /// pasàndole a base un mensaje de error y la referencia
        /// al error interno que produjo la excepciòn.
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException):base("Error en la lectura/escritura del archivo",innerException)
        { }

    }
}
