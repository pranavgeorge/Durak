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
                MyGame.Players[0].IsThrowing = true;
                MyGame.Players[1].Status = GameStatus.Defending;
                MyGame.Players[1].IsThrowing = false;

                do
                {
                    if (MyGame.Players[0].IsThrowing == true)
                    {
                        if (MyGame.Players[0].PlayerHand.NumberOfCardsRemaining != 0)
                        {
                            Console.WriteLine("__________________________________________________");
                            Console.WriteLine("__________________________________________________");
                            Console.WriteLine(MyGame.Players[0].ToString());
                            Console.WriteLine("__________________________________________________");
                            Console.WriteLine("__________________________________________________");
                            Console.Write("Player Card Choice: ");
                            if (int.TryParse(Console.ReadLine(), out int PlayerCardChoice))
                            {
                                if (PlayerCardChoice == 0 && MyGame.River.NumberOfCards >= 1)
                                {
                                    MyGame.Players[0].Take(MyGame.River.RiverCards);
                                    MyGame.EndTurn();
                                    MyGame.Players[0].IsThrowing = false;
                                    Console.WriteLine("__________________________________________________");
                                    Console.WriteLine("__________________________________________________");
                                    Console.WriteLine(MyGame.River.ToString());
                                    Console.WriteLine("__________________________________________________");
                                    Console.WriteLine("__________________________________________________");
                                }
                                else if (PlayerCardChoice == 100 && MyGame.River.NumberOfCards > 1)
                                {
                                    if (MyGame.Players[0].Status == GameStatus.Attacking && MyGame.Players[0].IsThrowing == true)
                                    {
                                        MyGame.Players[0].IsThrowing = false;
                                        MyGame.EndTurn();
                                        Console.WriteLine(MyGame.River.ToString());
                                        Console.WriteLine("__________________________________________________");
                                        Console.WriteLine("__________________________________________________");
                                    }
                                }
                                else
                                {
                                    Play(MyGame, PlayerCardChoice);
                                    Console.WriteLine(MyGame.River.ToString());
                                    Console.WriteLine("__________________________________________________");
                                    Console.WriteLine("__________________________________________________");
                                    if (MyGame.River.NumberOfCards > 1)
                                    {
                                        if (!MyGame.River.CompareCards())
                                        {
                                            MyGame.EndTurn();
                                            Console.WriteLine("__________________________________________________");
                                            Console.WriteLine("__________________________________________________");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please type Numerical value and type 0 to take Cards from the river");
                            }
                        }
                    }

                    if (MyGame.Players[1].IsThrowing == true && MyGame.Players[1].PlayerHand.NumberOfCardsRemaining != 0)
                    {
                        Console.WriteLine(MyGame.Players[1].ToString());
                        Console.WriteLine("__________________________________________________");
                        Console.WriteLine("__________________________________________________");
                        if (MyGame.Players[1].Status == GameStatus.Defending && MyGame.River.NumberOfCards > 0)
                        {
                            MyGame.Players[1].Defend(MyGame);
                            if (MyGame.River.NumberOfCards != 0)
                                MyGame.Players[0].IsThrowing = true;
                        }
                        else if (MyGame.Players[1].Status == GameStatus.Attacking )
                        {
                            if (MyGame.River.NumberOfCards == 0)
                            {
                                MyGame.Players[1].Attack(MyGame);
                            }
                            else
                            {
                                MyGame.Players[1].Defend(MyGame);
                            }
                            if (MyGame.River.NumberOfCards != 0)
                                MyGame.Players[0].IsThrowing = true;
                        }
                        if (MyGame.River.NumberOfCards > 1)
                        {
                            if (!MyGame.River.CompareCards())
                            {
                                MyGame.EndTurn();
                                Console.WriteLine("__________________________________________________");
                                Console.WriteLine("__________________________________________________");
                            }
                        }
                        Console.WriteLine(MyGame.River.ToString());
                        Console.WriteLine("__________________________________________________");
                        Console.WriteLine("__________________________________________________");
                    }
                    else
                    {
                        MyGame.EndTurn();
                    }
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
            MyGame.Players[0].IsThrowing = false;
            MyGame.Players[1].IsThrowing = true;

        }
    }
}
