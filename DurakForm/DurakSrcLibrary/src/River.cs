using System;
using System.Collections.Generic;
using System.Text;

namespace DurakSrcLibrary
{
    public class River
    {
        #region field variables for River
        private List<Card> fRiverCards;
        private int fNumberOfCards;
        #endregion

        #region Encapsulate field variables
        /// <summary>
        /// Get Property of River Cards
        /// </summary>
        public List<Card> RiverCards { get => fRiverCards; }

        /// <summary>
        /// Get number of cards in river
        /// </summary>
        public int NumberOfCards { get => fNumberOfCards; }
        #endregion

        #region Constructor
        /// <summary>
        /// default Constructor
        /// </summary>
        public River()
        {
            fRiverCards = new List<Card>();
        }

        /// <summary>
        /// parameriterized constructor that set the river
        /// </summary>
        /// <param name="aRiverCards"></param>
        public River(List<Card> aRiverCards)
        {
            fRiverCards = new List<Card>();
            fRiverCards = aRiverCards;
        }
        #endregion

        #region Methods for River

        /// <summary>
        /// Add Cards to River
        /// </summary>
        /// <param name="aCard"></param>
        public void AddCard(Card aCard)
        {
            fRiverCards.Add(aCard);
            fNumberOfCards = fRiverCards.Count;
        }

        /// <summary>
        /// Remove Card from the river
        /// </summary>
        /// <param name="aCard"></param>
        public void RemoveCard(Card aCard)
        {
            if (!(aCard is null))
            {
                if (fRiverCards.Contains(aCard))
                {
                    fRiverCards.Remove(aCard);
                    fNumberOfCards = fRiverCards.Count;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Card Doesn't exist in the river");
                }
            }
            else
            {
                throw new ArgumentNullException($"Null Card is passed to remove from river.\nCard: {aCard.ToString()}");
            }

        }

        /// <summary>
        /// Remove All the Crad from the River
        /// </summary>
        /// <returns></returns>
        public List<Card> RemoveCard()
        {
            if (fNumberOfCards > 0)
            {
                List<Card> lCards = new List<Card>();
                foreach (Card item in fRiverCards)
                {
                    lCards.Add(item);
                }
                ClearRiver();
                return lCards;
            }
            else
            {
                throw new InitializationException("River is Empty");
            }
        }

        /// <summary>
        /// Compare the Players card Dealt on the river
        /// </summary>
        /// <returns></returns>
        public bool CompareCards()
        {
            Console.WriteLine(fRiverCards.Count);
            Console.WriteLine(fRiverCards[fNumberOfCards - 1].ToString() + " > " + fRiverCards[fNumberOfCards - 2].ToString());
            Console.WriteLine(fRiverCards[fNumberOfCards - 1] > fRiverCards[fNumberOfCards - 2]);
            return fRiverCards[fNumberOfCards - 1] > fRiverCards[fNumberOfCards - 2];
        }

        /// <summary>
        /// Clear the River List
        /// </summary>
        public void ClearRiver()
        {
            fRiverCards.Clear();
            fNumberOfCards = fRiverCards.Count;
        }
        #endregion

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder lBuilder = new StringBuilder();
            lBuilder.AppendLine("River: ");
            foreach (Card item in fRiverCards)
            {
                lBuilder.AppendLine(item.ToString());
            }
            return lBuilder.Append("Number Of Cards Remaining: ")
                           .Append(fNumberOfCards.ToString()).ToString();
        }
    }
}
