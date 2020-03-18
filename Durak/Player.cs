using System;
using System.Collections.Generic;
using System.Text;

namespace Durak
{
    public class Player
    {
        private static readonly string DEFALUT_NAME = "Pranav"; // Default Name in the Game
        private static readonly int MINIMUM_HAND_SIZE = 6;
        private const GameStatus DEFAULT_GAME_STATUS = GameStatus.None;

        #region field variable for Player Class
        // Player name in the game
        protected string fPlayerName;
        // Number of Cards that player will hold
        protected PlayerHand fPlayerHand;
        // Status of the Player
        protected GameStatus fGameStatus;
        #endregion

        #region Encapsulate field properties
        /// <summary>
        /// Get Property for Player Name
        /// </summary>
        public string PlayerName { get => fPlayerName; }
        /// <summary>
        /// Get and Set Property for Player Hand
        /// </summary>
        public PlayerHand PlayerHand { get => fPlayerHand; set => fPlayerHand = value; }
        /// <summary>
        /// Get and Set Property for GameStatus <see cref="GameStatus"/>
        /// </summary>
        public GameStatus Status { get => fGameStatus; set => fGameStatus = value; }
        #endregion

        #region Constructor
        // default Constructor
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
        #endregion

        #region Methods for Player
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
        /// Fills the player hand with at least 6 cards throughout the game
        /// </summary>
        /// <param name="aDeck">Current Deck in the game</param>
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
        /// Take all the Cards from the table when Player loses the Attack or defence
        /// </summary>
        /// <param name="aCards">Cards from the Table</param>
        public void Take(List<Card> aCards)
        {

            if (!Object.ReferenceEquals(aCards, null))
            {
                fPlayerHand.AddCard(aCards);
            }
            // may need to call endturn
            else
            {
                throw new ArgumentNullException("Argument passed is Null");
            }
        }
        #endregion

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
    }
}
