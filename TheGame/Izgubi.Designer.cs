namespace TheGame
{
    partial class Izgubi
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
            this.backToMenu2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // backToMenu2
            // 
            this.backToMenu2.AutoSize = true;
            this.backToMenu2.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backToMenu2.Location = new System.Drawing.Point(137, 265);
            this.backToMenu2.Name = "backToMenu2";
            this.backToMenu2.Size = new System.Drawing.Size(120, 30);
            this.backToMenu2.TabIndex = 3;
            this.backToMenu2.Text = "Main menu";
            this.backToMenu2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.backToMenu2_MouseClick);
            this.backToMenu2.MouseEnter += new System.EventHandler(this.backToMenu2_MouseEnter);
            this.backToMenu2.MouseLeave += new System.EventHandler(this.backToMenu2_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TheGame.Properties.Resources.stop;
            this.pictureBox1.Location = new System.Drawing.Point(122, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(148, 166);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(82, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 75);
            this.label1.TabIndex = 5;
            this.label1.Text = "Time\'s up!\r\nBetter Luck next time\r\n\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Izgubi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 341);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.backToMenu2);
            this.Name = "Izgubi";
            this.Text = "Time\'s up!";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label backToMenu2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}