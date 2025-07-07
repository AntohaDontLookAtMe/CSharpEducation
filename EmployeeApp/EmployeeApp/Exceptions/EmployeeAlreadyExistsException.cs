using System;

namespace EmployeeApp.Exceptions
{
    public class EmployeeAlreadyExistsException : Exception
    {
        public EmployeeAlreadyExistsException(string name)
            : base($"Сотрудник с именем {name} уже существует.") { }
    }
}
