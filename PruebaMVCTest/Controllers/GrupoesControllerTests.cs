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

        public GrupoesController Gcontroller = new(new EFGenericRepositorio<Grupo>(InitConfiguration()));

        [TestMethod()]
        public async Task IndexTest()
        {
            var resultado = await Gcontroller.Index("", "") as ViewResult;
            Assert.IsInstanceOfType(resultado.Model as IEnumerable<Grupo>, typeof(IEnumerable<Grupo>));
            Assert.IsNotNull(resultado.Model as IEnumerable<Grupo>);
            Assert.AreEqual(5, (resultado.Model as IEnumerable<Grupo>).Count());
            Assert.AreEqual(null, resultado.ViewName);

            var resultadoNombre = await Gcontroller.Index("Nombre", "") as ViewResult;
            Assert.AreEqual("AC/DC", (resultadoNombre.Model as IEnumerable<Grupo>).ElementAt(0).Nombre);
            Assert.AreEqual("Boney M.", (resultadoNombre.Model as IEnumerable<Grupo>).ElementAt(1).Nombre);
            Assert.AreEqual("Metallica", (resultadoNombre.Model as IEnumerable<Grupo>).ElementAt(2).Nombre);
            Assert.AreEqual("Nirvana", (resultadoNombre.Model as IEnumerable<Grupo>).ElementAt(3).Nombre);
            Assert.AreEqual("Violadores del Verso", (resultadoNombre.Model as IEnumerable<Grupo>).ElementAt(4).Nombre);
            Assert.IsInstanceOfType(resultadoNombre.Model as IEnumerable<Grupo>, typeof(IEnumerable<Grupo>));
            Assert.IsNotNull(resultadoNombre.Model as IEnumerable<Grupo>);
            Assert.AreEqual(5, (resultadoNombre.Model as IEnumerable<Grupo>).Count());

            var resultadoNombreDesc = await Gcontroller.Index("Nombre_desc", "") as ViewResult;
            Assert.AreEqual("AC/DC", (resultadoNombre.Model as IEnumerable<Grupo>).ElementAt(0).Nombre);
            Assert.AreEqual("Boney M.", (resultadoNombre.Model as IEnumerable<Grupo>).ElementAt(1).Nombre);
            Assert.AreEqual("Metallica", (resultadoNombre.Model as IEnumerable<Grupo>).ElementAt(2).Nombre);
            Assert.AreEqual("Nirvana", (resultadoNombre.Model as IEnumerable<Grupo>).ElementAt(3).Nombre);
            Assert.AreEqual("Violadores del Verso", (resultadoNombre.Model as IEnumerable<Grupo>).ElementAt(4).Nombre);
            Assert.IsInstanceOfType(resultadoNombreDesc.Model as IEnumerable<Grupo>, typeof(IEnumerable<Grupo>));
            Assert.IsNotNull(resultadoNombreDesc.Model as IEnumerable<Grupo>);
            Assert.AreEqual(5, (resultadoNombreDesc.Model as IEnumerable<Grupo>).Count());


        }

        [TestMethod()]
        public async Task IndexConArtistasTest()
        {
            var resultado = await Gcontroller.Index("", "") as ViewResult;
            Assert.IsInstanceOfType(resultado.Model as IEnumerable<Grupo>, typeof(IEnumerable<Grupo>));
            Assert.IsNotNull(resultado.Model as IEnumerable<Grupo>);
            Assert.AreEqual(5, (resultado.Model as IEnumerable<Grupo>).Count());
            Assert.AreEqual(null, resultado.ViewName);

            var resultadoNombre = await Gcontroller.Index("Nombre", "") as ViewResult;
            Assert.AreEqual("AC/DC", (resultadoNombre.Model as IEnumerable<Grupo>).ElementAt(0).Nombre);
            Assert.AreEqual("Boney M.", (resultadoNombre.Model as IEnumerable<Grupo>).ElementAt(1).Nombre);
            Assert.AreEqual("Metallica", (resultadoNombre.Model as IEnumerable<Grupo>).ElementAt(2).Nombre);
            Assert.AreEqual("Nirvana", (resultadoNombre.Model as IEnumerable<Grupo>).ElementAt(3).Nombre);
            Assert.AreEqual("Violadores del Verso", (resultadoNombre.Model as IEnumerable<Grupo>).ElementAt(4).Nombre);
            Assert.IsInstanceOfType(resultadoNombre.Model as IEnumerable<Grupo>, typeof(IEnumerable<Grupo>));
            Assert.IsNotNull(resultadoNombre.Model as IEnumerable<Grupo>);
            Assert.AreEqual(5, (resultadoNombre.Model as IEnumerable<Grupo>).Count());

            var resultadoNombreDesc = await Gcontroller.Index("Nombre_desc", "") as ViewResult;
            Assert.AreEqual("AC/DC", (resultadoNombre.Model as IEnumerable<Grupo>).ElementAt(0).Nombre);
            Assert.AreEqual("Boney M.", (resultadoNombre.Model as IEnumerable<Grupo>).ElementAt(1).Nombre);
            Assert.AreEqual("Metallica", (resultadoNombre.Model as IEnumerable<Grupo>).ElementAt(2).Nombre);
            Assert.AreEqual("Nirvana", (resultadoNombre.Model as IEnumerable<Grupo>).ElementAt(3).Nombre);
            Assert.AreEqual("Violadores del Verso", (resultadoNombre.Model as IEnumerable<Grupo>).ElementAt(4).Nombre);
            Assert.IsInstanceOfType(resultadoNombreDesc.Model as IEnumerable<Grupo>, typeof(IEnumerable<Grupo>));
            Assert.IsNotNull(resultadoNombreDesc.Model as IEnumerable<Grupo>);
            Assert.AreEqual(5, (resultadoNombreDesc.Model as IEnumerable<Grupo>).Count());
        }

        [TestMethod()]
        public async Task DetailsTest()
        {
            var resultado = await Gcontroller.Details(1) as ViewResult;
            var grupo = resultado.Model as Grupo;

            Assert.IsInstanceOfType(grupo, typeof(Grupo));
            Assert.AreEqual("Metallica", grupo.Nombre);

            var lista = (await Gcontroller.Index("", "") as ViewResult).Model as IEnumerable<Grupo>;
            int id = lista.FirstOrDefault(x => x.Nombre.Equals("Metallica")).Id + 10;

            try
            {
                var error = (await Gcontroller.Details(id) as ViewResult).Model as Grupo;
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error capturado en Test Details");
            }
        }

        [TestMethod()]
        public void CreateTest()
        {
            var resultado = Gcontroller.Create() as ViewResult;
            Assert.AreEqual(null, resultado.Model);
        }

        [TestMethod()]
        public async Task CreateTest1()
        {
            Grupo grupo = new Grupo();

            grupo.Nombre = "Los plataplomo";


            await Gcontroller.Create(grupo);

            var lista = (await Gcontroller.Index("", "") as ViewResult).Model as IEnumerable<Grupo>;
            int id = lista.FirstOrDefault(x => x.Nombre.Equals("Los plataplomo")).Id;

            var resultado = await Gcontroller.Details(id) as ViewResult;
            Assert.IsInstanceOfType(resultado.Model as Grupo, typeof(Grupo));
            Assert.AreEqual(resultado.Model as Grupo, grupo);
            Assert.AreEqual("Los plataplomo", (resultado.Model as Grupo).Nombre);

        }

        [TestMethod()]
        public void EditTest()
        {
            var result = Gcontroller.Edit(4).Result as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public async Task EditTest1()
        {
            var lista = (await Gcontroller.Index("", "") as ViewResult).Model as IEnumerable<Grupo>;
            int id = lista.FirstOrDefault(x => x.Nombre.Equals("Metallica")).Id;

            Grupo grupo = new Grupo();
            grupo.Nombre = "Los plataplomo";

            await Gcontroller.Edit(id, grupo);

            var resultadoId = await Gcontroller.Details(id) as ViewResult;
            Assert.IsInstanceOfType(resultadoId.Model as Grupo, typeof(Grupo));
            Assert.AreEqual("Metallica", (resultadoId.Model as Grupo).Nombre);

        }

        [TestMethod()]
        public async Task DeleteTest()
        {


            var resultado = await Gcontroller.Delete(4) as ViewResult;
            var grupo1 = resultado.Model as Grupo;

            Assert.IsInstanceOfType(grupo1, typeof(Grupo));
            Assert.AreEqual("Violadores del Verso", grupo1.Nombre);

            var lista = (await Gcontroller.Index("", "") as ViewResult).Model as IEnumerable<Grupo>;
            int id = lista.FirstOrDefault(x => x.Nombre.Equals("Violadores del Verso")).Id;

            try
            {
                var error = (await Gcontroller.Delete(id) as ViewResult).Model as Grupo;
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error capturado en Test Delete");
            }
        }

        [TestMethod()]
        public async Task DeleteConfirmedTest()
        {
            var lista = (await Gcontroller.Index("", "") as ViewResult).Model as IEnumerable<Grupo>;
            int id = lista.FirstOrDefault(x => x.Nombre.Equals("Los plataplomo")).Id;

            var resultado = await Gcontroller.Details(id) as ViewResult;
            var grupo1 = resultado.Model as Grupo;

            Assert.IsInstanceOfType(grupo1, typeof(Grupo));
            Assert.AreEqual("Los plataplomo", grupo1.Nombre);

            await Gcontroller.DeleteConfirmed(id);

            try
            {
                var details = await Gcontroller.Details(id) as ViewResult;
                Assert.Fail();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error capturado en Test Delete Confirmed");
            }
        }
    }
}