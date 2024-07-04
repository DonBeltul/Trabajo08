using Microsoft.Extensions.Configuration;
using PruebaMVC.Models;
using PruebaMVC.Services.Repositorio;

namespace PruebaMVCTest.Services.Repositorio
{
    [TestClass]
    public class FakeRepositorioTest
    {
        private readonly FakeRepositorio repositorio = new();

        [TestMethod]
        public void DameTodosTest()
        {
            var should = repositorio.DameTodos();
            var expected = new List<Concierto>()
            {
                new Concierto() { Titulo = "FakeTitulo1", Precio = 13, Lugar = "Dinamarca", Fecha = new DateTime(2001, 2, 12, 12, 12, 00), Id = 1, Genero = "Funk"},
                new Concierto() { Titulo = "FakeTitulo2", Precio = 100, Lugar = "Albacete", Fecha = new DateTime(2001, 4, 12, 12, 12, 00), Id = 2, Genero = "Metal" },
                new Concierto() { Titulo = "FakeTitulo3", Precio = 200, Lugar = "Finlandia", Fecha = new DateTime(2001, 11, 12, 12, 12, 00), Id = 3, Genero = "Heavy Metal" },
                new Concierto() { Titulo = "FakeTitulo4", Precio = 50, Lugar = "Asturias", Fecha = new DateTime(2022, 9, 12, 12, 12, 00), Id = 4, Genero = "Rock" },
                new Concierto() { Titulo = "FakeTitulo5", Precio = 12, Lugar = "Suecia", Fecha = new DateTime(2003, 1, 12, 23, 12, 00), Id = 5, Genero = "Jamaicano" }
            };
            Assert.IsNotNull(should);
            Assert.AreEqual(expected.Count(), should.Count());
        }
        [TestMethod]
        public void DameUnoTest()
        {
            var should = repositorio.DameUno(1);
            var expected = new Concierto() { Titulo = "FakeTitulo1", Precio = 13, Lugar = "Dinamarca", Fecha = new DateTime(2001, 2, 12, 12, 12, 00), Id = 1, Genero = "Funk" };

            Assert.IsNotNull(should);
            Assert.AreEqual(expected.Id, should.Id);
        }

        [TestMethod]
        public void AgregarModificarYBorrarTest()
        {
            //Agregar
            Concierto concierto = new Concierto() { Titulo = "FakeTitulo1", Precio = 13, Lugar = "Dinamarca", Fecha = new DateTime(2001, 2, 12, 12, 12, 00), Id = 1, Genero = "Funk" };
            repositorio.Agregar(concierto);
            

            //Modificar
            concierto.Titulo = "PruebaMod";
            repositorio.Modificar(concierto.Id, concierto);

            //Borrar
            repositorio.Borrar(concierto.Id);

        }
    }
}
