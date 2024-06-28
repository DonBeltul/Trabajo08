using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PruebaMVC.Controllers;
using PruebaMVC.Models;
using PruebaMVC.Services.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMVC.Controllers.Tests
{
    [TestClass()]
    public class AlbumesControllerTests
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .AddEnvironmentVariables()
                .Build();
            return config;
        }

        public readonly AlbumesController Acontroller = new(new EFGenericRepositorio<Albume>(InitConfiguration()), 
            new EFGenericRepositorio<Grupo>(InitConfiguration()), 
            new EFGenericRepositorio<VistaAlbume>(InitConfiguration()));

        [TestMethod()]
        public void IndexTest()
        {
            var result = Acontroller.Index("","").Result as ViewResult;
            Assert.IsNotNull(result);
           
            Assert.IsNotNull(result.ViewData.Model);
            var listaAlbumes = result.ViewData.Model as List<Albume>;
            Assert.IsNotNull(listaAlbumes);
            Assert.AreEqual(5, listaAlbumes.Count);
        }

        [TestMethod()]
        public void IndexConsultaTest()
        {
            var result = Acontroller.Index("", "").Result as ViewResult;
            Assert.IsNotNull(result);
        
            Assert.IsNotNull(result.ViewData.Model);
            var listaAlbumes = result.ViewData.Model as List<Albume>;
            Assert.IsNotNull(listaAlbumes);
            Assert.AreEqual(5, listaAlbumes.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            var result = Acontroller.Details(1).Result as ViewResult;
            Assert.IsNotNull(result);
         
            Assert.IsNotNull(result.ViewData.Model);
            var album = result.ViewData.Model as Albume;
            Assert.IsNotNull(album);
            Assert.AreEqual("Highway to Hell", album.Titulo);
        }

        [TestMethod()]
        public void CreateTest()
        {
            var result = Acontroller.Create().Result as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void CreateTest1()
        {
            Albume album = new Albume() {Fecha= DateOnly.Parse("2005/10/07"), Genero="Rock",Titulo = "Las niñas de la Saye", GruposId = 1};
            var aux = Acontroller.Create(album).Result;
            var result = Acontroller.Index("", "").Result as ViewResult;
            Assert.IsNotNull(result);
      
            Assert.IsNotNull(result.ViewData.Model);
            var listaAlbumes = result.ViewData.Model as List<VistaAlbume>;
            Assert.IsNotNull(listaAlbumes);
            Assert.AreEqual(6, listaAlbumes.Count);
            
        }

        [TestMethod()]
        public void EditTest()
        {
            var result = Acontroller.Edit(89).Result as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void EditTest1()
        {
            var aux = Acontroller.Edit(12).Result;
            var result = Acontroller.Details(11).Result as ViewResult;
            Assert.IsNotNull(result);
          
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var result = Acontroller.Delete(12).Result as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void DeleteConfirmedTest()
        {
            var aux =  Acontroller.DeleteConfirmed(12).Result;
            var result = Acontroller.Index("", "").Result as ViewResult;
            Assert.IsNotNull(result);
           
            Assert.IsNotNull(result.ViewData.Model);
            var listaAlbumes = result.ViewData.Model as List<Albume>;
            Assert.IsNotNull(listaAlbumes);
            Assert.AreEqual(5, listaAlbumes.Count);
           
        }
    }
}