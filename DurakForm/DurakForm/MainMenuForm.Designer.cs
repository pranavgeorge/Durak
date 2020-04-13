namespace DurakForm
{
    partial class MainMenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.QuitButton = new System.Windows.Forms.Button();
            this.PlayButton = new System.Windows.Forms.Button();
            this.DurakLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.DeckSizeLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.deckComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(85, 336);
            this.QuitButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(100, 28);
            this.QuitButton.TabIndex = 0;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.Location = new System.Drawing.Point(516, 336);
            this.PlayButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(100, 28);
            this.PlayButton.TabIndex = 1;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // DurakLabel
            // 
            this.DurakLabel.AutoSize = true;
            this.DurakLabel.Font = new System.Drawing.Font("Monotype Corsiva", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DurakLabel.Location = new System.Drawing.Point(274, 23);
            this.DurakLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DurakLabel.Name = "DurakLabel";
            this.DurakLabel.Size = new System.Drawing.Size(174, 72);
            this.DurakLabel.TabIndex = 3;
            this.DurakLabel.Text = "Durak";
            this.DurakLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.Location = new System.Drawing.Point(80, 158);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(226, 25);
            this.NameLabel.TabIndex = 4;
            this.NameLabel.Text = "Please Enter Your Name";
            // 
            // DeckSizeLabel
            // 
            this.DeckSizeLabel.AutoSize = true;
            this.DeckSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeckSizeLabel.Location = new System.Drawing.Point(80, 224);
            this.DeckSizeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DeckSizeLabel.Name = "DeckSizeLabel";
            this.DeckSizeLabel.Size = new System.Drawing.Size(272, 25);
            this.DeckSizeLabel.TabIndex = 5;
            this.DeckSizeLabel.Text = "Please Choose the Deck Size";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(456, 156);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(160, 22);
            this.NameTextBox.TabIndex = 6;
            // 
            // deckComboBox
            // 
            this.deckComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deckComboBox.DropDownWidth = 280;
            this.deckComboBox.FormattingEnabled = true;
            this.deckComboBox.Items.AddRange(new object[] {
            "20",
            "36",
            "52"});
            this.deckComboBox.Location = new System.Drawing.Point(456, 222);
            this.deckComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deckComboBox.Name = "deckComboBox";
            this.deckComboBox.Size = new System.Drawing.Size(160, 24);
            this.deckComboBox.TabIndex = 7;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(706, 468);
            this.Controls.Add(this.deckComboBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.DeckSizeLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.DurakLabel);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.QuitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Label DurakLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label DeckSizeLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.ComboBox deckComboBox;
    }
}