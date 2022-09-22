using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// $G$ CSS-999 (-3) Class that inherit from Form - should be named with Form at the beginning.

namespace UI
{
    public partial class GameSettings : Form
    {
        private const string k_ComputerName = "[Computer]";

        public GameSettings()
        {
            InitializeComponent();
        }
    
        private void buttonStart_Click(object sender, EventArgs e)
        {
            Hide();
            // $G$ DSN-999 (-5) You shouldn't create and show the GameBoard From through the Settings From.
            GameWindow GameWindow = new GameWindow(textBoxPlayerOneName.Text, textBoxPlayerTwoName.Text, (int)numericUpDownNumOfRows.Value, (int)numericUpDownNumOfCols.Value, checkBoxPlayerTwoName.Checked);
            GameWindow.ShowDialog();
        }

        private void checkBoxPlayerTwoName_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPlayerTwoName.Enabled = !textBoxPlayerTwoName.Enabled;
            if (!textBoxPlayerTwoName.Enabled)
            {
                textBoxPlayerTwoName.Text = k_ComputerName;
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
