using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Archivos;

namespace UnitTestExcepciones
{
    [TestClass]
    public class UnitTestExcepciones
    {
        /// <summary>
        /// Testea que el dni recibido esté dentro del rango
        /// de los valores para un dni argentino.
        /// </summary>
        [TestMethod]
        public void DniArgentinoTest()
        {
            try
            {
                Alumno alumno1 = new Alumno(1, "Nicolas", "Tatavini", "38123456", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio,Alumno.EEstadoCuenta.AlDia);
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }

        /// <summary>
        /// Testea que haya un profesor disponible para la clase indicada.
        /// </summary>
        [TestMethod]
        public void ProfesorDisponibleTest()
        {
            Universidad miUniversidad = new Universidad();
            try
            {
                miUniversidad += Universidad.EClases.Programacion;
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(SinProfesorException));
            }
        }
    }
}
