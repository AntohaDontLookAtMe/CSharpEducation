using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeApp.Models;

namespace EmployeeApp.Interfaces
{
    public interface IEmployeeManager<T> where T : Employee
    {
        void AddEmployee(T employee);
        T GetEmployee(string name);
        void UpdateEmployee(T employee);
        void DeleteEmployee(string name);
    }
}
