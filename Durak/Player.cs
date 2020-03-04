using System;
using System.Collections.Generic;
using System.Text;

namespace Durak
{
    public class Player
    {
        protected string fPlayerName; // Player name in the game
        protected PlayerHand fPlayerHand; // Number of Cards that player will hold
        protected GameStatus fGameStatus; // Status of the Player


        private static readonly string DEFALUT_NAME = "Pranav"; // Default Name in the Game
        private static readonly int MINIMUM_HAND_SIZE = 6;
        private const GameStatus DEFAULT_GAME_STATUS = GameStatus.None;

        //default constructor
        public Player()
        {
            fPlayerHand = new PlayerHand();
            fPlayerName = DEFALUT_NAME;
            fGameStatus = DEFAULT_GAME_STATUS;
        }

        // Parameterised constructor 
        public Player(string aPlayerName)
        {
            fPlayerHand = new PlayerHand();
            fPlayerName = aPlayerName;
            fGameStatus = DEFAULT_GAME_STATUS;
        }

        /// <summary>
        /// Player Start the attack
        /// </summary>
        /// <param name="aGame"></param>
        public virtual void Attack(Game aGame)
        {

        }

        /// <summary>
        /// Player defend the attack
        /// </summary>
        /// <param name="aGame"></param>
        public virtual void Defend(Game aGame)
        {

        }
        /// <summary>
        /// Property for Player Name
        /// </summary>
        public string PlayerName { get => fPlayerName; set => fPlayerName = value; }
        /// <summary>
        /// Property for Player Hand
        /// </summary>
        public PlayerHand PlayerHand { get => fPlayerHand; set => fPlayerHand = value; }
        /// <summary>
        /// Property for GameStatus
        /// </summary>
        public GameStatus GameStatus { get => fGameStatus; set => fGameStatus = value; }

        /// <summary>
        /// Fills the player hand with at least 6 cards throughout the game
        /// </summary>
        /// <param name="aDeck"></param>
        public void CompleteHand(CardDeck aDeck)
        {
            if (!(fPlayerHand.HandCount() > MINIMUM_HAND_SIZE))
            {
                List<Card> lCards = aDeck.RemoveCard(MINIMUM_HAND_SIZE - fPlayerHand.HandCount());
                foreach (Card item in lCards)
                {
                    fPlayerHand.AddCard(item);
                }
            }
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder lBuilder = new StringBuilder();
            return lBuilder.Append("Player Name: ")
                    .Append(fPlayerName)
                    .Append(Environment.NewLine)
                    .AppendLine(fPlayerHand.ToString()).ToString();
        }

        /// <summary>
        /// Take all the Cards from the table when Player loses the Attack or defence
        /// </summary>
        /// <param name="aCards">Cards from the Table</param>
        public void Take(List<Card> aCards) 
        {

            if(!Object.ReferenceEquals(aCards, null))
            {
                fPlayerHand.AddCard(aCards);
            }
            // may need to call endturn
            else
            {
                throw new ArgumentNullException("Argument passed is Null");
            }
        }
    }
}
