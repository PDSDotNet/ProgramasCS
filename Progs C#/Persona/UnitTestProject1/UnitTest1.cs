using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonaProject;


namespace UnitTestProject1
{
    [TestClass]
    public class PersonaTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var persona = new Persona( "Juanita", 11);

            Assert.AreEqual("Juanita", persona.Nombre);
        }

        [TestMethod]
        public void DadoNombreNullPersonaDebeFallar()
        {
            Persona persona = new Persona();
            try
            {
                persona = new Persona("No es un nombre valido", 11);
                throw new Exception();
            }
            catch (PersonaNombreExeption)
            {
                Assert.IsNull(persona.Nombre);
                
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
                persona = new Persona("No es un nombre valido", 11);
                throw new Exception();
            }
            catch (PersonaNombreExeption)
            {
                Assert.IsNull(persona.Nombre);

            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void xxxxxxxxxxxxxx()
        {
            Persona persona = new Persona();

            try
            {
                persona = new Persona("Juanita", 0);
                throw new Exception();
            }
            catch (PersonaDNIExeption)
            {
                Assert.AreEqual(-10000, persona.DNI);

            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }


        [TestMethod]
        public void DadoCelularVacioDebeCrearPersona()
        {
            Persona persona = new Persona("Juanita", 22365365, "");

            try
            {
                persona = new Persona("Juanita", 0);
                throw new Exception();
            }
            catch (PersonaDNIExeption)
            {
                Assert.AreEqual(-10000, persona.DNI);

            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }


        [TestMethod]
        public void DadoCelular12Caracteres_DebeAsignarCelularCorrectamente()
        {
            Persona persona = new Persona("Juanita", 22365365, "");

            Assert.AreEqual(12, persona.Celular.Length);
        }


        [TestMethod]
        public void DadoCelular11Caracteres_DebeAsignarCelularCorrectamente()
        {
            Persona persona = new Persona("Juanita", 22365365, "");

            Assert.AreEqual(12, persona.Celular.Length);
        }
    }
}
