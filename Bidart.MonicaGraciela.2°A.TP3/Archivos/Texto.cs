using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;


namespace Archivos
{
    public class Texto:IArchivo<string>
    {
    #region "Methods"
        /// <summary>
        /// Método que permite guardar en un archivo de texto.
        /// Retorna true en caso de que guarde bien y en caso
        /// contrario lanza ArchivosException.
        /// </summary>
        /// <param name="archivo">Es el path de donde guardar</param>
        /// <param name="datos">Son los datos a ser guardados</param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                StreamWriter escritor = new StreamWriter(archivo);
                escritor.WriteLine(datos);
                escritor.Close();
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            return true;
        }
        /// <summary>
        /// Método que permite leer desde un archivo de texto.
        /// Retorna true si logra hacerlo o una excepción en caso de error.
        /// </summary>
        /// <param name="archivo">Es la dirección(path) del archivo a leer</param>
        /// <param name="datos">Es la cadena que contendrá los datos leídos</param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            StringBuilder sb = new StringBuilder();
            string linea = "";
            try
            {
                StreamReader lector = new StreamReader(archivo);
                while(lector.EndOfStream == false)
                {
                    linea = lector.ReadLine();
                    sb.AppendLine(linea);
                }
                datos = sb.ToString();
                lector.Close();
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            return true;
        }
#endregion

    }
}
