

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using testInter.Service;
using testInter.Data;
using Microsoft.AspNetCore.Authorization;

namespace testInter.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public IActionResult GetEmployee()
        {
            IEnumerable<Employee> Employee = _employeeService.GetEmployees();
            return Ok(Employee);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetEmployee(int id)
        {

            Employee Employee = _employeeService.GetEmployee(id);
            if (Employee == null)
            {
                return NotFound();
            }
            return Ok(Employee);
        }


        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult PostEmployee(Employee Employee)
        {
            _employeeService.InsertEmployee(Employee);
            return Ok(Employee);
        }
        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public IActionResult PutEmployee(int id, Employee Employee)
        {
            if (id != Employee.Id)
            {
                return BadRequest();
            }

            _employeeService.UpdateEmployee(Employee);
            Employee = _employeeService.GetEmployee(id);

            return Ok(Employee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            Employee Employee = _employeeService.GetEmployee(id);

            if (Employee == null)
            {
                return NotFound();
            }

            _employeeService.DeleteEmployee(id);

            return Ok(Employee);
        }
    }
}

