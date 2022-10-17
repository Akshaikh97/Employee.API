using Employee.API.Models;
using Employee.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Employee.API.Controllers {

    [RoutePrefix("api/Employee")]
    public class EmployeeController : ApiController 
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository) {
            _employeeRepository = employeeRepository;
        }

        [Route("all")]
        [HttpGet]
        public IHttpActionResult GetEmployees() {
            return Ok(_employeeRepository.GetEmployees().ToList());
        }
        [HttpGet, Route("{EmployeeId}")]
        public IHttpActionResult GetEmployee(int EmployeeId) {
            return Ok(_employeeRepository.GetEmployee(EmployeeId));
        }
        [HttpPost, Route("AddEmployee")]
        public IHttpActionResult AddEmploye([FromBody] Employe employe) {
            return Ok(_employeeRepository.AddEmployee(employe));
        }
        [HttpPut, Route("UpdateEmployee")]
        public IHttpActionResult UpdateEmployee(Employe employe, int EmployeeId) {
            return Ok(_employeeRepository.UpdateEmployee(employe, EmployeeId));
        }
        [HttpDelete, Route("DeleteEmployee")]
        public IHttpActionResult Delete(int EmployeeId) {
            return Ok(_employeeRepository.DeleteEmployee(EmployeeId));
        }
    }
}