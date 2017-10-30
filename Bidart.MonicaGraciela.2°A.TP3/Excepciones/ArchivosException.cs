using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Inicializa una nueva instancia de la clase
    /// excepción invocando a base y asignándole un
    /// mensaje de error y la referencia al error
    /// interno que causa la excepción.
    /// </summary>
    public class ArchivosException:Exception
    {
        public ArchivosException(Exception innerException):base("Error en la lectura/escritura del archivo",innerException)
        { }
    }
}
