using System;
using EmployeeApp.Models;
using EmployeeApp.Services;
using EmployeeApp.Exceptions;
using System.Threading;

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
                Console.Clear();
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
                        Console.Clear();
                        Console.WriteLine("-----ДОБАВЛЕНИЕ СОТРУДНИКА----\n");
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
                        else if (type == "2")
                        {
                            Console.Write("Почасовая ставка: ");
                            decimal rate = decimal.Parse(Console.ReadLine());
                            manager.AddEmployee(new PartTimeEmployee { Name = name, HourRate = rate});
                        }
                        else
                        {
                            Console.WriteLine("Неверный ввод");
                            Thread.Sleep(3000);
                        }
                        break;
                    case "2":
                        Console.WriteLine("-----ПОЛУЧЕНИЕ ИНФОРМАЦИИ О СОТРУДНИКЕ----\n");
                        Console.Clear();
                        Console.WriteLine("Введите имя сотрудника: ");
                        string findingName = Console.ReadLine();
                        manager.GetEmployee(findingName);
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("-----ОБНОВЛЕНИЕ ИНФОРМАЦИИ О СОТРУДНИКЕ----\n");
                        Console.WriteLine("Введите имя сотрудника: ");
                        findingName = Console.ReadLine();
                        Employee findingEmployee = manager.GetEmployee(findingName);
                        manager.UpdateEmployee(findingEmployee);
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("-----УДАЛЕНИЕ СОТРУДНИКА----\n");
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