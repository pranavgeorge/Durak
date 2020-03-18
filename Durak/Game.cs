﻿using System;
using System.Collections.Generic;
namespace Durak
{
    public class Game
    {
        private List<Player> fPlayers;
        private CardDeck fDeck;
        private River fRiver;

        private const int DEFAULT_CARD_DECK_SIZE = 52;
        /// <summary>
        /// Constructor with defalut 2 Players and default 52 Card Deck
        /// </summary>
        public Game()
        {
            //sets the default Card deck for the game
            fDeck = new CardDeck(DEFAULT_CARD_DECK_SIZE);
            fRiver = new River();
            fPlayers = new List<Player>
            {
                new Player(),
                new AIPlayer("AIPlayer1")
            };
            Initialize();
        }

        /// <summary>
        /// Constructor with Arguments
        /// </summary>
        /// <param name="aNumberofPlayers">Number of player in the Game</param>
        /// <param name="aCardDeckSize">Card deck Size</param>
        public Game(int aNumberofPlayers, int aCardDeckSize)
        {
            // set the size of the deck, May throw InvalidDeckSizeException
            fDeck = new CardDeck(aCardDeckSize);
            fRiver = new River();
            fPlayers = new List<Player>
            {
                new Player() // default Player
            };
            for (int i = 1; i < aNumberofPlayers; i++)
            {
                fPlayers.Add(new AIPlayer("AIPlayer" + i));
            }
            Initialize();
        }

        private void Initialize()
        {
            foreach (Player item in fPlayers)
            {
                item.CompleteHand(Deck);
            }
        }

        /// <summary>
        /// Change the turn from attacking to defending or vice versa
        /// </summary>
        public void SwapTurn()
        {
            foreach (var player in fPlayers)
            {
                if (player.GameStatus != GameStatus.Won || player.GameStatus != GameStatus.Lost)
                {
                    if (player.GameStatus == GameStatus.Attacking)
                    {
                        player.GameStatus = GameStatus.Defending;
                    }
                    else if (player.GameStatus == GameStatus.Defending)
                    {
                        player.GameStatus = GameStatus.Attacking;
                    }
                } 
            }
        }

        /// <summary>
        /// End the player turn after Attacking or defending
        /// </summary>
        public void EndTurn()
        {
            Initialize();
            fRiver.ClearRiver();

            foreach (Player player in fPlayers)
            {
                if(player.PlayerHand.NumberOfCardsRemaining == 0 && fRiver.NumberOfCards == 0 && fDeck.GetDeckSize() == 0)
                {
                    player.GameStatus = GameStatus.Won;
                    Console.WriteLine(player.PlayerName + " has Won");
                    break;
                }
            }
            SwapTurn();
        }
        /// <summary>
        /// Get Property for Players in the game
        /// </summary>
        public List<Player> Players { get => fPlayers; }

        /// <summary>
        /// Get Property for Card Deck
        /// </summary>
        public CardDeck Deck { get => fDeck; }

        /// <summary>
        /// Get Property for River
        /// </summary>
        public River River { get => fRiver; }
    }
}