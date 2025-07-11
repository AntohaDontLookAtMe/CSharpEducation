using System;

namespace EmployeeApp.Exceptions
{
    /// <summary>
    /// Исключение, выбрасываемое при попытке задать нового сотрудника с уже существующим именем.
    /// </summary>
    public class EmployeeAlreadyExistsException : Exception
    {
        /// <summary>
        /// Инициализирует исключение с именем уже существующего сотрудника.
        /// </summary>
        /// <param name="name">Имя уже существующего сотрудника</param>
        public EmployeeAlreadyExistsException(string name)
            : base($"Сотрудник с именем {name} уже существует.") { }
    }
}
