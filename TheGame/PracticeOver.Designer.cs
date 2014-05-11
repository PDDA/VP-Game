namespace TheGame
{
    partial class PracticeOver
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
            this.label1 = new System.Windows.Forms.Label();
            this.backToMenu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // finishMessage
            // 
            this.finishMessage.AutoSize = true;
            this.finishMessage.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.finishMessage.Location = new System.Drawing.Point(27, 182);
            this.finishMessage.Name = "finishMessage";
            this.finishMessage.Size = new System.Drawing.Size(0, 25);
            this.finishMessage.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(26, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 61);
            this.label1.TabIndex = 2;
            this.label1.Text = "Congratulations, you passed the practice. Let\'s try the game now.";
            // 
            // backToMenu
            // 
            this.backToMenu.AutoSize = true;
            this.backToMenu.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backToMenu.Location = new System.Drawing.Point(133, 235);
            this.backToMenu.Name = "backToMenu";
            this.backToMenu.Size = new System.Drawing.Size(120, 29);
            this.backToMenu.TabIndex = 3;
            this.backToMenu.Text = "Main menu";
            // 
            // PracticeOver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 341);
            this.Controls.Add(this.backToMenu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.finishMessage);
            this.Name = "PracticeOver";
            this.Text = "PracticeOver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label finishMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label backToMenu;
    }
}