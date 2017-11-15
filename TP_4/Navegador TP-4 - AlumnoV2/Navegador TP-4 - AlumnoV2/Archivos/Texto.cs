using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;


namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        #region "Fields"
        private string _archivo;
        #endregion

#region "Constructors"
        /// <summary>
        /// Constructor de instancia que inicializa el atributo 
        /// ùnico de la Clase
        /// </summary>
        /// <param name="archivo"></param>
        public Texto(string archivo)
        {
            this._archivo = archivo;
        }
        #endregion

        #region "Methods"
        /// <summary>
        /// Mètodo que permite guardar en un archivo de Texto.Retorna true en caso
        /// de lograrlo y en caso contrario lanza ArchivosException
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool guardar(string datos)
        {
            try
            {
                StreamWriter escritor = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + this._archivo, true);
                escritor.WriteLine(datos.ToString());
                escritor.Close();
            }
            catch(Exception )
            {
                //throw new ArchivosException(e);// VERIFICAR QUE LO LANCE Y CAPTURE BIEN
            }
            return true;
        }

        public bool leer(out List<string> datos)
        {
            // Instancio la lista para el out
            datos = new List<string>();
            try
            {
                StreamReader lector = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + this._archivo);
                while(lector.EndOfStream == false)
                {
                    datos.Add(lector.ReadLine());
                }
                lector.Close();
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
                //Console.WriteLine(e.Message);
                //datos = default(List<string>);
                //return false;
            }

            return true;
        }
        #endregion
    }
}
