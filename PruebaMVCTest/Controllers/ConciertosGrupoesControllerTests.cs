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
    public class ConciertosGrupoesControllerTests
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .AddEnvironmentVariables()
                .Build();
            return config;
        }

        private ConciertosGrupoesController controller = new ConciertosGrupoesController(new EFGenericRepositorio<ConciertosGrupo>(InitConfiguration()),
        new EFGenericRepositorio<Concierto>(InitConfiguration()),
        new EFGenericRepositorio<Grupo>(InitConfiguration()),
        new EFGenericRepositorio<VistaConciertosGrupo>(InitConfiguration()));

        [TestMethod()]
        public async Task AIndexTest()
        {
            var resultado = await controller.Index("") as ViewResult;
            Assert.IsInstanceOfType(resultado.Model as List<VistaConciertosGrupo>, typeof(List<VistaConciertosGrupo>));
            Assert.IsNotNull(resultado.Model as List<VistaConciertosGrupo>);
            Assert.AreEqual(12, (resultado.Model as List<VistaConciertosGrupo>).Count());
            Assert.AreEqual(null, resultado.ViewName);

            var resultadoTC = await controller.Index("Nombre") as ViewResult;
            Assert.AreEqual("AC/DC", (resultadoTC.Model as List<VistaConciertosGrupo>).ElementAt(0).Nombre);
            Assert.AreEqual("AC/DC", (resultadoTC.Model as List<VistaConciertosGrupo>).ElementAt(1).Nombre);
            Assert.AreEqual("AC/DC", (resultadoTC.Model as List<VistaConciertosGrupo>).ElementAt(2).Nombre);
            Assert.IsInstanceOfType(resultadoTC.Model as List<VistaConciertosGrupo>, typeof(List<VistaConciertosGrupo>));
            Assert.IsNotNull(resultadoTC.Model as List<VistaConciertosGrupo>);
            Assert.AreEqual(12, (resultadoTC.Model as List<VistaConciertosGrupo>).Count());

            var resultadoGruposDesc = await controller.Index("nombre_desc") as ViewResult;
            Assert.AreEqual("Violadores del Verso", (resultadoGruposDesc.Model as List<VistaConciertosGrupo>).ElementAt(0).Nombre);
            Assert.AreEqual("Violadores del Verso", (resultadoGruposDesc.Model as List<VistaConciertosGrupo>).ElementAt(1).Nombre);
            Assert.AreEqual("Nirvana", (resultadoGruposDesc.Model as List<VistaConciertosGrupo>).ElementAt(2).Nombre);
            Assert.IsInstanceOfType(resultadoGruposDesc.Model as List<VistaConciertosGrupo>, typeof(List<VistaConciertosGrupo>));
            Assert.IsNotNull(resultadoGruposDesc.Model as List<VistaConciertosGrupo>);
            Assert.AreEqual(12, (resultadoGruposDesc.Model as List<VistaConciertosGrupo>).Count());

            var resultadoTitulo = await controller.Index("Titulo") as ViewResult;
            Assert.AreEqual("FestivalLondres", (resultadoTitulo.Model as List<VistaConciertosGrupo>).ElementAt(0).Titulo);
            Assert.AreEqual("FestivalLondres", (resultadoTitulo.Model as List<VistaConciertosGrupo>).ElementAt(1).Titulo);
            Assert.AreEqual("FestivalMalaga", (resultadoTitulo.Model as List<VistaConciertosGrupo>).ElementAt(2).Titulo);
            Assert.IsInstanceOfType(resultadoTitulo.Model as List<VistaConciertosGrupo>, typeof(List<VistaConciertosGrupo>));
            Assert.IsNotNull(resultadoTitulo.Model as List<VistaConciertosGrupo>);
            Assert.AreEqual(12, (resultadoTitulo.Model as List<VistaConciertosGrupo>).Count());

            var resultadoTituloDesc = await controller.Index("titulo_desc") as ViewResult;
            Assert.AreEqual("FestivalZaragoza", (resultadoTituloDesc.Model as List<VistaConciertosGrupo>).ElementAt(0).Titulo);
            Assert.AreEqual("FestivalZaragoza", (resultadoTituloDesc.Model as List<VistaConciertosGrupo>).ElementAt(1).Titulo);
            Assert.AreEqual("FestivalRoma", (resultadoTituloDesc.Model as List<VistaConciertosGrupo>).ElementAt(2).Titulo);
            Assert.IsInstanceOfType(resultadoTituloDesc.Model as List<VistaConciertosGrupo>, typeof(List<VistaConciertosGrupo>));
            Assert.IsNotNull(resultadoTituloDesc.Model as List<VistaConciertosGrupo>);
            Assert.AreEqual(12, (resultadoTituloDesc.Model as List<VistaConciertosGrupo>).Count());
        }

        [TestMethod()]
        public async Task DCreateTest1()
        {
            ConciertosGrupo concierto = new ConciertosGrupo();

            concierto.ConciertosId = 1;
            concierto.GruposId = 4;

            await controller.Create(concierto);

            var lista = await controller.getGrupoConciertoContext().DameTodos();
            int id = lista.FirstOrDefault(x => x.GruposId.Equals(4) && x.ConciertosId.Equals(1)).Id;

            var resultado = await controller.Details(id) as ViewResult;
            Assert.IsInstanceOfType(resultado.Model as VistaConciertosGrupo, typeof(VistaConciertosGrupo));
            Assert.AreEqual("Zaragoza", (resultado.Model as VistaConciertosGrupo).Lugar);
            Assert.AreEqual("FestivalZaragoza", (resultado.Model as VistaConciertosGrupo).Titulo);

            var contextGrupo = (await controller.getGrupoContext().DameTodos()).OrderBy(x => x.Nombre);
            var contextConci = (await controller.getConciertoContext().DameTodos()).OrderBy(x => x.Titulo);

            Assert.IsInstanceOfType(contextGrupo, typeof(IOrderedEnumerable<Grupo>));
            Assert.IsInstanceOfType(contextConci, typeof(IOrderedEnumerable<Concierto>));

            Assert.AreEqual("FestivalLondres", contextConci.ElementAt(0).Titulo);
            Assert.AreEqual("FestivalMalaga", contextConci.ElementAt(1).Titulo);
            Assert.AreEqual("FestivalParis", contextConci.ElementAt(2).Titulo);

            Assert.AreEqual("AC/DC", contextGrupo.ElementAt(0).Nombre);
            Assert.AreEqual("Boney M.", contextGrupo.ElementAt(1).Nombre);
            Assert.AreEqual("Metallica", contextGrupo.ElementAt(2).Nombre);
        }

        [TestMethod()]
        public async Task EDetailsTest()
        {
            var resultado = await controller.Details(1) as ViewResult;
            var conciertoGrupoId1 = resultado.Model as VistaConciertosGrupo;

            Assert.IsInstanceOfType(conciertoGrupoId1, typeof(VistaConciertosGrupo));
            Assert.AreEqual("FestivalZaragoza", conciertoGrupoId1.Titulo);

            var lista = await controller.getGrupoConciertoContext().DameTodos();
            int id = lista.FirstOrDefault(x => x.GruposId.Equals(4) && x.ConciertosId.Equals(1)).Id;

            try
            {
                var error = (await controller.Details(id) as ViewResult).Model as List<VistaConciertosGrupo>;
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
            var contextGrupo = (await controller.getGrupoContext().DameTodos()).OrderBy(x => x.Nombre);
            var contextConci = (await controller.getConciertoContext().DameTodos()).OrderBy(x => x.Titulo);

            Assert.IsInstanceOfType(contextGrupo, typeof(IOrderedEnumerable<Grupo>));
            Assert.IsInstanceOfType(contextConci, typeof(IOrderedEnumerable<Concierto>));

            Assert.AreEqual("FestivalLondres", contextConci.ElementAt(0).Titulo);
            Assert.AreEqual("FestivalMalaga", contextConci.ElementAt(1).Titulo);
            Assert.AreEqual("FestivalParis", contextConci.ElementAt(2).Titulo);

            Assert.AreEqual("AC/DC", contextGrupo.ElementAt(0).Nombre);
            Assert.AreEqual("Boney M.", contextGrupo.ElementAt(1).Nombre);
            Assert.AreEqual("Metallica", contextGrupo.ElementAt(2).Nombre);
        }

        [TestMethod()]
        public async Task EditTest()
        {
            var resultado = await controller.Details(1) as ViewResult;
            var conciertoGrupoId1 = resultado.Model as VistaConciertosGrupo;

            Assert.IsInstanceOfType(conciertoGrupoId1, typeof(VistaConciertosGrupo));
            Assert.AreEqual("FestivalZaragoza", conciertoGrupoId1.Titulo);

            var contextGrupo = (await controller.getGrupoContext().DameTodos()).OrderBy(x => x.Nombre);
            var contextConci = (await controller.getConciertoContext().DameTodos()).OrderBy(x => x.Titulo);

            Assert.IsInstanceOfType(contextGrupo, typeof(IOrderedEnumerable<Grupo>));
            Assert.IsInstanceOfType(contextConci, typeof(IOrderedEnumerable<Concierto>));

            Assert.AreEqual("FestivalLondres", contextConci.ElementAt(0).Titulo);
            Assert.AreEqual("FestivalMalaga", contextConci.ElementAt(1).Titulo);
            Assert.AreEqual("FestivalParis", contextConci.ElementAt(2).Titulo);

            Assert.AreEqual("AC/DC", contextGrupo.ElementAt(0).Nombre);
            Assert.AreEqual("Boney M.", contextGrupo.ElementAt(1).Nombre);
            Assert.AreEqual("Metallica", contextGrupo.ElementAt(2).Nombre);
        }

        [TestMethod()]
        public void HEditTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public async Task IDeleteTest()
        {
            var resultado = await controller.Delete(1) as ViewResult;
            var conciertoGrupoId1 = resultado.Model as VistaConciertosGrupo;

            Assert.IsInstanceOfType(conciertoGrupoId1, typeof(VistaConciertosGrupo));
            Assert.AreEqual("FestivalZaragoza", conciertoGrupoId1.Titulo);

            var lista = await controller.getGrupoConciertoContext().DameTodos();
            int id = lista.FirstOrDefault(x => x.GruposId.Equals(4) && x.ConciertosId.Equals(1)).Id;

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
        public async Task JDeleteConfirmedTest()
        {
            var lista = await controller.getGrupoConciertoContext().DameTodos();
            int id = lista.FirstOrDefault(x => x.GruposId.Equals(4) && x.ConciertosId.Equals(1)).Id;

            var resultado = await controller.Delete(id) as ViewResult;
            var conciertoGrupoId1 = resultado.Model as VistaConciertosGrupo;

            Assert.IsInstanceOfType(conciertoGrupoId1, typeof(VistaConciertosGrupo));
            Assert.AreEqual(4, conciertoGrupoId1.GruposId);
            Assert.AreEqual(1, conciertoGrupoId1.ConciertosId);

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
        public async Task ZExistTest()
        {
            Assert.AreEqual(true, await controller.ConciertosGrupoExists(1));
            Assert.AreEqual(false, await controller.ConciertosGrupoExists(100));
        }
        
    }
}