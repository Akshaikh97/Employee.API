using Employee.API.Models;
using System.Collections.Generic;

namespace Employee.API.Repositories {
    public interface IEmployeeRepository {
        List<Employe> GetEmployees();
        Employe GetEmployee(int EmployeeId);
        bool AddEmployee(Employe obj);
        bool UpdateEmployee(Employe obj);
        bool DeleteEmployee(int EmployeeId);
    }
}