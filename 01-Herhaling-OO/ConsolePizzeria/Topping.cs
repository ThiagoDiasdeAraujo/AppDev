using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePizzeria
{
	public class Topping
	{
		public string Name { get; set; }
		public double Price { get; set; }

        public Topping(string n, double p)
        {
            Name = n;
            Price = p;
        }
    }
}
