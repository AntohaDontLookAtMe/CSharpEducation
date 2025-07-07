using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace EmployeeApp.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class Employee
    {
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public decimal BaseSalary { get; set; }
        public Employee() { }
        public Employee(string name, decimal baseSalary)
        {
            Name = name;
            BaseSalary = baseSalary;
        }

        public abstract decimal CalculateSalary();
    }
}
