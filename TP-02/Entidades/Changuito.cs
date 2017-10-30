using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    /// <summary>
    /// Clase que no podrá tener clases heredadas,
    /// agrego modificador sealed.
    /// </summary>
    public sealed class Changuito
    {
    #region "Fields"

        List<Producto> _productos;
        int _espacioDisponible;

        #endregion

    #region "Enumerados"

        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }

#endregion

    #region "Constructores"

        /// <summary>
        /// Constructor por defecto que inicializa la por única y primera vez la lista de Productos
        /// </summary>
        private Changuito()
        {
            this._productos = new List<Producto>();
        }

        /// <summary>
        /// Sobrecarga de constructor que recibe un valor para inicializar el atributo _espacioDisponible
        /// invoca al constructor por defecto
        /// </summary>
        /// <param name="espacioDisponible"> Es el valor a asignar </param>
        public Changuito(int espacioDisponible):this()
        {
            this._espacioDisponible = espacioDisponible;
        }

        #endregion

    #region "Sobrecargas"

        /// <summary>
        /// Muestro el objeto de tipo Changuito y TODOS los Productos que contiene
        /// </summary>
        /// <returns> Una cadena con los datos leídos </returns>
        public override string ToString()
        {
            return this.Mostrar(this, ETipo.Todos);
        }
        
        #endregion

    #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns> Una cadena con los valores recibidos </returns>
        public string Mostrar(Changuito c, ETipo tipo) //quitar static
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c._productos.Count, c._espacioDisponible);
            sb.AppendLine("");
            foreach (Producto v in c._productos)
            {
                switch (tipo)
                {
                    case ETipo.Snacks:
                        if(v is Snacks)
                        {
                            sb.AppendLine(v.Mostrar());
                        }                        
                        break;
                    case ETipo.Dulce:
                        if(v is Dulce)
                        {
                            sb.AppendLine(v.Mostrar());
                        }                        
                        break;
                    case ETipo.Leche:
                        if(v is Leche)
                        {
                            sb.AppendLine(v.Mostrar());
                        }                        
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }

            return sb.ToString();
        }

        #endregion

    #region "Operadores"

        /// <summary>
        /// Sobrecarga del operador suma que: Agregará un elemento a la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns> El objeto que recibió con el elemento agregado si no existía en la lista </returns>
        public static Changuito operator +(Changuito c, Producto p)
        {
            foreach (Producto v in (c._productos))
            {
                if (v == p)
                {
                    return c;
                }                
            }
            if (c._espacioDisponible > c._productos.Count)
            {
                (c._productos).Add(p);
            }
            return c;
        }

        /// <summary>
        /// Sobrecarga del operador resta que: Quitará un elemento de la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns> El objeto recibido sin el elemento pasado por parámetro para eliminar </returns>
        public static Changuito operator -(Changuito c, Producto p)
        {
            foreach (Producto v in c._productos)
            {
                if (v == p)
                {
                    (c._productos).Remove(v); // Lo encuentra, lo remueve y rompe el foreach
                    break;
                }
            }

            return c;
        }

        #endregion
    }
}
