using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;
using Archivos;

namespace UnitTestExcepciones
{
    [TestClass]
    public class UnitTestMetodos
    {           
        /// <summary>
        /// Testea que las listas del objeto Universidad
        /// estén inicializadas correctamente.
        /// </summary>
        [TestMethod]
        public void IniciarListasTest()
        {
            Universidad miUniversidad = new Universidad();
            Assert.IsNotNull(miUniversidad.Alumnos);
            Assert.IsNotNull(miUniversidad.Jornadas);
            Assert.IsNotNull(miUniversidad.Instructores);
        }
    }
}
