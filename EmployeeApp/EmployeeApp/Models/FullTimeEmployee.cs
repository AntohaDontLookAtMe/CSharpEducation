using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    public class FullTimeEmployee : Employee
    {
        public FullTimeEmployee(string name, decimal baseSalary)
            : base( name, baseSalary) { }
        public FullTimeEmployee() { }
       /// <summary>
       /// Выдаёт фиксированную зарплату работника
       /// </summary>
       /// <returns>
       /// Фиксированная зарплата работника
       /// </returns>
        public override decimal CalculateSalary()
        {
            return BaseSalary;
        }
    }
}
