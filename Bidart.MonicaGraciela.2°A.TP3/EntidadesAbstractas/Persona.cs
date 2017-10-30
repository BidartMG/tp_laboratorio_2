using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

/// <summary>
/// Clase Persona: 
///  Abstracta, con los atributos Nombre, Apellido, Nacionalidad y DNI.
///  Se deberá validar que el DNI sea correcto, teniendo en cuenta su 
/// nacionalidad.Argentino entre 1 y 89999999. Caso contrario, se lanzará
/// la excepción DniInvalidoException.
///  Sólo se realizarán las validaciones dentro de las propiedades.
///  Validará que los nombres sean cadenas con caracteres válidos para 
/// nombres.Caso contrario, no se cargará.
///  ToString retornará los datos de la Persona.
/// </summary>
namespace EntidadesAbstractas
{
    public abstract class Persona
    {
    #region "Enumerados"
        public enum ENacionalidad
        { Argentino,Extranjero}
#endregion

    #region "Fields"
        private string _nombre;
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        #endregion

    #region "Properties"
        /// <summary>
        /// Propiedad de lectura y escritura que valida
        /// el dato antes de asignarlo al atributo Nombre
        /// </summary>
        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = this.ValidarNombreApellido(value); }
        }
        /// <summary>
        /// Propiedad de lectura y escritura que valida
        /// el dato antes de asignarlo al atributo Apellido
        /// </summary>
        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = this.ValidarNombreApellido(value); }
        }
        /// <summary>
        /// Propiedad de lectura y escritura que valida y asigna
        /// el dato validado al atributo DNI
        /// </summary>
        public int DNI
        {
            get { return this._dni; }
            set { this._dni = this.ValidarDni(this.Nacionalidad, value); }
        }
        /// <summary>
        /// Propiedad de lectura y escritura asociadas al
        /// atributo de clase _nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }
        /// <summary>
        /// Propiedad de escritura que valida el dato
        /// a asignar al atributo dni.
        /// </summary>
        public string StringToDNI
        {
            set { this._dni = this.ValidarDni(this._nacionalidad, value); }
        }

        #endregion

    #region "Constructores"
        /// <summary>
        /// Constructor de clase por default
        /// </summary>
        public Persona()
        { }
        /// <summary>
        /// Sobrecarga parametrizada del constructor de instancia,inicializa
        /// los atributos de la clase con los parámetros recibidos.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre,string apellido,ENacionalidad nacionalidad):this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Sobrecarga parametrizada del constructor de instancia
        /// que invoca a la primer sobrecarga pasándole los datos
        /// necesarios e inicializando el atributo dni con el int
        /// recibido por parámetro,validándolo primero.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido,int dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }
        /// <summary>
        /// Sobrecarga parametrizada del constructor de instancia
        /// que invoca a la primer sobrecarga asignándole los datos
        /// necesarios e inicializando el atributo dni validando
        /// primero que sea un string con un valor válido.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido,string dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

    #region "Methods"
        /// <summary>
        /// Método que valida que el DNI sea correcto, teniendo en cuenta su 
        /// nacionalidad y el valor numérico recibido.En caso de error lanza
        /// la excepcion Nacionalidad invalida
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int dniValidado = -1;
            if ((nacionalidad == ENacionalidad.Argentino) && (dato > 0) && (dato <= 89999999))
            {
                dniValidado = dato;
            }
            else if ((nacionalidad == ENacionalidad.Extranjero) && (dato > 89999999) && (dato < 99999999))
            {
                dniValidado = dato;
            }
            // Sino si dato es mayor a 99.999.999 también valida el exceso de longitud del dato dni
            else if (dato < 1 || dato > 99999999)
            {
                throw new DniInvalidoException("DNI invalido.Fuera de rango");
            }
            else
            {
                throw new NacionalidadInvalidaException();
            }
            // Me aseguro de que no haya quedado en -1
            if(dniValidado == -1)
            {
                throw new DniInvalidoException();
            }
            return dniValidado;
        }
        /// <summary>
        /// Método que valida que el DNI sea correcto, verificando que el 
        /// string recibido sea un dato numérico valido.En caso de error
        /// lanza la excepcion Nacionalidad invalida.Reutiliza código.
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad,string dato)
        {
            int valor;
            try
            {
                // Parsea a int el string recibido
                valor = Int32.Parse(dato);
            }
            catch (SystemException e)
            {
                throw new DniInvalidoException(dato.ToString(), e);
            }
            // Retorna el dato valor validado a través de ValidarDni,si éste recibiera un
            // dato inválido la excepción se lanzaría en este método Por ejemplo 
            return this.ValidarDni(nacionalidad, valor);
        }
        /// <summary>
        /// Método que validará que los nombres sean cadenas con caracteres
        /// válidos para nombres. Caso contrario, no se cargará.
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            bool datoValido = true;
            foreach (char letra in dato)
            {
                if (!Char.IsLetter(letra))
                {
                    datoValido = false;
                    break;
                }
            }
            if (datoValido)
            {
                return dato;
            }
            // Si el dato no es valido retorna ""
            return "";
        }
        #endregion

    #region "Sobrecargas"
        /// <summary>
        /// Sobrecarga del método ToString que retorna los datos  
        /// de la Persona.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("NOMBRE COMPLETO: " + this.Apellido + " " + this.Nombre);
            sb.AppendLine("NACIONALIDAD: " + this.Nacionalidad);
            sb.AppendLine("DNI: " + this.DNI);
            return sb.ToString();
        }
        #endregion

    }
}
