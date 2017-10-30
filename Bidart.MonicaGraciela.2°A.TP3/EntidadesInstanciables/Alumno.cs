using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;

/// <summary>
/// Clase Alumno: 
///  Atributos ClaseQueToma del tipo EClase y EstadoCuenta del tipo 
/// EEstadoCuenta.
///  Sobreescribirá el método MostrarDatos con todos los datos del alumno.
///  ParticiparEnClase retornará la cadena "TOMA CLASE DE " junto al nombre
/// de la clase que toma.
///  ToString hará públicos los datos del Alumno.
///  Un Alumno será igual a un EClase si toma esa clase y su estado de 
/// cuenta no es Deudor.
///  Un Alumno será distinto a un EClase sólo si no toma esa clase.
/// </summary>
namespace EntidadesInstanciables
{
    public sealed class Alumno:Universitario
    {
    #region "Enumerados"
        public enum EEstadoCuenta
        { AlDia,Deudor,Becado}
#endregion

    #region "Fields"
        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;
        #endregion

    #region "Constructores"
        /// <summary>
        /// Constructor de instancia por default 
        /// de la clase Alumno.
        /// </summary>
        public Alumno():base()
        { }
        /// <summary>
        /// Sobrecarga parametrizada del constructor de instancia
        /// que inicializa los atributos con los datos recibidos,
        /// invocando al constructor base.
        /// por parámetro.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad,Universidad.EClases claseQueToma):base(id,nombre,apellido,dni,nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }
        /// <summary>
        /// Sobrecarga parametrizada del constructor de instancia,
        /// inicializa los atributos de la clase con los parámetros
        /// recibidos a través de invocar a la otra sobrecarga del
        /// constructor e inicializando el atributo estadoDeCuenta.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad,Universidad.EClases claseQueToma,EEstadoCuenta estadoCuenta):this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }
        #endregion

    #region "Sobrecargas"
        /// <summary>
        /// Sobrecarga del método MostrarDatos que retorna
        /// un string con todos los datos del alumno.Invoca
        /// al MostrarDatos de base.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.MostrarDatos());
            if (this._estadoCuenta == EEstadoCuenta.AlDia)
            { sb.AppendLine("ESTADO DE CUENTA: Cuota al dia "); }
            else
            { sb.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta); }
            sb.AppendLine(this.ParticiparEnClase());
            sb.AppendLine();//Espacio entre alumnos
            
            return sb.ToString();
        }
        /// <summary>
        /// Implementación del método de base abstracto
        /// ParticiparEnClase que retorna una string con
        /// la frase "Toma clase de: "y el nombre de la
        /// clase que toma.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return "Toma Clase de: " + this._claseQueToma;
        }
        /// <summary>
        /// Sobreescritura del método ToString() que hace 
        /// públicos los datos del Alumno.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        /// <summary>
        /// Sobrecarga del operador de igualdad que evalúa 
        /// si un alumno es igual a una clase,teniendo en 
        /// cuenta que la clase que toma sea igual a la clase
        /// pasada por parámetro y que el estado de cuenta no 
        /// sea deudor.En este caso retorna true y false en
        /// caso contrario.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a,Universidad.EClases clase)
        {
            if ((a._estadoCuenta != EEstadoCuenta.Deudor) && (a._claseQueToma == clase))
                return true;
            return false;
        }
        /// <summary>
        /// Sobrecarga del operador de desigualdad que compara
        /// que un alumno sea distinto a una clase.Reutiliza 
        /// sobrecarga de igualdad.Retornando true en caso de 
        /// ser distintos y false en caso contrario.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a,Universidad.EClases clase)
        {
            return (!(a == clase));
        }
        #endregion
    }
}
