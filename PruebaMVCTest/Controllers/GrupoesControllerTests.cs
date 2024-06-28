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
    public class GrupoesControllerTests
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .AddEnvironmentVariables()
                .Build();
            return config;
        }

        public readonly GrupoesController Gcontroller = new(new EFGenericRepositorio<Grupo>(InitConfiguration()));

        [TestMethod()]
        public void IndexTest()
        {
            var result = Gcontroller.Index("","").Result as ViewResult;
            Assert.IsNotNull(result);
          
            Assert.IsNotNull(result.ViewData.Model);
            var listaGrupos = result.ViewData.Model as List<Grupo>;
            Assert.IsNotNull(listaGrupos);
            Assert.AreEqual(5, listaGrupos.Count);
        }

        [TestMethod()]
        public  void IndexConArtistasTest()
        {
            var result = Gcontroller.Index("", "").Result as ViewResult;
            Assert.IsNotNull(result);
          
            Assert.IsNotNull(result.ViewData.Model);
            var listaGrupos = result.ViewData.Model as List<Grupo>;
            Assert.IsNotNull(listaGrupos);
            Assert.AreEqual(5, listaGrupos.Count);
        }

        [TestMethod()]
        public  void DetailsTest()
        {
            var result = Gcontroller.Details(1).Result as ViewResult;
            Assert.IsNotNull(result);
          
            Assert.IsNotNull(result.ViewData.Model);
            var grupo = result.ViewData.Model as Grupo;
            Assert.IsNotNull(grupo);
            Assert.AreEqual("Metallica", grupo.Nombre);
        }

        [TestMethod()]
        public void CreateTest()
        {
            var result = Gcontroller.Create() as ViewResult;
            Assert.IsNotNull(result); 
        }

        [TestMethod()]
        public void CreateTest1()
        {
            Grupo grupo = new Grupo() { Id = 89, Nombre = "Los Eustaquios" };
            var aux = Gcontroller.Create(grupo).Result;
            var result = Gcontroller.Index("", "").Result as ViewResult;
            Assert.IsNotNull(result);
        
            Assert.IsNotNull(result.ViewData.Model);
            var listaGrupos = result.ViewData.Model as List<Grupo>;
            Assert.IsNotNull(listaGrupos);
            Assert.AreEqual(6, listaGrupos.Count);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public  void EditTest()
        {
            var result = Gcontroller.Edit(89).Result as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public  void EditTest1()
        {

            Grupo grupo = new Grupo() { Id = 89, Nombre = "Los Eustaquios"};
            var aux = Gcontroller.Edit(89).Result;
            var result = Gcontroller.Details(89).Result as ViewResult;
            Assert.IsNotNull(result);
        
            Assert.IsNotNull(result.ViewData.Model);
            Assert.IsNotNull(grupo);
            Assert.AreEqual("Los Eustaquios", grupo.Nombre);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public  void DeleteTest()
        {
            var result = Gcontroller.Delete(89).Result as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public  void DeleteConfirmedTest()
        {
            var aux = Gcontroller.DeleteConfirmed(89).Result;
            var result = Gcontroller.Index("", "").Result as ViewResult;
            Assert.IsNull(result);
         
            Assert.IsNull(result.ViewData.Model);
            var listaGrupos = result.ViewData.Model as List<Grupo>;
            Assert.IsNull(listaGrupos);
            Assert.AreEqual(5, listaGrupos.Count);
            Assert.IsNull(result);
        }
    }
}