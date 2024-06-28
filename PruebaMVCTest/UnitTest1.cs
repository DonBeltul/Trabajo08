using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using PruebaMVC.Models;
using System.Configuration;

namespace PruebaMVCTest
{
    [TestClass]
    public class UnitTest1
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .AddEnvironmentVariables()
                .Build();
            return config;
        }


        //[TestMethod()]
        //public void TestContexto()
        //{
        //    IConfiguration config = InitConfiguration();
        //    GrupoCContext contexto = new(config);
        //    Assert.AreEqual(contexto.Albumes.Count(),7);
        //    Assert.IsNotNull(contexto);


        //}
       

    }
}