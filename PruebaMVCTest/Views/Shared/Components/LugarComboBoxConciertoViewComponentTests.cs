using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PruebaMVC.Models;
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
    public class LugarComboBoxConciertoViewComponentTests
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
            LugarComboBoxConciertoViewComponent component = new LugarComboBoxConciertoViewComponent(new EFGenericRepositorio<Concierto>(InitConfiguration()));

            Assert.IsInstanceOfType(((await component.InvokeAsync()) as ViewViewComponentResult).ViewData.Model as IEnumerable<Concierto>, typeof(IEnumerable<Concierto>));
            Assert.AreEqual("Zaragoza", (((await component.InvokeAsync()) as ViewViewComponentResult).ViewData.Model as IEnumerable<Concierto>).ElementAt(0).Lugar);
            Assert.AreEqual("Roma", (((await component.InvokeAsync()) as ViewViewComponentResult).ViewData.Model as IEnumerable<Concierto>).ElementAt(1).Lugar);
            Assert.AreEqual("Londres", (((await component.InvokeAsync()) as ViewViewComponentResult).ViewData.Model as IEnumerable<Concierto>).ElementAt(2).Lugar);
            Assert.AreEqual(5, (((await component.InvokeAsync()) as ViewViewComponentResult).ViewData.Model as IEnumerable<Concierto>).Count());
        }
    }
}