namespace UI
{
    public partial class GameSettings
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
            this.labelPlayers = new System.Windows.Forms.Label();
            this.labelPlayerOneName = new System.Windows.Forms.Label();
            this.textBoxPlayerOneName = new System.Windows.Forms.TextBox();
            this.textBoxPlayerTwoName = new System.Windows.Forms.TextBox();
            this.checkBoxPlayerTwoName = new System.Windows.Forms.CheckBox();
            this.labelBoardSize = new System.Windows.Forms.Label();
            this.labelNumOfRows = new System.Windows.Forms.Label();
            this.labelNumOfCols = new System.Windows.Forms.Label();
            this.numericUpDownNumOfRows = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownNumOfCols = new System.Windows.Forms.NumericUpDown();
            this.buttonStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumOfRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumOfCols)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPlayers
            // 
            this.labelPlayers.AutoSize = true;
            this.labelPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelPlayers.Location = new System.Drawing.Point(14, 9);
            this.labelPlayers.Name = "labelPlayers";
            this.labelPlayers.Size = new System.Drawing.Size(59, 17);
            this.labelPlayers.TabIndex = 0;
            this.labelPlayers.Text = "Players:";
            // 
            // labelPlayerOneName
            // 
            this.labelPlayerOneName.AutoSize = true;
            this.labelPlayerOneName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelPlayerOneName.Location = new System.Drawing.Point(31, 44);
            this.labelPlayerOneName.Name = "labelPlayerOneName";
            this.labelPlayerOneName.Size = new System.Drawing.Size(64, 17);
            this.labelPlayerOneName.TabIndex = 1;
            this.labelPlayerOneName.Text = "Player 1:";
            // 
            // textBoxPlayerOneName
            // 
            this.textBoxPlayerOneName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxPlayerOneName.Location = new System.Drawing.Point(122, 44);
            this.textBoxPlayerOneName.Name = "textBoxPlayerOneName";
            this.textBoxPlayerOneName.Size = new System.Drawing.Size(118, 23);
            this.textBoxPlayerOneName.TabIndex = 2;
            this.textBoxPlayerOneName.TextChanged += new System.EventHandler(this.textBoxPlayerOneName_TextChanged);
            // 
            // textBoxPlayerTwoName
            // 
            this.textBoxPlayerTwoName.Enabled = false;
            this.textBoxPlayerTwoName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxPlayerTwoName.Location = new System.Drawing.Point(123, 86);
            this.textBoxPlayerTwoName.Name = "textBoxPlayerTwoName";
            this.textBoxPlayerTwoName.Size = new System.Drawing.Size(118, 23);
            this.textBoxPlayerTwoName.TabIndex = 4;
            this.textBoxPlayerTwoName.Text = "[Computer]";
            this.textBoxPlayerTwoName.TextChanged += new System.EventHandler(this.textBoxPlayerTwoName_TextChanged);
            // 
            // checkBoxPlayerTwoName
            // 
            this.checkBoxPlayerTwoName.AutoSize = true;
            this.checkBoxPlayerTwoName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.checkBoxPlayerTwoName.Location = new System.Drawing.Point(34, 88);
            this.checkBoxPlayerTwoName.Name = "checkBoxPlayerTwoName";
            this.checkBoxPlayerTwoName.Size = new System.Drawing.Size(83, 21);
            this.checkBoxPlayerTwoName.TabIndex = 5;
            this.checkBoxPlayerTwoName.Text = "Player 2:";
            this.checkBoxPlayerTwoName.UseVisualStyleBackColor = true;
            this.checkBoxPlayerTwoName.CheckedChanged += new System.EventHandler(this.checkBoxPlayerTwoName_CheckedChanged);
            // 
            // labelBoardSize
            // 
            this.labelBoardSize.AutoSize = true;
            this.labelBoardSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelBoardSize.Location = new System.Drawing.Point(14, 137);
            this.labelBoardSize.Name = "labelBoardSize";
            this.labelBoardSize.Size = new System.Drawing.Size(81, 17);
            this.labelBoardSize.TabIndex = 6;
            this.labelBoardSize.Text = "Board Size:";
            // 
            // labelNumOfRows
            // 
            this.labelNumOfRows.AutoSize = true;
            this.labelNumOfRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelNumOfRows.Location = new System.Drawing.Point(27, 174);
            this.labelNumOfRows.Name = "labelNumOfRows";
            this.labelNumOfRows.Size = new System.Drawing.Size(46, 17);
            this.labelNumOfRows.TabIndex = 7;
            this.labelNumOfRows.Text = "Rows:";
            // 
            // labelNumOfCols
            // 
            this.labelNumOfCols.AutoSize = true;
            this.labelNumOfCols.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelNumOfCols.Location = new System.Drawing.Point(139, 174);
            this.labelNumOfCols.Name = "labelNumOfCols";
            this.labelNumOfCols.Size = new System.Drawing.Size(39, 17);
            this.labelNumOfCols.TabIndex = 8;
            this.labelNumOfCols.Text = "Cols:";
            // 
            // numericUpDownNumOfRows
            // 
            this.numericUpDownNumOfRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.numericUpDownNumOfRows.Location = new System.Drawing.Point(83, 172);
            this.numericUpDownNumOfRows.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownNumOfRows.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownNumOfRows.Name = "numericUpDownNumOfRows";
            this.numericUpDownNumOfRows.Size = new System.Drawing.Size(34, 23);
            this.numericUpDownNumOfRows.TabIndex = 9;
            this.numericUpDownNumOfRows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // numericUpDownNumOfCols
            // 
            this.numericUpDownNumOfCols.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.numericUpDownNumOfCols.Location = new System.Drawing.Point(184, 172);
            this.numericUpDownNumOfCols.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownNumOfCols.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownNumOfCols.Name = "numericUpDownNumOfCols";
            this.numericUpDownNumOfCols.Size = new System.Drawing.Size(34, 23);
            this.numericUpDownNumOfCols.TabIndex = 10;
            this.numericUpDownNumOfCols.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(15, 217);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(233, 23);
            this.buttonStart.TabIndex = 11;
            this.buttonStart.Text = "Start!";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Enabled = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // Game_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 247);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.numericUpDownNumOfCols);
            this.Controls.Add(this.numericUpDownNumOfRows);
            this.Controls.Add(this.labelNumOfCols);
            this.Controls.Add(this.labelNumOfRows);
            this.Controls.Add(this.labelBoardSize);
            this.Controls.Add(this.checkBoxPlayerTwoName);
            this.Controls.Add(this.textBoxPlayerTwoName);
            this.Controls.Add(this.textBoxPlayerOneName);
            this.Controls.Add(this.labelPlayerOneName);
            this.Controls.Add(this.labelPlayers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Game_Settings";
            this.ShowInTaskbar = false;
            this.Text = "Game Settings";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumOfRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumOfCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPlayers;
        private System.Windows.Forms.Label labelPlayerOneName;
        private System.Windows.Forms.TextBox textBoxPlayerOneName;
        private System.Windows.Forms.TextBox textBoxPlayerTwoName;
        private System.Windows.Forms.CheckBox checkBoxPlayerTwoName;
        private System.Windows.Forms.Label labelBoardSize;
        private System.Windows.Forms.Label labelNumOfRows;
        private System.Windows.Forms.Label labelNumOfCols;
        private System.Windows.Forms.NumericUpDown numericUpDownNumOfRows;
        private System.Windows.Forms.NumericUpDown numericUpDownNumOfCols;
        private System.Windows.Forms.Button buttonStart;
    }
}