using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DurakSrcLibrary
{
    public class PlayerHand
    {
        #region field variables for PlayerHand Class
        private List<Card> fPlayerCard;
        private int fNumberOfCardsRemaining;
        #endregion

        #region Constructor
        /// <summary>
        /// default constructor 
        /// </summary>
        public PlayerHand()
        {
            fPlayerCard = new List<Card>();
        }

        /// <summary>
        /// Constructor that takes card for the player
        /// </summary>
        /// <param name="aDeckCards"></param>
        public PlayerHand(List<Card> aDeckCards)
        {
            fPlayerCard = new List<Card>();
            fPlayerCard = aDeckCards;
        }
        #endregion

        #region Encapsulate field variables
        /// <summary>
        /// Get the cards available in player hand
        /// </summary>
        public List<Card> PlayerHandDeck { get => fPlayerCard; set => fPlayerCard = value; }
        /// <summary>
        /// Get total number of cards the Player Holds
        /// </summary>
        public int NumberOfCardsRemaining { get => fNumberOfCardsRemaining; }
        #endregion

        #region Methods for PlayerHand
        /// <summary>
        /// Add Card to Player Hand
        /// </summary>
        /// <param name="aCard"></param>
        public void AddCard(Card aCard)
        {
            fPlayerCard.Add(aCard);
            fNumberOfCardsRemaining = fPlayerCard.Count;
        }

        /// <summary>
        /// Add Multiple Cards to Player Hand
        /// </summary>
        /// <param name="aCard"></param>
        public void AddCard(List<Card> aCard)
        {
            //fPlayerCard.AddRange(aCard);
            foreach (Card item in aCard)
            {
                fPlayerCard.Add(item);
            }
            fNumberOfCardsRemaining = fPlayerCard.Count;
        }

        /// <summary>
        /// remove card at Specific position
        /// </summary>
        /// <param name="aCardPositon"></param>
        /// <returns>Remove card</returns>
        public Card RemoveCard(int aCardPositon)
        {
            if (aCardPositon >= 0 && aCardPositon < 52)
            {
                Card lCard = fPlayerCard?.ElementAtOrDefault(aCardPositon);
                if (!lCard.Equals(null))
                {
                    fPlayerCard.RemoveAt(aCardPositon);
                    fNumberOfCardsRemaining = fPlayerCard.Count;
                    return lCard;
                }
                else
                {
                    throw new InitializationException("PlayerHand Collection is Empty");
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Cannot Remove the Card from the Deck, as it doesn,t exist in the deck");
            }

        }

        /// <summary>
        /// remove Card from the player hand by passing the card
        /// </summary>
        /// <param name="aCard"></param>
        public void RemoveCard(Card aCard)
        {
            if (!(aCard is null))
            {
                if (fPlayerCard.Contains(aCard))
                {
                    fPlayerCard.Remove(aCard);
                    fNumberOfCardsRemaining = fPlayerCard.Count;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Cannot Remove the Card from the Deck, as it doesn,t exist in the deck" + aCard.ToString());
                }
            }
            else
            {
                throw new ArgumentNullException($"Null Card is passed to remove from playerHand.\nCard: {aCard.ToString()}");
            }
        }

        /// <summary>
        /// return the choosen card from the playerHand
        /// </summary>
        /// <param name="aIndex"></param>
        /// <returns></returns>
        public Card ChooseCardFromPlayerHand(int aIndex)
        {
            Card lCard = fPlayerCard?.ElementAtOrDefault(aIndex);
            if (!lCard.Equals(null))
            {
                return lCard;
            }
            else
            {
                throw new InitializationException("PlayerHand Collection is Empty");
            }
        }

        /// <summary>
        /// Get the number of element in current instance
        /// </summary>
        /// <returns></returns>
        public int HandCount()
        {
            return fNumberOfCardsRemaining;
        }
        #endregion

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder lBuilder = new StringBuilder();
            foreach (Card item in fPlayerCard)
            {
                lBuilder.AppendLine(item.ToString());
            }
            _ = lBuilder.Append("Number Of Cards Remaining: ")
                    .Append(fNumberOfCardsRemaining.ToString());
            return lBuilder.ToString();
        }

        //public List<Card> SortPlayerHand()
        //{
        //    var vri = fPlayerCard.OrderByDescending(x => (int)(x.CardRankProperty)).ToList();
        //    return vri;
        //}
    }
}
