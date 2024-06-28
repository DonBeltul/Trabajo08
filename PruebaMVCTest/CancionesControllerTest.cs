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

namespace PruebaMVCTest
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
            Cancione CancionValida = new() { Titulo = "CancionTest", Genero = "GeneroPrueba", Fecha = new DateOnly(2005,10,07), AlbumesId =7, UrlVideo = ""};
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
            await controlador.DeleteConfirmed(CancionCreada.Id);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var result = controlador.Delete(1).Result as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNull(result.ViewName);
        }
        [TestMethod()]
        public void ExistTest()
        {
            var result = controlador.CancioneExists(1).Result;
            Assert.IsNotNull(result);
        }
    }
}
