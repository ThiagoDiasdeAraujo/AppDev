using System;

namespace Opdracht_Online_CV.Models
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public List<string> Hobbies { get; set; }

        public int Age
        {
            get
            {
                return DateTime.Today.Year - Birthdate.Year;
            }
        }

        public Person(string name, DateTime birthdate)
        {
            Name = name;
            Birthdate = birthdate;
            Hobbies = new List<string>();
        }
    }
}
