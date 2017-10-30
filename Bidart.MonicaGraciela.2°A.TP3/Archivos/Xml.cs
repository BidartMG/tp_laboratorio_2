using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using EntidadesInstanciables;
using System.IO;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T>:IArchivo<Jornada>
    {
    #region "Methods"
        /// <summary>
        /// Serializa y guarda un objeto en un archivo de formato xml
        /// Retornando true si logra hacerlo o una excepción en caso
        /// contrario
        /// </summary>
        /// <param name="archivo">Path del archivo</param>
        /// <param name="datos">Es el objeto a ser serializado y guardado</param>
        /// <returns></returns>
        public bool Guardar(string archivo, Jornada datos)
        {
            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(Universidad));
                StreamWriter escritor = new StreamWriter(archivo);
                serializador.Serialize(escritor, datos);
                escritor.Close();
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return true;
        }
        /// <summary>
        /// Lee y deserializa un archivo de formato xml y los carga 
        /// en un objeto
        /// Retorna true en caso de lograrlo o una excepción en caso
        /// contrario
        /// </summary>
        /// <param name="archivo">Es la ruta de dirección del archivo</param>
        /// <param name="datos">Es el objeto donde se guardarán los datos
        /// leídos</param>
        /// <returns></returns>
        public bool Leer(string archivo, out Jornada datos)
        {
            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(Jornada));
                StreamReader lector = new StreamReader(archivo);
                datos = (Jornada)serializador.Deserialize(lector);
            }
            catch (Exception excepcion)
            {
                throw new ArchivosException(excepcion);
            }
            return true;
        }
#endregion

    }
}
