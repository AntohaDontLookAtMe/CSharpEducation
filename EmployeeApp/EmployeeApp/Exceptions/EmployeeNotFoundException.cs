using System;

namespace EmployeeApp.Exceptions
{
    /// <summary>
    /// Исключение,выбрасываемое при попытке изменить или удалить сотрудника с несуществующим именем.
    /// </summary>
    public class EmployeeNotFoundException : Exception
    {
        /// <summary>
        /// Инициализирует исключение с именем сотрудника, ненайденного в системе.
        /// </summary>
        /// <param name="name">Имя несуществующего сотрудника</param>
        public EmployeeNotFoundException(string name)
            : base($"Сотрудник с именем {name} не найден.") { }
    }
}
