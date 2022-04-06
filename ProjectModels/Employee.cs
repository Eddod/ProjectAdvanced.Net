using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectModels
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public ICollection<TimeReport> TimeReport {get; set;}
    }
}
