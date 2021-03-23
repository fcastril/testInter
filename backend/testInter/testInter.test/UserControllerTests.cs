using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using testInter.Data;
using testInter.Service;
using testInter.Repo;
using testInter.WebAPI.Controllers;
using System;
using System.Net.Http;
using Moq;
using Microsoft.EntityFrameworkCore;
using System.Web.Http;
using testInter.Repo.Security;

namespace testInter.test
{

    
    [TestClass]
    public class UserControllerTests
    {


        [TestMethod]
        public void GetUser_ReturnOK_AllRegisters()
        {
            #region Arrange
            List<User> listUser = new List<User>();
            User User = new User { Id = 1, Email = "login1@dominio.com", Password = "Abcd1234" };
            listUser.Add(User);
            User = new User { Id = 2, Email = "login2@dominio.com", Password = "Abcd1234" };
            listUser.Add(User);
            User = new User { Id = 3, Email = "login3@dominio.com", Password = "Abcd1234" };
            listUser.Add(User);

            var mockUsuarios = new Mock<IUserService>();
            mockUsuarios.Setup(sp => sp.GetUsers()).Returns(listUser);

            var userController = new UserController(mockUsuarios.Object);
            #endregion


            #region Act
            var response = userController.GetUser();

            #endregion

            #region Assert
            // The 'Response' is of type OkResult and returns an Object (OkObjectResult)..
            //The Object returned by the OkResult is of type IEnumerable<Country>.
            Assert.IsInstanceOfType((response as OkObjectResult).Value, typeof(IEnumerable<User>));
            #endregion
        }
        [TestMethod]
        public void PostUser_ReturnOK()
        {
            #region Arrange
            
            User User = new User { Id = 4, Email = Crypto.Encrypt("login4@dominio.com"), Password = Crypto.Encrypt("Abcd1234") };


            var mockUsuarios = new Mock<IUserService>();
            mockUsuarios.Setup(sp => sp.InsertUser(User)).Verifiable();

            var userController = new UserController(mockUsuarios.Object);
            #endregion


            #region Act
            IActionResult actionResult = userController.PostUser(User);
            #endregion

            #region Assert
            // The 'Response' is of type OkResult and returns an Object (OkObjectResult)..
            //The Object returned by the OkResult is of type IEnumerable<Country>.
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
            #endregion
        }
        [TestMethod]
        public void GetUser_ReturnOK ()
        {
            #region Arrange

            int id = 1;
            int idNotFound = 3;
            User User = new User { Id = 1, Email = "login1@dominio.com", Password = "Abcd1234" };

            var mockUsuarios = new Mock<IUserService>();
            mockUsuarios.Setup(sp => sp.GetUser(id)).Returns(User);

            var userController = new UserController(mockUsuarios.Object);
            #endregion


            #region Act
            IActionResult responseOK = userController.GetUser(id);
            IActionResult responseNotFound = userController.GetUser(idNotFound);

            #endregion

            #region Assert
            // The 'Response' is of type OkResult and returns an Object (OkObjectResult)..
            //The Object returned by the OkResult is of type IEnumerable<Country>.
            Assert.AreEqual(((User)(responseOK as OkObjectResult).Value).Id, id);
            Assert.AreNotEqual(((User)(responseOK as OkObjectResult).Value).Id, idNotFound);
            #endregion
        }
    }
}
