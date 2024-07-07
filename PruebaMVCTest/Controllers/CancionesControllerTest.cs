using PruebaMVC.Models;
using PruebaMVC.Services.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.Ini;
using PruebaMVC.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;
using DateOnly = System.DateOnly;

namespace PruebaMVCTest.Controllers
{
    [TestClass]
    public class CancionesControllerTest
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .AddEnvironmentVariables()
                .Build();
            return config;
        }
        private CancionesController controlador = new CancionesController(new EFGenericRepositorio<Cancione>(InitConfiguration()),
            new EFGenericRepositorio<Albume>(InitConfiguration()), new EFGenericRepositorio<VistaCancione>(InitConfiguration()));
        public EFGenericRepositorio<Cancione> contexto = new EFGenericRepositorio<Cancione>(InitConfiguration());
        [TestMethod()]
        public void IndexTest()
        {
            var result = controlador.Index("", null).Result as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNull(result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);
            var listaCancione = result.ViewData.Model as IEnumerable<VistaCancione>;
            Assert.IsNotNull(listaCancione);
            Assert.AreEqual(6, listaCancione.Count());

            var resultadoDesc = controlador.Index("titulo_desc", "").Result as ViewResult;
            Assert.AreEqual("You and me", (resultadoDesc.Model as IEnumerable<VistaCancione>).ElementAt(0).Titulo);
            Assert.AreEqual("Trois", (resultadoDesc.Model as IEnumerable<VistaCancione>).ElementAt(1).Titulo);
            Assert.AreEqual("Take Over", (resultadoDesc.Model as IEnumerable<VistaCancione>).ElementAt(2).Titulo);
            Assert.IsInstanceOfType(resultadoDesc.Model as IEnumerable<VistaCancione>, typeof(IEnumerable<VistaCancione>));
            Assert.IsNotNull(resultadoDesc.Model as IEnumerable<VistaCancione>);
            Assert.AreEqual(6, (resultadoDesc.Model as IEnumerable<VistaCancione>).Count());

            var resultadoGenero =  controlador.Index("Genero", "").Result as ViewResult;
            Assert.AreEqual("Funk", (resultadoGenero.Model as IEnumerable<VistaCancione>).ElementAt(0).Genero);
            Assert.AreEqual("GeneroPrueba", (resultadoGenero.Model as IEnumerable<VistaCancione>).ElementAt(1).Genero);
            Assert.AreEqual("Jazz", (resultadoGenero.Model as IEnumerable<VistaCancione>).ElementAt(2).Genero);
            Assert.IsInstanceOfType(resultadoGenero.Model as IEnumerable<VistaCancione>, typeof(IEnumerable<VistaCancione>));
            Assert.IsNotNull(resultadoGenero.Model as IEnumerable<VistaCancione>);
            Assert.AreEqual(6, (resultadoGenero.Model as IEnumerable<VistaCancione>).Count());

            var resultadoGeneroDesc = controlador.Index("genero_desc", "").Result as ViewResult;
            Assert.AreEqual("Rock", (resultadoGeneroDesc.Model as IEnumerable<VistaCancione>).ElementAt(0).Genero);
            Assert.AreEqual("Pop", (resultadoGeneroDesc.Model as IEnumerable<VistaCancione>).ElementAt(1).Genero);
            Assert.AreEqual("Moderno", (resultadoGeneroDesc.Model as IEnumerable<VistaCancione>).ElementAt(2).Genero);
            Assert.IsInstanceOfType(resultadoGeneroDesc.Model as IEnumerable<VistaCancione>, typeof(IEnumerable<VistaCancione>));
            Assert.IsNotNull(resultadoGeneroDesc.Model as IEnumerable<VistaCancione>);
            Assert.AreEqual(6, (resultadoGeneroDesc.Model as IEnumerable<VistaCancione>).Count());

            var resultadoFecha = controlador.Index("Fecha", "").Result as ViewResult;
            Assert.AreEqual(new DateOnly(1979, 01 ,01), (resultadoFecha.Model as IEnumerable<VistaCancione>).ElementAt(0).Fecha);
            Assert.AreEqual(new DateOnly(1983, 05, 31), (resultadoFecha.Model as IEnumerable<VistaCancione>).ElementAt(1).Fecha);
            Assert.AreEqual(new DateOnly(1999, 02, 03), (resultadoFecha.Model as IEnumerable<VistaCancione>).ElementAt(2).Fecha);
            Assert.IsInstanceOfType(resultadoFecha.Model as IEnumerable<VistaCancione>, typeof(IEnumerable<VistaCancione>));
            Assert.IsNotNull(resultadoFecha.Model as IEnumerable<VistaCancione>);
            Assert.AreEqual(6, (resultadoFecha.Model as IEnumerable<VistaCancione>).Count());

            var resultadoFechaDesc = controlador.Index("fecha_desc", "").Result as ViewResult;
            Assert.AreEqual(new DateOnly(2021, 03, 24), (resultadoFechaDesc.Model as IEnumerable<VistaCancione>).ElementAt(0).Fecha);
            Assert.AreEqual(new DateOnly(2005, 10, 07), (resultadoFechaDesc.Model as IEnumerable<VistaCancione>).ElementAt(1).Fecha);
            Assert.AreEqual(new DateOnly(2001, 08, 12), (resultadoFechaDesc.Model as IEnumerable<VistaCancione>).ElementAt(2).Fecha);
            Assert.IsInstanceOfType(resultadoFechaDesc.Model as IEnumerable<VistaCancione>, typeof(IEnumerable<VistaCancione>));
            Assert.IsNotNull(resultadoFechaDesc.Model as IEnumerable<VistaCancione>);
            Assert.AreEqual(6, (resultadoFechaDesc.Model as IEnumerable<VistaCancione>).Count());

            var resultadoAlbumes = controlador.Index("Albumes", "").Result as ViewResult;
            Assert.AreEqual("Highway to Hell", (resultadoAlbumes.Model as IEnumerable<VistaCancione>).ElementAt(0).TituloAlbum);
            Assert.AreEqual("Highway to Hell", (resultadoAlbumes.Model as IEnumerable<VistaCancione>).ElementAt(1).TituloAlbum);
            Assert.AreEqual("Master of Puppets", (resultadoAlbumes.Model as IEnumerable<VistaCancione>).ElementAt(2).TituloAlbum);
            Assert.IsInstanceOfType(resultadoAlbumes.Model as IEnumerable<VistaCancione>, typeof(IEnumerable<VistaCancione>));
            Assert.IsNotNull(resultadoAlbumes.Model as IEnumerable<VistaCancione>);
            Assert.AreEqual(6, (resultadoAlbumes.Model as IEnumerable<VistaCancione>).Count());

            var resultadoAlbumesDesc = controlador.Index("albumes_desc", "").Result as ViewResult;
            Assert.AreEqual("Vivir para Contarlo", (resultadoAlbumesDesc.Model as IEnumerable<VistaCancione>).ElementAt(0).TituloAlbum);
            Assert.AreEqual("Sultans of Swing", (resultadoAlbumesDesc.Model as IEnumerable<VistaCancione>).ElementAt(1).TituloAlbum);
            Assert.AreEqual("Nevermind", (resultadoAlbumesDesc.Model as IEnumerable<VistaCancione>).ElementAt(2).TituloAlbum);
            Assert.IsInstanceOfType(resultadoAlbumesDesc.Model as IEnumerable<VistaCancione>, typeof(IEnumerable<VistaCancione>));
            Assert.IsNotNull(resultadoAlbumesDesc.Model as IEnumerable<VistaCancione>);
            Assert.AreEqual(6, (resultadoAlbumesDesc.Model as IEnumerable<VistaCancione>).Count());
        }

        [TestMethod()]
        public void DetailsTest()
        {
            var result = controlador.Details(1).Result as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNull(result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);
            var canciones = result.ViewData.Model as VistaCancione;
            Assert.IsNotNull(canciones);
            Assert.AreEqual("Ignite", canciones.Titulo);

            var resultIdNotFound = controlador.Details(null).Result as NotFoundResult;
            Assert.IsNotNull(resultIdNotFound);
            Assert.AreEqual(404, resultIdNotFound.StatusCode);
            var resultNotFound = controlador.Details(99).Result as NotFoundResult;
            Assert.IsNotNull(resultNotFound);
            Assert.AreEqual(404, resultNotFound.StatusCode);
        }

        [TestMethod()]
        public void CreateTest()
        {
            var result = controlador.Create().Result as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNull(result.ViewName);
            Assert.IsInstanceOfType(result.ViewData["AlbumesId"], typeof(SelectList));
        }

        [TestMethod()]
        public async Task CreateTest1()
        {
            Cancione CancionValida = new() { Titulo = "CancionTest", Genero = "GeneroPrueba", Fecha = new DateOnly(2005, 10, 07), AlbumesId = 7, UrlVideo = "" };
            await controlador.Create(CancionValida);
            var CancionCreada = contexto.DameTodos().Result.FirstOrDefault(x => x.Titulo == "CancionTest");
            Assert.IsNotNull(CancionCreada);
            Assert.AreEqual("CancionTest", CancionCreada.Titulo);
            Assert.AreEqual(7, CancionCreada.AlbumesId);
            await controlador.DeleteConfirmed(CancionCreada.Id);
        }

        [TestMethod()]
        public void EditTest()
        {
            var result = controlador.Edit(1).Result as ViewResult;
            Assert.IsNotNull(result);

            var resultNotFound = controlador.Edit(99).Result as NotFoundResult;
            Assert.IsNotNull(resultNotFound);
            Assert.AreEqual(404, resultNotFound.StatusCode);
        }

        [TestMethod()]
        public async Task EditTest1()
        {
            Cancione CancionValida = new() { Titulo = "CancionTest", Genero = "GeneroPrueba", Fecha = new DateOnly(2005, 10, 07), AlbumesId = 7, UrlVideo = "" };
            await controlador.Create(CancionValida);
            var CancionCreada = contexto.DameTodos().Result.FirstOrDefault(x => x.Titulo == "CancionTest");
            CancionCreada.Titulo = "CancionTest2";
            CancionCreada.AlbumesId = 8;

            await controlador.Edit(CancionCreada.Id, CancionCreada);
            var CancionModificada = contexto.DameTodos().Result.FirstOrDefault(x => x.Titulo == "CancionTest2");
            Assert.IsNotNull(CancionModificada);
            Assert.AreEqual("CancionTest2", CancionModificada.Titulo);

            var resultIdNotFound = controlador.Edit(99, CancionCreada).Result as NotFoundResult;
            Assert.IsNotNull(resultIdNotFound);
            Assert.AreEqual(404, resultIdNotFound.StatusCode);

            controlador.ModelState.AddModelError("Titulo", "Required");
            var resultInvalidModel =await controlador.Edit(CancionCreada.Id, CancionCreada) as ViewResult;
            Assert.IsNotNull(resultInvalidModel);
            controlador.ModelState.Clear();

            await controlador.DeleteConfirmed(CancionCreada.Id);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var result = controlador.Delete(1).Result as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNull(result.ViewName);

            var resultNotFound = controlador.Delete(99).Result as NotFoundResult;
            Assert.IsNotNull(resultNotFound);
            Assert.AreEqual(404, resultNotFound.StatusCode);
        }
        [TestMethod()]
        public void ExistTest()
        {
            var result = controlador.CancioneExists(1).Result;
            Assert.IsNotNull(result);
        }
    }
}
