using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

/// <summary>
/// Clase Universitario: 
///  Abstracta, con el atributo Legajo.
///  Método protegido y virtual MostrarDatos retornará todos los datos
/// del Universitario.
///  Método protegido y abstracto ParticiparEnClase.
///  Dos Universitario serán iguales si y sólo si son del mismo Tipo y 
/// su Legajo o DNI son iguales.
/// </summary>
namespace EntidadesAbstractas
{
    public abstract class Universitario:Persona
    {
    #region "Fields"
        private int _legajo;
        #endregion

    #region "Constructores"
        public Universitario():base()
        { }
        public Universitario(int legajo,string nombre,string apellido,string dni,ENacionalidad nacionalidad):base(nombre,apellido,dni,nacionalidad)
        {
            this._legajo = legajo;
        }
        #endregion

    #region "Methods"
        /// <summary>
        /// Método protegido y virtual que retorna todos los datos
        /// del universitario en un string.
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendLine("LEGAJO: " + this._legajo);
            return sb.ToString();
        }
        /// <summary>
        /// Método abstracto que se implementará en las clases
        /// derivadas.
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();// Sólo firma,implementa en clases hijas
        #endregion

    #region "Sobrecargas"
        /// <summary>
        /// Sobrecarga del método Equals() que compara si
        /// el objeto que invoca es del mismo tipo que el 
        /// objeto pasado por parámetro.Retorna true en 
        /// caso de ser iguales o false en caso contrario.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (this.GetType() == obj.GetType())
                return true;
            return false;
        }
        /// <summary>
        /// Sobrecarga del operador de igualdad que compara dos 
        /// Universitarios retornando true en caso de que ambos
        /// sean del mismo tipo y sus legajos ó dni sean iguales
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1,Universitario pg2)
        {
            if ((pg1.Equals(pg2)) && (pg1.DNI == pg2.DNI || pg1._legajo == pg2._legajo))
                return true;
            return false;
        }
        /// <summary>
        /// Sobrecarga del operador de desigualdad que compara dos 
        /// Universitarios retornando false en caso de que ambos
        /// sean del mismo tipo y sus legajos ó dni sean iguales.
        /// Reutiliza código del operador de igualdad
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1,Universitario pg2)
        {
            return (!(pg1 == pg2));
        }
        #endregion

    }
}
