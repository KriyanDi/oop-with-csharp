using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prob5
{
    public class DeckOfCardsTest
    {
        static private void RandomHandTest()
        {
            Console.WriteLine("Random hand:");
            DeckOfCards myDeckOfCards = new DeckOfCards();
            Card[] hand = myDeckOfCards.DealFiveCards();
            myDeckOfCards.PrintHand(hand);

            Console.WriteLine();
        }
        static private void SortHandTest()
        {
            Console.WriteLine("SortHand:");
            DeckOfCards myDeckOfCards = new DeckOfCards();
            Card[] handUnsorted = myDeckOfCards.DealFiveCards();
            myDeckOfCards.PrintHand(handUnsorted);
            myDeckOfCards.SortHand(handUnsorted);
            myDeckOfCards.PrintHand(handUnsorted);

            Console.WriteLine();
        }
        static private void IsTestedHandDesiredType(bool isItDesiredType)
        {
            if (isItDesiredType)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
        static private void IsHandPairTest()
        {
            Console.Write("Pair: ");
            DeckOfCards myDeckOfCards = new DeckOfCards();
            Card[] handPair = { new Card("Three", "Hearts"),
                                new Card("Eight", "Diamonds"),
                                new Card("Ace", "Clubs"),
                                new Card("Six", "Clubs"),
                                new Card("Ace", "Spades")};

            IsTestedHandDesiredType(myDeckOfCards.IsPair(handPair));
        }
        static private void IsHandTwoPairTest()
        {
            Console.Write("Two Pair: ");
            DeckOfCards myDeckOfCards = new DeckOfCards();
            Card[] handTwoPair = { new Card("Three", "Hearts"),
                                   new Card("Eight", "Diamonds"),
                                   new Card("Ace", "Clubs"),
                                   new Card("Eight", "Clubs"),
                                   new Card("Three", "Spades")};

            IsTestedHandDesiredType(myDeckOfCards.IsTwoPair(handTwoPair));
        }
        static private void IsHandThreeOfAKindTest()
        {
            Console.Write("Three of a kind: ");
            DeckOfCards myDeckOfCards = new DeckOfCards();
            Card[] handThreeOfAKind = { new Card("Three", "Hearts"),
                                        new Card("Eight", "Diamonds"),
                                        new Card("Three", "Clubs"),
                                        new Card("Six", "Clubs"),
                                        new Card("Three", "Spades")};

            IsTestedHandDesiredType(myDeckOfCards.IsThreeOfAKind(handThreeOfAKind));
        }
        static private void IsHandFlushTest()
        {
            Console.Write("Flush: ");
            DeckOfCards myDeckOfCards = new DeckOfCards();
            Card[] handFlush = { new Card("King", "Hearts"),
                                 new Card("Ten", "Hearts"),
                                 new Card("Eight", "Hearts"),
                                 new Card("Seven", "Hearts"),
                                 new Card("Jack", "Hearts")};

            IsTestedHandDesiredType(myDeckOfCards.IsFlush(handFlush));
        }
        static private void IsHandStraightTest()
        {
            Console.Write("Straight: ");
            DeckOfCards myDeckOfCards = new DeckOfCards();
            Card[] handStraight = { new Card("Nine", "Hearts"),
                                    new Card("Ten", "Hearts"),
                                    new Card("King", "Hearts"),
                                    new Card("Queen", "Hearts"),
                                    new Card("Jack", "Hearts")};

            IsTestedHandDesiredType(myDeckOfCards.IsStraight(handStraight));
        }
        static private void IsHandFullHouseTest()
        {
            Console.Write("Full house: ");
            DeckOfCards myDeckOfCards = new DeckOfCards();
            Card[] handFullHouse = { new Card("Nine", "Hearts"),
                                    new Card("Ten", "Hearts"),
                                    new Card("Ten", "Clubs"),
                                    new Card("Nine", "Diamonds"),
                                    new Card("Nine", "Clubs")};

            IsTestedHandDesiredType(myDeckOfCards.IsFullHouse(handFullHouse));
        }
        static private void GameRoundsTest()
        {
            Console.WriteLine("Game rounds:");
            DeckOfCards myDeckOfCards = new DeckOfCards();
            myDeckOfCards.totalHand();
        }

        public DeckOfCardsTest()
        {
            Console.WriteLine("Test:");

            RandomHandTest();
            SortHandTest();

            IsHandPairTest();
            IsHandTwoPairTest();
            IsHandThreeOfAKindTest();
            IsHandFlushTest();
            IsHandStraightTest();
            IsHandFullHouseTest();

            GameRoundsTest();
        }
    }
}
