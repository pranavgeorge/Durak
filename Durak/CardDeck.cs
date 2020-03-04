using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Durak
{
    public class CardDeck
    {
        private static readonly int CARD_RANK_SIZE = Enum.GetValues(typeof(CardRank)).Length;
        private static readonly Random rand = new Random();

        /// <summary>
        /// default constructor that set all the card values with its suit
        /// </summary>
        public CardDeck()
        {
            PlayingCards = new List<Card>();
            // if not creating empty deck
            #region to create full deck
            //foreach (CardSuit suit in (CardSuit[])Enum.GetValues(typeof(CardSuit))) 
            //{
            //    foreach (CardRank rank in (CardRank[])Enum.GetValues(typeof(CardRank)))
            //    {
            //        PlayingCards.Add(new Card(suit, rank));
            //    }
            //}
            //Shuffle();
            #endregion
        }

        /// <summary>
        /// create a specific amount of deck according to user requirement
        /// this game supports range of 20, 36, and 52
        /// </summary>
        /// <param name="aDeckSize"></param>
        public CardDeck(int aDeckSize)
        {
            int lStartCardRank; // define the start point of the deck including ace card
            PlayingCards = new List<Card>();
            switch (aDeckSize)
            {
                case 52: // Card include [Ace,Deuce,Three,Four,Five,Six,Seven,Eight,Nine,Ten,Jack,Queen,King]x[Club,Diamond,Heart,Spade]
                    foreach (CardSuit suit in (CardSuit[])Enum.GetValues(typeof(CardSuit)))
                    {
                        foreach (CardRank rank in (CardRank[])Enum.GetValues(typeof(CardRank)))
                        {
                            PlayingCards.Add(new Card(suit, rank));
                        }
                    }
                    Initalise();
                    break;
                case 36: // Card include [Ace,Six,Seven,Eight,Nine,Ten,Jack,Queen,King]x[Club,Diamond,Heart,Spade]
                    lStartCardRank = 6;
                    foreach (CardSuit suit in (CardSuit[])Enum.GetValues(typeof(CardSuit)))
                    {
                        PlayingCards.Add(new Card(suit, CardRank.Ace));
                    }
                    /* PlayingCards.Add(new Card(CardSuit.Club, CardRank.Ace));
                       PlayingCards.Add(new Card(CardSuit.Diamond, CardRank.Ace));
                       PlayingCards.Add(new Card(CardSuit.Heart, CardRank.Ace));
                       PlayingCards.Add(new Card(CardSuit.Spade, CardRank.Ace));
                    */

                    foreach (CardSuit suit in (CardSuit[])Enum.GetValues(typeof(CardSuit))) 
                    {
                        for (int i = lStartCardRank; i <= CARD_RANK_SIZE; i++)
                        {
                            PlayingCards.Add(new Card(suit, (CardRank)i));
                        }
                    }
                    Initalise();
                    break;
                case 20: // Card include [Ace,Ten,Jack,Queen,King]x[Club,Diamond,Heart,Spade]
                    lStartCardRank = 10;
                    foreach (CardSuit suit in (CardSuit[])Enum.GetValues(typeof(CardSuit)))
                    {
                        PlayingCards.Add(new Card(suit, CardRank.Ace));
                    }
                    /* PlayingCards.Add(new Card(CardSuit.Club, CardRank.Ace));
                       PlayingCards.Add(new Card(CardSuit.Diamond, CardRank.Ace));
                       PlayingCards.Add(new Card(CardSuit.Heart, CardRank.Ace));
                       PlayingCards.Add(new Card(CardSuit.Spade, CardRank.Ace));
                    */

                    foreach(CardSuit suit in (CardSuit[])Enum.GetValues(typeof(CardSuit)))
                    {
                        for (int i = lStartCardRank; i <= CARD_RANK_SIZE; i++)
                        {
                            PlayingCards.Add(new Card(suit, (CardRank)i));
                        }
                    }
                    Initalise();
                    break;
                default:
                    // throw error if any other value is passed
                    throw new InvalidDeckSizeException("Not a valid Deck Size");
            }
        }

        private void Initalise()
        {
            Shuffle();
            SetTrumpSuit();
            PrintDeckCards();
        }
        /// <summary>
        /// Get list that represents the cards been generated of the given size
        /// </summary>
        public List<Card> PlayingCards { get; } // uses auto property


        /// <summary>
        /// Prints all the cards of the deck
        /// </summary>
        public void PrintDeckCards()
        {
            int i = 0;
            Console.WriteLine("Printing Deck Cards: ");
            foreach (Card item in PlayingCards)
            {
                Console.Write(++i + " =>\t");
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Shuffle All the cards in the deck using Fisher-Yates_shuffle
        /// </summary>
        private void Shuffle()
        {
            for (int n = GetDeckSize() - 1; n > 0; --n)
            {
                int k = rand.Next(n + 1);
                Swap(PlayingCards, n, k);
            }
        }

        private static void Swap(List<Card> list, int indexA, int indexB)
        {
            Card tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }

        /// <summary>
        /// return the deck size
        /// </summary>
        /// <returns></returns>
        public int GetDeckSize()
        {
            return PlayingCards.Count;
        }

        /// <summary>
        /// Initialise the trump cards in the Card deck
        /// </summary>
        /// <param name="aSuit"></param>
        private void SetTrumpSuit()
        {
            Card lCard = PlayingCards.ElementAt(12);
            PlayingCards.RemoveAt(12);
            PlayingCards.Add(lCard); 
            foreach (Card item in PlayingCards)
            {
                if (item.CardSuitProperty == lCard.CardSuitProperty)
                {
                    item.IsTrumpCardProperty = true;
                }
            }
        }

        /// <summary>
        /// Draws N number of card from the Deck
        /// </summary>
        /// <param name="aNumberOfCards"></param>
        /// <returns></returns>
        public List<Card> RemoveCard(int aNumberOfCards)
        {
            List<Card> lCards = new List<Card>();
            for (int i = 0; i < aNumberOfCards; i++)
            {
                if(PlayingCards.Count > 0)
                {
                    lCards.Add(PlayingCards.ElementAt(0));
                    PlayingCards.RemoveAt(0);
                }
                else
                {
                    break;
                }
                
            }
            return lCards;
        }

        /// <summary>
        /// Draws the first card from the deck
        /// </summary>
        /// <returns>the removed card from the deck</returns>
        public Card RemoveCard()
        {
            Card lCard = PlayingCards.First();
            PlayingCards.RemoveAt(0);
            return lCard;
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder lBuilder = new StringBuilder();
            lBuilder.AppendLine("Deck: ");
            foreach (Card item in PlayingCards)
            {
                _ = lBuilder.AppendLine(item.ToString());
            }
            return lBuilder.Append("Number Of Cards Remaining: ")
                           .AppendLine(PlayingCards.Count.ToString()).ToString();
        }
    }
}
