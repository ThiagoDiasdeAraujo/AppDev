using System.ComponentModel.DataAnnotations;

namespace Formulier2.Data
{
    public class Employee
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public DateTime? Birthdate { get; set; }

        public int DepartmentID { get; set; }
     
    }
}
