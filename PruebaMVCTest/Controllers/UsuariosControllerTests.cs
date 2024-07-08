using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PruebaMVC.Models;
using PruebaMVC.Services.Repositorio;

namespace PruebaMVC.Controllers.Tests
{
    [TestClass()]
    public class UsuariosControllerTests
    {
        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .AddEnvironmentVariables()
                .Build();
            return config;
        }

        public UsuariosController Ucontroller = new(new EFGenericRepositorio<Usuario>(InitConfiguration()));

        [TestMethod()]
        public async Task IndexTest()
        {
            var resultado = await Ucontroller.Index("", "") as ViewResult;
            Assert.IsInstanceOfType(resultado.Model as IEnumerable<Usuario>, typeof(IEnumerable<Usuario>));
            Assert.IsNotNull(resultado.Model as IEnumerable<Usuario>);
            Assert.AreEqual(4, (resultado.Model as IEnumerable<Usuario>).Count());
            Assert.AreEqual(null, resultado.ViewName);

            var resultadoNombre = await Ucontroller.Index("Nombre", "") as ViewResult;
            Assert.AreEqual("Anggeld", (resultadoNombre.Model as IEnumerable<Usuario>).ElementAt(0).Nombre);
            Assert.AreEqual("Francisco", (resultadoNombre.Model as IEnumerable<Usuario>).ElementAt(1).Nombre);
            Assert.AreEqual("Jose María", (resultadoNombre.Model as IEnumerable<Usuario>).ElementAt(2).Nombre);
            Assert.AreEqual("Majose", (resultadoNombre.Model as IEnumerable<Usuario>).ElementAt(3).Nombre);
            Assert.IsInstanceOfType(resultadoNombre.Model as IEnumerable<Usuario>, typeof(IEnumerable<Usuario>));
            Assert.IsNotNull(resultadoNombre.Model as IEnumerable<Usuario>);
            Assert.AreEqual(4, (resultadoNombre.Model as IEnumerable<Usuario>).Count());

            var resultadoNombreDesc = await Ucontroller.Index("Nombre_desc", "") as ViewResult;
            Assert.AreEqual("Anggeld", (resultadoNombreDesc.Model as IEnumerable<Usuario>).ElementAt(0).Nombre);
            Assert.AreEqual("Francisco", (resultadoNombreDesc.Model as IEnumerable<Usuario>).ElementAt(1).Nombre);
            Assert.AreEqual("Jose María", (resultadoNombreDesc.Model as IEnumerable<Usuario>).ElementAt(2).Nombre);
            Assert.AreEqual("Majose", (resultadoNombreDesc.Model as IEnumerable<Usuario>).ElementAt(3).Nombre);
            Assert.IsInstanceOfType(resultadoNombreDesc.Model as IEnumerable<Usuario>, typeof(IEnumerable<Usuario>));
            Assert.IsNotNull(resultadoNombreDesc.Model as IEnumerable<Usuario>);
            Assert.AreEqual(4, (resultadoNombreDesc.Model as IEnumerable<Usuario>).Count());

            var resultadoEmail = await Ucontroller.Index("Email", "") as ViewResult;
            Assert.AreEqual("ang@gmail.com", (resultadoEmail.Model as IEnumerable<Usuario>).ElementAt(0).Email);
            Assert.AreEqual("frtrj@gmail.com", (resultadoEmail.Model as IEnumerable<Usuario>).ElementAt(1).Email);
            Assert.AreEqual("joma@gmail.com", (resultadoEmail.Model as IEnumerable<Usuario>).ElementAt(2).Email);
            Assert.AreEqual("mjo@gmail.com", (resultadoEmail.Model as IEnumerable<Usuario>).ElementAt(3).Email);
            Assert.IsInstanceOfType(resultadoEmail.Model as IEnumerable<Usuario>, typeof(IEnumerable<Usuario>));
            Assert.IsNotNull(resultadoEmail.Model as IEnumerable<Usuario>);
            Assert.AreEqual(4, (resultadoEmail.Model as IEnumerable<Usuario>).Count());

            var resultadoEmailDesc = await Ucontroller.Index("Email_desc", "") as ViewResult;
            Assert.AreEqual("mjo@gmail.com", (resultadoEmailDesc.Model as IEnumerable<Usuario>).ElementAt(3).Email);
            Assert.AreEqual("joma@gmail.com", (resultadoEmailDesc.Model as IEnumerable<Usuario>).ElementAt(2).Email);
            Assert.AreEqual("frtrj@gmail.com", (resultadoEmailDesc.Model as IEnumerable<Usuario>).ElementAt(1).Email);
            Assert.AreEqual("ang@gmail.com", (resultadoEmailDesc.Model as IEnumerable<Usuario>).ElementAt(0).Email);
            Assert.IsInstanceOfType(resultadoEmailDesc.Model as IEnumerable<Usuario>, typeof(IEnumerable<Usuario>));
            Assert.IsNotNull(resultadoEmailDesc.Model as IEnumerable<Usuario>);
            Assert.AreEqual(4, (resultadoEmailDesc.Model as IEnumerable<Usuario>).Count());

            var resultadoContrasena = await Ucontroller.Index("Contraseña_desc", "") as ViewResult;
            Assert.AreEqual("angeld", (resultadoContrasena.Model as IEnumerable<Usuario>).ElementAt(0).Contraseña);
            Assert.AreEqual("franchesco", (resultadoContrasena.Model as IEnumerable<Usuario>).ElementAt(1).Contraseña);
            Assert.AreEqual("chema", (resultadoContrasena.Model as IEnumerable<Usuario>).ElementAt(2).Contraseña);
            Assert.AreEqual("mariajose", (resultadoContrasena.Model as IEnumerable<Usuario>).ElementAt(3).Contraseña);
            Assert.IsInstanceOfType(resultadoContrasena.Model as IEnumerable<Usuario>, typeof(IEnumerable<Usuario>));
            Assert.IsNotNull(resultadoContrasena.Model as IEnumerable<Usuario>);
            Assert.AreEqual(4, (resultadoContrasena.Model as IEnumerable<Usuario>).Count());

            var resultadoContrasenaDesc = await Ucontroller.Index("Contraseña", "") as ViewResult;
            Assert.AreEqual("mariajose", (resultadoContrasenaDesc.Model as IEnumerable<Usuario>).ElementAt(3).Contraseña);
            Assert.AreEqual("franchesco", (resultadoContrasenaDesc.Model as IEnumerable<Usuario>).ElementAt(2).Contraseña);
            Assert.AreEqual("chema", (resultadoContrasenaDesc.Model as IEnumerable<Usuario>).ElementAt(1).Contraseña);
            Assert.AreEqual("angeld", (resultadoContrasenaDesc.Model as IEnumerable<Usuario>).ElementAt(0).Contraseña);
            Assert.IsInstanceOfType(resultadoContrasenaDesc.Model as IEnumerable<Usuario>, typeof(IEnumerable<Usuario>));
            Assert.IsNotNull(resultadoContrasenaDesc.Model as IEnumerable<Usuario>);
            Assert.AreEqual(4, (resultadoContrasenaDesc.Model as IEnumerable<Usuario>).Count());

        }

        [TestMethod()]
        public async Task DetailsTest()
        {
            var resultado = await Ucontroller.Details(1) as ViewResult;
            var usuario = resultado.Model as Usuario;

            Assert.IsInstanceOfType(usuario, typeof(Usuario));
            Assert.AreEqual("Francisco", usuario.Nombre);

            var lista = (await Ucontroller.Index("", "") as ViewResult).Model as IEnumerable<Usuario>;
            int id = lista.FirstOrDefault(x => x.Nombre.Equals("Francisco")).Id;

            try
            {
                var error = (await Ucontroller.Details(id) as ViewResult).Model as Usuario;
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
            var resultado = Ucontroller.Create() as ViewResult;
            Assert.AreEqual(null, resultado.Model);
        }

        [TestMethod()]
        public async Task CreateTest1()
        {
            Usuario usuario = new Usuario();

            usuario.Nombre = "Pepe";
            usuario.Email = "pepe@gmail.com";
            usuario.Contraseña = "pepepepe";

            await Ucontroller.Create(usuario);

            var lista = (await Ucontroller.Index("", "") as ViewResult).Model as IEnumerable<Usuario>;
            int id = lista.FirstOrDefault(x => x.Nombre.Equals("Pepe")).Id;

            var resultado = await Ucontroller.Details(id) as ViewResult;
            Assert.IsInstanceOfType(resultado.Model as Usuario, typeof(Usuario));
            Assert.AreEqual("Pepe", (resultado.Model as Usuario).Nombre);
            Assert.AreEqual("pepe@gmail.com", (resultado.Model as Usuario).Email);
            Assert.AreEqual("pepepepe", (resultado.Model as Usuario).Contraseña);

            await Ucontroller.Delete(id);
            await Ucontroller.DeleteConfirmed(id);
        }

        [TestMethod()]
        public void EditTest()
        {
            var result = Ucontroller.Edit(4).Result as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public async Task EditTest1()
        {
            var lista = (await Ucontroller.Index("", "") as ViewResult).Model as IEnumerable<Usuario>;
            int id = lista.FirstOrDefault(x => x.Nombre.Equals("Francisco")).Id;

            Usuario usuario1 = new Usuario();

            usuario1.Id = 35;
            usuario1.Nombre = "Pepe";
            usuario1.Email = "pepe@gmail.com";
            usuario1.Contraseña = "pepepepe";

            await Ucontroller.Edit(id, usuario1);

            var resultadoId = await Ucontroller.Details(id) as ViewResult;
            Assert.IsInstanceOfType(resultadoId.Model as Usuario, typeof(Usuario));

        }

        [TestMethod()]
        public async Task DeleteTest()
        {
            var lista = (await Ucontroller.Index("", "") as ViewResult).Model as IEnumerable<Usuario>;
            int id = lista.FirstOrDefault(x => x.Nombre.Equals("Francisco")).Id;

            var resultado = await Ucontroller.Delete(id) as ViewResult;
            var usuario1 = resultado.Model as Usuario;

            Assert.IsInstanceOfType(usuario1, typeof(Usuario));
            Assert.AreEqual("Francisco", usuario1.Nombre);

            try
            {
                var error = (await Ucontroller.Delete(id) as ViewResult).Model as Usuario;
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error capturado en Test Delete");
            }
        }

        
    }
}