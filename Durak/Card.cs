using System;
using System.Text;

namespace Durak
{
    public class Card : IEquatable<Card>, IComparable<Card>
    {
        //field variable for Card Class
        private readonly CardSuit fCardSuit;
        private readonly CardRank fCardRank;
        private bool fIsTrumpCard = false;

        // Encapsulate field properties
        public CardSuit CardSuitProperty { get => fCardSuit; }
        public CardRank CardRankProperty { get => fCardRank; }
        public bool IsTrumpCardProperty { get => fIsTrumpCard; set => fIsTrumpCard = value; }

        // to initialise the default value to the default constructor
        //private const CardSuit DEFAULT_CARD_SUIT = CardSuit.Heart;
        //private const CardRank DEFAULT_CARD_RANK = CardRank.Ace;

        /// <summary>
        /// defalut constructor 
        /// </summary>
        public Card()
        {
        }

        /// <summary>
        /// constructor with arguments to initialise the card value
        /// </summary>
        /// <param name="aCardSuit"></param>
        /// <param name="aCardRank"></param>
        public Card(CardSuit aCardSuit, CardRank aCardRank)
        {
            fCardSuit = aCardSuit;
            fCardRank = aCardRank;
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder lBuilder = new StringBuilder();
            return lBuilder.Append("Card{ Rank = ")
                    .Append(fCardRank.ToString())
                    .Append(",\tSuit = ")
                    .Append(fCardSuit.ToString())
                    .Append(",\tTrump Card = ")
                    .Append(fIsTrumpCard.ToString())
                    .Append("}").ToString();
        }

        /// <summary>
        /// Get the hash code for the current instance
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() // reference from https://docs.microsoft.com/en-us/visualstudio/ide/reference/generate-equals-gethashcode-methods?view=vs-2019 to generate hashcode
        {
            var lhashCode = 352033288;
            lhashCode = lhashCode * (-1521134295) + fCardRank.GetHashCode();
            lhashCode = lhashCode * (-1521134295) + fCardSuit.GetHashCode();
            return lhashCode;
        }
        // operator overloading

        public override bool Equals(object aObj)
        {
            return Equals(aObj as Card);
        }

        public bool Equals(Card other)
        {
            return !(other is null) && (fCardSuit == other.fCardSuit) && (fCardRank == other.fCardRank);
        }

        public int CompareTo(Card other)
        {
            if (other is null)
            {
                return 1;
            }

            Card lCard = other as Card;
            if (!(lCard is null))
            {
                return this.fCardRank.CompareTo(other.fCardRank);
            }
            else
            {
                throw new ArgumentException("Object is not a Card");
            }
        }

        /// <summary>
        /// compare two card with their suit and rank
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <returns></returns>
        public static bool operator !=(Card aCard1, Card aCard2)
        {
            return !(aCard1 == aCard2);
        }

        /// <summary>
        /// compare two card with their suit and rank
        /// </summary>
        /// <param name="aCard1"></param>
        /// <param name="aCard2"></param>
        /// <returns></returns>
        public static bool operator ==(Card aCard1, Card aCard2)
        {
            return (aCard1.fCardSuit == aCard2.fCardSuit) && (aCard1.fCardRank == aCard2.fCardRank);
        }

        /// <summary>
        /// check if card1 is greater than card2
        /// </summary>
        /// <param name="aCard1"></param>
        /// <param name="aCard2"></param>
        /// <returns></returns>
        public static bool operator >(Card aCard1, Card aCard2)
        {
            
            if (aCard1.fCardSuit == aCard2.fCardSuit)
            {
                if (aCard1.fCardRank == CardRank.Ace && aCard2.fCardRank == CardRank.Ace)
                {
                    return false;
                }
                else if (aCard1.fCardRank == CardRank.Ace && aCard2.fCardRank != CardRank.Ace)
                {
                    return true;
                }
                else if (aCard1.fCardRank != CardRank.Ace && aCard2.fCardRank == CardRank.Ace)
                {
                    return false;
                }
                else
                {
                    return aCard1.fCardRank > aCard2.fCardRank;
                }
            }
            else
            {
                if(aCard1.fIsTrumpCard == true && aCard2.fIsTrumpCard == false)
                {
                    return true;
                }
                else if(aCard1.fIsTrumpCard == true && aCard2.fIsTrumpCard == true)
                {
                    return aCard1.fCardRank > aCard2.fCardRank;
                }
                else if (aCard1.CardRankProperty == aCard2.CardRankProperty)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// check if card2 is greater than card1
        /// </summary>
        /// <param name="aCard1"></param>
        /// <param name="aCard2"></param>
        /// <returns></returns>
        public static bool operator <(Card aCard1, Card aCard2)
        {
            return !(aCard1 > aCard2);
        }
    }
}
