namespace MijnCV.Models
{
	public class Person
	{
		public string Name { get; set; }
		public DateTime Birthdate { get; set; }
		public List<string> Hobbies { get; set; }

		public Person(string name, DateTime birthdate)
		{
			Name = name;
			Birthdate = birthdate;
			Hobbies = new List<string>();
		}
	}
}
