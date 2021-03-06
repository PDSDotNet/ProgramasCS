using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonaProject;


namespace UnitTestProject1
{
    [TestClass]
    public class PersonaTest
    {
        /// <summary>
        /// Tests referentes al Nombre
        /// </summary>
        [TestMethod]
        public void DatoUnNombreValidoSeDebeCrearPersona()
        {
            var persona = new Persona( "Juanita", 11, "11-2222-3333");

            Assert.AreEqual("Juanita", persona.Nombre);
        }

        [TestMethod]
        public void DadoNombreNullPersonaDebeFallar()
        {
            Persona persona = new Persona();
            try
            {
                persona = new Persona( null, 11, "11-2222-3333");
                throw new Exception();
            }
            catch (PersonaNombreExeption)
            {
                //Assert.IsNull(persona.Nombre);
                Assert.AreEqual("No es un nombre valido", persona.Nombre);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void DadoNombreVacioPersonaDebeFallar()
        {
            Persona persona = new Persona();
            try
            {
                persona = new Persona("", 11, "11-2222-3333");
                throw new Exception();
            }
            catch (PersonaNombreExeption)
            {
                //Assert.IsNull(persona.Nombre);
                Assert.AreEqual("No es un nombre valido", persona.Nombre);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }



        /// <summary>
        /// Tests referentes al DNI
        /// </summary>
        [TestMethod]
        public void DadoDniValidoDebeCrearPersona()
        {
            var persona = new Persona("Juanita", 22333444, "11-2222-3333");

            Assert.AreEqual(22333444, persona.DNI);
        }

        [TestMethod]
        public void DadoDniCeroPersonaDebeFallar()
        {
            Persona persona = new Persona();

            try
            {
                persona = new Persona("Juanita", 0, "11-2222-3333");
                throw new Exception();
            }
            catch (PersonaDNIExeption)
            {
                Assert.AreEqual( -10000, persona.DNI);

            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }



        /// <summary>
        /// Tests referentes al Celular
        /// </summary>
        [TestMethod]
        public void DadoCelularVacioDebeCrearPersona()
        {
            /*
            Persona persona = new Persona("Juanita", 22365365, "");

            Assert.AreEqual("Juanita", persona.Nombre);
            Assert.AreEqual(22365365, persona.DNI);
            Assert.IsNull( persona.Celular);
            */

            Persona persona = new Persona();

            try
            {
                persona = new Persona("Juanita", 22333444, "");
                throw new Exception();
            }
            catch (PersonaCelularExeption)
            {
                Assert.AreEqual("Juanita", persona.Nombre);
                Assert.AreEqual(22365365, persona.DNI);
                Assert.AreEqual("No es un nombre valido", persona.Celular);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void DadoCelularCorrectoDebeCrearPersona()
        {
            Persona persona = new Persona("Juanita", 22365365, "11-2222-3333");

            Assert.AreEqual("Juanita", persona.Nombre);
            Assert.AreEqual(22365365, persona.DNI);
            Assert.AreEqual("11-2222-3333", persona.Celular);
        }

        [TestMethod]
        public void DadoCelular12CaracteresDebeAsignarCelularCorrectamente()
        {
            Persona persona = new Persona("Juanita", 22365365, "11-2222-3333");

            Assert.AreEqual(12, persona.Celular.Length);
        }

        [TestMethod]
        public void DadoCelularDistinto12CaracteresNoDebeAsignarCelular()
        {
            Persona persona = new Persona();

            try
            {
                persona = new Persona("Juanita", 22365365, "01122223333");
                throw new Exception();
            }
            catch (PersonaCelularExeption)
            {
                Assert.AreEqual("Juanita", persona.Nombre);
                Assert.AreEqual(22365365, persona.DNI);
                //Assert.AreNotEqual(12, persona.Celular.Length);
                Assert.IsNull(persona.Celular);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

    }
}
