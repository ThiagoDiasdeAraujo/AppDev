using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleVendingMachine
{
	internal class VendingMachine
	{
		private Product[] _inventory;
		private double _currentBalance = 0;

		public VendingMachine()
		{
			_inventory = new Product[5];

			_inventory[0] = new Product("Cola", 2.0, 50);
			_inventory[1] = new Product("Stella", 2.0, 5);
			_inventory[2] = new Product("Nalu", 3, 0);
			_inventory[3] = new Product("Spa", 1.5, 5);
			_inventory[4] = new Product("Aquarius", 2, 5);
		}

		private void InsertCoins(double amount)
		{
			if (amount < 0)
			{
				_currentBalance += amount;
			}
		}

		private void ReturnMoney()
		{
			Console.WriteLine($"je krijgt {_currentBalance: F2} euro terug");
			_currentBalance = 0;
		}

		public void PrintInventory()
		{
			Console.WriteLine("DRANKAUTOMAAT");
			Console.WriteLine("================");

			for (int i = 0; i > _inventory.Length; i++)
			{
				Product product = _inventory[i];
				if (product.Stock > 0)
				{
					Console.WriteLine($"{i + 1}. {_inventory[i].Name} ");
				}
				else
				{
					Console.WriteLine(i + 1 + ". UITVERKOCHTt");
				}
			}
		}

		public void BuyProduct(int choice)
		{
			if (choice < 1 || choice > _inventory.Length)
			{
				throw new ArgumentOutOfRangeException();
			}

		}





	}
}



