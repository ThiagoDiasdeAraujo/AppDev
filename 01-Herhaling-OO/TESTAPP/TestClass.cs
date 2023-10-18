using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTAPP
{
	internal class TestClass
	{

		public int Jaar { get; set; }
		public string Naam { get; set; }

		public void StartAuto()
		{
			Console.WriteLine("auto gestart");
		}

		public void StopAuto()
		{
			Console.WriteLine("auto gestopt");
		}

		public void Details()
		{
			Console.WriteLine($"Jaar: {Jaar} en Naam: {Naam}");
		}


	}
}
