using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class Game_Settings : Form
    {
        public Game_Settings()
        {
            InitializeComponent();
         
        }
        
        private void game_Settings_Load(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Hide();
            GameWindow GameWindow = new GameWindow(textBoxPlayerOneName.Text, textBoxPlayerTwoName.Text, (int)numericUpDownNumOfRows.Value, (int)numericUpDownNumOfCols.Value, checkBoxPlayerTwoName.Checked);
            GameWindow.ShowDialog();
        }

     

        private void checkBoxPlayerTwoName_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPlayerTwoName.Enabled = !textBoxPlayerTwoName.Enabled;
            if (!textBoxPlayerTwoName.Enabled)
            {
                textBoxPlayerTwoName.Text = "[Computer]";
            }
            else
            {
                textBoxPlayerTwoName.Text = string.Empty;
            }
        }

        private void textBoxPlayerOneName_TextChanged(object sender, EventArgs e)
        {
            checkIfCanStartTheGame();
        }

        private void checkIfCanStartTheGame()
        {
            if (textBoxPlayerOneName.Text.Length > 0 && textBoxPlayerTwoName.Text.Length > 0)
            {
                buttonStart.Enabled = true;
            }
            else
            {
                buttonStart.Enabled = false;
            }
        }

        private void textBoxPlayerTwoName_TextChanged(object sender, EventArgs e)
        {
            checkIfCanStartTheGame();
        }
    }
}
