using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EmployeeApp.Models
{
    /// <summary>
    /// Абастрактный базовый класс сотрудника.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class Employee
    {
        #region Поля и Свойства
        /// <summary>
        /// Идентификатор сотрудника.
        /// </summary>
        [JsonProperty]
        public int Id { get; set; }

        /// <summary>
        /// Имя сотрудника.
        /// </summary>
        [JsonProperty]
        public string Name { get; set; }

        /// <summary>
        /// Фиксированная зарплата сотрудника.
        /// </summary>
        [JsonProperty]
        public decimal BaseSalary { get; set; }
        #endregion

        #region Методы
        /// <summary>
        /// Абстрактный метод расчёта зарплаты.
        /// </summary>
        /// <returns></returns>
        public abstract decimal CalculateSalary();
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор инициализации нового экземпляра сотрудника.
        /// </summary>
        public Employee() { }

        /// <summary>
        /// Конструктор инициализации нового экземпляра сотрудника с заданными именем и зарплатой.
        /// </summary>
        public Employee(string name, decimal baseSalary)
        {
            Name = name;
            BaseSalary = baseSalary;
        }
        #endregion
    }
}
