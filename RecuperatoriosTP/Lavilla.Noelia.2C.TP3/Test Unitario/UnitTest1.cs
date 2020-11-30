using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using Clases_Instanciables;
using Excepciones;

namespace Test_Unitario
{
    [TestClass]
    public class Excepciones

    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestDniInvalidoException()
        {
            Profesor dniInvalido = new Profesor(43, "Juan", "Lopez", "sadas46", Persona.ENacionalidad.Argentino);
        }

    }
}
