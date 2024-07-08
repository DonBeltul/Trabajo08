using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PruebaMVC.Models;
using PruebaMVC.ViewModel;
using PruebaMVC.Services.Repositorio;
using PruebaMVC.Views.Shared.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMVC.Views.Shared.Components.Tests
{
    [TestClass()]
    public class TarjetaConciertoViewComponentTests
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .AddEnvironmentVariables()
                .Build();
            return config;
        }

        [TestMethod()]
        public async Task InvokeAsyncTest()
        {
            TarjetaConciertoViewComponent component = new TarjetaConciertoViewComponent(new EFGenericRepositorio<Concierto>(InitConfiguration()),
                new EFGenericRepositorio<ConciertosGrupo>(InitConfiguration()), new EFGenericRepositorio<Grupo>(InitConfiguration()));

            Assert.IsInstanceOfType(((await component.InvokeAsync()) as ViewViewComponentResult).ViewData.Model as ConciertoConListaGrupos, typeof(ConciertoConListaGrupos));
            Assert.AreEqual("Zaragoza", (((await component.InvokeAsync(1)) as ViewViewComponentResult).ViewData.Model as ConciertoConListaGrupos).Lugar);
            Assert.AreEqual("Roma", (((await component.InvokeAsync(2)) as ViewViewComponentResult).ViewData.Model as ConciertoConListaGrupos).Lugar);
            Assert.AreEqual("Londres", (((await component.InvokeAsync(3)) as ViewViewComponentResult).ViewData.Model as ConciertoConListaGrupos).Lugar);

            Assert.AreEqual("Nirvana", (((await component.InvokeAsync(1)) as ViewViewComponentResult).ViewData.Model as ConciertoConListaGrupos).listaGrupo.ElementAt(0).Nombre);
            Assert.AreEqual("Boney M.", (((await component.InvokeAsync(2)) as ViewViewComponentResult).ViewData.Model as ConciertoConListaGrupos).listaGrupo.ElementAt(1).Nombre);

            Assert.AreEqual("Nirvana", (((await component.InvokeAsync(1)) as ViewViewComponentResult).ViewData.Model as ConciertoConListaGrupos).listaGrupo.ElementAt(0).Nombre);
            Assert.AreEqual("Boney M.", (((await component.InvokeAsync(2)) as ViewViewComponentResult).ViewData.Model as ConciertoConListaGrupos).listaGrupo.ElementAt(1).Nombre);
        }
    }
}