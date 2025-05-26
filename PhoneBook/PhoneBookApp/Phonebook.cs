using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using AbonentClass;

namespace PhonebookClass
{
    public sealed class Phonebook
    {
        private static readonly Lazy<Phonebook> _instance = new Lazy<Phonebook>(() => new Phonebook());
        public static Phonebook Instance => _instance.Value;
        private const string FilePath = "phonebook.json";
        public List<Abonent> Abonents;
        private Phonebook()
        {
            LoadPhoneBook();
        }

        /// <summary>
        /// Добавление абонента в телефонную книгу
        /// </summary>
        /// <param name="abonentName">Принимамое имя абонента</param>
        /// <param name="abonentPhoneNumber">Принимамемый номер телефона абонента</param>
        public void AddAbonent(string abonentName, string abonentPhoneNumber)
        {
            Abonent newAbonent = new Abonent(abonentName, abonentPhoneNumber);
            if (!Abonents.Any(a => a.Name.Equals(newAbonent.Name, StringComparison.OrdinalIgnoreCase)))
            {
                Abonents.Add(newAbonent);
                Console.WriteLine($"Абонент с именем {newAbonent.Name} добавлен");
                SavePhoneBook();
                Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню...");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                {

                }
            }
            else
            {
                Console.WriteLine("Такой абонент уже существует");
                Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню...");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                {

                }
            }
        }

        /// <summary>
        /// Удаление абонента из телефонной книги
        /// </summary>
        /// <param name="abonentName">Передаваемое имя абонента</param>
        public void RemoveAbonent(string abonentName)
        {
            var abonent = Abonents.FirstOrDefault(a => a.Name.Equals(abonentName, StringComparison.OrdinalIgnoreCase));
            if (abonent != null)
            {
                Abonents.Remove(abonent);
                Console.WriteLine($"Абонент {abonent.Name} удалён");
                SavePhoneBook();
                Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню...");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                {

                }
            }
            else
            {
                Console.WriteLine($"Абонент с именем {abonentName} не найден");
                Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню...");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                {

                }
            }
        }

        /// <summary>
        /// Поиск абонента по имени
        /// </summary>
        /// <param name="abonentName">Передаваемое имя абонента</param>
        /// <returns>
        /// Найденный объект Abonent, если абонент существует;
        /// null, если абонент не найден;
        /// Измененная версия абонента, если пользователь выбрал редактирование
        /// </returns>
        public Abonent GetAbonentByName(string abonentName)
        {
            var abonent = Abonents.FirstOrDefault(a => a.Name.Equals(abonentName, StringComparison.OrdinalIgnoreCase));
            if (abonent != null)
            {
                while (true)
                {
                    Console.WriteLine($"Имя: {abonent.Name}\n"
                                     + $"Номер телефона: {abonent.PhoneNumber}\n");
                    Console.WriteLine("Хотите изменить информацию об абоненте?\n"
                                     + "1. Да\n"
                                     + "2. Нет\n");
                    Console.Write("Выберите действие: ");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            return ChangeInformation(abonent);

                        case "2":
                            return abonent;
                        default:
                            Console.WriteLine("Неверный ввод");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine($"Абонент с именем {abonentName} не найден");
                Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню...");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                {

                }
                return null;
            }
        }

        /// <summary>
        /// Изменение информации об абоненте
        /// </summary>
        /// <param name="abonent">Передаваемый абонент,чьи данные нужжно изменить</param>
        /// <returns>
        /// Измененная версия абонента
        /// </returns>
        public Abonent ChangeInformation(Abonent abonent)
        {
            Console.WriteLine($"Текущие Имя и Телефон абонента: {abonent.Name}, {abonent.PhoneNumber}");
            Console.Write("Введите новое имя абонента: ");
            string changingName = Console.ReadLine();
            Console.Write("Введите новый номер абонента: ");
            string changingPhoneNumber = Console.ReadLine();
            abonent.Name = changingName;
            abonent.PhoneNumber = changingPhoneNumber;
            Console.WriteLine($"Новые Имя и Телефон абонента: {abonent.Name}, {abonent.PhoneNumber}");
            SavePhoneBook();
            Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню...");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {

            }
            return abonent;
        }

        /// <summary>
        /// Поиск абонента по номеру телефона
        /// </summary>
        /// <param name="abonentPhoneNumber">Передаваемый номер телефона абонента</param>
        /// <returns>
        /// Найденный объект Abonent, если абонент существует;
        /// null, если абонент не найден;
        /// Измененная версия абонента, если пользователь выбрал редактирование
        /// </returns>
        public Abonent GetAbonentByPhoneNumber(string abonentPhoneNumber)
        {
            var abonent = Abonents.FirstOrDefault(a => a.PhoneNumber == abonentPhoneNumber);
            if (abonent != null)
            {
                while (true)
                {
                    Console.WriteLine($"Имя: {abonent.Name}\n"
                                     + $"Номер телефона: {abonent.PhoneNumber}\n");
                    Console.WriteLine("Хотите изменить информацию об абоненте?\n"
                                     + "1. Да\n"
                                     + "2. Нет\n");
                    Console.Write("Выберите действие: ");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            return ChangeInformation(abonent);

                        case "2":
                            return abonent;
                        default:
                            Console.WriteLine("Неверный ввод");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine($"Абонент с номером {abonentPhoneNumber} не найден");
                Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню...");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                {

                }
                return null;
            }
        }

        /// <summary>
        /// Вывод всех абонентов
        /// </summary>
        /// <returns>
        /// Отсортированный по именам список абонентов
        /// null, если количество абонентов в телефонной книге равно 0
        /// </returns>
        public List<Abonent> GetAllAbonents()
        {
            var sortedAbonents = Abonents.OrderBy(a => a.Name).ToList();
            if (sortedAbonents.Count != 0)
            {
                foreach (var abonent in sortedAbonents)
                {
                    Console.WriteLine($"Имя: {abonent.Name}\n"
                                     + $"Номер телефона: {abonent.PhoneNumber}\n");
                }
                Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню...");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                {

                }
                return sortedAbonents;
            }
            else
            {
                Console.WriteLine("В телефонной книге нет абонентов");
                Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню...");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                {

                }
                return null;
            }
        }

        /// <summary>
        /// Загрузка данных с JSON-файла
        /// </summary>
        private void LoadPhoneBook()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                Abonents = JsonConvert.DeserializeObject<List<Abonent>>(json) ?? new List<Abonent>();
            }
            else
            {
                Abonents = new List<Abonent>();
            }
        }

        /// <summary>
        /// Сохранение изменений в JSON-файле
        /// </summary>
        private void SavePhoneBook()
        {
            var json = JsonConvert.SerializeObject(Abonents, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }
    }
}
