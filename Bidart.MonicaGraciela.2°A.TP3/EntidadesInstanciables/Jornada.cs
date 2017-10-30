using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using System.IO;

/// <summary>
/// Clase Jornada: 
///  Atributos Profesor, Clase y Alumnos que toman dicha clase.
///  Se inicializará la lista de alumnos en el constructor por defecto.
///  Una Jornada será igual a un Alumno si el mismo participa de la clase.
///  Agregar Alumnos a la clase por medio del operador +, validando que no
/// estén previamente cargados.
///  ToString mostrará todos los datos de la Jornada.
///  Guardar de clase guardará los datos de la Jornada en un archivo de
/// texto.  
///  Leer de clase retornará los datos de la Jornada como texto.
/// </summary>
namespace EntidadesInstanciables
{
    public class Jornada
    {
    #region "Fields"
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;
        #endregion

    #region "Properties"
        /// <summary>
        /// Propiedad de lectura y escritura asociada
        /// al atributo alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }
        /// <summary>
        /// Propiedad de lectura y escritura asociada
        /// al atributo clases
        /// </summary>
        public Universidad.EClases Clases
        {
            get { return this._clase; }
            set { this._clase = value; }
        }
        /// <summary>
        /// Propiedad de lectura y escritura asociada
        /// al atributo profesores
        /// </summary>
        public Profesor Instructor
        {
            get { return this._instructor; }
            set { this._instructor = value; }
        }
        #endregion

    #region "Constructores"
        /// <summary>
        /// Constructor de instancia por default,privado 
        /// que inicializa la lista de alumnos.
        /// </summary>
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Constructor parametrizado de instancia que inicializa los 
        /// atributos de la clase con los parámetros recibidos.
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase,Profesor instructor):this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }
        #endregion

    #region "Methods"
        /// <summary>
        /// Método Guardar de clase guardará los datos de la
        /// Jornada en un archivo de texto. 
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            try
            {
                StreamWriter escritor = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Jornada.txt", false);
                escritor.WriteLine(jornada.ToString());
                escritor.Close();
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return true;
        }
        /// <summary>
        /// Método Leer de clase retornará los datos de la 
        /// Jornada como texto.
        /// </summary>
        /// <returns></returns>
        public string Leer()
        {
            StringBuilder sb = new StringBuilder();
            string linea;
            try
            {
                StreamReader lector = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\Jornada.txt");
                while (lector.EndOfStream == false)
                {
                    linea = lector.ReadLine();
                    sb.AppendLine(linea);
                }
                lector.Close();
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return sb.ToString();
        }
        #endregion

    #region "Sobrecargas"
        /// <summary>
        /// Sobrecarga del método ToString que retorna un string
        /// con todos los datos de la jornada
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine("JORNADA:");
            sb.AppendFormat("\nCLASE DE: {0} {1}", this._clase, this._instructor.ToString());
            sb.AppendLine("ALUMNOS: \n");
            foreach (Alumno item in this.Alumnos)
            {
                sb.Append(item.ToString());
            }
            sb.AppendLine("<---------------------------------------------->");
            return sb.ToString();
        }
        /// <summary>
        /// Sobrecarga del operador de igualdad que compara una
        /// Jornada con un alumno retornando true en caso de que
        /// el alumno pertenezca a la jornada o false en caso 
        /// contrario.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j,Alumno a)
        {
            foreach (Alumno item in j._alumnos)
            {
                if (item == a)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Sobrecarga del operador de desigualdad que compara
        /// si un alumno pertenece a una jornada.Retorna true 
        /// en caso de No pertenecer a la misma y false en caso
        /// contrario.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j,Alumno a)
        {
            return (!(j == a));
        }
        /// <summary>
        /// Sobrecarga del operador adición que agrega un alumno
        /// a la jornada si éste no se encuentra ya en la lista.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j,Alumno a)
        {
            if (j == a)
            {
                throw new AlumnoRepetidoException();
            }
            j._alumnos.Add(a);
            return j;
        }
        #endregion

    }
}
