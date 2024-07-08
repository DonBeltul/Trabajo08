using Microsoft.VisualStudio.TestTools.UnitTesting;
using PruebaMVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaMVC.Models;
using PruebaMVC.Services.Repositorio;
using Microsoft.Extensions.Configuration;

namespace PruebaMVC.Controllers.Tests
{
    [TestClass()]

    public class ConciertoesControllerTests
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .AddEnvironmentVariables()
                .Build();
            return config;
        }

        private ConciertoesController controller = new ConciertoesController(new EFGenericRepositorio<Concierto>(InitConfiguration()));

        [TestMethod()]
        public  async Task AIndexTestDefault()
        {
            var resultado = await controller.Index("", "") as ViewResult;
            Assert.IsInstanceOfType(resultado.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultado.Model as IEnumerable<Concierto>);
            Assert.AreEqual(5, (resultado.Model as IEnumerable<Concierto>).Count());
            Assert.AreEqual(null, resultado.ViewName);

            var resultadoTitulo = await controller.Index("", "") as ViewResult;
            Assert.AreEqual("FestivalLondres", (resultadoTitulo.Model as IEnumerable<Concierto>).ElementAt(0).Titulo);
            Assert.AreEqual("FestivalMalaga", (resultadoTitulo.Model as IEnumerable<Concierto>).ElementAt(1).Titulo);
            Assert.AreEqual("FestivalParis", (resultadoTitulo.Model as IEnumerable<Concierto>).ElementAt(2).Titulo);
            Assert.IsInstanceOfType(resultadoTitulo.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoTitulo.Model as IEnumerable<Concierto>);
            Assert.AreEqual(5, (resultadoTitulo.Model as IEnumerable<Concierto>).Count());
        }

        [TestMethod()]
        public async Task AIndexTestLugarDesc()
        {
            var resultadoDesc = await controller.Index("lugar_desc", "") as ViewResult;
            Assert.AreEqual("Zaragoza", (resultadoDesc.Model as IEnumerable<Concierto>).ElementAt(0).Lugar);
            Assert.AreEqual("Roma", (resultadoDesc.Model as IEnumerable<Concierto>).ElementAt(1).Lugar);
            Assert.AreEqual("Paris", (resultadoDesc.Model as IEnumerable<Concierto>).ElementAt(2).Lugar);
            Assert.IsInstanceOfType(resultadoDesc.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoDesc.Model as IEnumerable<Concierto>);
            Assert.AreEqual(5, (resultadoDesc.Model as IEnumerable<Concierto>).Count());
        }

        [TestMethod()]
        public async Task AIndexTestLugar()
        {
            var resultadoLugar = await controller.Index("Lugar", "") as ViewResult;
            Assert.AreEqual("Londres", (resultadoLugar.Model as IEnumerable<Concierto>).ElementAt(0).Lugar);
            Assert.AreEqual("Malaga", (resultadoLugar.Model as IEnumerable<Concierto>).ElementAt(1).Lugar);
            Assert.AreEqual("Paris", (resultadoLugar.Model as IEnumerable<Concierto>).ElementAt(2).Lugar);
            Assert.IsInstanceOfType(resultadoLugar.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoLugar.Model as IEnumerable<Concierto>);
            Assert.AreEqual(5, (resultadoLugar.Model as IEnumerable<Concierto>).Count());
        }

        [TestMethod()]
        public async Task AIndexTestGeneroDesc()
        {
            var resultadoGeneroDesc = await controller.Index("genero_desc", "") as ViewResult;
            Assert.AreEqual("rock", (resultadoGeneroDesc.Model as IEnumerable<Concierto>).ElementAt(0).Genero);
            Assert.AreEqual("rock", (resultadoGeneroDesc.Model as IEnumerable<Concierto>).ElementAt(1).Genero);
            Assert.AreEqual("pop", (resultadoGeneroDesc.Model as IEnumerable<Concierto>).ElementAt(2).Genero);
            Assert.IsInstanceOfType(resultadoGeneroDesc.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoGeneroDesc.Model as IEnumerable<Concierto>);
            Assert.AreEqual(5, (resultadoGeneroDesc.Model as IEnumerable<Concierto>).Count());
        }

        [TestMethod()]
        public async Task AIndexTestGenero()
        {
            var resultadoGenero = await controller.Index("Genero", "") as ViewResult;
            Assert.AreEqual("Metal", (resultadoGenero.Model as IEnumerable<Concierto>).ElementAt(0).Genero);
            Assert.AreEqual("pop", (resultadoGenero.Model as IEnumerable<Concierto>).ElementAt(1).Genero);
            Assert.AreEqual("pop", (resultadoGenero.Model as IEnumerable<Concierto>).ElementAt(2).Genero);
            Assert.IsInstanceOfType(resultadoGenero.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoGenero.Model as IEnumerable<Concierto>);
            Assert.AreEqual(5, (resultadoGenero.Model as IEnumerable<Concierto>).Count());
        }

        [TestMethod()]
        public async Task AIndexTestPrecioDesc()
        {
            var resultadoPrecioDesc = await controller.Index("precio_desc", "") as ViewResult;
            Assert.AreEqual(100, (resultadoPrecioDesc.Model as IEnumerable<Concierto>).ElementAt(0).Precio);
            Assert.AreEqual(77, (resultadoPrecioDesc.Model as IEnumerable<Concierto>).ElementAt(1).Precio);
            Assert.AreEqual(55, (resultadoPrecioDesc.Model as IEnumerable<Concierto>).ElementAt(2).Precio);
            Assert.IsInstanceOfType(resultadoPrecioDesc.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoPrecioDesc.Model as IEnumerable<Concierto>);
            Assert.AreEqual(5, (resultadoPrecioDesc.Model as IEnumerable<Concierto>).Count());
        }

        [TestMethod()]
        public async Task AIndexTestPrecio()
        {
            var resultadoPrecio = await controller.Index("Precio", "") as ViewResult;
            Assert.AreEqual(34, (resultadoPrecio.Model as IEnumerable<Concierto>).ElementAt(0).Precio);
            Assert.AreEqual(44, (resultadoPrecio.Model as IEnumerable<Concierto>).ElementAt(1).Precio);
            Assert.AreEqual(55, (resultadoPrecio.Model as IEnumerable<Concierto>).ElementAt(2).Precio);
            Assert.IsInstanceOfType(resultadoPrecio.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoPrecio.Model as IEnumerable<Concierto>);
            Assert.AreEqual(5, (resultadoPrecio.Model as IEnumerable<Concierto>).Count());
        }

        [TestMethod()]
        public async Task AIndexTestTituloDesc()
        {
            var resultadoTituloDesc = await controller.Index("titulo_desc", "") as ViewResult;
            Assert.AreEqual("FestivalZaragoza", (resultadoTituloDesc.Model as IEnumerable<Concierto>).ElementAt(0).Titulo);
            Assert.AreEqual("FestivalRoma", (resultadoTituloDesc.Model as IEnumerable<Concierto>).ElementAt(1).Titulo);
            Assert.AreEqual("FestivalParis", (resultadoTituloDesc.Model as IEnumerable<Concierto>).ElementAt(2).Titulo);
            Assert.IsInstanceOfType(resultadoTituloDesc.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoTituloDesc.Model as IEnumerable<Concierto>);
            Assert.AreEqual(5, (resultadoTituloDesc.Model as IEnumerable<Concierto>).Count());
        }

        [TestMethod()]
        public async Task AIndexTestFilter()
        {
            var resultadoFilter = await controller.Index("", "Malaga") as ViewResult;
            var orderFilter = resultadoFilter.Model as IEnumerable<Concierto>;
            Assert.AreEqual(1, orderFilter.Count());
            Assert.AreEqual("FestivalMalaga", orderFilter.ElementAt(0).Titulo);
        }

        [TestMethod()]
        public async Task BIndexConsultaTestDefault()
        {
            var resultadoTitulo = await controller.IndexConsulta("") as ViewResult;
            Assert.AreEqual("FestivalLondres", (resultadoTitulo.Model as IEnumerable<Concierto>).ElementAt(0).Titulo);
            Assert.AreEqual("FestivalMalaga", (resultadoTitulo.Model as IEnumerable<Concierto>).ElementAt(1).Titulo);
            Assert.AreEqual("FestivalRoma", (resultadoTitulo.Model as IEnumerable<Concierto>).ElementAt(2).Titulo);
            Assert.IsInstanceOfType(resultadoTitulo.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoTitulo.Model as IEnumerable<Concierto>);
            Assert.AreEqual(4, (resultadoTitulo.Model as IEnumerable<Concierto>).Count());    
        }

        [TestMethod()]
        public async Task BIndexConsultaTestLugarDesc()
        {
            var resultadoDesc = await controller.IndexConsulta("lugar_desc") as ViewResult;
            Assert.AreEqual("Zaragoza", (resultadoDesc.Model as IEnumerable<Concierto>).ElementAt(0).Lugar);
            Assert.AreEqual("Roma", (resultadoDesc.Model as IEnumerable<Concierto>).ElementAt(1).Lugar);
            Assert.AreEqual("Malaga", (resultadoDesc.Model as IEnumerable<Concierto>).ElementAt(2).Lugar);
            Assert.IsInstanceOfType(resultadoDesc.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoDesc.Model as IEnumerable<Concierto>);
            Assert.AreEqual(4, (resultadoDesc.Model as IEnumerable<Concierto>).Count());
        }
        [TestMethod()]
        public async Task BIndexConsultaTestLugar()
        {
            var resultadoLugar = await controller.IndexConsulta("Lugar") as ViewResult;
            Assert.AreEqual("Londres", (resultadoLugar.Model as IEnumerable<Concierto>).ElementAt(0).Lugar);
            Assert.AreEqual("Malaga", (resultadoLugar.Model as IEnumerable<Concierto>).ElementAt(1).Lugar);
            Assert.AreEqual("Roma", (resultadoLugar.Model as IEnumerable<Concierto>).ElementAt(2).Lugar);
            Assert.IsInstanceOfType(resultadoLugar.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoLugar.Model as IEnumerable<Concierto>);
            Assert.AreEqual(4, (resultadoLugar.Model as IEnumerable<Concierto>).Count());
        }

        [TestMethod()]
        public async Task BIndexConsultaTestGeneroDesc()
        {
            var resultadoGeneroDesc = await controller.IndexConsulta("genero_desc") as ViewResult;
            Assert.AreEqual("rock", (resultadoGeneroDesc.Model as IEnumerable<Concierto>).ElementAt(0).Genero);
            Assert.AreEqual("rock", (resultadoGeneroDesc.Model as IEnumerable<Concierto>).ElementAt(1).Genero);
            Assert.AreEqual("pop", (resultadoGeneroDesc.Model as IEnumerable<Concierto>).ElementAt(2).Genero);
            Assert.IsInstanceOfType(resultadoGeneroDesc.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoGeneroDesc.Model as IEnumerable<Concierto>);
            Assert.AreEqual(4, (resultadoGeneroDesc.Model as IEnumerable<Concierto>).Count());
        }

        [TestMethod()]
        public async Task BIndexConsultaTestGenero()
        {
            var resultadoGenero = await controller.IndexConsulta("Genero") as ViewResult;
            Assert.AreEqual("Metal", (resultadoGenero.Model as IEnumerable<Concierto>).ElementAt(0).Genero);
            Assert.AreEqual("pop", (resultadoGenero.Model as IEnumerable<Concierto>).ElementAt(1).Genero);
            Assert.AreEqual("rock", (resultadoGenero.Model as IEnumerable<Concierto>).ElementAt(2).Genero);
            Assert.IsInstanceOfType(resultadoGenero.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoGenero.Model as IEnumerable<Concierto>);
            Assert.AreEqual(4, (resultadoGenero.Model as IEnumerable<Concierto>).Count());
        }
        [TestMethod()]
        public async Task BIndexConsultaTestDesc()
        {
            var resultadoPrecioDesc = await controller.IndexConsulta("precio_desc") as ViewResult;
            Assert.AreEqual(100, (resultadoPrecioDesc.Model as IEnumerable<Concierto>).ElementAt(0).Precio);
            Assert.AreEqual(77, (resultadoPrecioDesc.Model as IEnumerable<Concierto>).ElementAt(1).Precio);
            Assert.AreEqual(44, (resultadoPrecioDesc.Model as IEnumerable<Concierto>).ElementAt(2).Precio);
            Assert.IsInstanceOfType(resultadoPrecioDesc.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoPrecioDesc.Model as IEnumerable<Concierto>);
            Assert.AreEqual(4, (resultadoPrecioDesc.Model as IEnumerable<Concierto>).Count());
        }

        [TestMethod()]
        public async Task BIndexConsultaTestPrecio()
        {
            var resultadoPrecio = await controller.IndexConsulta("Precio") as ViewResult;
            Assert.AreEqual(34, (resultadoPrecio.Model as IEnumerable<Concierto>).ElementAt(0).Precio);
            Assert.AreEqual(44, (resultadoPrecio.Model as IEnumerable<Concierto>).ElementAt(1).Precio);
            Assert.AreEqual(77, (resultadoPrecio.Model as IEnumerable<Concierto>).ElementAt(2).Precio);
            Assert.IsInstanceOfType(resultadoPrecio.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoPrecio.Model as IEnumerable<Concierto>);
            Assert.AreEqual(4, (resultadoPrecio.Model as IEnumerable<Concierto>).Count());
        }

        [TestMethod()]
        public async Task BIndexConsultaTestTituloDesc()
        {
            var resultadoTituloDesc = await controller.IndexConsulta("titulo_desc") as ViewResult;
            Assert.AreEqual("FestivalZaragoza", (resultadoTituloDesc.Model as IEnumerable<Concierto>).ElementAt(0).Titulo);
            Assert.AreEqual("FestivalRoma", (resultadoTituloDesc.Model as IEnumerable<Concierto>).ElementAt(1).Titulo);
            Assert.AreEqual("FestivalMalaga", (resultadoTituloDesc.Model as IEnumerable<Concierto>).ElementAt(2).Titulo);
            Assert.IsInstanceOfType(resultadoTituloDesc.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoTituloDesc.Model as IEnumerable<Concierto>);
            Assert.AreEqual(4, (resultadoTituloDesc.Model as IEnumerable<Concierto>).Count());
        }

        [TestMethod()]
        public void DCreateTest()
        {
            var resultado = controller.Create() as ViewResult;
            Assert.AreEqual(null, resultado.Model);
        }

        [TestMethod()]
        public async Task CCreateTest1()
        {

            Concierto concierto = new Concierto();

            concierto.Lugar = "Prueba";
            concierto.Titulo = "Prueba";
            concierto.Precio = 30;
            concierto.Fecha = DateTime.Now;

            await controller.Create(concierto);

            var lista = (await controller.Index("", "") as ViewResult).Model as IEnumerable<Concierto>;
            int id = lista.FirstOrDefault(x => x.Lugar.Equals("Prueba")).Id;

            var resultado = await controller.Details(id) as ViewResult;
            Assert.IsInstanceOfType(resultado.Model as Concierto, typeof(Concierto));
            Assert.AreEqual(resultado.Model as Concierto, concierto);
            Assert.AreEqual("Prueba", (resultado.Model as Concierto).Lugar);
            Assert.AreEqual("Prueba", (resultado.Model as Concierto).Titulo);
            Assert.AreEqual(30, (resultado.Model as Concierto).Precio);

            var concieroId1 = resultado.Model as Concierto;

            Assert.IsInstanceOfType(concieroId1, typeof(Concierto));
            Assert.AreEqual("Prueba", concieroId1.Lugar);

            await controller.DeleteConfirmed(id);

            try
            {
                var details = await controller.Details(id) as ViewResult;
                Assert.Fail();
            }
            catch (Exception e)
            {

            }
        }

        [TestMethod()]
        public async Task EDetailsTest()
        {
            var resultado = await controller.Details(1) as ViewResult;
            var concieroId1 = resultado.Model as Concierto;

            Assert.IsInstanceOfType(concieroId1, typeof(Concierto));
            Assert.AreEqual("Zaragoza", concieroId1.Lugar);

            try
            {
                var error = (await controller.Details(1000) as ViewResult).Model as Concierto;
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error capturado en Test Details");
            }
        }

        [TestMethod()]
        public async Task FEditTest()
        {
            var resultado = await controller.Edit(1) as ViewResult;
            var concieroId1 = resultado.Model as Concierto;

            Assert.IsInstanceOfType(concieroId1, typeof(Concierto));
            Assert.AreEqual("Zaragoza", concieroId1.Lugar);

            try
            {
                var error = (await controller.Edit(1000) as ViewResult).Model as Concierto;
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error capturado en Test Edit");
            }
        }

        [TestMethod()]
        public async Task GEditTest1()
        {

            Concierto objeto = new Concierto();
            objeto.Id = 25;

            try
            {
                await controller.Edit(25, objeto);
                Assert.Fail();
            }
            catch (Exception e)
            {

            }
            try
            {
                await controller.Edit(15, objeto);
                Assert.Fail();
            }
            catch (Exception e)
            {

            }
            Concierto conciertoCancion = new Concierto();
            conciertoCancion.Lugar = "Zaragoza";
            var vista = await controller.Edit(1, conciertoCancion);
        }

        [TestMethod()]
        public async Task ExistTest()
        {
            Assert.AreEqual(true, await controller.ConciertoExists(1));
            Assert.AreEqual(false, await controller.ConciertoExists(1000));
        }

        [TestMethod()]
        public async Task HDeleteTest()
        {
            var resultado = await controller.Delete(1) as ViewResult;
            var concieroId1 = resultado.Model as Concierto;

            Assert.IsInstanceOfType(concieroId1, typeof(Concierto));
            Assert.AreEqual("Zaragoza", concieroId1.Lugar);

            try
            {
                var error = (await controller.Delete(1000) as ViewResult).Model as Concierto;
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error capturado en Test Delete");
            }
        }
    }
}