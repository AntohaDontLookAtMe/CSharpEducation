using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    /// <summary>
    /// Класс работника на полной ставке.
    /// </summary>
    public class FullTimeEmployee : Employee
    {
        #region Методы
        
        #region Методы, реализующие Базовый класс

        /// <summary>
        /// Выдаёт фиксированную зарплату работника.
        /// </summary>
        /// <returns>
        /// Фиксированная зарплата работника.
        /// </returns>
        public override decimal CalculateSalary()
        {
            return BaseSalary;
        }

        #endregion

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор инициализации нового экземпляра сотрудника на полной ставке с задаваемыми именем и зарплатой.
        /// </summary>
        /// <param name="name">Задаваемое имя</param>
        /// <param name="baseSalary">Задаваемая зарплата</param>
        public FullTimeEmployee(string name, decimal baseSalary)
    : base(name, baseSalary) { }

        /// <summary>
        /// Конструктор инициализации нового экземпляра сотрудника на полной ставке.
        /// </summary>
        public FullTimeEmployee() { }
        #endregion
    }
}
