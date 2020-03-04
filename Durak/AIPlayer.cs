using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
namespace Durak
{
    public class AIPlayer : Player
    {
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

        public override void Attack(Game aGame)
        {
            //if (fPlayerHand.HandCount() >= 0)
            //{
                Card lCard = new Card();
                Console.WriteLine("Thinking ........");
                Thread.Sleep(2000);
                
                // logic to attack with the lowest card except Ace
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
                else
                {
                    lCard = fPlayerHand.PlayerHandDeck.Min();
                }

                aGame.River.AddCard(lCard);
                fPlayerHand.RemoveCard(lCard);
                //may need to call end turn method
            //}
            //else
            //{
            //    aGame.EndTurn();
            //}

        }

        public override void Defend(Game aGame)
        {
            Console.WriteLine("Thinking ........");
            Thread.Sleep(2000);
            //if (fPlayerHand.HandCount() > 0)
            //{
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
                            Take(aGame.River.RiverCards);
                            aGame.EndTurn();
                        }
                    }
                }
                // may need to call endturn method
            //}
            //else
            //{
            //    aGame.EndTurn();
            //}
        }
    }
}
