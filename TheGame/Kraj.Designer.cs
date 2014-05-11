namespace TheGame
{
    partial class Kraj
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
            this.finishMessage = new System.Windows.Forms.Label();
            this.backToMenu = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // finishMessage
            // 
            this.finishMessage.AutoSize = true;
            this.finishMessage.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.finishMessage.Location = new System.Drawing.Point(29, 161);
            this.finishMessage.Name = "finishMessage";
            this.finishMessage.Size = new System.Drawing.Size(348, 50);
            this.finishMessage.TabIndex = 0;
            this.finishMessage.Text = "Congratulations, finished the \r\ngame, you have.  Hmmmmmm.";
            // 
            // backToMenu
            // 
            this.backToMenu.AutoSize = true;
            this.backToMenu.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backToMenu.Location = new System.Drawing.Point(132, 256);
            this.backToMenu.Name = "backToMenu";
            this.backToMenu.Size = new System.Drawing.Size(120, 30);
            this.backToMenu.TabIndex = 2;
            this.backToMenu.Text = "Main menu";
            this.backToMenu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.backToMenu_MouseClick);
            this.backToMenu.MouseEnter += new System.EventHandler(this.backToMenu_MouseEnter);
            this.backToMenu.MouseLeave += new System.EventHandler(this.backToMenu_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TheGame.Properties.Resources.yodaKraj;
            this.pictureBox1.Location = new System.Drawing.Point(90, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(207, 146);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Kraj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 341);
            this.Controls.Add(this.backToMenu);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.finishMessage);
            this.Name = "Kraj";
            this.Text = "End!";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label finishMessage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label backToMenu;
    }
}