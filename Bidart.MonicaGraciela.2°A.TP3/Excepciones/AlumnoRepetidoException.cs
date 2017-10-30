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
    /// mensaje de error.
    /// </summary>
    public class AlumnoRepetidoException:Exception
    {
        public AlumnoRepetidoException():base("Alumno Repetido")
        { }
    }
}
