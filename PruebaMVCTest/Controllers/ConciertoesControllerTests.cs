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
        public  async Task AIndexTest()
        {
            var resultado = await controller.Index("", "") as ViewResult;
            Assert.IsInstanceOfType(resultado.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultado.Model as IEnumerable<Concierto>);
            Assert.AreEqual(5, (resultado.Model as IEnumerable<Concierto>).Count());
            Assert.AreEqual(null, resultado.ViewName);

            var resultadoDesc = await controller.Index("lugar_desc", "") as ViewResult;
            Assert.AreEqual("Zaragoza", (resultadoDesc.Model as IEnumerable<Concierto>).ElementAt(0).Lugar);
            Assert.AreEqual("Roma", (resultadoDesc.Model as IEnumerable<Concierto>).ElementAt(1).Lugar);
            Assert.AreEqual("Paris", (resultadoDesc.Model as IEnumerable<Concierto>).ElementAt(2).Lugar);
            Assert.IsInstanceOfType(resultadoDesc.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoDesc.Model as IEnumerable<Concierto>);
            Assert.AreEqual(5, (resultadoDesc.Model as IEnumerable<Concierto>).Count());

            var resultadoLugar = await controller.Index("Lugar", "") as ViewResult;
            Assert.AreEqual("Londres", (resultadoDesc.Model as IEnumerable<Concierto>).ElementAt(0).Lugar);
            Assert.AreEqual("Malaga", (resultadoDesc.Model as IEnumerable<Concierto>).ElementAt(1).Lugar);
            Assert.AreEqual("Paris", (resultadoDesc.Model as IEnumerable<Concierto>).ElementAt(2).Lugar);
            Assert.IsInstanceOfType(resultadoLugar.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoLugar.Model as IEnumerable<Concierto>);
            Assert.AreEqual(5, (resultadoLugar.Model as IEnumerable<Concierto>).Count());

            var resultadoGeneroDesc = await controller.Index("genero_desc", "") as ViewResult;
            Assert.AreEqual("rock", (resultadoGeneroDesc.Model as IEnumerable<Concierto>).ElementAt(0).Genero);
            Assert.AreEqual("rock", (resultadoGeneroDesc.Model as IEnumerable<Concierto>).ElementAt(1).Genero);
            Assert.AreEqual("pop", (resultadoGeneroDesc.Model as IEnumerable<Concierto>).ElementAt(2).Genero);
            Assert.IsInstanceOfType(resultadoGeneroDesc.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoGeneroDesc.Model as IEnumerable<Concierto>);
            Assert.AreEqual(5, (resultadoGeneroDesc.Model as IEnumerable<Concierto>).Count());

            var resultadoGenero = await controller.Index("Genero", "") as ViewResult;
            Assert.AreEqual("Metal", (resultadoGenero.Model as IEnumerable<Concierto>).ElementAt(0).Genero);
            Assert.AreEqual("pop", (resultadoGenero.Model as IEnumerable<Concierto>).ElementAt(1).Genero);
            Assert.AreEqual("pop", (resultadoGenero.Model as IEnumerable<Concierto>).ElementAt(2).Genero);
            Assert.IsInstanceOfType(resultadoGenero.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoGenero.Model as IEnumerable<Concierto>);
            Assert.AreEqual(5, (resultadoGenero.Model as IEnumerable<Concierto>).Count());

            var resultadoPrecioDesc = await controller.Index("precio_desc", "") as ViewResult;
            Assert.AreEqual(100, (resultadoPrecioDesc.Model as IEnumerable<Concierto>).ElementAt(0).Precio);
            Assert.AreEqual(77, (resultadoPrecioDesc.Model as IEnumerable<Concierto>).ElementAt(1).Precio);
            Assert.AreEqual(55, (resultadoPrecioDesc.Model as IEnumerable<Concierto>).ElementAt(2).Precio);
            Assert.IsInstanceOfType(resultadoPrecioDesc.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoPrecioDesc.Model as IEnumerable<Concierto>);
            Assert.AreEqual(5, (resultadoPrecioDesc.Model as IEnumerable<Concierto>).Count());

            var resultadoPrecio = await controller.Index("Precio", "") as ViewResult;
            Assert.AreEqual(34, (resultadoPrecio.Model as IEnumerable<Concierto>).ElementAt(0).Precio);
            Assert.AreEqual(44, (resultadoPrecio.Model as IEnumerable<Concierto>).ElementAt(1).Precio);
            Assert.AreEqual(55, (resultadoPrecio.Model as IEnumerable<Concierto>).ElementAt(2).Precio);
            Assert.IsInstanceOfType(resultadoPrecio.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoPrecio.Model as IEnumerable<Concierto>);
            Assert.AreEqual(5, (resultadoPrecio.Model as IEnumerable<Concierto>).Count());

            var resultadoTitulo = await controller.Index("", "") as ViewResult;
            Assert.AreEqual("FestivalLondres", (resultadoTitulo.Model as IEnumerable<Concierto>).ElementAt(0).Titulo);
            Assert.AreEqual("FestivalMalaga", (resultadoTitulo.Model as IEnumerable<Concierto>).ElementAt(1).Titulo);
            Assert.AreEqual("FestivalParis", (resultadoTitulo.Model as IEnumerable<Concierto>).ElementAt(2).Titulo);
            Assert.IsInstanceOfType(resultadoTitulo.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoTitulo.Model as IEnumerable<Concierto>);
            Assert.AreEqual(5, (resultadoTitulo.Model as IEnumerable<Concierto>).Count());

            var resultadoTituloDesc = await controller.Index("titulo_desc", "") as ViewResult;
            Assert.AreEqual("FestivalZaragoza", (resultadoTituloDesc.Model as IEnumerable<Concierto>).ElementAt(0).Titulo);
            Assert.AreEqual("FestivalRoma", (resultadoTituloDesc.Model as IEnumerable<Concierto>).ElementAt(1).Titulo);
            Assert.AreEqual("FestivalParis", (resultadoTituloDesc.Model as IEnumerable<Concierto>).ElementAt(2).Titulo);
            Assert.IsInstanceOfType(resultadoTituloDesc.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoTituloDesc.Model as IEnumerable<Concierto>);
            Assert.AreEqual(5, (resultadoTituloDesc.Model as IEnumerable<Concierto>).Count());

            var resultadoFilter = await controller.Index("", "Malaga") as ViewResult;
            var orderFilter = resultadoFilter.Model as IEnumerable<Concierto>;
            Assert.AreEqual(1, orderFilter.Count());
            Assert.AreEqual("FestivalMalaga", orderFilter.ElementAt(0).Titulo);

        }

        [TestMethod()]
        public async Task BIndexConsultaTest()
        {
            var resultadoDesc = await controller.IndexConsulta("lugar_desc") as ViewResult;
            Assert.AreEqual("Zaragoza", (resultadoDesc.Model as IEnumerable<Concierto>).ElementAt(0).Lugar);
            Assert.AreEqual("Roma", (resultadoDesc.Model as IEnumerable<Concierto>).ElementAt(1).Lugar);
            Assert.AreEqual("Malaga", (resultadoDesc.Model as IEnumerable<Concierto>).ElementAt(2).Lugar);
            Assert.IsInstanceOfType(resultadoDesc.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoDesc.Model as IEnumerable<Concierto>);
            Assert.AreEqual(4, (resultadoDesc.Model as IEnumerable<Concierto>).Count());

            var resultadoLugar = await controller.IndexConsulta("Lugar") as ViewResult;
            Assert.AreEqual("Londres", (resultadoDesc.Model as IEnumerable<Concierto>).ElementAt(0).Lugar);
            Assert.AreEqual("Malaga", (resultadoDesc.Model as IEnumerable<Concierto>).ElementAt(1).Lugar);
            Assert.AreEqual("Roma", (resultadoDesc.Model as IEnumerable<Concierto>).ElementAt(2).Lugar);
            Assert.IsInstanceOfType(resultadoLugar.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoLugar.Model as IEnumerable<Concierto>);
            Assert.AreEqual(4, (resultadoLugar.Model as IEnumerable<Concierto>).Count());

            var resultadoGeneroDesc = await controller.IndexConsulta("genero_desc") as ViewResult;
            Assert.AreEqual("rock", (resultadoGeneroDesc.Model as IEnumerable<Concierto>).ElementAt(0).Genero);
            Assert.AreEqual("rock", (resultadoGeneroDesc.Model as IEnumerable<Concierto>).ElementAt(1).Genero);
            Assert.AreEqual("pop", (resultadoGeneroDesc.Model as IEnumerable<Concierto>).ElementAt(2).Genero);
            Assert.IsInstanceOfType(resultadoGeneroDesc.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoGeneroDesc.Model as IEnumerable<Concierto>);
            Assert.AreEqual(4, (resultadoGeneroDesc.Model as IEnumerable<Concierto>).Count());

            var resultadoGenero = await controller.IndexConsulta("Genero") as ViewResult;
            Assert.AreEqual("Metal", (resultadoGenero.Model as IEnumerable<Concierto>).ElementAt(0).Genero);
            Assert.AreEqual("pop", (resultadoGenero.Model as IEnumerable<Concierto>).ElementAt(1).Genero);
            Assert.AreEqual("rock", (resultadoGenero.Model as IEnumerable<Concierto>).ElementAt(2).Genero);
            Assert.IsInstanceOfType(resultadoGenero.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoGenero.Model as IEnumerable<Concierto>);
            Assert.AreEqual(4, (resultadoGenero.Model as IEnumerable<Concierto>).Count());

            var resultadoPrecioDesc = await controller.IndexConsulta("precio_desc") as ViewResult;
            Assert.AreEqual(100, (resultadoPrecioDesc.Model as IEnumerable<Concierto>).ElementAt(0).Precio);
            Assert.AreEqual(77, (resultadoPrecioDesc.Model as IEnumerable<Concierto>).ElementAt(1).Precio);
            Assert.AreEqual(44, (resultadoPrecioDesc.Model as IEnumerable<Concierto>).ElementAt(2).Precio);
            Assert.IsInstanceOfType(resultadoPrecioDesc.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoPrecioDesc.Model as IEnumerable<Concierto>);
            Assert.AreEqual(4, (resultadoPrecioDesc.Model as IEnumerable<Concierto>).Count());

            var resultadoPrecio = await controller.IndexConsulta("Precio") as ViewResult;
            Assert.AreEqual(34, (resultadoPrecio.Model as IEnumerable<Concierto>).ElementAt(0).Precio);
            Assert.AreEqual(44, (resultadoPrecio.Model as IEnumerable<Concierto>).ElementAt(1).Precio);
            Assert.AreEqual(77, (resultadoPrecio.Model as IEnumerable<Concierto>).ElementAt(2).Precio);
            Assert.IsInstanceOfType(resultadoPrecio.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoPrecio.Model as IEnumerable<Concierto>);
            Assert.AreEqual(4, (resultadoPrecio.Model as IEnumerable<Concierto>).Count());

            var resultadoTitulo = await controller.IndexConsulta("") as ViewResult;
            Assert.AreEqual("FestivalLondres", (resultadoTitulo.Model as IEnumerable<Concierto>).ElementAt(0).Titulo);
            Assert.AreEqual("FestivalMalaga", (resultadoTitulo.Model as IEnumerable<Concierto>).ElementAt(1).Titulo);
            Assert.AreEqual("FestivalRoma", (resultadoTitulo.Model as IEnumerable<Concierto>).ElementAt(2).Titulo);
            Assert.IsInstanceOfType(resultadoTitulo.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.IsNotNull(resultadoTitulo.Model as IEnumerable<Concierto>);
            Assert.AreEqual(4, (resultadoTitulo.Model as IEnumerable<Concierto>).Count());

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
        }

        [TestMethod()]
        public async Task EDetailsTest()
        {
            var resultado = await controller.Details(1) as ViewResult;
            var concieroId1 = resultado.Model as Concierto;

            Assert.IsInstanceOfType(concieroId1, typeof(Concierto));
            Assert.AreEqual("Zaragoza", concieroId1.Lugar);

            var lista = (await controller.Index("", "") as ViewResult).Model as IEnumerable<Concierto>;
            int id = lista.FirstOrDefault(x => x.Lugar.Equals("Prueba")).Id + 10;

            try
            {
                var error = (await controller.Details(id) as ViewResult).Model as Concierto;
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

            var lista = (await controller.Index("", "") as ViewResult).Model as IEnumerable<Concierto>;
            int id = lista.FirstOrDefault(x => x.Lugar.Equals("Prueba")).Id + 10;

            try
            {
                var error = (await controller.Edit(id) as ViewResult).Model as Concierto;
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

            //Concierto concierto = new Concierto();

            //concierto.Lugar = "Zaragozica";
            //concierto.Titulo = "Pilares 2020";
            //concierto.Id = 1;
            //concierto.Precio = 253;
            //concierto.Genero = "Rock";
            //concierto.Fecha = DateTime.Now;
            ////20200512

            //await controller.Edit(1, concierto);

            //var resultado = await controller.Details(1) as ViewResult;
            //Assert.IsInstanceOfType(resultado.Model as Concierto, typeof(Concierto)); ;
            //Assert.AreEqual("Zaragozica", (resultado.Model as Concierto).Lugar);
            //Assert.AreEqual("Pilares 2020", (resultado.Model as Concierto).Titulo);
            //Assert.AreEqual(253, (resultado.Model as Concierto).Precio);

            var lista = (await controller.Index("", "") as ViewResult).Model as IEnumerable<Concierto>;
            int id = lista.FirstOrDefault(x => x.Lugar.Equals("Prueba")).Id;

            Concierto concierto2 = new Concierto();

            concierto2.Lugar = "Prueba";
            concierto2.Titulo = "Titulo";
            concierto2.Precio = 30;
            concierto2.Id = id;
            concierto2.Genero = "Prueba";
            concierto2.Fecha = DateTime.Now;

            await controller.Edit(id, concierto2);

            var resultadoId = await controller.Details(id) as ViewResult;
            Assert.IsInstanceOfType(resultadoId.Model as Concierto, typeof(Concierto)); ;
            Assert.AreEqual("Prueba", (resultadoId.Model as Concierto).Lugar);
            Assert.AreEqual("Titulo", (resultadoId.Model as Concierto).Titulo);
            Assert.AreEqual(30, (resultadoId.Model as Concierto).Precio);
        }

        [TestMethod()]
        public async Task ExistTest()
        {
            var lista = (await controller.Index("", "") as ViewResult).Model as IEnumerable<Concierto>;
            int id = lista.FirstOrDefault(x => x.Lugar.Equals("Prueba")).Id + 11;
            Assert.AreEqual(true, await controller.ConciertoExists(1));
            Assert.AreEqual(false, await controller.ConciertoExists(id));
        }

        [TestMethod()]
        public async Task HDeleteTest()
        {
            var resultado = await controller.Delete(1) as ViewResult;
            var concieroId1 = resultado.Model as Concierto;

            Assert.IsInstanceOfType(concieroId1, typeof(Concierto));
            Assert.AreEqual("Zaragoza", concieroId1.Lugar);

            var lista = (await controller.Index("", "") as ViewResult).Model as IEnumerable<Concierto>;
            int id = lista.FirstOrDefault(x => x.Lugar.Equals("Prueba")).Id + 10;

            try
            {
                var error = (await controller.Delete(id) as ViewResult).Model as Concierto;
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error capturado en Test Delete");
            }
        }

        [TestMethod()]
        public async Task IDeleteConfirmedTest()
        {
            var lista = (await controller.Index("", "") as ViewResult).Model as IEnumerable<Concierto>;
            int id = lista.FirstOrDefault(x => x.Lugar.Equals("Prueba")).Id;

            var resultado = await controller.Details(id) as ViewResult;
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
    }
}