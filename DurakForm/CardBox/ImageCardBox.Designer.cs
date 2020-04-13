namespace CardBox
{
    partial class ImageCardBox
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CardPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.CardPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CardPictureBox
            // 
            this.CardPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CardPictureBox.Location = new System.Drawing.Point(0, 0);
            this.CardPictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CardPictureBox.Name = "CardPictureBox";
            this.CardPictureBox.Size = new System.Drawing.Size(71, 104);
            this.CardPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CardPictureBox.TabIndex = 0;
            this.CardPictureBox.TabStop = false;
            this.CardPictureBox.Click += new System.EventHandler(this.CardPictureBox_Click);
            this.CardPictureBox.MouseEnter += new System.EventHandler(this.CardPictureBox_MouseEnter);
            this.CardPictureBox.MouseLeave += new System.EventHandler(this.CardPictureBox_MouseLeave);
            // 
            // ImageCardBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CardPictureBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ImageCardBox";
            this.Size = new System.Drawing.Size(71, 104);
            this.Load += new System.EventHandler(this.CardBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CardPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox CardPictureBox;
    }
}
