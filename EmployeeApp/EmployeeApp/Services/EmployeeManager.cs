using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EmployeeApp.Exceptions;
using EmployeeApp.Interfaces;
using EmployeeApp.Models;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace EmployeeApp.Services
{
    /// <summary>
    /// Класс для работы с данными сотрудников.
    /// </summary>
    /// <typeparam name="T">Тип сотрудников</typeparam>
    public class EmployeeManager<T> : IEmployeeManager<T> where T : Employee
    {
        #region

        private List<T> employees = new List<T>();
        private readonly string filePath = "employees.json";
        private int nextId = 0;

        #endregion

        #region Методы

        #region Методы, реализующие интерфейс IEmployeeManager

        public void AddEmployee(T employee)
        {
            if (employees.Any(e => e.Name.Equals(employee.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new EmployeeAlreadyExistsException(employee.Name);
            }
            employee.Id = nextId++;
            employees.Add(employee);
            SaveJSON();
        }

        public T GetEmployee(string name)
        {
            var employee = employees.FirstOrDefault(e => e.Name == name);
            if (employee == null)
            {
                throw new EmployeeNotFoundException(name);
            }
            Console.WriteLine($"id сотрудника: {employee.Id}\n"+
                              $"Имя сотрудника: {employee.Name}");
            return employee;
        }

        public void UpdateEmployee(T employee)
        {
            Console.WriteLine("Введите новое имя сотрудника: ");
            string newName = Console.ReadLine();
            if (employees.Any(e => e.Name == newName))
                throw new EmployeeAlreadyExistsException(newName);
            else employee.Name = newName;
            if (employee is FullTimeEmployee fullTimeEmployee)
            {
                Console.Write("Фиксированная зарплата: ");
                decimal salary = decimal.Parse(Console.ReadLine());
                employee.BaseSalary = salary;
            }
            if (employee is PartTimeEmployee partTimeEmployee)
            {
                Console.Write("Почасовая ставка: ");
                decimal rate = decimal.Parse(Console.ReadLine());
            }
            SaveJSON();
        }

        public void DeleteEmployee(string name)
        {
            var employee = employees.FirstOrDefault(e => e.Name == name);
            if (employee == null)
                throw new EmployeeNotFoundException(name);

            employees.Remove(employee);
            SaveJSON();
        }

        #endregion

        /// <summary>
        /// Сохранение данных в файле JSON.
        /// </summary>
        public void SaveJSON()
        {
            var saveSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Auto
            };

            File.WriteAllText(filePath, JsonConvert.SerializeObject(employees, saveSettings));
        }

        /// <summary>
        /// Загрузка данных из файла JSON.
        /// </summary>
        public void LoadJSON()
        {
            if (!File.Exists(filePath))
            {
                return;
            }
            var loadSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };

            employees = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(filePath), loadSettings)
              ?? new List<T>();

            if (employees.Any())
                nextId = employees.Max(e => e.Id) + 1;
        }

        #endregion
    }
}
