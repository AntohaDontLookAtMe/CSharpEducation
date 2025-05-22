using System.Collections.Generic;
using Newtonsoft.Json;
using AbonentClass;

namespace PhonebookClass
{
    public sealed class Phonebook
    {
        private static readonly Lazy<Phonebook> _instance = new Lazy<Phonebook>(() => new Phonebook());
        public static Phonebook Instance => _instance.Value;
        private readonly string FilePath = "phonebook.json";
        private List<Abonent> Abonents;
        private Phonebook()
        {
            LoadPhoneBook();
        }

        /// <summary>
        /// Добавление абонента в телефонную книгу
        /// </summary>
        public void AddAbonent()
        {
            Console.Clear();
            Console.WriteLine("-----СОЗДАНИЕ АБОНЕНТА-----");
            Console.Write("Введите имя абонента: ");
            string abonentName = Console.ReadLine();
            Console.Write("Введите номер абонента: ");
            string abonentPhoneNumber = Console.ReadLine();
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
        public void GetAbonentByName(string abonentName)
        {
            var abonent = Abonents.FirstOrDefault(a => a.Name.Equals(abonentName, StringComparison.OrdinalIgnoreCase));
            if (abonent != null)
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
                        abonent = ChangeInformation(abonent);
                        Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню...");
                        while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                        {

                        }
                        break;

                    case "2":
                        return;
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
        /// Изменение информации об абоненте
        /// </summary>
        /// <param name="abonent">Передаваемый абонент,чьи данные нужжно изменить</param>
        /// <returns></returns>
        public Abonent ChangeInformation(Abonent abonent)
        {
            Console.WriteLine($"Текущие Имя и Телефон абонента: {abonent.Name}, {abonent.PhoneNumber}");
            Console.Write("Введите новое имя абонента: ");
            string changingName = Console.ReadLine();
            Console.WriteLine("Введите новый номер абонента: ");
            string changingPhoneNumber = Console.ReadLine();
            abonent.Name = changingName;
            abonent.PhoneNumber = changingPhoneNumber;
            Console.WriteLine($"Новые Имя и Телефон абонента: {abonent.Name}, {abonent.PhoneNumber}");
            SavePhoneBook();
            return abonent;
        }

        /// <summary>
        /// Поиск абонента по номеру телефона
        /// </summary>
        /// <param name="abonentPhoneNumber">Передаваемый номер телефона абонента</param>
        public void GetAbonentByPhoneNumber(string abonentPhoneNumber)
        {
            var abonent = Abonents.FirstOrDefault(a => a.PhoneNumber == abonentPhoneNumber);
            if (abonent != null)
            {
                Console.WriteLine($"Имя: {abonent.Name}\n"
                                + $"Номер телефона: {abonent.PhoneNumber}\n");

                Console.WriteLine("Хотите изменить информацию об абоненте?"
                     + "1. Да"
                     + "2. Нет");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        abonent = ChangeInformation(abonent);
                        Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню...");
                        while (Console.ReadKey(true).Key != ConsoleKey.Enter)
                        {

                        }
                        break;

                    case "2":
                        return;
                }
            }
            else
            {
                Console.WriteLine($"Абонент с номером {abonentPhoneNumber} не найден");
            }
        }

        /// <summary>
        /// Вывод всех абонентов
        /// </summary>
        public void GetAllAbonents()
        {
            Console.Clear();
            Console.WriteLine("-----СПИСОК ВСЕХ АБОНЕНТОВ-----\n");
            var sortedAbonents = Abonents.OrderBy(a => a.Name);

            foreach (var abonent in sortedAbonents)
            {
                Console.WriteLine($"Имя: {abonent.Name}\n"
                                 + $"Номер телефона: {abonent.PhoneNumber}\n");
            }
            Console.WriteLine("\nНажмите Enter, чтобы вернуться в меню...");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {

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
