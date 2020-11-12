using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prob5
{
    public class DeckOfCards
    {
        #region Constant Fields
        #region public

        #endregion

        #region private
        private const int NUMBER_OF_CARDS = 52;

        private enum cardsFaces
        {
            DEUCE = 0,
            THREE,
            FOUR,
            FIVE,
            SIX,
            SEVEN,
            EIGTH,
            NINE,
            TEN,
            JACK,
            QUEEN,
            KING,
            ACE
        }

        #endregion
        #endregion

        #region Fields
        #region public

        #endregion

        #region private
        private Card[] deck;
        private int currentCard;
        private Random randomNumber;
        private string[] faces = { "Ace", "Deuce", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
        private string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };

        #endregion
        #endregion

        #region Constructors
        public DeckOfCards()
        {
            currentCard = 0;
            randomNumber = new Random();

            deck = new Card[NUMBER_OF_CARDS];
            for (int i = 0; i < deck.Length; i++)
            {
                deck[i] = new Card(faces[i % 13], suits[i / 13]);
            }

            Shuffle();
        }

        #endregion

        #region Methods
        #region public
        public void Shuffle()
        {
            currentCard = 0;

            for (int cardId = 0; cardId < deck.Length; cardId++)
            {
                int randomCardId = randomNumber.Next(NUMBER_OF_CARDS);

                Card temp = deck[cardId];
                deck[cardId] = deck[randomCardId];
                deck[randomCardId] = temp;
            }
        }

        public Card DealCard()
        {
            Card newCard = null;

            if (CanDealCard())
            {
                newCard = deck[currentCard];
                currentCard++;
            }

            return newCard;
        }

        public Card[] DealFiveCards()
        {
            Card[] hand = null;

            if (!CanDealFiveCards())
            {
                currentCard = 0;
                Shuffle();
            }

            hand = new Card[5];
            for (int i = 0; i < hand.Length; i++)
            {
                hand[i] = DealCard();
            }

            return hand;
        }

        public int[] totalHand()
        {
            int[] hands = new int[13];

            for (int i = 0; i < 13; i++)
            {
                Card[] playerHand = DealFiveCards();

                ShowHandType(playerHand);

                hands[i] = CountSpecificFaceInHand(playerHand, faces[i]);
            }

            return hands;
        }

        public void PrintHandType(Card[] hand, string typeHand)
        {
            Console.WriteLine($"{typeHand}");
            foreach (var card in hand)
            {
                Console.Write($"{card.ToString()}, ");
            }

            Console.WriteLine();
        }

        public void PrintHand(Card[] hand)
        {
            foreach (var card in hand)
            {
                Console.Write($"{card.ToString()}, ");
            }

            Console.WriteLine();
        }

        public void SortHand(Card[] hand)
        {
            Card key;
            int j;
            for (int i = 1; i < hand.Length; i++)
            {
                key = hand[i];
                j = i - 1;

                while (j >= 0 &&
                    CardPower(hand[j]) > CardPower(key))
                {
                    hand[j + 1] = hand[j];
                    j = j - 1;
                }

                hand[j + 1] = key;
            }
        }

        public bool IsPair(Card[] hand)
        {
            SortHand(hand);

            for (int i = 1; i < hand.Length; i++)
            {
                if (CardPower(hand[i - 1]) == CardPower(hand[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsTwoPair(Card[] hand)
        {
            SortHand(hand);

            int pairCounter = 0;
            for (int i = 1; i < hand.Length; i++)
            {
                if (CardPower(hand[i - 1]) == CardPower(hand[i]))
                {
                    pairCounter++;
                    i++;
                }
            }

            if (pairCounter == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsThreeOfAKind(Card[] hand)
        {
            SortHand(hand);

            int sameCardPowerCounter = 0;
            for (int i = 1; i < hand.Length; i++)
            {
                if (CardPower(hand[i - 1]) == CardPower(hand[i]))
                {
                    sameCardPowerCounter++;
                }
                else if (sameCardPowerCounter == 2 && i > 2)
                {
                    return true;
                }
                else
                {
                    sameCardPowerCounter = 0;
                }
            }

            return false;
        }

        public bool IsFourOfAKind(Card[] hand)
        {
            SortHand(hand);

            int sameCardPowerCounter = 0;
            for (int i = 1; i < hand.Length; i++)
            {
                if (CardPower(hand[i - 1]) == CardPower(hand[i]))
                {
                    sameCardPowerCounter++;
                }
                else
                {
                    sameCardPowerCounter = 0;
                }

            }

            if (sameCardPowerCounter == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFlush(Card[] hand)
        {
            if (hand[0].Suit == hand[1].Suit &&
                hand[1].Suit == hand[2].Suit &&
                hand[2].Suit == hand[3].Suit &&
                hand[3].Suit == hand[4].Suit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsStraight(Card[] hand)
        {
            SortHand(hand);

            if (hand[0].Suit == hand[1].Suit &&
                hand[1].Suit == hand[2].Suit &&
                hand[2].Suit == hand[3].Suit &&
                hand[3].Suit == hand[4].Suit &&
                CardPower(hand[0]) < CardPower(hand[1]) &&
                CardPower(hand[1]) < CardPower(hand[2]) &&
                CardPower(hand[2]) < CardPower(hand[3]) &&
                CardPower(hand[3]) < CardPower(hand[4]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFullHouse(Card[] hand)
        {
            SortHand(hand);

            if ((CardPower(hand[0]) == CardPower(hand[1]) &&
                 CardPower(hand[1]) == CardPower(hand[2]) &&
                 CardPower(hand[2]) != CardPower(hand[3]) &&
                 CardPower(hand[3]) == CardPower(hand[4]))
                 ||
                (CardPower(hand[0]) == CardPower(hand[1]) &&
                 CardPower(hand[1]) != CardPower(hand[2]) &&
                 CardPower(hand[2]) == CardPower(hand[3]) &&
                 CardPower(hand[3]) == CardPower(hand[4])))
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        #endregion

        #region private
        private bool CanDealCard()
        {
            if (currentCard < deck.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CanDealFiveCards()
        {
            if (currentCard + 4 < deck.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int CardPower(Card card)
        {
            switch (card.Face)
            {
                case "Deuce":
                    return (int)cardsFaces.DEUCE;
                case "Three":
                    return (int)cardsFaces.THREE;
                case "Four":
                    return (int)cardsFaces.FOUR;
                case "Five":
                    return (int)cardsFaces.FIVE;
                case "Six":
                    return (int)cardsFaces.SIX;
                case "Seven":
                    return (int)cardsFaces.SEVEN;
                case "Eight":
                    return (int)cardsFaces.EIGTH;
                case "Nine":
                    return (int)cardsFaces.NINE;
                case "Ten":
                    return (int)cardsFaces.TEN;
                case "Jack":
                    return (int)cardsFaces.JACK;
                case "Queen":
                    return (int)cardsFaces.QUEEN;
                case "King":
                    return (int)cardsFaces.KING;
                case "Ace":
                    return (int)cardsFaces.ACE;
                default:
                    return -1;
                    break;
            }
        }

        private int CountSpecificFaceInHand(Card[] hand, string face)
        {
            int counter = 0;
            foreach (var card in hand)
            {
                if (card.Face == face)
                {
                    counter++;
                }
            }

            return counter;
        }

        private void ShowHandType(Card[] hand)
        {
            if (IsPair(hand))
            {
                PrintHandType(hand, "Pair");
            }
            else if (IsTwoPair(hand))
            {
                PrintHandType(hand, "Two Pair");
            }
            else if (IsThreeOfAKind(hand))
            {
                PrintHandType(hand, "Three Of A Kind");
            }
            else if (IsFourOfAKind(hand))
            {
                PrintHandType(hand, "Four Of A Kind");
            }
            else if (IsFlush(hand))
            {
                PrintHandType(hand, "Flush");
            }
            else if (IsFullHouse(hand))
            {
                PrintHandType(hand, "Fool House");
            }
            else
            {
                Console.WriteLine("Hand is not good...");
                PrintHand(hand);
            }
            Console.WriteLine();
        }

        #endregion
        #endregion
    }
}