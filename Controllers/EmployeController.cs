using Employee.API.Models;
using Employee.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Employee.API.Controllers {

    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController {

        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository) {
            _employeeRepository = employeeRepository;
        }

        [Route("all")]
        [HttpGet]
        public IHttpActionResult GetEmployees() {
            return Ok(_employeeRepository.GetEmployees().ToList());
        }
        [HttpGet, Route("EmployeeId:int")]
        public IHttpActionResult GetEmployee(int EmployeeId) {
            return Ok(_employeeRepository.GetEmployee(EmployeeId));
        }
        [HttpPost, Route("AddEmployee")]
        public IHttpActionResult AddEmploye([FromBody] Employe employe) {
            return Ok(_employeeRepository.AddEmployee(employe));
        }
        [HttpPut, Route("UpdateEmpoloyee")]
        public IHttpActionResult UpdateEmployee(Employe employe) {
            return Ok(_employeeRepository.UpdateEmployee(employe));
        }
        [HttpDelete, Route("DeleteEmployee")]
        public void Delete(int EmployeeId) => _employeeRepository.DeleteEmployee(EmployeeId);
    }
}