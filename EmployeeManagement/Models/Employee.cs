﻿using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Department> Departments { get; set; }
    }
}
