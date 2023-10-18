using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCardss
{
	public enum Suit
	{
		Clubs,
		Hearts,
		Spades,
		Diamonds
	}
	public class Card
	{
		public int Value { get; }
		public Suit Suit { get; }

		public Card(int value, Suit suit)
		{
			Value = value;
			Suit = suit;
		}

		public bool IsHigherThan(Card otherCard)
		{
			if (Value > otherCard.Value)
			{
				return true;
			}
			else { return false; }
		}

		public override string ToString()
		{
			string text = "";
			switch(Suit)
			{
				case Suit.Clubs: text += "Klaveren"; break;
			}

			text += " ";

			switch (Value)
			{
				case 1: text += "ass"; break;
			}

			return text;
		}
	}
}
