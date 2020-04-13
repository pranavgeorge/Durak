using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DurakForm
{
    public partial class MainMenuForm : Form
    {
        string playerName;
        public MainMenuForm()
        {
            InitializeComponent();
            deckComboBox.SelectedIndex = 0;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            // close the application
            Close();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            playerName = this.NameTextBox.Text;
            if (int.TryParse(this.deckComboBox.SelectedItem.ToString(),out int deckSize))
            {
                this.Hide();
                DurakGame durakGame = new DurakGame(playerName, deckSize);
                durakGame.ShowDialog();
                this.Show();
            }
            

        }
    }
}
