using System;
using System.Collections.Generic;

namespace SPM.Core.Models
{
    public partial class Person
    {
        public Person()
        {
            Customer = new HashSet<Customer>();
            Employee = new HashSet<Employee>();
        }

        public int PersonId { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] Photo { get; set; }
        public DateTime ModifyDate { get; set; }

        public ICollection<Customer> Customer { get; set; }
        public ICollection<Employee> Employee { get; set; }
    }
}
