using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    public class PartTimeEmployee : Employee
    {
        public decimal HourRate { get; set; }
        public PartTimeEmployee() { }
        public PartTimeEmployee(string name, decimal hourRate)
            : base(name, 0)
        {
            HourRate = hourRate;
        }
        /// <summary>
        /// Расчёт зарплаты в зависимости от отработанных часов 
        /// </summary>
        /// <returns>
        /// Расчитанная за отработанные часы зарплата
        /// </returns>
        public override decimal CalculateSalary()
        {
            Console.Write("Введите отработанное количество часов сотрудника: ");
            int hoursWorked = Convert.ToInt32(Console.ReadLine());
            return HourRate * hoursWorked;
        }
    }
}
