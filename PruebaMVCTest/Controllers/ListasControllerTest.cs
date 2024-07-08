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

namespace PruebaMVCTest.Controllers
{
    [TestClass]
    public class ListasControllerTest
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .AddEnvironmentVariables()
                .Build();
            return config;
        }
        private ListasController controlador = new ListasController(new EFGenericRepositorio<Lista>(InitConfiguration()),
            new EFGenericRepositorio<Usuario>(InitConfiguration()));
        public EFGenericRepositorio<Lista> contexto = new EFGenericRepositorio<Lista>(InitConfiguration());
        [TestMethod()]
        public void IndexTest()
        {
            var result = controlador.Index("").Result as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNull(result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);
            var listaLista = result.ViewData.Model as List<Lista>;
            Assert.IsNotNull(listaLista);
            Assert.AreEqual(6, listaLista.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            var result = controlador.Details(1).Result as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNull(result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);
            var lista = result.ViewData.Model as Lista;
            Assert.IsNotNull(lista);
            Assert.AreEqual("Gimnasio", lista.Nombre);


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
            Assert.IsInstanceOfType(result.ViewData["UsuarioId"], typeof(SelectList));
        }

        [TestMethod()]
        public async Task CreateTest1()
        {
            Lista ListaValido = new() { Nombre = "PruebaTest", UsuarioId = 1 };
            await controlador.Create(ListaValido);
            var ListaCreada = contexto.DameTodos().Result.FirstOrDefault(x => x.Nombre == "PruebaTest");
            Assert.IsNotNull(ListaCreada);
            Assert.AreEqual("PruebaTest", ListaCreada.Nombre);
            Assert.AreEqual(1, ListaCreada.UsuarioId);
            await controlador.DeleteConfirmed(ListaCreada.Id);
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
            Lista ListaValido = new() { Nombre = "PruebaTest", UsuarioId = 1 };
            await controlador.Create(ListaValido);
            var ListaCreada = contexto.DameTodos().Result.FirstOrDefault(x => x.Nombre == "PruebaTest");
            ListaCreada.Nombre = "PruebaTest2";
            ListaCreada.UsuarioId = 2;
            await controlador.Edit(ListaCreada.Id, ListaCreada);
            var ListaModificada = contexto.DameTodos().Result.FirstOrDefault(x => x.Nombre == "PruebaTest2");
            Assert.IsNotNull(ListaModificada);
            Assert.AreEqual("PruebaTest2", ListaModificada.Nombre);

            var resultIdNotFound = controlador.Edit(99,ListaCreada).Result as NotFoundResult;
            Assert.IsNotNull(resultIdNotFound);
            Assert.AreEqual(404, resultIdNotFound.StatusCode);

            await controlador.DeleteConfirmed(ListaCreada.Id);


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
            var result = controlador.ListaExists(1).Result;
            Assert.IsNotNull(result);
        }
    }
}
