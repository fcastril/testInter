using System.Collections.Generic;
using testInter.Data;

namespace testInter.Service
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int id);
        void InsertEmployee(Employee user);
        void UpdateEmployee(Employee user);
        void DeleteEmployee(int id);
    }
}
