using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using testInter.Data;
using testInter.Repo.Security;
using testInter.Service;
using testInter.WebAPI.Controllers;

namespace testInter.test
{

    [TestClass]
    public class EmployeeControllerTest
    {


        [TestMethod]
        public void GetEmployee_ReturnOK_AllRegisters()
        {
            #region Arrange
            List<Employee> listEmployee = new List<Employee>();
            Employee Employee = new Employee { Id = 1, FirstName = "Primer Nombre", LastName = "Segundo NOmbre", Position ="Position", DocumentId = "1" };
            listEmployee.Add(Employee);

            var mockUsuarios = new Mock<IEmployeeService>();
            mockUsuarios.Setup(sp => sp.GetEmployees()).Returns(listEmployee);

            var EmployeeController = new EmployeeController(mockUsuarios.Object);
            #endregion


            #region Act
            var response = EmployeeController.GetEmployee();

            #endregion

            #region Assert
            // The 'Response' is of type OkResult and returns an Object (OkObjectResult)..
            //The Object returned by the OkResult is of type IEnumerable<Country>.
            Assert.IsInstanceOfType((response as OkObjectResult).Value, typeof(IEnumerable<Employee>));
            #endregion
        }
        [TestMethod]
        public void PostEmployee_ReturnOK()
        {
            #region Arrange

            Employee Employee = new Employee { Id = 1, FirstName = "Primer Nombre", LastName = "Segundo NOmbre", Position = "Position", DocumentId = "1" };


            var mockUsuarios = new Mock<IEmployeeService>();
            mockUsuarios.Setup(sp => sp.InsertEmployee(Employee)).Verifiable();

            var EmployeeController = new EmployeeController(mockUsuarios.Object);
            #endregion


            #region Act
            IActionResult actionResult = EmployeeController.PostEmployee(Employee);
            #endregion

            #region Assert
            // The 'Response' is of type OkResult and returns an Object (OkObjectResult)..
            //The Object returned by the OkResult is of type IEnumerable<Country>.
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
            #endregion
        }
        [TestMethod]
        public void PutEmployee_ReturnOK()
        {
            #region Arrange
            int id = 1;
            int idBad = 5;
            Employee Employee = new Employee { Id = 1, FirstName = "Primer Nombre", LastName = "Segundo NOmbre", Position = "Position", DocumentId = "1" };


            var mockUsuarios = new Mock<IEmployeeService>();
            mockUsuarios.Setup(sp => sp.UpdateEmployee(Employee)).Verifiable();

            var EmployeeController = new EmployeeController(mockUsuarios.Object);
            #endregion


            #region Act
            IActionResult actionResult = EmployeeController.PutEmployee(id, Employee);
            IActionResult actionResultBadRequest = EmployeeController.PutEmployee(idBad, Employee);
            #endregion

            #region Assert
            // The 'Response' is of type OkResult and returns an Object (OkObjectResult)..
            //The Object returned by the OkResult is of type IEnumerable<Country>.
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
            Assert.IsInstanceOfType(actionResultBadRequest, typeof(BadRequestResult));
            #endregion
        }
        [TestMethod]
        public void DeleteEmployee_ReturnOK()
        {
            #region Arrange

            int id = 1;
            int idNotFound = 3;
            Employee Employee = new Employee { Id = 1, FirstName = "Primer Nombre", LastName = "Segundo NOmbre", Position = "Position", DocumentId = "1" };

            var mockUsuarios = new Mock<IEmployeeService>();
            mockUsuarios.Setup(sp => sp.GetEmployee(id)).Returns(Employee);

            mockUsuarios.Setup(sp => sp.DeleteEmployee(id)).Verifiable();

            var EmployeeController = new EmployeeController(mockUsuarios.Object);
            #endregion


            #region Act
            IActionResult actionResult = EmployeeController.DeleteEmployee(id);
            IActionResult actionResultNot = EmployeeController.DeleteEmployee(idNotFound);
            #endregion

            #region Assert
            // The 'Response' is of type OkResult and returns an Object (OkObjectResult)..
            //The Object returned by the OkResult is of type IEnumerable<Country>.
            Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
            Assert.IsInstanceOfType(actionResultNot, typeof(NotFoundResult));
            #endregion
        }
        [TestMethod]
        public void GetEmployee_ReturnOK()
        {
            #region Arrange

            int id = 1;
            int idNotFound = 3;
            Employee Employee = new Employee { Id = 1, FirstName = "Primer Nombre", LastName = "Segundo NOmbre", Position = "Position", DocumentId = "1" };

            var mockUsuarios = new Mock<IEmployeeService>();
            mockUsuarios.Setup(sp => sp.GetEmployee(id)).Returns(Employee);

            var EmployeeController = new EmployeeController(mockUsuarios.Object);
            #endregion


            #region Act
            IActionResult responseOK = EmployeeController.GetEmployee(id);
            IActionResult responseNotFound = EmployeeController.GetEmployee(idNotFound);

            #endregion

            #region Assert
            // The 'Response' is of type OkResult and returns an Object (OkObjectResult)..
            //The Object returned by the OkResult is of type IEnumerable<Country>.
            Assert.AreEqual(((Employee)(responseOK as OkObjectResult).Value).Id, id);
            Assert.AreNotEqual(((Employee)(responseOK as OkObjectResult).Value).Id, idNotFound);
            #endregion
        }
    }
}
