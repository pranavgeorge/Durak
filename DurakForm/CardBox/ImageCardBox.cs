using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DurakSrcLibrary;
using System.Resources;


namespace CardBox
{
    /// <summary>
    /// a control to use in Windows form Application that displays Playing Card
    /// </summary>
    public partial class ImageCardBox: UserControl
    {
        #region Fields
        private Card fCard;
        private Orientation fOrientation;
        private bool fFaceUp;
        private Image fImage;
        private string fImageName;
        #endregion

        #region Constructor
        /// <summary>
        ///  Constructs the control with a new card, oriented vertically.
        /// </summary>
        public ImageCardBox()
        {
            InitializeComponent();
            fOrientation = Orientation.Vertical;
            fCard = new Card();
        }
        /// <summary>
        /// Consturcts the control using parameters
        /// </summary>
        /// <param name="aCard"></param>
        /// <param name="aOrientation"></param>
        public ImageCardBox(Card aCard, Orientation aOrientation = Orientation.Vertical)
        {
            InitializeComponent();
            fOrientation = aOrientation;
            fCard = aCard;
        }
        #endregion

        #region Encapsulate Fields
       
        public Card PlayingCard { get => fCard;
            set
            {
                fCard = value;
                // update the card Image
                UpdateCardImage();
            }
        }
        public Orientation CardOrientation
        {
            get => fOrientation;
            set
            {
                // if Value is different thank orientation
                if (fOrientation != value)
                {
                    // change the orientation
                    fOrientation = value;
                    // swap the height and width of the orientation
                    this.Size = new Size(Size.Height, Size.Width);
                    // update the card Image
                    UpdateCardImage();
                }
                fOrientation = value;
            }
        }

        public bool FaceUp { get => fCard.FaceUp;
            set
            {
                if(fCard.FaceUp != value)
                {
                    fCard.FaceUp = value;

                    UpdateCardImage();

                   CardFlipped?.Invoke(this, new EventArgs());
                   
                }
            }
        }

        public Image CardImage { get => fImage;
            set
            {
                fImage = value;
                UpdateCardImage();
            }
        }

        public string CardImageName { get => fImageName;
            set
            {
                fImageName = value;
                UpdateCardImage();
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Change the face Up property of the card and updates the image
        /// </summary>
        public void TurnOver()
        {
            fCard.TurnOver();
            // update the card Image
            UpdateCardImage();
        }

        /// <summary>
        /// sets the Picture Box image using the underlying card and the orientation
        /// </summary>
        private void UpdateCardImage()
        {
            // Sets the image using the underlying card
            // string lImageName = fCard.GetCardImage();

            string lImageName = fCard.CardImage;
            this.CardPictureBox.Image = fImage;

            // if the orientation is horizontal
            if (fOrientation == Orientation.Horizontal)
            {
                // rotate the image
                this.CardPictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }

        }
        #endregion

        #region Events and Events Handlers
        /// <summary>
        /// Event handler for the load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardBox_Load(object sender, EventArgs e)
        {
            //update the card Image
            UpdateCardImage();
        }
        /// <summary>
        /// An event the client program can handle when the card flips face up/down
        /// </summary>
        public event EventHandler CardFlipped;
        /// <summary>
        /// event the client program can handle when the user click the control
        /// </summary>
        new public event EventHandler Click;

        /// <summary>
        /// An event handler for the user clicking the picturebox control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardPictureBox_Click(object sender, EventArgs e)
        {
            // if there is a handler for clicking the control in the client program
            Click?.Invoke(this, e);
        }
        /// <summary>
        /// An event the client can handle when the mouse enter the picturebox control
        /// </summary>
        new public event EventHandler MouseEnter;

        /// <summary>
        /// An event handler for mouse to enter the picturebox control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardPictureBox_MouseEnter(object sender, EventArgs e)
        {
            MouseEnter?.Invoke(this, e);
        }

        /// <summary>
        /// An event the client can handle when the mouse leave the picturebox control
        /// </summary>
        new public event EventHandler MouseLeave;

        /// <summary>
        /// An event handler for mouse to leave the picturebox control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CardPictureBox_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave?.Invoke(this, e);
        }
        #endregion

    }
}
