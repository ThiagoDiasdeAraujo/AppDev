using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TESTAPP
{
	internal class Program
	{
		static void Main(string[] args)
		{
			TestClass auto = new TestClass();
			auto.Jaar = 0;
			auto.Naam = "";	

			auto.Details();

			auto.StartAuto();

            Console.WriteLine("  ");
		
        }
	}
}
