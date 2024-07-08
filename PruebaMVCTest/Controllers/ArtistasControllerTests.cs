using Microsoft.Extensions.Configuration;
using PruebaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using PruebaMVC.Services.Repositorio;
using Microsoft.EntityFrameworkCore;
using PruebaMVC.Controllers;

namespace PruebaMVC.Controllers.Tests
{
    [TestClass()]
    public class ArtistasControllerTests

    {
        private readonly GrupoCContext contexto = new(InitConfiguration());
        private readonly ArtistasController _controlador= new(new EFGenericRepositorio<Artista>(InitConfiguration()));
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Test.json")
                .AddEnvironmentVariables()
                .Build();
            return config;
        }

        [TestMethod()]
        public async Task AIndexTest()
        {
            var resultado = await _controlador.Index("", "") as ViewResult;
            Assert.IsNotNull(resultado);
            Assert.IsNull(resultado.ViewName);
            Assert.IsNotNull(resultado.ViewData.Model);
            Assert.AreEqual(contexto.Artistas.Count(), 5);
            Assert.IsNotNull(contexto);
        }

        [TestMethod()]
        public async Task BDetailsTest()
        {
            var resultado = await _controlador.Details(5) as ViewResult;
            Assert.IsNotNull(resultado);
            Assert.IsNull(resultado.ViewName);
            Assert.IsNotNull(resultado.ViewData.Model);
            var artista = resultado.ViewData.Model as Artista;
            Assert.IsNotNull(artista);
            Assert.AreEqual("Artista5", artista.Nombre);

            Assert.AreEqual(contexto.Artistas.Count(), 5);
            Assert.IsNotNull(contexto);
        }

       
        [TestMethod()]
        public  void CCreateTest()
        {
            var resultado =  _controlador.Create() as ViewResult;
            Assert.IsNotNull(resultado);

            var artista = new Artista
            {
                Nombre="Artista6",
                Genero = "Rock",
                FechaNac = DateOnly.Parse("1975/10/02"),
                Foto=null
            };

            _controlador.Create(artista,null);

           var nuevoArtista = contexto.Artistas.FirstOrDefault(x => x.Nombre == "Artista6");
           Assert.IsNotNull(nuevoArtista);
            
            Assert.AreEqual("Artista6", nuevoArtista.Nombre);
            Assert.AreEqual("Rock", nuevoArtista.Genero);
            Assert.AreEqual(DateOnly.Parse("1975/10/02"), nuevoArtista.FechaNac);
            Assert.AreEqual(null, nuevoArtista.Foto);

        }

        [TestMethod()]
        public async Task DEditTest()
        {
            var resultado = await _controlador.Edit(3) as ViewResult;
            Assert.IsNotNull(resultado);
            Assert.IsNull(resultado.ViewName);
            Assert.IsNotNull(resultado.ViewData.Model);
            var artista = resultado.ViewData.Model as Artista;
            Assert.IsNotNull(artista);
            Assert.AreEqual("Artista3", artista.Nombre);

            artista.Nombre = "Artista 3 Modificado";
            await _controlador.Edit(3, artista, null);
            var artistaMod = contexto.Artistas.FirstOrDefault(x => x.Nombre == "Artista 3 Modificado");
            Assert.IsNotNull(artistaMod);

        }
        [TestMethod()]
        public async Task EEditTestVolver()
        {
            var resultado = await _controlador.Details(3) as ViewResult;
            var artista = contexto.Artistas.FirstOrDefault(x => x.Nombre == "Artista 3 Modificado");
            Assert.IsNotNull(artista);
            Assert.AreEqual("Artista 3 Modificado", artista.Nombre);

            artista.Nombre = "Artista3";
            await _controlador.Edit(3, artista, null);
            var artistaVolver = contexto.Artistas.FirstOrDefault(x => x.Nombre == "Artista3");
            Assert.IsNotNull(artistaVolver);
        }

        [TestMethod()]
        public async Task FDeleteTest()
        {

            var ArtistaEliminar = await contexto.Artistas.FirstOrDefaultAsync(x => x.Nombre == "Artista6");
            var resultado = await _controlador.Delete(ArtistaEliminar.Id) as ViewResult;
            Assert.IsNotNull(resultado);
            Assert.IsNull(resultado.ViewName);
            Assert.IsNotNull(resultado.ViewData.Model);
            var artista = resultado.ViewData.Model as Artista;
            Assert.IsNotNull(artista);
            Assert.AreEqual("Artista6", artista.Nombre);
            
            var artistaXEliminar = contexto.Artistas.FirstOrDefault(x => x.Nombre == "Artista6");
            Assert.IsNotNull(artistaXEliminar);

            await _controlador.DeleteConfirmed(ArtistaEliminar.Id);

            var artistaEliminado = contexto.Artistas.FirstOrDefault(x => x.Id == artistaXEliminar.Id);
            Assert.IsNull(artistaEliminado);

        }

        [TestMethod()]
        public async Task ExisteTest()
        {
            var resultado = await _controlador.ArtistaExists(5);
            Assert.IsTrue(resultado);

            var resultado1 = await _controlador.ArtistaExists(96);
            Assert.IsFalse(resultado1);

        }

    }
}