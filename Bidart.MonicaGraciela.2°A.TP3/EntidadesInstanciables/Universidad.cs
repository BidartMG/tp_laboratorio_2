using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using System.IO;
using System.Xml.Serialization;

/// <summary>
/// Clase Universidad: 
///  Atributos Alumnos(lista de inscriptos), Profesores(lista de quienes
/// pueden dar clases) y Jornadas. 
///  Se accederá a una Jornada específica a través de un indexador.
///  Un Universidad será igual a un Alumno si el mismo está inscripto en él.
///  Un Universidad será igual a un Profesor si el mismo está dando clases
/// en él.
///  Al agregar una clase a un Universidad se deberá generar y agregar una
/// nueva Jornada indicando la clase, un Profesor que pueda darla (según su 
/// atributo ClasesDelDia) y la lista de alumnos que la toman(todos los que
/// coincidan en su campo ClaseQueToma). 
///  Se agregarán Alumnos y Profesores mediante el operador +, validando
/// que no estén previamente cargados.
///  La igualación entre un Universidad y una Clase retornará el primer 
/// Profesor capaz de dar esa clase. Sino, lanzará la Excepción SinProfesor
/// Exception. El distinto retornará el primer Profesor que no pueda dar la 
/// clase. 
///  MostrarDatos será privado y de clase. Los datos del Universidad se
/// harán públicos mediante ToString.
///  Guardar de clase serializará los datos del Universidad en un XML, 
/// incluyendo todos los datos de sus Profesores, Alumnos y Jornadas. 
///  Leer de clase retornará un Universidad con todos los datos previamente
/// serializados.
/// </summary>
namespace EntidadesInstanciables
{
    [Serializable]
    [XmlInclude(typeof(Jornada))]
    [XmlInclude(typeof(Profesor))]
    [XmlInclude(typeof(Alumno))]
    public class Universidad
    {
        public enum EClases
        { Laboratorio,Legislacion,Programacion,SPD}

        #region "Fields"
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region "Properties e Indexador"
        /// <summary>
        /// Propiedad de lectura y escritura asociada 
        /// al atributo de la clase "alumnos"
        /// </summary>
        public List<Alumno> Alumnos
        {
            get {return this.alumnos; }
            set {this.alumnos = value; }
        }
        /// <summary>
        /// Propiedad de lectura y escritura asociada 
        /// al atributo de la clase "jornada"
        /// </summary>
        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }
        /// <summary>
        /// Propiedad de lectura y escritura asociada 
        /// al atributo de la clase "profesores"
        /// </summary>
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }
        /// <summary>
        /// Indexador de lectura y escritura que 
        /// retorna un dato de tipo Jornada
        /// </summary>
        public Jornada this[int i]
        {
            get { return this.jornada[i]; }
            set { this.jornada[i] = value; }
        }
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor de instancia que inicializa
        /// las listas.
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion

        #region "Methods"
        /// <summary>
        /// Guardar de clase serializará los datos del Universidad 
        /// en un XML,incluyendo todos los datos de sus Profesores,
        /// Alumnos y Jornadas.
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad gim)
        {
            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(Universidad));
                StreamWriter escritor = new StreamWriter("Universidad.xml");
                serializador.Serialize(escritor, gim);
                escritor.Close();
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
            return true;
        }
        /// <summary>
        /// Método privado y de clase que retorna un string con 
        /// los datos de la Universidad,se harán públicos mediante 
        /// ToString().
        /// </summary>
        /// <param name="gim"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\nJORNADA: \n");
            foreach (Jornada item in gim.jornada)
            {
                sb.Append(item.ToString());
            }
            return sb.ToString();
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Sobrecarga del método ToString que hace
        /// públicos los datos de la Universidad,reutilizando
        /// código.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        /// <summary>
        /// Sobrecarga del operador de igualdad que evalúa: Una universidad
        /// es igual a un alumno si éste está inscripto en ella.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g,Alumno a)
        {
            foreach (Alumno item in g.alumnos)
            {
                if (item == a)// Ver si no comparo con equals
                    return true;
                break;
            }
            return false;
        }
        /// <summary>
        /// Sobrecarga del operador de desigualdad que evalúa: Una 
        /// universidad es diferente a un alumno si éste No está 
        /// inscripto en ella.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g,Alumno a)
        {
            return (!(g == a));
        }
        /// <summary>
        /// Sobrecarga del operador adición que agrega un alumno 
        /// a una Universidad validando que el alumno no esté
        /// previamente cargado. 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g,Alumno a)
        {
            if (g == a)
            {
                throw new AlumnoRepetidoException();
            }
            g.alumnos.Add(a);
            return g;
        }
        /// <summary>
        /// Sobrecarga del operador de igualdad: La igualación entre una
        /// Universidad y una Clase retornará el primer Profesor capaz de dar
        /// esa clase. Sino, lanzará la Excepción SinProfesorException.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad g,EClases clase)
        {
            foreach (Profesor item in g.profesores)
            {
                if (item == clase) // usa el == de profesor
                {
                    return item;
                }
            }
            // No encontró profesor,lanza excepción
            throw new SinProfesorException();
        }
        /// <summary>
        /// Sobrecarga del operador de desigualdad: retorna el primer
        /// Profesor que no pueda dar la clase. 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad g,EClases clase)
        {
            foreach (Profesor item in g.profesores)
            {
                if (item != clase)
                {
                    return item;
                }
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// Al agregar una clase a una Universidad se deberá generar y 
        /// agregar una nueva Jornada indicando la clase, un Profesor que 
        /// pueda darla (según su atributo ClasesDelDia) y la lista de
        /// alumnos que la toman (todos los que coincidan en su campo 
        /// ClaseQueToma). 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g,EClases clase)
        {
            // Busco un profesor que pueda dar la clase
            Profesor auxInstructor = (g == clase);

            // Genero una instancia de nueva jornada 
            Jornada nuevaJornada = new Jornada(clase, auxInstructor);

            // Recorro los alumnos buscando quienes toman la clase
            foreach (Alumno item in g.alumnos)
            {
                if (item == clase)// Comparo con el == de alumno
                {
                    // Si toma la clase = true lo agrego a la jornada
                    nuevaJornada += item;
                }
            }
            // Agrego a la universidad la jornada con los alumnos cargados
            g.jornada.Add(nuevaJornada);

            return g;
        }
        /// <summary>
        /// Sobrecarga del operador de igualdad que evalúa si una
        /// Universidad es igual a un Profesor,será true si el 
        /// profesor pasado por parámetro está dando clases en ella.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g,Profesor i)
        {
            foreach (Profesor item in g.Instructores)
            {
                if (item == i)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Sobrecarga del operador de desigualdad que evalúa si una
        /// Universidad es desigual a un Profesor,será true si el 
        /// profesor pasado por parámetro No está dando clases en ella.
        /// Reutiliza código.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g,Profesor i)
        {
            return (!(g == i));
        }
        /// <summary>
        /// Sobrecarga del operador adición que agrega un profesor
        /// a una Universidad validando que el profesor no esté
        /// previamente cargado. 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g,Profesor i)
        {
            if(g != i)
            {
                g.profesores.Add(i);
            }
            return g;
        }
        #endregion

    }
}
