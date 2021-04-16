using System;
using System.Collections.Generic;
using System.Linq;

namespace KWTS_card_task 
{
    class Deck
    {
        static void Main(string[] args)
        {
            List<Card> myDeck = new List<Card>();
            var adjustedValues = new List<string> { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };   //To retrieve non-
                                                                                                                                                                // numeric names mainly
            int count = 1;
            string tempSuit = "";
            while (count < 53)
            {
                if (count < 14)
                {
                    tempSuit = "Clubs";
                }
                if ((count > 13) & (count < 27))    //13 cards in each suit so these bounds are set appropriately
                {
                    tempSuit = "Diamonds";
                }
                if ((count > 26) & (count < 40))
                {
                    tempSuit = "Hearts";
                }
                if ((count > 39) & (count < 53))
                {
                    tempSuit = "Spades";
                }
                myDeck.Add(new Card
                {
                    Suit = tempSuit,
                    Value = adjustedValues[(count % 13)]

                }); ;
                count++;
            }
            Shuffle(myDeck);

        }
        static void Shuffle(List<Card> myDeck)
        {
            var shuffledMyDeck = myDeck.OrderBy(x => Guid.NewGuid()).ToList();  //GUID based shuffling system
            Deal(shuffledMyDeck);

        }
        static void Deal(List<Card> shuffledMyDeck)
        {
            int count = 0;
            while (count < 51)
            {
                Console.WriteLine("Enter d to deal a card > "); //d for the first letter of deal. Not so random.
                if (Console.ReadLine() != "d")
                {
                    Console.WriteLine("Enter d to deal a card > ");
                }
                Console.WriteLine("*************************************************************************");
                Console.WriteLine(shuffledMyDeck[count].Value); //These format for a card-dealing output
                Console.WriteLine("of");
                Console.WriteLine(shuffledMyDeck[count].Suit);
                Console.WriteLine("*************************************************************************");
                count++;    //Increments count by 1 to adjust values appropriately
            }
            isEmpty();
        }
        static void isEmpty()   //Lets the user know why cards have stopped being dealt (no more)
        {
            Console.WriteLine("Deck is now Empty");
        }
    }
    class Card
    {
        public string Suit { get; set; }     // Gets and sets the recommended attributes
        public string Value { get; set; }
    }
}
