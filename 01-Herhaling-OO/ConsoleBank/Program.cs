using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBank
{
	internal class Program
	{
		static void Main(string[] args)
		{
			SavingsAccount savingsAccount1 = new SavingsAccount("BE69", 0.2);
			CheckingAccount checkingAccount1 = new CheckingAccount("BE00");

			Console.WriteLine("BANK APP");
			Console.WriteLine("************");

			Console.WriteLine("1) Deposit");
			Console.WriteLine("2) Withdraw");
			Console.WriteLine("3) Exit");

			int choice = Convert.ToInt32(Console.ReadLine());

			if (choice == 1 || choice == 2)
			{
				Console.WriteLine("Choose Account");
				Console.WriteLine($"1. {savingsAccount1.BankAccountNumber}: {savingsAccount1.BankAccountBalance}€ (savings)");
				Console.WriteLine($"1. {checkingAccount1.BankAccountNumber}: {checkingAccount1.BankAccountBalance}€ (checkings)");
			}
			else if (choice == 3)
			{
				Console.WriteLine("END");
			}
			else
			{
                Console.WriteLine("Ongeldige keuze");
				Console.WriteLine("Choose Account");
				Console.WriteLine("1) Deposit");
				Console.WriteLine("2) Withdraw");
				Console.WriteLine("3) Exit");
			}
            Console.WriteLine("Kies welke rekening");
            int choiceAcc = Convert.ToInt32(Console.ReadLine());
			if (choiceAcc == 1)
			{
                Console.WriteLine("baaaaah");
            }
		}
	}

	public abstract class BankAccount
	{
		public double BankAccountBalance { get; set; }
		public string BankAccountNumber { get; set; }

		protected BankAccount(string bankAccountNumber)
		{
			BankAccountBalance = 0;
			BankAccountNumber = bankAccountNumber;
		}

		public abstract void Deposit(double amount);
		public abstract void Withdraw(double amount);
		//public abstract void CloseMonth();
		//public abstract override string ToString();
	}


	public class SavingsAccount : BankAccount
	{
		public double MonthlyInterest { get; set; }

		public SavingsAccount(string bankAccountNumber, double interest) : base(bankAccountNumber)
		{
			MonthlyInterest = interest;
		}

		//public override void CloseMonth()
		//{
		//	throw new NotImplementedException();
		//}

		public override void Deposit(double amount)
		{
			if (amount > 0)
			{
				throw new ArgumentException("Moet hoger zijn als 0");
			}
			else
			{
				throw new ArgumentException($"Gelukt! Je hebt {amount}€ gestort! ");
			}
			BankAccountBalance += amount;
		}

		public override void Withdraw(double amount)
		{
			if (amount > BankAccountBalance)
			{
				throw new ArgumentException("Transactie niet gelukt, uw saldo is" + BankAccountBalance);
			}
		}
	}

	public class CheckingAccount : BankAccount
	{

		private const int NUMBER_OF_FREE_TRANSACTIONS = 100;
		private const double TRANSACTION_PRICE = 0.10;

		public CheckingAccount(string bankAccountNumber) : base(bankAccountNumber)
		{

		}

		//public override void CloseMonth()
		//{
		//	throw new NotImplementedException();
		//}
		public override void Deposit(double amount)
		{
			if (amount > 0)
			{
				throw new ArgumentException("Moet hoger zijn als 0");
			}
			else
			{
				throw new ArgumentException($"Gelukt! Je hebt {amount}€ gestort! ");
			}
			BankAccountBalance += amount;
		}

		public override void Withdraw(double amount)
		{
			if (amount > BankAccountBalance)
			{
				throw new ArgumentException("Transactie niet gelukt, uw saldo is" + BankAccountBalance);
			}
		}
	}
}
