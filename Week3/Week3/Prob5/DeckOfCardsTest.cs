using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prob5
{
    public class DeckOfCardsTest
    {
        public DeckOfCardsTest()
        {
            DeckOfCards myDeckOfCards = new DeckOfCards();

            Console.WriteLine("Test:");

            //Random hand
            Console.WriteLine("Random hand:");
            Card[] hand = myDeckOfCards.DealFiveCards();
            myDeckOfCards.PrintHand(hand);

            Console.WriteLine();

            //Sort hand
            Console.WriteLine("SortHand:");
            Card[] handUnsorted = myDeckOfCards.DealFiveCards();
            myDeckOfCards.PrintHand(handUnsorted);
            myDeckOfCards.SortHand(handUnsorted);
            myDeckOfCards.PrintHand(handUnsorted);

            Console.WriteLine();
            //pair
            Console.Write("Pair: ");
            Card[] handPair = { new Card("Three", "Hearts"),
                                new Card("Eight", "Diamonds"),
                                new Card("Ace", "Clubs"),
                                new Card("Six", "Clubs"),
                                new Card("Ace", "Spades")};
            if (myDeckOfCards.IsPair(handPair)) { Console.WriteLine("Yes"); } else { Console.WriteLine("No"); }

            //two pair
            Console.Write("Two Pair: ");
            Card[] handTwoPair = { new Card("Three", "Hearts"),
                                   new Card("Eight", "Diamonds"),
                                   new Card("Ace", "Clubs"),
                                   new Card("Eight", "Clubs"),
                                   new Card("Three", "Spades")};
            if (myDeckOfCards.IsTwoPair(handTwoPair)) { Console.WriteLine("Yes"); } else { Console.WriteLine("No"); }

            //three of a kind
            Console.Write("Three of a kind: ");
            Card[] handThreeOfAKind = { new Card("Three", "Hearts"),
                                        new Card("Eight", "Diamonds"),
                                        new Card("Three", "Clubs"),
                                        new Card("Six", "Clubs"),
                                        new Card("Three", "Spades")};
            if (myDeckOfCards.IsThreeOfAKind(handThreeOfAKind)) { Console.WriteLine("Yes"); } else { Console.WriteLine("No"); }

            //four of a kind
            Console.Write("Four of a kind: ");
            Card[] handFourOfAKind = { new Card("Ace", "Hearts"),
                                       new Card("Eight", "Diamonds"),
                                       new Card("Ace", "Clubs"),
                                       new Card("Ace", "Diamonds"),
                                       new Card("Ace", "Spades")};
            if (myDeckOfCards.IsFourOfAKind(handFourOfAKind)) { Console.WriteLine("Yes"); } else { Console.WriteLine("No"); }

            //flush
            Console.Write("Flush: ");
            Card[] handFlush = { new Card("King", "Hearts"),
                                 new Card("Ten", "Hearts"),
                                 new Card("Eight", "Hearts"),
                                 new Card("Seven", "Hearts"),
                                 new Card("Jack", "Hearts")};
            if (myDeckOfCards.IsFlush(handFlush)) { Console.WriteLine("Yes"); } else { Console.WriteLine("No"); }

            //straight
            Console.Write("Straight: ");
            Card[] handStraight = { new Card("Nine", "Hearts"),
                                    new Card("Ten", "Hearts"),
                                    new Card("King", "Hearts"),
                                    new Card("Queen", "Hearts"),
                                    new Card("Jack", "Hearts")};
            if (myDeckOfCards.IsStraight(handStraight)) { Console.WriteLine("Yes"); } else { Console.WriteLine("No"); }

            //full house
            Console.Write("Full house: ");
            Card[] handFullHouse = { new Card("Nine", "Hearts"),
                                    new Card("Ten", "Hearts"),
                                    new Card("Ten", "Clubs"),
                                    new Card("Nine", "Diamonds"),
                                    new Card("Nine", "Clubs")};
            if (myDeckOfCards.IsFullHouse(handFullHouse)) { Console.WriteLine("Yes"); } else { Console.WriteLine("No"); }

            Console.WriteLine();

            //Game rounds
            Console.WriteLine("Game rounds:");
            myDeckOfCards.totalHand();
        }
    }
}