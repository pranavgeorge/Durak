using System;

namespace Durak
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            try
            {
                Game MyGame = new Game(2, 20);
                Console.WriteLine();
                Console.WriteLine("__________________________________________________");
                MyGame.Players[0].Status = GameStatus.Attacking;
                MyGame.Players[1].Status = GameStatus.Defending;

                do
                {
                    Console.WriteLine(MyGame.Players[0].ToString());
                    Console.WriteLine("__________________________________________________");
                    Console.Write("Player Card Choice: ");
                    if (MyGame.Players[0].PlayerHand.NumberOfCardsRemaining != 0)
                    {
                        if (int.TryParse(Console.ReadLine(), out int PlayerCardChoice))
                        {
                            if (PlayerCardChoice == 0)
                            {
                                MyGame.Players[0].Take(MyGame.River.RiverCards);
                                MyGame.EndTurn();
                                Console.WriteLine("__________________________________________________");
                                Console.WriteLine(MyGame.River.ToString());
                                Console.WriteLine("__________________________________________________");
                            }
                            else
                            {
                                Play(MyGame, PlayerCardChoice);
                                Console.WriteLine(MyGame.Players[1].ToString());
                                if (MyGame.River.NumberOfCards > 1)
                                {
                                    if (!MyGame.River.CompareCards())
                                    {
                                        MyGame.EndTurn();
                                        Console.WriteLine(MyGame.Players[1].ToString());
                                        MyGame.Players[1].Attack(MyGame);
                                        Console.WriteLine(MyGame.River.ToString());
                                        Console.WriteLine("__________________________________________________");
                                    }
                                    else
                                    {
                                        MyGame.SwapTurn();   //MyGame.EndTurn();
                                    }
                                }

                                if (MyGame.Players[1].Status == GameStatus.Defending)
                                {
                                    MyGame.Players[1].Defend(MyGame);
                                }
                                else if (MyGame.Players[1].Status == GameStatus.Attacking)
                                {
                                    MyGame.Players[1].Attack(MyGame);
                                }
                                Console.WriteLine();
                                Console.WriteLine("__________________________________________________");
                                Console.WriteLine(MyGame.River.ToString());
                                Console.WriteLine("__________________________________________________");
                                if (!MyGame.River.CompareCards())
                                {
                                    MyGame.EndTurn();
                                    Console.WriteLine(MyGame.Players[1].ToString());
                                    MyGame.Players[1].Attack(MyGame);
                                    Console.WriteLine(MyGame.River.ToString());
                                    Console.WriteLine("__________________________________________________");
                                }
                                else
                                {
                                    MyGame.SwapTurn();   //MyGame.EndTurn();
                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine("Please type Numerical value and type 0 to take Cards from the river");
                        }
                    }
                    else
                    {
                        MyGame.EndTurn();
                    }

                    //MyGame.Players[0].GameStatus = GameStatus.Won;
                } while (MyGame.Players[0].Status != GameStatus.Won || MyGame.Players[0].Status != GameStatus.Lost);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        private static void Play(Game MyGame, int aPlayerCardChoice)
        {
            Card card = MyGame.Players[0].PlayerHand.ChooseCardFromPlayerHand(aPlayerCardChoice - 1);
            MyGame.River.AddCard(card);
            MyGame.Players[0].PlayerHand.RemoveCard(card);

        }
    }
}
