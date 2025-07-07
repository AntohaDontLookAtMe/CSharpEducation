using System;

namespace EmployeeApp.Exceptions
{
    public class EmployeeNotFoundException : Exception
    {
        public EmployeeNotFoundException(string name)
            : base($"Сотрудник с именем {name} не найден.") { }
    }
}
