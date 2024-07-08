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

        public AlbumesController Acontroller = new(new EFGenericRepositorio<Albume>(InitConfiguration()),
            new EFGenericRepositorio<Grupo>(InitConfiguration()));

        [TestMethod]
        public async Task IndexTest()
        {
            var resultado = await Acontroller.Index("", "") as ViewResult;
            Assert.IsInstanceOfType(resultado.Model as IEnumerable<Albume>, typeof(IEnumerable<Albume>));
            Assert.IsNotNull(resultado.Model as IEnumerable<Albume>);
            Assert.AreEqual(5, (resultado.Model as IEnumerable<Albume>).Count());
            Assert.AreEqual(null, resultado.ViewName);
        }

        [TestMethod()]
        public async Task IndexTestGenero()
        {

            var resultadoGenero = await Acontroller.Index("Genero", "") as ViewResult;
            Assert.AreEqual("Grunge ", (resultadoGenero.Model as IEnumerable<Albume>).ElementAt(0).Genero);
            Assert.AreEqual("Hard Rock", (resultadoGenero.Model as IEnumerable<Albume>).ElementAt(1).Genero);
            Assert.AreEqual("Heavy Metal", (resultadoGenero.Model as IEnumerable<Albume>).ElementAt(2).Genero);
            Assert.AreEqual("Rap", (resultadoGenero.Model as IEnumerable<Albume>).ElementAt(3).Genero);
            Assert.AreEqual("Rock", (resultadoGenero.Model as IEnumerable<Albume>).ElementAt(4).Genero);
            Assert.IsInstanceOfType(resultadoGenero.Model as IEnumerable<Albume>, typeof(IEnumerable<Albume>));
            Assert.IsNotNull(resultadoGenero.Model as IEnumerable<Albume>);
            Assert.AreEqual(5, (resultadoGenero.Model as IEnumerable<Albume>).Count());
        }
        [TestMethod]
        public async Task IndexTestTitulo()
        {
            var resultadoTitulo = await Acontroller.Index("Titulo", "") as ViewResult;
            Assert.AreEqual("Highway to Hell", (resultadoTitulo.Model as IEnumerable<Albume>).ElementAt(0).Titulo);
            Assert.AreEqual("Master of Puppets", (resultadoTitulo.Model as IEnumerable<Albume>).ElementAt(1).Titulo);
            Assert.AreEqual("Nevermind", (resultadoTitulo.Model as IEnumerable<Albume>).ElementAt(2).Titulo);
            Assert.AreEqual("Sultans of Swing", (resultadoTitulo.Model as IEnumerable<Albume>).ElementAt(3).Titulo);
            Assert.AreEqual("Vivir para Contarlo", (resultadoTitulo.Model as IEnumerable<Albume>).ElementAt(4).Titulo);
            Assert.IsInstanceOfType(resultadoTitulo.Model as IEnumerable<Albume>, typeof(IEnumerable<Albume>));
            Assert.IsNotNull(resultadoTitulo.Model as IEnumerable<Albume>);
            Assert.AreEqual(5, (resultadoTitulo.Model as IEnumerable<Albume>).Count());

            var resultadoTituloDesc = await Acontroller.Index("titulo_desc", "") as ViewResult;
            Assert.AreEqual("Highway to Hell", (resultadoTituloDesc.Model as IEnumerable<Albume>).ElementAt(0).Titulo);
            Assert.AreEqual("Master of Puppets", (resultadoTituloDesc.Model as IEnumerable<Albume>).ElementAt(1).Titulo);
            Assert.AreEqual("Nevermind", (resultadoTituloDesc.Model as IEnumerable<Albume>).ElementAt(2).Titulo);
            Assert.AreEqual("Sultans of Swing", (resultadoTitulo.Model as IEnumerable<Albume>).ElementAt(3).Titulo);
            Assert.AreEqual("Vivir para Contarlo", (resultadoTitulo.Model as IEnumerable<Albume>).ElementAt(4).Titulo);
            Assert.IsInstanceOfType(resultadoTituloDesc.Model as IEnumerable<Albume>, typeof(IEnumerable<Albume>));
            Assert.IsNotNull(resultadoTituloDesc.Model as IEnumerable<Albume>);
            Assert.AreEqual(5, (resultadoTituloDesc.Model as IEnumerable<Albume>).Count());
        }
        [TestMethod]
        public async Task IndexTestFecha()
        {
            var resultadoFecha = await Acontroller.Index("Fecha", "") as ViewResult;
            Assert.AreEqual(DateOnly.Parse("1979/07/27"), (resultadoFecha.Model as IEnumerable<Albume>).ElementAt(0).Fecha);
            Assert.AreEqual(DateOnly.Parse("1990/09/10"), (resultadoFecha.Model as IEnumerable<Albume>).ElementAt(1).Fecha);
            Assert.AreEqual(DateOnly.Parse("1991/09/24"), (resultadoFecha.Model as IEnumerable<Albume>).ElementAt(2).Fecha);
            Assert.AreEqual(DateOnly.Parse("1998/10/19"), (resultadoFecha.Model as IEnumerable<Albume>).ElementAt(3).Fecha);
            Assert.AreEqual(DateOnly.Parse("2006/03/05"), (resultadoFecha.Model as IEnumerable<Albume>).ElementAt(4).Fecha);
            Assert.IsInstanceOfType(resultadoFecha.Model as IEnumerable<Albume>, typeof(IEnumerable<Albume>));
            Assert.IsNotNull(resultadoFecha.Model as IEnumerable<Albume>);
            Assert.AreEqual(5, (resultadoFecha.Model as IEnumerable<Albume>).Count());

            var resultadoFechaDesc = await Acontroller.Index("Fecha_desc", "") as ViewResult;
            Assert.AreEqual(DateOnly.Parse("1979/07/27"), (resultadoFecha.Model as IEnumerable<Albume>).ElementAt(0).Fecha);
            Assert.AreEqual(DateOnly.Parse("1990/09/10"), (resultadoFecha.Model as IEnumerable<Albume>).ElementAt(1).Fecha);
            Assert.AreEqual(DateOnly.Parse("1991/09/24"), (resultadoFecha.Model as IEnumerable<Albume>).ElementAt(2).Fecha);
            Assert.AreEqual(DateOnly.Parse("1998/10/19"), (resultadoFecha.Model as IEnumerable<Albume>).ElementAt(3).Fecha);
            Assert.AreEqual(DateOnly.Parse("2006/03/05"), (resultadoFecha.Model as IEnumerable<Albume>).ElementAt(4).Fecha);
            Assert.IsInstanceOfType(resultadoFechaDesc.Model as IEnumerable<Albume>, typeof(IEnumerable<Albume>));
            Assert.IsNotNull(resultadoFechaDesc.Model as IEnumerable<Albume>);
            Assert.AreEqual(5, (resultadoFechaDesc.Model as IEnumerable<Albume>).Count());
        }

        [TestMethod()]
        public async Task IndexConsultaTest()
        {
            var resultado = await Acontroller.IndexConsulta("", "") as ViewResult;
            Assert.IsInstanceOfType(resultado.Model as IEnumerable<Albume>, typeof(IEnumerable<Albume>));
            Assert.IsNotNull(resultado.Model as IEnumerable<Albume>);
            Assert.AreEqual(1, (resultado.Model as IEnumerable<Albume>).Count());
            Assert.AreEqual(null, resultado.ViewName);
        }
        [TestMethod]
        public async Task IndexConsultaTestGenero()
        {
            var resultadoGenero = await Acontroller.IndexConsulta("Genero", "") as ViewResult;
            Assert.AreEqual("Heavy Metal", (resultadoGenero.Model as IEnumerable<Albume>).ElementAt(0).Genero);
            Assert.IsInstanceOfType(resultadoGenero.Model as IEnumerable<Albume>, typeof(IEnumerable<Albume>));
            Assert.IsNotNull(resultadoGenero.Model as IEnumerable<Albume>);
            Assert.AreEqual(1, (resultadoGenero.Model as IEnumerable<Albume>).Count());

            var resultadoGeneroDesc = await Acontroller.IndexConsulta("Genero_desc", "") as ViewResult;
            Assert.AreEqual("Heavy Metal", (resultadoGeneroDesc.Model as IEnumerable<Albume>).ElementAt(0).Genero);
            Assert.IsInstanceOfType(resultadoGeneroDesc.Model as IEnumerable<Albume>, typeof(IEnumerable<Albume>));
            Assert.IsNotNull(resultadoGeneroDesc.Model as IEnumerable<Albume>);
            Assert.AreEqual(1, (resultadoGeneroDesc.Model as IEnumerable<Albume>).Count());
        }
        [TestMethod]
        public async Task IndexConsultaTestTitulo()
        {
            var resultadoTitulo = await Acontroller.IndexConsulta("Titulo", "") as ViewResult;
            Assert.AreEqual("Master of Puppets", (resultadoTitulo.Model as IEnumerable<Albume>).ElementAt(0).Titulo);
            Assert.IsInstanceOfType(resultadoTitulo.Model as IEnumerable<Albume>, typeof(IEnumerable<Albume>));
            Assert.IsNotNull(resultadoTitulo.Model as IEnumerable<Albume>);
            Assert.AreEqual(1, (resultadoTitulo.Model as IEnumerable<Albume>).Count());

            var resultadoTituloDesc = await Acontroller.IndexConsulta("titulo_desc", "") as ViewResult;
            Assert.AreEqual("Master of Puppets", (resultadoTituloDesc.Model as IEnumerable<Albume>).ElementAt(0).Titulo);
            Assert.IsInstanceOfType(resultadoTituloDesc.Model as IEnumerable<Albume>, typeof(IEnumerable<Albume>));
            Assert.IsNotNull(resultadoTituloDesc.Model as IEnumerable<Albume>);
            Assert.AreEqual(1, (resultadoTituloDesc.Model as IEnumerable<Albume>).Count());
        }
        [TestMethod]
        public async Task IndexConsultaTestFecha()
        {
            var resultadoFecha = await Acontroller.Index("Fecha", "") as ViewResult;
            Assert.AreEqual(DateOnly.Parse("1979/07/27"), (resultadoFecha.Model as IEnumerable<Albume>).ElementAt(0).Fecha);
            Assert.IsInstanceOfType(resultadoFecha.Model as IEnumerable<Albume>, typeof(IEnumerable<Albume>));
            Assert.IsNotNull(resultadoFecha.Model as IEnumerable<Albume>);
            Assert.AreEqual(5, (resultadoFecha.Model as IEnumerable<Albume>).Count());

            var resultadoFechaDesc = await Acontroller.IndexConsulta("Fecha_desc", "") as ViewResult;
            Assert.AreEqual(DateOnly.Parse("1990/09/10"), (resultadoFecha.Model as IEnumerable<Albume>).ElementAt(0).Fecha);
            Assert.IsInstanceOfType(resultadoFechaDesc.Model as IEnumerable<Albume>, typeof(IEnumerable<Albume>));
            Assert.IsNotNull(resultadoFechaDesc.Model as IEnumerable<Albume>);
            Assert.AreEqual(1, (resultadoFechaDesc.Model as IEnumerable<Albume>).Count());
        }


        [TestMethod()]
        public async Task DetailsTest()
        {
            var result = Acontroller.Details(7).Result as ViewResult;
            var album = result.Model as Albume;

            Assert.IsInstanceOfType(album, typeof(Albume));
            Assert.AreEqual("Highway to Hell", album.Titulo);

            var lista = (await Acontroller.Index("", "") as ViewResult).Model as IEnumerable<Albume>;
            int id = lista.FirstOrDefault(x => x.Titulo.Equals("Highway to Hell")).Id;

            try
            {
                var error = (await Acontroller.Details(id) as ViewResult).Model as IEnumerable<Albume>;
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
            var result = Acontroller.Create().Result as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public async Task CreateTest1()
        {
            Albume album = new Albume();


            album.Fecha = DateOnly.Parse("2005/10/07");
            album.Genero = "Rock";
            album.Titulo = "Las niñas de la Saye";
            album.GruposId = 1;

            await Acontroller.Create(album);
            var lista = (await Acontroller.Index("", "") as ViewResult).Model as IEnumerable<Albume>;
            int id = lista.FirstOrDefault(x => x.Titulo.Equals("Las niñas de la Saye")).Id;

            var resultado = await Acontroller.Details(id) as ViewResult;
            Assert.IsInstanceOfType(resultado.Model as Albume, typeof(Albume));
            Assert.AreEqual("Las niñas de la Saye", (resultado.Model as Albume).Titulo);
            Assert.AreEqual("Rock", (resultado.Model as Albume).Genero);
            Assert.AreEqual(1, (resultado.Model as Albume).GruposId);
            Assert.AreEqual(DateOnly.Parse("2005/10/07"), (resultado.Model as Albume).Fecha);

        }

        [TestMethod()]
        public void EditTest()
        {
            var result = Acontroller.Edit(7).Result as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public async Task EditTest1()
        {
            var lista = (await Acontroller.Index("", "") as ViewResult).Model as IEnumerable<Albume>;
            int id = lista.FirstOrDefault(x => x.Titulo.Equals("Highway to Hell")).Id;

            Albume album = new Albume();


            album.Fecha = DateOnly.Parse("2005/10/07");
            album.Genero = "Rock";
            album.Titulo = "Las niñas de la Saye";
            album.GruposId = 1;

            await Acontroller.Edit(id, album);

            var resultadoId = await Acontroller.Details(id) as ViewResult;
            Assert.IsInstanceOfType(resultadoId.Model as Albume, typeof(Albume));

        }

        [TestMethod()]
        public async Task DeleteTest()
        {
            var lista = (await Acontroller.Index("", "") as ViewResult).Model as IEnumerable<Albume>;
            int id = lista.FirstOrDefault(x => x.Titulo.Equals("Highway to Hell")).Id;
            var resultado = await Acontroller.Delete(id) as ViewResult;
            var album = resultado.Model as Albume;

            Assert.IsInstanceOfType(album, typeof(Albume));
            Assert.AreEqual("Highway to Hell", album.Titulo);

            try
            {
                var error = (await Acontroller.Delete(id) as ViewResult).Model as Albume;
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
            var lista = (await Acontroller.Index("", "") as ViewResult).Model as IEnumerable<Albume>;
            int id = lista.FirstOrDefault(x => x.Titulo.Equals("Las niñas de la Saye")).Id;

            var resultado = await Acontroller.Details(id) as ViewResult;
            var album = resultado.Model as Albume;

            Assert.IsInstanceOfType(album, typeof(Albume));
            Assert.AreEqual("Las niñas de la Saye", album.Titulo); ;

            await Acontroller.DeleteConfirmed(id);

            try
            {
                var details = await Acontroller.Details(id) as ViewResult;
                Assert.Fail();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error capturado en Test DeleteConfirmed");
            }

        }
    }
}