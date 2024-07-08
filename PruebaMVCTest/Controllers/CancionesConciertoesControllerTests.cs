using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class CancionesConciertoesControllerTests
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .AddEnvironmentVariables()
                .Build();
            return config;
        }

        private CancionesConciertoesController controller = new CancionesConciertoesController(new EFGenericRepositorio<CancionesConcierto> (InitConfiguration()),
        new EFGenericRepositorio<Cancione>(InitConfiguration()),
        new EFGenericRepositorio<Concierto> (InitConfiguration()),
        new EFGenericRepositorio<VistaCancionConcierto> (InitConfiguration()));

        [TestMethod()]
        public async Task AIndexTestDefault()
        {
            var resultado = await controller.Index("") as ViewResult;
            Assert.IsInstanceOfType(resultado.Model as List<VistaCancionConcierto>, typeof(List<VistaCancionConcierto>));
            Assert.IsNotNull(resultado.Model as List<VistaCancionConcierto>);
            Assert.AreEqual(11, (resultado.Model as List<VistaCancionConcierto>).Count());
            Assert.AreEqual(null, resultado.ViewName); 
        }
        [TestMethod()]
        public async Task AIndexTestTitiloCancionest()
        {
            var resultadoTC = await controller.Index("TituloCanciones") as ViewResult;
            Assert.AreEqual("Ignite", (resultadoTC.Model as List<VistaCancionConcierto>).ElementAt(0).TituloCanciones);
            Assert.AreEqual("Ignite", (resultadoTC.Model as List<VistaCancionConcierto>).ElementAt(1).TituloCanciones);
            Assert.AreEqual("Ignite", (resultadoTC.Model as List<VistaCancionConcierto>).ElementAt(2).TituloCanciones);
            Assert.IsInstanceOfType(resultadoTC.Model as List<VistaCancionConcierto>, typeof(List<VistaCancionConcierto>));
            Assert.IsNotNull(resultadoTC.Model as List<VistaCancionConcierto>);
            Assert.AreEqual(11, (resultadoTC.Model as List<VistaCancionConcierto>).Count());
        }
        [TestMethod()]
        public async Task AIndexTestTitiloCancionestDesc()
        {
            var resultadoCancionesDesc = await controller.Index("canciones_desc") as ViewResult;
            Assert.AreEqual("Trois", (resultadoCancionesDesc.Model as List<VistaCancionConcierto>).ElementAt(0).TituloCanciones);
            Assert.AreEqual("Trois", (resultadoCancionesDesc.Model as List<VistaCancionConcierto>).ElementAt(1).TituloCanciones);
            Assert.AreEqual("Trois", (resultadoCancionesDesc.Model as List<VistaCancionConcierto>).ElementAt(2).TituloCanciones);
            Assert.IsInstanceOfType(resultadoCancionesDesc.Model as List<VistaCancionConcierto>, typeof(List<VistaCancionConcierto>));
            Assert.IsNotNull(resultadoCancionesDesc.Model as List<VistaCancionConcierto>);
            Assert.AreEqual(11, (resultadoCancionesDesc.Model as List<VistaCancionConcierto>).Count());
        }
        [TestMethod()]
        public async Task AIndexTestTitiloTitulo()
        {
            var resultadoTitulo = await controller.Index("Titulo") as ViewResult;
            Assert.AreEqual("FestivalLondres", (resultadoTitulo.Model as List<VistaCancionConcierto>).ElementAt(0).Titulo);
            Assert.AreEqual("FestivalLondres", (resultadoTitulo.Model as List<VistaCancionConcierto>).ElementAt(1).Titulo);
            Assert.AreEqual("FestivalMalaga", (resultadoTitulo.Model as List<VistaCancionConcierto>).ElementAt(2).Titulo);
            Assert.IsInstanceOfType(resultadoTitulo.Model as List<VistaCancionConcierto>, typeof(List<VistaCancionConcierto>));
            Assert.IsNotNull(resultadoTitulo.Model as List<VistaCancionConcierto>);
            Assert.AreEqual(11, (resultadoTitulo.Model as List<VistaCancionConcierto>).Count());
        }
        [TestMethod()]
        public async Task AIndexTestTitiloTituloDesc()
        {
            var resultadoTituloDesc = await controller.Index("titulo_desc") as ViewResult;
            Assert.AreEqual("FestivalZaragoza", (resultadoTituloDesc.Model as List<VistaCancionConcierto>).ElementAt(0).Titulo);
            Assert.AreEqual("FestivalZaragoza", (resultadoTituloDesc.Model as List<VistaCancionConcierto>).ElementAt(1).Titulo);
            Assert.AreEqual("FestivalZaragoza", (resultadoTituloDesc.Model as List<VistaCancionConcierto>).ElementAt(2).Titulo);
            Assert.IsInstanceOfType(resultadoTituloDesc.Model as List<VistaCancionConcierto>, typeof(List<VistaCancionConcierto>));
            Assert.IsNotNull(resultadoTituloDesc.Model as List<VistaCancionConcierto>);
            Assert.AreEqual(11, (resultadoTituloDesc.Model as List<VistaCancionConcierto>).Count());
        }
        [TestMethod()]
        public async Task BCreateTest1()
        {
            CancionesConcierto concierto = new CancionesConcierto();

            concierto.ConciertosId = 1;
            concierto.CancionesId = 4;

            await controller.Create(concierto);

            var lista = await controller.getCancionesConciertoContext().DameTodos();
            int id = lista.FirstOrDefault(x => x.CancionesId == 4 && x.ConciertosId == 1).Id;

            var resultado = await controller.Details(id) as ViewResult;
            Assert.IsInstanceOfType(resultado.Model as VistaCancionConcierto, typeof(VistaCancionConcierto));
            Assert.AreEqual("Zaragoza", (resultado.Model as VistaCancionConcierto).Lugar);
            Assert.AreEqual("FestivalZaragoza", (resultado.Model as VistaCancionConcierto).Titulo);

            var concieroId1 = resultado.Model as VistaCancionConcierto;

            Assert.IsInstanceOfType(concieroId1, typeof(VistaCancionConcierto));
            Assert.AreEqual(4, concieroId1.CancionesId);
            Assert.AreEqual(1, concieroId1.ConciertosId);

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
            var conciertoCancionId1 = resultado.Model as VistaCancionConcierto;

            Assert.IsInstanceOfType(conciertoCancionId1, typeof(VistaCancionConcierto));
            Assert.AreEqual("FestivalZaragoza", conciertoCancionId1.Titulo);

            try
            {
                var error = (await controller.Details(1000) as ViewResult).Model as List<VistaCancionConcierto>;
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error capturado en Test Details");
            }
        }

        [TestMethod()]
        public async Task CreateTest()
        {
            var contextCan = (await controller.getCancionesoContext().DameTodos()).OrderBy(x => x.Titulo);
            var contextConci = (await controller.getConciertoContext().DameTodos()).OrderBy(x => x.Titulo);

            Assert.IsInstanceOfType((await controller.Create()) as ViewResult, typeof(ViewResult));
            Assert.IsInstanceOfType(((await controller.Create()) as ViewResult).ViewData["CancionesId"] as SelectList, typeof(SelectList));
            Assert.IsInstanceOfType(((await controller.Create()) as ViewResult).ViewData["ConciertosId"] as SelectList, typeof(SelectList));

            Assert.AreEqual(null, (((await controller.Create()) as ViewResult).ViewData["CancionesId"] as SelectList).Items.GetEnumerator().Current);
            var lista = ((controller).ViewData["CancionesId"] as SelectList).Items.GetEnumerator();
            lista.MoveNext();
            Assert.AreEqual("CancionTest", (lista.Current as Cancione).Titulo);
            lista.MoveNext();
            Assert.AreEqual("Chispas", (lista.Current as Cancione).Titulo);
            lista.MoveNext();
            Assert.AreEqual("Ignite", (lista.Current as Cancione).Titulo);

            Assert.AreEqual(null, ((controller).ViewData["ConciertosId"] as SelectList).Items.GetEnumerator().Current);
            var conciertosLista = ((controller).ViewData["ConciertosId"] as SelectList).Items.GetEnumerator();
            conciertosLista.MoveNext();
            Assert.AreEqual("FestivalLondres", (conciertosLista.Current as Concierto).Titulo);
            lista.MoveNext();
            Assert.AreEqual("FestivalLondres", (conciertosLista.Current as Concierto).Titulo);
            lista.MoveNext();
            Assert.AreEqual("FestivalLondres", (conciertosLista.Current as Concierto).Titulo);
        }

        [TestMethod()]
        public async Task EditTest()
        {
            var resultado = await controller.Details(1) as ViewResult;
            var conciertoCancionId1 = resultado.Model as VistaCancionConcierto;

            Assert.IsInstanceOfType(conciertoCancionId1, typeof(VistaCancionConcierto));
            Assert.AreEqual("FestivalZaragoza", conciertoCancionId1.Titulo);

            Assert.IsInstanceOfType(((await controller.Create()) as ViewResult).ViewData["CancionesId"] as SelectList, typeof(SelectList));
            Assert.IsInstanceOfType(((await controller.Create()) as ViewResult).ViewData["ConciertosId"] as SelectList, typeof(SelectList));

            Assert.AreEqual(null, (((await controller.Create()) as ViewResult).ViewData["CancionesId"] as SelectList).Items.GetEnumerator().Current);
            var lista = ((controller).ViewData["CancionesId"] as SelectList).Items.GetEnumerator();
            lista.MoveNext();
            Assert.AreEqual("CancionTest", (lista.Current as Cancione).Titulo);
            lista.MoveNext();
            Assert.AreEqual("Chispas", (lista.Current as Cancione).Titulo);
            lista.MoveNext();
            Assert.AreEqual("Ignite", (lista.Current as Cancione).Titulo);

            Assert.AreEqual(null, ((controller).ViewData["ConciertosId"] as SelectList).Items.GetEnumerator().Current);
            var conciertosLista = ((controller).ViewData["ConciertosId"] as SelectList).Items.GetEnumerator();
            conciertosLista.MoveNext();
            Assert.AreEqual("FestivalLondres", (conciertosLista.Current as Concierto).Titulo);
            lista.MoveNext();
            Assert.AreEqual("FestivalLondres", (conciertosLista.Current as Concierto).Titulo);
            lista.MoveNext();
            Assert.AreEqual("FestivalLondres", (conciertosLista.Current as Concierto).Titulo);

            CancionesConcierto objeto = new CancionesConcierto();
            objeto.CancionesId = 2;
            objeto.ConciertosId = 3;
            objeto.Id = 15;

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
            CancionesConcierto conciertoCancion = new CancionesConcierto();
            conciertoCancion.CancionesId = 2;
            conciertoCancion.ConciertosId = 3;
            var vista = await controller.Edit(10, conciertoCancion);
        }

        [TestMethod()]
        public async Task HEditTest1()
        {
            var result = await controller.Edit(1) as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model as VistaCancionConcierto, typeof(VistaCancionConcierto));
            Assert.AreEqual("Take Over", (result.Model as VistaCancionConcierto).TituloCanciones);
        }

        [TestMethod()]
        public async Task IDeleteTest()
        {
            var resultado = await controller.Delete(1) as ViewResult;
            var concieroId1 = resultado.Model as VistaCancionConcierto;

            Assert.IsInstanceOfType(concieroId1, typeof(VistaCancionConcierto));
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

        [TestMethod()]
        public async Task ZExistTest()
        {
            Assert.AreEqual(true, await controller.CancionesConciertoExists(1));
            Assert.AreEqual(false, await controller.CancionesConciertoExists(1000));
        }
    }
}