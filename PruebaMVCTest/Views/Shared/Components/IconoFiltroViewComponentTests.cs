using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PruebaMVC.Models;
using PruebaMVC.Views.Shared.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMVC.Views.Shared.Components.Tests
{
    [TestClass()]
    public class IconoFiltroViewComponentTests
    {
        [TestMethod()]
        public void InvokeAsyncTest()
        {
            IconoFiltroViewComponent componente = new IconoFiltroViewComponent();
            Assert.IsInstanceOfType(componente.InvokeAsync().Result as ViewViewComponentResult, typeof(Microsoft.AspNetCore.Mvc.ViewComponents.ViewViewComponentResult));
        }
    }
}