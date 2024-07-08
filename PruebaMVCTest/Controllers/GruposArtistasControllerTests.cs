using Microsoft.Extensions.Configuration;
using PruebaMVC.Models;
using PruebaMVC.Services.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace PruebaMVC.Controllers.Tests
{
    [TestClass()]

    public class GruposArtistasControllerTests

    {
        private readonly GrupoCContext contexto = new(InitConfiguration());
        private readonly GruposArtistasController controlador = new(new EFGenericRepositorio<GruposArtista>(InitConfiguration()),
            new EFGenericRepositorio<Artista>(InitConfiguration()),
            new EFGenericRepositorio<Grupo>(InitConfiguration()));
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
            var resultado = await controlador.Index("") as ViewResult;
            Assert.IsNotNull(resultado);
            Assert.IsNull(resultado.ViewName);
            Assert.IsNotNull(resultado.ViewData.Model);
            Assert.AreEqual(5,contexto.GruposArtistas.Count());
            Assert.IsNotNull(contexto);
        }

        [TestMethod()]
        public async Task BDetailsTest()
        {
            var resultado = await controlador.Details(1) as ViewResult;
            Assert.IsNotNull(resultado);
            Assert.IsNull(resultado.ViewName);
            Assert.IsNotNull(resultado.ViewData.Model);
            var grupoArtista = resultado.ViewData.Model as GruposArtista;

            Assert.IsNotNull(grupoArtista);
            Assert.AreEqual(1, grupoArtista.ArtistasId);

        }

        [TestMethod()]
        public async Task CCreateTest()
        {
            var resultado = await  controlador.Create() as ViewResult;
            Assert.IsNotNull(resultado);
            
            var nuevoGrupoaArtista = new GruposArtista
            {
                GruposId = 2,
                ArtistasId = 3
            };
            Assert.IsNotNull(nuevoGrupoaArtista);
            await controlador.Create(nuevoGrupoaArtista);

            var artistaGrupoNuevo = contexto.GruposArtistas.FirstOrDefault(x => x.GruposId == 2 && x.ArtistasId == 3);
            Assert.IsNotNull(artistaGrupoNuevo);

            Assert.AreEqual(3, artistaGrupoNuevo.ArtistasId);
        }

        [TestMethod()]
        public async Task DEditTest()
        {
            int id = 3;
            
            GruposArtista GrupoArtistaAModificar = new GruposArtista() { ArtistasId = 3, GruposId = 3, Id = id };

            await controlador.Edit(id, GrupoArtistaAModificar);

            var resultado = await controlador.Details(3) as ViewResult;
            GruposArtista ARecuperar = resultado.ViewData.Model as GruposArtista;

            Assert.IsNotNull(ARecuperar);

            Assert.AreEqual(3,ARecuperar.ArtistasId);
            Assert.AreEqual(3, ARecuperar.GruposId);
         


        }
        [TestMethod()]
        public async Task EDeleteTestVista()
        {
            
            var grupoArtistaVistaEliminar = await contexto.GruposArtistas.FirstOrDefaultAsync(x => x.GruposId == 2 && x.ArtistasId == 3);
            var resultado = await controlador.Delete(grupoArtistaVistaEliminar.Id) as ViewResult;
            Assert.IsNotNull(resultado);
            Assert.IsNull(resultado.ViewName);
            Assert.IsNotNull(resultado.ViewData.Model);
            var grupoArtista = resultado.ViewData.Model as GruposArtista;
            Assert.IsNotNull(grupoArtista);
            Assert.AreEqual(2, grupoArtista.GruposId);
            Assert.AreEqual(3, grupoArtista.ArtistasId);
        }
        [TestMethod()]
        public async Task FDeleteDefinitivoTest()
        {
            var grupoArtistaEliminar = await contexto.GruposArtistas.FirstOrDefaultAsync(x => x.GruposId == 2 && x.ArtistasId == 3);
            Assert.IsNotNull(grupoArtistaEliminar);
            await controlador.DeleteConfirmed(grupoArtistaEliminar.Id);
            var artistaGrupoEliminado = await contexto.GruposArtistas.FirstOrDefaultAsync(x => x.Id == grupoArtistaEliminar.Id);
            Assert.IsNull(artistaGrupoEliminado);
        }
        [TestMethod()]
        public async Task ExisteTest()
        {
            var resultado = await controlador.GruposArtistaExists(5);
            Assert.IsTrue(resultado);

            var resultado1 = await controlador.GruposArtistaExists(96);
            Assert.IsFalse(resultado1);

        }

    }
}