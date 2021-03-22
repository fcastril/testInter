using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using testInter.Data;
using testInter.Service;
using testInter.Repo;
using testInter.WebAPI.Controllers;
using System;
using System.Net.Http;

namespace testInter.test
{

    
    [TestClass]
    public class UserControllerTests
    {
        private UserService _userService;
        [TestMethod]
        public void GetUser_ReturnOK_AllRegisters()
        {
            #region Arrange
            var userController = new UserController(_userService);
            #endregion


            #region Act
            var response = userController.GetUser();

            #endregion

            #region Assert
            // The 'Response' is of type OkResult and returns an Object (OkObjectResult)..
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
            //The Object returned by the OkResult is of type IEnumerable<Country>.
            Assert.IsInstanceOfType((response as OkObjectResult).Value, typeof(IEnumerable<User>));
            #endregion
        }
    }
}
