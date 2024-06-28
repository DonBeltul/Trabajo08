using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PruebaMVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PruebaMVC.Models;
using PruebaMVC.Services.Repositorio;

namespace PruebaMVC.Controllers.Tests
{
    [TestClass()]
    public class UsuariosControllerTests
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .AddEnvironmentVariables()
                .Build();
            return config;
        }

        public readonly UsuariosController Ucontroller = new(new EFGenericRepositorio<Usuario>(InitConfiguration()));

        [TestMethod()]
        public void IndexTest()
        {
            var result = Ucontroller.Index("", "", "Ocultar").Result as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ViewData.Model);
            var listaUsuarios = result.ViewData.Model as List<Usuario>;
            Assert.IsNotNull(listaUsuarios);
            Assert.AreEqual(4, listaUsuarios.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            var result = Ucontroller.Details(1).Result as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ViewData.Model);
            var usuario = result.ViewData.Model as Usuario;
            Assert.IsNotNull(usuario);
            Assert.AreEqual("Francisco", usuario.Nombre);
        }

        [TestMethod()]
        public void CreateTest()
        {
            var result = Ucontroller.Create() as ViewResult; 
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void CreateTest1()
        {
            Usuario usuario = new Usuario() { Id = 89, Contraseña = "papapa", Email = "ojksa", Nombre = "Pepe" };
            var aux = Ucontroller.Create(usuario).Result;
            var result = Ucontroller.Index("", "", "").Result as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ViewData.Model);
            var listaUsuarios = result.ViewData.Model as List<Usuario>;
            Assert.IsNotNull(listaUsuarios);
            Assert.AreEqual(5, listaUsuarios.Count);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void EditTest()
        {
            var result = Ucontroller.Edit(4).Result as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void EditTest1()
        {
            Usuario usuario = new Usuario() { Id = 89, Contraseña = "papapa", Email = "ojksa", Nombre = "Pepe" };
            var aux = Ucontroller.Edit(89).Result;
            var result = Ucontroller.Details(89).Result as ViewResult;
            Assert.IsNotNull(result);
        
            Assert.IsNotNull(result.ViewData.Model);
            Assert.IsNotNull(usuario);
            Assert.AreEqual("Pepe", usuario.Nombre);
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var result = Ucontroller.Delete(89).Result as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void DeleteConfirmedTest()
        {
            var aux = Ucontroller.DeleteConfirmed(89).Result;
            var result = Ucontroller.Index("", "", "Mostrar").Result as ViewResult;
            Assert.IsNotNull(result);
           
            Assert.IsNotNull(result.ViewData.Model);
            var listaUsuarios = result.ViewData.Model as List<Usuario>;
            Assert.IsNotNull(listaUsuarios);
            Assert.AreEqual(5, listaUsuarios.Count);
            Assert.IsNotNull(result);
        }
    }
}