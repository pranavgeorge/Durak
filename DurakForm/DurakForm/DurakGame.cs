using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

using DurakSrcLibrary;
using CardBox;
using System.Threading;

namespace DurakForm
{
    public partial class DurakGame : Form
    {
        readonly Game MyGame;

        /// <summary>
        /// The amount, in points, that CardBox controls are enlarged when hovered over. 
        /// </summary>
        private const int POP = 25;

        /// <summary>
        /// The regular size of a CardBox control
        /// </summary>

        private Size regularSize = new Size(71, 104);

        #region Constructor
        public DurakGame(string aPlayerName, int aDeckSize)
        {
            // Initialize the component of the form
            InitializeComponent();
            // Create instance of MyGame Object
            MyGame = new Game(2, aDeckSize, aPlayerName);
            // Allow the Player to Start the attack
            MyGame.Players[0].Status = GameStatus.Attacking;
            MyGame.Players[0].IsThrowing = true;
            MyGame.Players[1].Status = GameStatus.Defending;
            MyGame.Players[1].IsThrowing = false;

            // Update the Deck Images in the current form
            UpdateDeckImages();
            // Update all the Panel in the form
            UpdateCardPanels();
            UpdatePlayerNameLabels();

        }

        private void UpdatePlayerNameLabels()
        {
            // Set the AIPlayer name
            this.AIPlayerNameLabel.Text = MyGame.Players[1].PlayerName.ToString() + " is " + MyGame.Players[1].Status.ToString() + "  Throwing: " + MyGame.Players[1].IsThrowing.ToString() + " (" + MyGame.Players[1].PlayerHand.PlayerHandDeck.Count.ToString() + ")";
            AIPlayerNameLabel.Refresh();
            // Set the Player Name
            this.PlayerNameLabel.Text = MyGame.Players[0].PlayerName.ToString() + " is " + MyGame.Players[0].Status.ToString() + "  Throwing: " + MyGame.Players[0].IsThrowing.ToString() + " (" + MyGame.Players[0].PlayerHand.PlayerHandDeck.Count.ToString() + ")";
            PlayerNameLabel.Refresh();

            // Deck card Count
            this.labelDeck.Text = "Deck (" + MyGame.Deck.PlayingCards.Count.ToString() + ")";
            labelDeck.Refresh();

            // River Cards Count
            this.RiverLabel.Text = "River (" + MyGame.River.RiverCards.Count.ToString() + ")";
            RiverLabel.Refresh();
        }
        #endregion




        #region UPDATE PANELS
        /// <summary>
        /// Update the Deck cards Image with face down and the trump card suit face up in Deck Panel
        /// </summary>
        private void UpdateDeckImages()
        {
            // clear the panel
            DeckPanel.Controls.Clear();
            // Get the update deck size
            int lDeckSize = MyGame.Deck.GetDeckSize();
            for (int i = 0; i < lDeckSize; i++)
            {
                // Set the Custom control (ImageControlBox) with Deck cards in vertical position
                ImageCardBox lCard = new ImageCardBox(MyGame.Deck.PlayingCards[i]);
                lCard.Size = new Size(70, 130);
                // if the card is at last position then faceup the card
                if (i != lDeckSize - 1)
                {
                    // set the position of the card to display the Card image
                    lCard.Location = new Point(i + 5, 1);
                }
                else
                {
                    // set the position of the card to display the Card image
                    lCard.Location = new Point(i + 30, 1);
                    // Face up the card
                    lCard.FaceUp = true;
                }
                // Get the Card Image from the resources
                lCard.CardImage = Properties.Resources.ResourceManager.GetObject(MyGame.Deck.PlayingCards.ElementAt(i).CardImage) as Image;
                // Add Custom Control (ImageCardBox) to the Deck Panel
                DeckPanel.Controls.Add(lCard);
            }
        }

        /// <summary>
        /// Update the Player cards Images in the Player Panel with face UP and Orientation vertical
        /// </summary>
        private void UpdatePlayerPanel()
        {
            // clear the panel
            PlayerPanel.Controls.Clear();
            // get the Updated PLayer Hand Count
            int lPlayerHandCount = MyGame.Players[0].PlayerHand.HandCount();
            for (int i = 0; i < lPlayerHandCount; i++)
            {
                // Set the Custom control (ImageControlBox) with PlayerHand cards in vertical position
                ImageCardBox lCard = new ImageCardBox(MyGame.Players[0].PlayerHand.PlayerHandDeck[i])
                {
                    FaceUp = true,
                    // Get the Card Image from the resources
                    CardImage = Properties.Resources.ResourceManager.GetObject(MyGame.Players[0].PlayerHand.PlayerHandDeck[i].CardImage) as Image
                };


                // click event for the current card
                lCard.Click += Card_Click;
                // mouse enter event
                lCard.MouseEnter += Card_MouseEnter;
                // mouse leave event
                lCard.MouseLeave += Card_MouseLeave;
                // Add Custom Control (ImageCardBox) to the Player Panel
                PlayerPanel.Controls.Add(lCard);
                RealignCards(PlayerPanel);
            }
        }

        /// <summary>
        /// Update the AIPlayer cards Images in the AIPlayer Panel with face DOWN and Orientation vertical
        /// </summary>
        private void UpdateAIPanel()
        {
            // clear the panel
            AIPlayerPanel.Controls.Clear();
            // get the Updated AIPLayer Hand Count
            int lAIPlayerHandCount = MyGame.Players[1].PlayerHand.HandCount();
            for (int i = 0; i < lAIPlayerHandCount; i++)
            {
                // Set the Custom control (ImageControlBox) with AIPlayerHand cards in vertical position
                ImageCardBox lCard = new ImageCardBox(MyGame.Players[1].PlayerHand.PlayerHandDeck[i])
                {
                    FaceUp = false,
                    // Get the Card Image from the resources
                    CardImage = Properties.Resources.ResourceManager.GetObject(MyGame.Players[1].PlayerHand.PlayerHandDeck.ElementAt(i).CardImage) as Image
                };
                // Add Custom Control (ImageCardBox) to the AIPlayer Panel
                AIPlayerPanel.Controls.Add(lCard);
                RealignCards(AIPlayerPanel);

            }
        }

        /// <summary>
        /// Update the RIver cards Images in the River Panel with face UP and Orientation vertical
        /// </summary>
        private void UpdateRiverPanel()
        {
            // clear the panel
            RiverPanel.Controls.Clear();
            // get the Updated River Count
            int lRiverCount = MyGame.River.RiverCards.Count;
            for (int i = 0; i < lRiverCount; i++)
            {
                // Set the Custom control (ImageControlBox) with River cards in vertical position
                ImageCardBox lCard = new ImageCardBox(MyGame.River.RiverCards[i])
                {
                    FaceUp = true,
                    Size = new Size(70, 130),

                    // Get the Card Image from the resources
                    CardImage = Properties.Resources.ResourceManager.GetObject(MyGame.River.RiverCards.ElementAt(i).CardImage) as Image
                };
                // Add Custom Control (ImageCardBox) to the River Panel
                RiverPanel.Controls.Add(lCard);
                RealignCards(RiverPanel);

            }

        }
        #endregion


        #region EVENTHANDLERS


        private void Card_MouseLeave(object sender, EventArgs e)
        {
            // Convert sender to a CardBox
            // If the conversion worked
            if (sender is ImageCardBox lCardBox)
            {
                lCardBox.Size = regularSize;
                lCardBox.Top = POP;
                // resize the card back to regular size
                // move the card down to accommodate for the smaller size.

            }
        }

        private void Card_MouseEnter(object sender, EventArgs e)
        {
            // Convert sender to a CardBox
            // If the conversion worked
            if (sender is ImageCardBox lCardBox)
            {
                lCardBox.Size = new Size(regularSize.Width + POP, regularSize.Height + POP);
                // Enlarge the card for visual effect
                lCardBox.Top = 0; // move the card to the top edge of the panel.
            }
        }

        /// <summary>
        /// Select the Player choice of card form the hand
        /// </summary>
        /// <param name="sender">ImageCardBox <see cref="ImageCardBox"/></param>
        /// <param name="e">Event Data</param>
        private void Card_Click(object sender, EventArgs e)
        {
            if (MyGame.Players[0].IsThrowing == true && MyGame.Players[0].PlayerHand.NumberOfCardsRemaining != 0)
            {
                // Get the Choice of card
                Card card = (sender as ImageCardBox).PlayingCard;
                // Add Card to the river
                MyGame.River.AddCard(card);
                // Rempove the card from the river
                MyGame.Players[0].PlayerHand.RemoveCard(card);
                // Set Player throwing to false to finish its turn
                MyGame.Players[0].IsThrowing = false;
                // Set AIPlayer throwing to true to start its turn
                MyGame.Players[1].IsThrowing = true;

                // Compare the cards if there is more than one card in the river
                CompareRiverCards(MyGame.Players[0]);

                // Call the AIPlayer to make its move
                AIPlay();
            }
            else
            {
                MyGame.EndTurn();
                // Set Player throwing to false to finish its turn
                MyGame.Players[0].IsThrowing = false;
                // Set AIPlayer throwing to true to start its turn
                MyGame.Players[1].IsThrowing = true;
                WinningStatus();
            }


        }

        

        /// <summary>
        /// Player Ends the Current Attack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFinish_Click(object sender, EventArgs e)
        {
            // Player Can finish its turn, when there are more than one turn and was the first to start the attack
            if (MyGame.River.NumberOfCards > 1)
            {
                if (MyGame.Players[0].Status == GameStatus.Attacking && MyGame.Players[0].IsThrowing == true)
                {
                    MyGame.EndTurn();
                    // Set Player throwing to false to finish its turn
                    MyGame.Players[0].IsThrowing = false;
                    // Set AIPlayer throwing to true to start its turn
                    MyGame.Players[1].IsThrowing = true;
                    AIPlay();

                    WinningStatus();

                }
            }
            // Update the Deck Panel
            UpdateDeckImages();
            // Update the AIPlayer, Player and River Panel
            UpdateCardPanels();

        }

        /// <summary>
        /// Take cards From the River
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTake_Click(object sender, EventArgs e)
        {
            // Perform this action when there is atleast one card in river
            if (MyGame.River.NumberOfCards >= 1)
            {
                // Pick all the cards from the river
                MyGame.Players[0].Take(MyGame.River.RiverCards);
                MyGame.EndTurn();
                if (MyGame.Players[0].Status == GameStatus.Defending && MyGame.Players[0].IsThrowing == true)
                {
                    // Set Player throwing to false to finish its turn
                    MyGame.Players[0].IsThrowing = false;
                    // Set AIPlayer throwing to true to start its turn
                    MyGame.Players[1].IsThrowing = true;
                }
                else if (MyGame.Players[0].Status == GameStatus.Attacking && MyGame.Players[0].IsThrowing == true)
                {
                    // Set AIPlayer throwing to false to finish its turn
                    MyGame.Players[1].IsThrowing = false;
                    // Set Player throwing to true to start its turn
                    MyGame.Players[0].IsThrowing = true;
                }

                WinningStatus();
            }
            // Update the Deck Panel
            UpdateDeckImages();
            // Update the AIPlayer, Player and River Panel
            UpdateCardPanels();

        }

        #endregion


        #region METHOD HELPERS
        /// <summary>
        /// Check if Any player won the game
        /// </summary>
        private void WinningStatus()
        {
            if (MyGame.Players[1].Status == GameStatus.Won || MyGame.Players[0].Status == GameStatus.Won)
            {
                if (MyGame.Players[0].Status == GameStatus.Won)
                {
                    WinMessage();
                }
                else if (MyGame.Players[1].Status == GameStatus.Won)

                {
                    LoseMessage();
                }
            }
        }
        /// <summary>
        /// won message for the player 
        /// </summary>
        public void WinMessage()
        {
            MyGame.Players[1].Status = GameStatus.Lost;
            MessageBox.Show("You Won! Press OK to Exit.", "Game Won");
            this.Close();

        }
        /// <summary>
        /// Lose message for the player
        /// </summary>
        public void LoseMessage()
        {
            MyGame.Players[0].Status = GameStatus.Lost;
            MessageBox.Show("You Lost! Press OK to Exit.", "Game Lost");
            this.Close();

        }
        /// <summary>
        /// Refresh all the form Panel
        /// </summary>
        private void UpdateCardPanels()
        {
            UpdateRiverPanel();
            UpdatePlayerPanel();
            UpdateAIPanel();
            UpdatePlayerNameLabels();
        }

        /// <summary>
        /// AIPlayer Attack or Defends the Card
        /// </summary>
        private async void AIPlay()
        {
            await Task.Run(() =>
            {
                // if AiPlayer is throwing and has atleast one card
                if (MyGame.Players[1].IsThrowing == true && MyGame.Players[1].PlayerHand.NumberOfCardsRemaining != 0)
                {
                    // if Player is defending
                    if (MyGame.Players[1].Status == GameStatus.Defending && MyGame.River.NumberOfCards > 0)
                    {
                        // try to defend the last card in the river
                        MyGame.Players[1].Defend(MyGame);
                        if (MyGame.River.NumberOfCards != 0)
                        {
                            MyGame.Players[0].IsThrowing = true;
                            MyGame.Players[1].IsThrowing = false;
                        }
                        else
                        {
                            AIPlay();
                        }

                    }
                    // if Player is attacking
                    else if (MyGame.Players[1].Status == GameStatus.Attacking)
                    {
                        // Player is starting the new attack
                        if (MyGame.River.NumberOfCards == 0)
                        {
                            MyGame.Players[1].Attack(MyGame);
                        }
                        // Player is defending the card when there is atleast one card in river
                        else
                        {
                            // try to defend the last card in the river
                            MyGame.Players[1].Defend(MyGame);
                        }
                        if (MyGame.River.NumberOfCards != 0)
                        {
                            MyGame.Players[0].IsThrowing = true;
                            MyGame.Players[1].IsThrowing = false;
                        }
                        else
                        {
                            AIPlay();
                        }
                    }
                    // until here player must be done by the move

                    // Compare the cards whether the defend is successful or not
                    CompareRiverCards(MyGame.Players[1]);

                }
                // else check if AiPlayer won the game if there is no card left in the deck
                else
                {
                    MyGame.EndTurn();
                    // Set AIPlayer throwing to false to finish its turn
                    MyGame.Players[1].IsThrowing = false;
                    // Set Player throwing to true to start its turn
                    MyGame.Players[0].IsThrowing = true;
                    WinningStatus();
                }
            });

        }
        /// <summary>
        /// Compare the Last two card in the river
        /// </summary>
        private void CompareRiverCards(Player aPLayer)
        {
            UpdateCardPanels();
            // If there is more than one card in river to compare cards
            if (MyGame.River.NumberOfCards > 1)
            {
                // if not successful to defend the finish the current attack
                if (!MyGame.River.CompareCards())
                {
                    UpdateRiverPanel();
                    //Thread.Sleep(1000);
                    MyGame.EndTurn();
                    if (aPLayer == MyGame.Players[0])
                    {
                        if (MyGame.Players[0].Status == GameStatus.Defending)
                        {
                            // Set Player throwing to false to finish its turn
                            MyGame.Players[0].IsThrowing = false;
                            // Set AIPlayer throwing to true to start its turn
                            MyGame.Players[1].IsThrowing = true;
                            AIPlay();
                        }
                        else
                        {
                            // Set AIPlayer throwing to false to finish its turn
                            MyGame.Players[1].IsThrowing = false;
                            // Set Player throwing to true to start its turn
                            MyGame.Players[0].IsThrowing = true;
                        }

                    }
                    else
                    {
                        if (MyGame.Players[1].Status == GameStatus.Defending)
                        {
                            // Set AIPlayer throwing to false to finish its turn
                            MyGame.Players[1].IsThrowing = false;
                            // SetIPlayer throwing to true to start its turn
                            MyGame.Players[0].IsThrowing = true;
                        }
                        else if (MyGame.Players[1].Status == GameStatus.Attacking)
                        {
                            // Set Player throwing to true to start its turn
                            MyGame.Players[1].IsThrowing = true;
                            // Set Player throwing to false to finish its turn
                            MyGame.Players[0].IsThrowing = false;
                            AIPlay();
                        }

                    }
                    WinningStatus();
                }
                UpdateCardPanels();
                UpdateDeckImages();
            }

        }


        private void RealignCards(Panel lPanelHand)
        {
            // Determine the number of cards/controls in the panel.
            int lMyCount = lPanelHand.Controls.Count;

            // If there are any cards in the panel
            if (lMyCount > 0)
            {
                // Determine how wide one card/control is.
                int lCardWidth = lPanelHand.Controls[0].Width;
                // Determine where the left-hand edge of a card/control placed 
                // in the middle of the panel should be  
                int lStartPoint = (lPanelHand.Width - lCardWidth) / 2;

                // An offset for the remaining cards
                int lOffset = 0;

                // If there are more than one cards/controls in the panel
                if (lMyCount > 1)
                {
                    // Determine what the offset should be for each card based on the 
                    // space available and the number of card/controls
                    lOffset = (lPanelHand.Width - lCardWidth - 2 * POP) / (lMyCount - 1);
                    // If the offset is bigger than the card/control width, i.e. there is lots of room, 
                    // set the offset to the card width. The cards/controls will not overlap at all.
                    if (lOffset > lCardWidth)
                        lOffset = lCardWidth;
                    // Determine width of all the cards/controls 
                    int allCardsWidth = (lMyCount - 1) * lOffset + lCardWidth;
                    // Set the start point to where the left-hand edge of the "first" card should be.

                    lStartPoint = (lPanelHand.Width - allCardsWidth) / 2;
                }
                // Aligning the cards: Note that I align them in reserve order from how they
                // are stored in the controls collection. This is so that cards on the left 
                // appear underneath cards to the right. This allows the user to see the rank
                // and suit more easily.

                // Align the "first" card (which is the last control in the collection)
                lPanelHand.Controls[lMyCount - 1].Top = POP;
                System.Diagnostics.Debug.Write(lPanelHand.Controls[lMyCount - 1].Top.ToString() + "\n");
                lPanelHand.Controls[lMyCount - 1].Left = lStartPoint;
                // for each of the remaining controls, in reverse order.
                for (int index = lMyCount - 2; index >= 0; index--)
                {
                    // Align the current card
                    lPanelHand.Controls[index].Top = POP;

                    lPanelHand.Controls[index].Left = lPanelHand.Controls[index + 1].Left + lOffset;
                }
            }
        }
        #endregion
    }

}
