using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePizzeria
{
	enum Size
	{
		Small,
		Medium,
		Large,
	}

	class Pizza
	{
		private const double BASE_PRICE = 11.0;

		public double Totaalprijs
		{
			get { return Totaalprijs; }
			set { Totaalprijs = value; }
		}

		private List<Topping> _toppings;
		private Size _size;

        public Pizza(Size size)
        {
            _size = size;
			_toppings = new List<Topping>();
        }

        public void AddTopping(Topping topping)
		{
			_toppings.Add(topping);
		}

		public double TotalPrice
		{
			get
			{
				double price = 0;

				if (_size == Size.Small)
				{
					price = BASE_PRICE * 0.8;
				}

				else if (_size == Size.Medium)
				{
					price = BASE_PRICE ;
				}

				else if (_size == Size.Large)
				{
					price = BASE_PRICE * 1.2;
				}
				foreach (Topping topping in _toppings)
				{
					price += topping.Price;
				}
				return price;
			}
		}


	}
}
