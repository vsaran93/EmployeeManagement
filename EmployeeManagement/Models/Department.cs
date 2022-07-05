using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EmployeeManagement.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Employee> Employees { get; set; }
    }
}
