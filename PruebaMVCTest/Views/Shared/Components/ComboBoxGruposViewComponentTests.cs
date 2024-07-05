using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PruebaMVC.Models;
using PruebaMVC.Services.Repositorio;
using PruebaMVC.Views.Shared.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMVC.Views.Shared.Components.Tests
{
    [TestClass()]
    public class ComboBoxGruposViewComponentTests
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .AddEnvironmentVariables()
                .Build();
            return config;
        }

        //ComboBoxGruposViewComponent component = new ComboBoxGruposViewComponent(new EFGenericRepositorio<Grupo>(InitConfiguration()));

        [TestMethod()]
        public async Task InvokeAsyncTest()
        {
            ComboBoxGruposViewComponent component = new ComboBoxGruposViewComponent(new EFGenericRepositorio<Grupo>(InitConfiguration()));

            Assert.IsInstanceOfType(((await component.InvokeAsync()) as ViewViewComponentResult).ViewData.Model as IEnumerable<Grupo>, typeof(IEnumerable<Grupo>));
            Assert.AreEqual("Metallica", (((await component.InvokeAsync()) as ViewViewComponentResult).ViewData.Model as IEnumerable<Grupo>).ElementAt(0).Nombre);
            Assert.AreEqual("Boney M.", (((await component.InvokeAsync()) as ViewViewComponentResult).ViewData.Model as IEnumerable<Grupo>).ElementAt(1).Nombre);
            Assert.AreEqual("Nirvana", (((await component.InvokeAsync()) as ViewViewComponentResult).ViewData.Model as IEnumerable<Grupo>).ElementAt(2).Nombre);
            Assert.AreEqual(5, (((await component.InvokeAsync()) as ViewViewComponentResult).ViewData.Model as IEnumerable<Grupo>).Count());
        }
    }
}