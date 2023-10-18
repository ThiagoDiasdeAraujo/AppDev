using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCardss
{
	internal class Deck
	{
		private List<Card> _cards;
        private Random _random = new Random();

        public Deck()
        {
            _cards = new List<Card>();

            for (int i = 1 ;  i <= 13 ; i++) 
            {
                _cards.Add(new Card(i, Suit.Clubs));
            }     
        }

        public void Shuffle()
        {
            for(int i = _cards.Count - 1 ; i > 0; i--)
            {

            }
        }
    }
}
