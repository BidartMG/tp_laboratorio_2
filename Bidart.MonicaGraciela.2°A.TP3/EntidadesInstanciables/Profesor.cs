using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;

/// <summary>
/// Clase Profesor: 
///  Atributos ClasesDelDia del tipo Cola y random del tipo Random y 
/// estático.
///  Sobrescribir el método MostrarDatos con todos los datos del profesor.
///  ParticiparEnClase retornará la cadena "CLASES DEL DÍA " junto al 
/// nombre de la clases que da.
///  ToString hará públicos los datos del Profesor.
///  Se inicializará a Random sólo en un constructor.
///  En el constructor de instancia se inicializará ClasesDelDia y se
/// asignarán dos clases al azar al Profesor mediante el método randomClases.
/// Las dos clases pueden o no ser la misma.
///  Un Profesor será igual a un EClase si da esa clase.
/// </summary>
namespace EntidadesInstanciables
{
    public class Profesor:Universitario
    {
    #region "Fields"
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;
        #endregion

    #region "Constructores"
        /// <summary>
        /// Constructor estático que inicializa el
        /// atributo _random 
        /// </summary>
        static Profesor()
        {
            Profesor._random = new Random();
        }
        /// <summary>
        /// Constructor de instancia de la clase
        /// Profesor.
        /// </summary>
        public Profesor()
        { }
        /// <summary>
        /// Sobrecarga parametrizada del constructor que inicializa
        /// la Cola con dos clases aleatorias que pueden ser iguales
        /// o no.Invoca al constructor base y asigna los parámetros
        /// recibidos.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad):base(id,nombre,apellido,dni,nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._ramdomClases();
            this._ramdomClases();
        }
        #endregion

    #region "Methods"
        /// <summary>
        /// Método que inicializa una clase a
        /// través de un valor Random.Las dos clases 
        /// pueden o no ser la misma.
        /// </summary>
        private void _ramdomClases()
        {
            this._clasesDelDia.Enqueue((Universidad.EClases)_random.Next(0, 4));
        }
        #endregion

    #region "Sobrecargas"
        /// <summary>
        /// Sobrecarga del método MostrarDatos que
        /// retorna todos los datos del profesor,
        /// utilizando el MostrarDatos de base.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            sb.AppendLine(ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// Implementación del método abstracto de base
        /// ParticiparEnClase que retorna la cadena "CLASES DEL DÍA " 
        /// junto al nombre de la clases que da.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA: ");
            foreach (Universidad.EClases item in this._clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// Sobreescritura del método ToString que hace 
        /// públicos los datos del Profesor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Sobrecarga del operador de igualdad que evalúa si
        /// un Profesor será igual a una EClase buscando si da
        /// esa clase.Retorna true en caso de que la dé y false
        /// en caso contrario
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i,Universidad.EClases clase)
        {
            foreach (Universidad.EClases item in i._clasesDelDia)
            {
                if (item == clase)
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Sobrecarga del operador de desigualdad que evalúa si
        /// un Profesor es diferente a una EClase a través de
        /// reutilizar la sobrecarga del operador de igualdad.
        /// Retorna true en caso de que el profesor no dé la clase
        /// y false en caso contrario
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i,Universidad.EClases clase)
        {
            return (!(i == clase));
        }
        #endregion

    }
}
