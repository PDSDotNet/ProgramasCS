using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonaProject;


namespace UnitTestProject1
{

    [TestClass]
    public class PersonaTest
    {
        [TestMethod]
        public void ConstructorPorDefectoNoAsignaValor()
        {
            var persona = new Persona();

            Assert.IsNull(persona.Nombre);
            Assert.IsNull(persona.Apellido);
            Assert.AreEqual(0, persona.DNI);
            Assert.IsNull(persona.Celular);
        }

        /// <summary>
        /// Tests referentes al Nombre
        /// </summary>
        [TestMethod]
        public void DatoUnNombreValidoSeDebeCrearPersona()
        {
            var persona = new Persona( "Juanita", "Lamarca", 11, "11-2222-3333");

            Assert.AreEqual("Juanita", persona.Nombre);
        }

        [TestMethod]
        public void DadoNombreNullPersonaDebeFallar()
        {
            Persona persona = new Persona( true);
            try
            {
                persona = new Persona( null, "Lamarca", 11, "11-2222-3333");
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
            Persona persona = new Persona( true);
            try
            {
                persona = new Persona("", "Lamarca", 11, "11-2222-3333");
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
        /// Tests referentes al Apellido
        /// </summary>
        [TestMethod]
        public void DatoUnApellidoValidoSeDebeCrearPersona()
        {
            var persona = new Persona("Juanita", "Lamarca", 11, "11-2222-3333");

            Assert.AreEqual("Lamarca", persona.Apellido);
        }

        
        [TestMethod]
        public void DadoApellidoNullPersonaDebeFallar()
        {
            Persona persona = new Persona(true);
            try
            {
                persona = new Persona("Juanita", null, 11, "11-2222-3333");
                throw new Exception();
            }
            catch (PersonaApellidoExeption)
            {
                //Assert.IsNull(persona.Nombre);
                Assert.AreEqual("No es un apellido valido", persona.Apellido);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }


        [TestMethod]
        public void DadoApellidoVacioPersonaDebeFallar()
        {
            Persona persona = new Persona(true);
            try
            {
                persona = new Persona("Juanita", "", 11, "11-2222-3333");
                throw new Exception();
            }
            catch (PersonaApellidoExeption)
            {
                //Assert.IsNull(persona.Nombre);
                Assert.AreEqual("No es un apellido valido", persona.Apellido);
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
            var persona = new Persona("Juanita", "Lamarca", 22333444, "11-2222-3333");

            Assert.AreEqual(22333444, persona.DNI);
        }

        [TestMethod]
        public void DadoDniCeroPersonaDebeFallar()
        {
            Persona persona = new Persona( true);

            try
            {
                persona = new Persona("Juanita", "Lamarca", 0, "11-2222-3333");
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
        public void DadoCelularCorrectoDebeCrearPersonaYAsignarCelular()
        {
            Persona persona = new Persona("Juanita", "Lamarca", 22365365, "11-2222-3333");

            Assert.AreEqual("Juanita", persona.Nombre);
            Assert.AreEqual(22365365, persona.DNI);
            Assert.AreEqual("11-2222-3333", persona.Celular);
        }

        [TestMethod]
        public void DadoCelularVacioDebeCrearPersonaYNoAsignarCelular()
        {
            
            Persona persona = new Persona("Juanita", "Lamarca", 22365365, "");

            Assert.AreEqual("Juanita", persona.Nombre);
            Assert.AreEqual(22365365, persona.DNI);
            Assert.IsNull(persona.Celular);
            

            /*
            Persona persona = new Persona( true);

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
            */
        }

        [TestMethod]
        public void DadoCelularNullDebeCrearPersonaYNoAsignarCelular()
        {

            Persona persona = new Persona("Juanita", "Lamarca", 22365365, null);

            Assert.AreEqual("Juanita", persona.Nombre);
            Assert.AreEqual(22365365, persona.DNI);
            Assert.IsNull(persona.Celular);
        }

        [TestMethod]
        public void DadoCelularDistinto12CaracteresDebeCrearPersonaYNoDebeAsignarCelular()
        {
            Persona persona = new Persona(true);
            persona = new Persona("Juanita", "Lamarca", 22365365, "01122223333");

            Assert.AreEqual("Juanita", persona.Nombre);
            Assert.AreEqual(22365365, persona.DNI);
            //Assert.AreNotEqual(12, persona.Celular.Length);
            //Assert.AreEqual("No es un celular valido", persona.Celular);
            Assert.IsNull(persona.Celular);
        }

        [TestMethod]
        public void DadoCelular12CaracteresFueraDeNormaDebeCrearPersonaYNoDebeAsignarCelular()
        {
            Persona persona = new Persona(true);
            persona = new Persona("Juanita", "Lamarca", 22365365, "001122223333");

            Assert.AreEqual("Juanita", persona.Nombre);
            Assert.AreEqual(22365365, persona.DNI);
            //Assert.AreNotEqual(12, persona.Celular.Length);
            //Assert.AreEqual("No es un celular valido", persona.Celular);
            Assert.IsNull(persona.Celular);
        }
    }
}
