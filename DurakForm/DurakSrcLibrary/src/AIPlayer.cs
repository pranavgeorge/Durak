using System;
using System.Threading;
using System.Linq;

namespace DurakSrcLibrary
{
    public class AIPlayer : Player
    {
        #region Constructor
        /// <summary>
        /// default constructor
        /// </summary>
        public AIPlayer() : base()
        {
        }

        /// <summary>
        /// Constructor that takes Player Name
        /// </summary>
        /// <param name="aPlayerName">Player Name</param>
        public AIPlayer(string aPlayerName) : base(aPlayerName)
        {

        }
        #endregion

        #region Methods for AIPlayer
        public override void Attack(Game aGame)
        {
            Card lCard = new Card();
            Console.WriteLine("Thinking during Attack........");
            Thread.Sleep(1500);

            // If AiPlayer has Ace in Hand, logic to attack with the lowest card except Ace
            if (fPlayerHand.PlayerHandDeck.Exists(x => x.CardRankProperty == CardRank.Ace) && fPlayerHand.HandCount() >= 1)
            {
                int lValue = 0;
                int lIndex = 0;
                bool lHasValue = false;
                for (int i = 0; i < fPlayerHand.PlayerHandDeck.Count; i++)
                {
                    Card item = fPlayerHand.PlayerHandDeck[i];
                    if (!(item.CardRankProperty == CardRank.Ace))
                    {
                        if (lHasValue)
                        {
                            if ((int)item.CardRankProperty < lValue)
                            {
                                lValue = (int)item.CardRankProperty;
                                lIndex = i; // store the lowest item index
                            }
                        }
                        else
                        {
                            lValue = (int)item.CardRankProperty;
                            lHasValue = true;
                        }
                    }
                }
                lCard = fPlayerHand.ChooseCardFromPlayerHand(lIndex);
            }
            // if AIPlayer doesn't have Ace in Hand
            else
            {
                //Choose the lowest rank card from the hand
                lCard = fPlayerHand.PlayerHandDeck.Min();
            }

            aGame.River.AddCard(lCard);
            fPlayerHand.RemoveCard(lCard);
        }

        public override void Defend(Game aGame)
        {
            Console.WriteLine("Thinking during defend........");
            Thread.Sleep(1500);
            Card lCard = new Card();
            int lIndex = aGame.River.NumberOfCards - 1;
            CardSuit lCardSuit = aGame.River.RiverCards[lIndex].CardSuitProperty;
            // if player hand contains the river card suit
            if (fPlayerHand.PlayerHandDeck.Exists(x => x.CardSuitProperty == lCardSuit))
            {
                lCard = (from x in fPlayerHand.PlayerHandDeck
                         where x.CardSuitProperty == lCardSuit
                         select x).Max();
                aGame.River.AddCard(lCard);
                fPlayerHand.RemoveCard(lCard);
            }
            else
            {
                CardRank lCardRank = aGame.River.RiverCards[lIndex].CardRankProperty;
                // if player hand doesn't contains the river card suit but has same card rank
                if (fPlayerHand.PlayerHandDeck.Exists(x => x.CardRankProperty == lCardRank))
                {
                    lCard = (from x in fPlayerHand.PlayerHandDeck
                             where x.CardRankProperty == lCardRank
                             select x).First();
                    //aGame.SwapTurn();
                    aGame.River.AddCard(lCard);
                    fPlayerHand.RemoveCard(lCard);
                }
                else
                {
                    // if player hand doesn't contains the river card suit but has trump card
                    if (fPlayerHand.PlayerHandDeck.Exists(x => x.IsTrumpCardProperty == true))
                    {
                        lCard = (from x in fPlayerHand.PlayerHandDeck
                                 where x.IsTrumpCardProperty == true
                                 select x).Max();
                        aGame.River.AddCard(lCard);
                        fPlayerHand.RemoveCard(lCard);
                    }
                    // if player hand doesn't contains the river card suit and trump card and same rank
                    else
                    {
                        if (this.fGameStatus == GameStatus.Attacking && fIsThrowing == true)
                        {
                            aGame.EndTurn();
                            if (Status == GameStatus.Defending && IsThrowing == true)
                            {
                                // Set Player throwing to true to start its turn
                                aGame.Players[0].IsThrowing = true;
                                // Set AIPlayer throwing to false to finish its turn
                                IsThrowing = false;
                            }
                            else if (Status == GameStatus.Attacking && IsThrowing == true)
                            {
                                // Set AIPlayer throwing to true to start its turn
                                IsThrowing = true;
                                // Set Player throwing to false to finish its turn
                                aGame.Players[0].IsThrowing = false;
                            }
                        }
                        else if (this.fGameStatus == GameStatus.Defending && fIsThrowing == true)
                        {
                            Take(aGame.River.RiverCards);
                            aGame.EndTurn();
                            if (Status == GameStatus.Defending && IsThrowing == true)
                            {
                                // Set Player throwing to true to start its turn
                                aGame.Players[0].IsThrowing = true;
                                // Set AIPlayer throwing to false to finish its turn
                                IsThrowing = false;
                            }
                            else if (Status == GameStatus.Attacking && IsThrowing == true)
                            {
                                // Set AIPlayer throwing to true to start its turn
                                IsThrowing = true;
                                // Set Player throwing to false to finish its turn
                                aGame.Players[0].IsThrowing = false;
                            }

                        }
                    }
                }
            }
        }
        #endregion
    }
}
