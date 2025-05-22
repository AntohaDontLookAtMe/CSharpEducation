using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using PhonebookClass;
using AbonentClass;

namespace PhoneBookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var phonebook = Phonebook.Instance;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Добавить абонента");
                Console.WriteLine("2. Удалить абонента");
                Console.WriteLine("3. Поиск абонента по имени");
                Console.WriteLine("4. Поиск абонента по номеру телефона");
                Console.WriteLine("5. Показать всех абонентов");
                Console.WriteLine("6. Выход");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        phonebook.AddAbonent();
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("-----УДАЛЕНИЕ АБОНЕНТА-----\n");
                        Console.Write("Введите имя удаляемого абонента: ");
                        string deleteAbonentName = Console.ReadLine();
                        phonebook.RemoveAbonent(deleteAbonentName);
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("-----ПОИСК АБОНЕНТА ПО ИМЕНИ-----\n");
                        Console.Write("Введите имя абонента для поиска: ");
                        string requiredAbonentName = Console.ReadLine();
                        phonebook.GetAbonentByName(requiredAbonentName);
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("-----ПОИСК АБОНЕНТА ПО НОМЕРУ ТЕЛЕФОНА-----\n");
                        Console.Write("Введите номер абонента для поиска: ");
                        string requiredAbonentPhoneNumber = Console.ReadLine();
                        phonebook.GetAbonentByPhoneNumber(requiredAbonentPhoneNumber);
                        break;
                    case "5":
                        phonebook.GetAllAbonents();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Неверный ввод!");
                        break;
                }
            }
        }
    }
}
