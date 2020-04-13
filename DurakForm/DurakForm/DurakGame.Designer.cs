namespace DurakForm
{
    partial class DurakGame
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.AIPlayerNameLabel = new System.Windows.Forms.Label();
            this.RiverLabel = new System.Windows.Forms.Label();
            this.PlayerNameLabel = new System.Windows.Forms.Label();
            this.AIPlayerPanel = new System.Windows.Forms.Panel();
            this.RiverPanel = new System.Windows.Forms.Panel();
            this.PlayerPanel = new System.Windows.Forms.Panel();
            this.btnTake = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.DeckPanel = new System.Windows.Forms.Panel();
            this.labelDeck = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AIPlayerNameLabel
            // 
            this.AIPlayerNameLabel.AutoSize = true;
            this.AIPlayerNameLabel.Location = new System.Drawing.Point(873, 2);
            this.AIPlayerNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AIPlayerNameLabel.Name = "AIPlayerNameLabel";
            this.AIPlayerNameLabel.Size = new System.Drawing.Size(46, 17);
            this.AIPlayerNameLabel.TabIndex = 3;
            this.AIPlayerNameLabel.Text = "label1";
            // 
            // RiverLabel
            // 
            this.RiverLabel.AutoSize = true;
            this.RiverLabel.Location = new System.Drawing.Point(304, 179);
            this.RiverLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RiverLabel.Name = "RiverLabel";
            this.RiverLabel.Size = new System.Drawing.Size(41, 17);
            this.RiverLabel.TabIndex = 4;
            this.RiverLabel.Text = "River";
            // 
            // PlayerNameLabel
            // 
            this.PlayerNameLabel.AutoSize = true;
            this.PlayerNameLabel.Location = new System.Drawing.Point(13, 501);
            this.PlayerNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PlayerNameLabel.Name = "PlayerNameLabel";
            this.PlayerNameLabel.Size = new System.Drawing.Size(46, 17);
            this.PlayerNameLabel.TabIndex = 5;
            this.PlayerNameLabel.Text = "label3";
            // 
            // AIPlayerPanel
            // 
            this.AIPlayerPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.AIPlayerPanel.Location = new System.Drawing.Point(12, 21);
            this.AIPlayerPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AIPlayerPanel.Name = "AIPlayerPanel";
            this.AIPlayerPanel.Size = new System.Drawing.Size(1284, 126);
            this.AIPlayerPanel.TabIndex = 6;
            // 
            // RiverPanel
            // 
            this.RiverPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.RiverPanel.Location = new System.Drawing.Point(208, 201);
            this.RiverPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RiverPanel.Name = "RiverPanel";
            this.RiverPanel.Size = new System.Drawing.Size(1087, 233);
            this.RiverPanel.TabIndex = 7;
            // 
            // PlayerPanel
            // 
            this.PlayerPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PlayerPanel.Location = new System.Drawing.Point(12, 520);
            this.PlayerPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PlayerPanel.Name = "PlayerPanel";
            this.PlayerPanel.Size = new System.Drawing.Size(1284, 134);
            this.PlayerPanel.TabIndex = 8;
            // 
            // btnTake
            // 
            this.btnTake.Location = new System.Drawing.Point(268, 459);
            this.btnTake.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTake.Name = "btnTake";
            this.btnTake.Size = new System.Drawing.Size(96, 38);
            this.btnTake.TabIndex = 9;
            this.btnTake.Text = "Take";
            this.btnTake.UseVisualStyleBackColor = true;
            this.btnTake.Click += new System.EventHandler(this.BtnTake_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(383, 459);
            this.btnFinish.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(96, 38);
            this.btnFinish.TabIndex = 10;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.BtnFinish_Click);
            // 
            // DeckPanel
            // 
            this.DeckPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DeckPanel.Location = new System.Drawing.Point(12, 201);
            this.DeckPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DeckPanel.Name = "DeckPanel";
            this.DeckPanel.Size = new System.Drawing.Size(190, 233);
            this.DeckPanel.TabIndex = 11;
            // 
            // labelDeck
            // 
            this.labelDeck.AutoSize = true;
            this.labelDeck.Location = new System.Drawing.Point(13, 179);
            this.labelDeck.Name = "labelDeck";
            this.labelDeck.Size = new System.Drawing.Size(40, 17);
            this.labelDeck.TabIndex = 12;
            this.labelDeck.Text = "Deck";
            // 
            // DurakGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(1308, 665);
            this.Controls.Add(this.labelDeck);
            this.Controls.Add(this.DeckPanel);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnTake);
            this.Controls.Add(this.RiverLabel);
            this.Controls.Add(this.PlayerPanel);
            this.Controls.Add(this.RiverPanel);
            this.Controls.Add(this.AIPlayerPanel);
            this.Controls.Add(this.PlayerNameLabel);
            this.Controls.Add(this.AIPlayerNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "DurakGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Durak";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Label AIPlayerNameLabel;
        private System.Windows.Forms.Label RiverLabel;
        private System.Windows.Forms.Label PlayerNameLabel;
        private System.Windows.Forms.Panel AIPlayerPanel;
        private System.Windows.Forms.Panel RiverPanel;
        private System.Windows.Forms.Panel PlayerPanel;
        private System.Windows.Forms.Button btnTake;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Panel DeckPanel;
        private System.Windows.Forms.Label labelDeck;
    }
}

