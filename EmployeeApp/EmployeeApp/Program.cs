using System;
using EmployeeApp.Models;
using EmployeeApp.Services;
using EmployeeApp.Exceptions;

namespace EmployeeApp
{
    class Program
    {
        static EmployeeManager<Employee> manager = new EmployeeManager<Employee>();

        static void Main()
        {
            manager.LoadJSON();
            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Добавить сотрудника");
                Console.WriteLine("2. Получить информацию о сотруднике");
                Console.WriteLine("3. Обновить сотрудника");
                Console.WriteLine("4. Удалить сотрудника");
                Console.WriteLine("0. Выход");
                Console.Write("Выбор: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Имя: ");
                        string name = Console.ReadLine();

                        Console.Write("Полный (1) или частичный (2) рабочий день? ");
                        string type = Console.ReadLine();

                        if (type == "1")
                        {
                            Console.Write("Фиксированная зарплата: ");
                            decimal salary = decimal.Parse(Console.ReadLine());
                            manager.AddEmployee(new FullTimeEmployee { Name = name, BaseSalary = salary });
                        }
                        else
                        {
                            Console.Write("Почасовая ставка: ");
                            decimal rate = decimal.Parse(Console.ReadLine());
                            manager.AddEmployee(new PartTimeEmployee { Name = name, HourRate = rate});
                        }
                        break;
                    case "2":
                        Console.WriteLine("Введите имя сотрудника: ");
                        string findingName = Console.ReadLine();
                        manager.GetEmployee(findingName);
                        break;
                    case "3":
                        Console.WriteLine("Введите имя сотрудника: ");
                        findingName = Console.ReadLine();
                        Employee findingEmployee = manager.GetEmployee(findingName);
                        manager.UpdateEmployee(findingEmployee);
                        break;
                    case "4":
                        Console.WriteLine("Введите имя сотрудника: ");
                        findingName = Console.ReadLine(); 
                        manager.DeleteEmployee(findingName);
                        break;
                    case "0": return;
                    default: Console.WriteLine("Неверный ввод."); break;
                }
            }
        }
    }
}