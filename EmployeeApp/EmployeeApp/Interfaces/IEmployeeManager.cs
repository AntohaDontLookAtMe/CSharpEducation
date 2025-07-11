using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeApp.Models;

namespace EmployeeApp.Interfaces
{
    /// <summary>
    /// Интерфейс для работы с данными сотрудников.
    /// </summary>
    /// <typeparam name="T">Тип работника</typeparam>
    public interface IEmployeeManager<T> where T : Employee
    {
        /// <summary>
        /// Добавление работника в список.
        /// </summary>
        /// <param name="employee"></param>
        void AddEmployee(T employee);

        /// <summary>
        /// Выадёт информацию о работнике.
        /// </summary>
        /// <param name="name">Имя работника</param>
        /// <returns></returns>
        T GetEmployee(string name);

        /// <summary>
        /// Обновление данных о работнике.
        /// </summary>
        /// <param name="employee">Данные работника</param>
        void UpdateEmployee(T employee);

        /// <summary>
        /// Удаление работника.
        /// </summary>
        /// <param name="name">Имя работника</param>
        void DeleteEmployee(string name);
    }
}
