using Microsoft.Extensions.Configuration;
using PruebaMVC.Models;
using PruebaMVC.Services.Repositorio;

namespace PruebaMVCTest.Services.Repositorio
{
    [TestClass]
    public class EFGenericRepositiorioTest
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .AddEnvironmentVariables()
                .Build();
            return config;
        }
        private readonly EFGenericRepositorio<Usuario> repositorio = new(InitConfiguration());

        [TestMethod]
        public async Task DameTodosTest()
        {
            var should = await repositorio.DameTodos();
            var expected = new List<Usuario>()
            {
                new Usuario(){Id = 1, Nombre = "Francisco", Email = "frtrj@gmail.com",Contraseña = "franchesco"},
                new Usuario(){Id = 2, Nombre = "Majose", Email = "mjo@gmail.com",Contraseña = "mariajose"},
                new Usuario(){Id = 3, Nombre = "Jose María", Email = "joma@gmail.com",Contraseña = "chema"},
                new Usuario(){Id = 5, Nombre = "Anggeld", Email = "angd@gmail.com",Contraseña = "anggeld"}

            };
            Assert.IsNotNull(should);
            Assert.AreEqual(expected.Count(), should.Count());
        }
        [TestMethod]
        public async Task DameUnoTest()
        {
            var should = await repositorio.DameUno(1);
            var expected = new Usuario() { Id = 1, Nombre = "Francisco", Email = "frtrj@gmail.com", Contraseña = "franchesco" };

            Assert.IsNotNull(should);
            Assert.AreEqual(expected.Id, should.Id);
        }

        [TestMethod]
        public async Task AgregarModificarYBorrarTest()
        {
            //Agregar
            Usuario usuario = new() { Nombre = "Prueba", Email = "fake@gmail.com", Contraseña = "prueba" };
            Assert.IsNotNull(usuario);
            await repositorio.Agregar(usuario);
            Assert.AreEqual(usuario, await repositorio.DameUno(usuario.Id));

            //Modificar
            Assert.AreEqual("Prueba", usuario.Nombre);
            usuario.Nombre = "PruebaMod";
            await repositorio.Modificar(usuario.Id, usuario);
            Assert.AreEqual("PruebaMod", usuario.Nombre);

            //Borrar
            await repositorio.Borrar(usuario.Id);
            Assert.IsNull(await repositorio.DameUno(usuario.Id));
        }
    }
}
