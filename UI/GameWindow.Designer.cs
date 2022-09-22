namespace UI
{
    public partial class GameWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="i_Disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool i_Disposing)
        {
            if (i_Disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(i_Disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelHumanPlayersScore = new System.Windows.Forms.Label();
            this.labelComputerScore = new System.Windows.Forms.Label();
            this.QuitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelHumanPlayersScore
            // 
            this.labelHumanPlayersScore.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelHumanPlayersScore.AutoSize = true;
            this.labelHumanPlayersScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelHumanPlayersScore.Location = new System.Drawing.Point(104, 272);
            this.labelHumanPlayersScore.Name = "labelHumanPlayersScore";
            this.labelHumanPlayersScore.Size = new System.Drawing.Size(0, 17);
            // 
            // labelComputerScore
            // 
            this.labelComputerScore.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelComputerScore.AutoSize = true;
            this.labelComputerScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelComputerScore.Location = new System.Drawing.Point(190, 272);
            this.labelComputerScore.Name = "labelComputerScore";
            this.labelComputerScore.Size = new System.Drawing.Size(0, 17);
            // 
            // QuitButton
            // 
            this.QuitButton.Location = new System.Drawing.Point(12, 12);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(38, 28);
            this.QuitButton.Text = "Q";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 302);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.labelComputerScore);
            this.Controls.Add(this.labelHumanPlayersScore);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GameWindow";
            this.Text = "4 in a Raw !!";
            this.Load += new System.EventHandler(this.gameWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHumanPlayersScore;
        private System.Windows.Forms.Label labelComputerScore;
        private System.Windows.Forms.Button QuitButton;
    }
}