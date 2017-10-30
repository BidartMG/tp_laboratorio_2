using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Archivos:
///  Generar una interfaz con las firmas para guardar y leer.
///  Implementar la interfaz en las clases Xml y Texto, a fin de poder 
/// guardar y leer archivos de esos tipos.
/// </summary>
namespace Archivos
{
    public interface IArchivo<T>
    {
    #region "Firmas"
        /// <summary>
        /// Firma del método Guardar que se implementará
        /// en la clases que implementen la interfaz IArchivo.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool Guardar(string archivo, T datos);
        /// <summary>
        /// Firma del método Leer que se implementará
        /// en las clases que implementen la interfaz IArchivo
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool Leer(string archivo, out T datos);
#endregion

    }
}
