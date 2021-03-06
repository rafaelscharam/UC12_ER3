using Chapter.WebApi.Controlers;
using Chapter.WebApi.Interfaces;
using Chapter.WebApi.Models;
using Chapter.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TesteXUnit
{
    public class LoginControllerTest
    {
        [Fact]
        public void LoginController_Retornar_UsuarioInvalido()
        {   
            //Arrange
            var repositorioFalso = new Mock<IUsuarioRepository>();
            repositorioFalso.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns((Usuario)null);

            LoginViewModel dadosUsuario = new LoginViewModel();
            dadosUsuario.email = "email123@gmail.com";
            dadosUsuario.senha = "123456";

            var controller = new LoginController(repositorioFalso.Object);

            //Act
             var resultado = controller.Login(dadosUsuario);

            //Assert

            Assert.IsType<UnauthorizedObjectResult>(resultado);

        }

        [Fact]
        public void LoginController_Retornar_Usuario()
        {
            //Arrange
            string issuerValidacao = "Chapter.WebApi";

            Usuario usuarioFalso = new Usuario();
            usuarioFalso.Email = "email123@gmail.com";
            usuarioFalso.Senha = "123456";

            var repositorioFalso = new Mock<IUsuarioRepository>();
            repositorioFalso.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(usuarioFalso);

            var controller = new LoginController(repositorioFalso.Object);

            LoginViewModel dadosUsuario = new LoginViewModel();
            dadosUsuario.email = "email123@gmail.com";
            dadosUsuario.senha = "123456";

            //Act
            OkObjectResult resultado = (OkObjectResult)controller.Login(dadosUsuario);

            var token = resultado.Value.ToString().Split(' ')[3];

            var jstHandLer = new JwtSecurityTokenHandler();
            var jwtToken = jstHandLer.ReadJwtToken(token);


            //Assert
            Assert.Equal(issuerValidacao, jwtToken.Issuer);
            Assert.Equal(usuarioFalso.Email, dadosUsuario.email);
            Assert.Equal(usuarioFalso.Senha, dadosUsuario.senha);
        }

    }
}
