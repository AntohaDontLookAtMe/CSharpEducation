using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    /// <summary>
    /// Класс работника с почасовой ставкой.
    /// </summary>
    public class PartTimeEmployee : Employee
    {
        #region Поля и свойства

        /// <summary>
        /// Почасовая ставка.
        /// </summary>
        public decimal HourRate { get; set; }

        #endregion

        #region Методы

        #region Методы, реализующие Базовый класс

        /// <summary>
        /// Расчёт зарплаты в зависимости от отработанных часов.
        /// </summary>
        /// <returns>
        /// Расчитанная за отработанные часы зарплата.
        /// </returns>
        public override decimal CalculateSalary()
        {
            Console.Write("Введите отработанное количество часов сотрудника: ");
            int hoursWorked = Convert.ToInt32(Console.ReadLine());
            return HourRate * hoursWorked;
        }

        #endregion

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор инициализации нового экземпляра сотрудника с почасовой ставкой.
        /// </summary>
        public PartTimeEmployee() { }

        /// <summary>
        /// Конструктор инициализации нового экземпляра сотрудника с почасовой ставкой с задаваемыми именем и почасовой ставкой.
        /// </summary>
        /// <param name="name">Задаваемое имя</param>
        /// <param name="hourRate">Задаваемая почасовая ставка</param>
        public PartTimeEmployee(string name, decimal hourRate)
            : base(name, 0)
        {
            HourRate = hourRate;
        }

        #endregion
    }
}
