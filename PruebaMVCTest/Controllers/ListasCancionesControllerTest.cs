using PruebaMVC.Models;
using PruebaMVC.Services.Repositorio;
using Microsoft.AspNetCore.Mvc;
using PruebaMVC.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PruebaMVCTest.Controllers
{
    [TestClass]
    public class ListasCancionesControllerTest
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .AddEnvironmentVariables()
                .Build();
            return config;
        }
        private ListasCancionesController controlador = new ListasCancionesController(new EFGenericRepositorio<ListasCancione>(InitConfiguration()),
            new EFGenericRepositorio<Cancione>(InitConfiguration()),
            new EFGenericRepositorio<Lista>(InitConfiguration()),
            new EFGenericRepositorio<VistaListaCancione>(InitConfiguration()));
        public EFGenericRepositorio<ListasCancione> contexto = new EFGenericRepositorio<ListasCancione>(InitConfiguration());
        [TestMethod()]
        public void IndexTest()
        {
            var result = controlador.Index("").Result as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNull(result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);
            var listaListacancione = result.ViewData.Model as IEnumerable<VistaListaCancione>;
            Assert.IsNotNull(listaListacancione);
            Assert.AreEqual(6, listaListacancione.Count());
        }

        [TestMethod()]
        public void DetailsTest()
        {
            var result = controlador.Details(1).Result as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNull(result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);
            var lista = result.ViewData.Model as VistaListaCancione;
            Assert.IsNotNull(lista);
            Assert.AreEqual(1, lista.ListasId);

            var resultIdNotFound = controlador.Details(null).Result as NotFoundResult;
            Assert.IsNotNull(resultIdNotFound);
            Assert.AreEqual(404, resultIdNotFound.StatusCode);
        }

        [TestMethod()]
        public void CreateTest()
        {
            var result = controlador.Create().Result as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNull(result.ViewName);
            Assert.IsInstanceOfType(result.ViewData["CancionesId"], typeof(SelectList));
            Assert.IsInstanceOfType(result.ViewData["ListasId"], typeof(SelectList));
        }

        [TestMethod()]
        public async Task CreateTest1()
        {
            ListasCancione ListaCancioneValido = new() { ListasId = 1, CancionesId = 2 };
            await controlador.Create(ListaCancioneValido);
            var listaCancioneCreada = contexto.DameTodos().Result.FirstOrDefault(x => x.ListasId == 1 && x.CancionesId == 2);
            Assert.IsNotNull(listaCancioneCreada);
            Assert.AreEqual(1, listaCancioneCreada.ListasId);
            Assert.AreEqual(2, listaCancioneCreada.CancionesId);

            controlador.ModelState.AddModelError("Titulo", "Required");
            controlador.ModelState.AddModelError("Nombre", "Required");
            var resultInvalidModel = await controlador.Create(ListaCancioneValido) as ViewResult;
            Assert.IsNotNull(resultInvalidModel);
            controlador.ModelState.Clear();

            await controlador.DeleteConfirmed(listaCancioneCreada.Id);
        }

        [TestMethod()]
        public void EditTest()
        {
            var result = controlador.Edit(1).Result as ViewResult;
            Assert.IsNotNull(result);

            var resultIdNotFound = controlador.Edit(null).Result as NotFoundResult;
            Assert.IsNotNull(resultIdNotFound);
            Assert.AreEqual(404, resultIdNotFound.StatusCode);

        }

        [TestMethod()]
        public async Task EditTest1()
        {
            ListasCancione ListaCancioneValido = new() { ListasId = 1, CancionesId = 2 };
            await controlador.Create(ListaCancioneValido);
            var listaCancioneCreada = contexto.DameTodos().Result.FirstOrDefault(x => x.ListasId == 1 && x.CancionesId == 2);
            listaCancioneCreada.CancionesId = 3;
            await controlador.Edit(listaCancioneCreada.Id, listaCancioneCreada);
            var listaCancioneModificada = contexto.DameTodos().Result.FirstOrDefault(x => x.ListasId == 1 && x.CancionesId == 3);
            Assert.IsNotNull(listaCancioneModificada);
            Assert.AreEqual(3, listaCancioneModificada.CancionesId);

            var resultIdNotFound = controlador.Edit(99, listaCancioneCreada).Result as NotFoundResult;
            Assert.IsNotNull(resultIdNotFound);
            Assert.AreEqual(404, resultIdNotFound.StatusCode);

            controlador.ModelState.AddModelError("Titulo", "Required");
            controlador.ModelState.AddModelError("Nombre", "Required");
            var resultInvalidModel = await controlador.Edit(listaCancioneCreada.Id, listaCancioneCreada) as ViewResult;
            Assert.IsNotNull(resultInvalidModel);
            controlador.ModelState.Clear();

            await controlador.DeleteConfirmed(listaCancioneCreada.Id);
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
            var result = controlador.ListasCancioneExists(1).Result;
            Assert.IsNotNull(result);
        }
    }
}
