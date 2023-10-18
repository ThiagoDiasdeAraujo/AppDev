using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePayroll
{
	public class Employee
	{
		string EmployeeName { get; set; }
		int EmployeeId { get; set; }
		int Seniority { get; set; }
	}

	public class FullTimeEmployee: Employee
	{
		public double AnnualSalary { get; set;}

		public double CalculateSalary()
		{
			double salary = AnnualSalary / 12;
			return salary;
		}
	}

	public class HourlyEmployee : Employee
	{
		public double HoursWorked { get; set; }
		public double SalaryPerHour { get; }

		public double CalculateSalary()
		{
			double salary = HoursWorked * SalaryPerHour;
			return salary;
		}
	}
}
