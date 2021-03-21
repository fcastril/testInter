using System.Collections.Generic;
using testInter.Data;
using testInter.Repo;

namespace testInter.Service
{
    public class EmployeeService : IEmployeeService
    {

        private IRepository<Employee> EmployeeRepository;
        public EmployeeService(IRepository<Employee> EmployeeRepository)
        {
            this.EmployeeRepository = EmployeeRepository;

        }

        public IEnumerable<Employee> GetEmployees()
        {
            return EmployeeRepository.GetAll();
        }
        public Employee GetEmployee(int id)
        {
            return EmployeeRepository.Get(id);
        }
        public void InsertEmployee(Employee Employee)
        {
            EmployeeRepository.Insert(Employee);
        }
        public void UpdateEmployee(Employee Employee)
        {
            EmployeeRepository.Update(Employee);
        }
        public void DeleteEmployee(int id)
        {
            Employee Employee = GetEmployee(id);
            EmployeeRepository.Remove(Employee);
            EmployeeRepository.SaveChanges();
        }
    }
}
