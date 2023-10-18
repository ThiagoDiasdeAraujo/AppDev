using Microsoft.AspNetCore.Mvc;
using Routing.Models;

namespace Routing.Controllers
{
	public class StudentController : Controller
	{
		private List<Student> _students;

		public StudentController()
		{
			_students = new List<Student>();
			_students.Add(new Student()
			{
				Id = 1,
				FirstName = "Jos",
				LastName = "Vermeulen",
				BirthDate = new DateTime(2000, 5, 14)
			});
			_students.Add(new Student()
			{
				Id = 2,
				FirstName = "Jan",
				LastName = "hoe",
				BirthDate = new DateTime(2010, 6, 14)
			});
			_students.Add(new Student()
			{
				Id = 3,
				FirstName = "hans",
				LastName = "anders",
				BirthDate = new DateTime(2000, 8, 14)
			});
		}

		public IActionResult ListStudents()
		{
			return View(_students);
		}

		public IActionResult Details(int id)
		{
			Student student = _students.Single(x => x.Id == id);
			return View(student);
		}
	}
}
