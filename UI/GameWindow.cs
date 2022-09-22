using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Logic;

namespace UI
{
    public partial class GameWindow : Form
    {
        private const int k_DefaultValueOfInt = 0;
        private const int k_PlayerOneIndex = 1;
        private const int k_PlayerTwoIndex = 2;
        private const int k_ButtonHeight = 30;
        private const int k_ButtonWidth = 40; 
        private const int k_WindowHeightToAdd = 165;
        private const int k_WindowWidthToAdd = 110;
        private const int k_ButtonXStartLocation = 52;
        private const int k_BoardButtonYStartLocation = 85;
        private const int k_ColIndexButtonYStartLocation = 45;
        private readonly int[] r_FreeSpacesInEachCol;
        private readonly Button[] r_AllIndexColButton;
        private readonly Button[,] r_BoardButtonArray;
        private readonly string r_PlayerOneName;
        private readonly string r_PlayerTwoName;
        private readonly int r_NumberOfRows;
        private readonly int r_NumberOfCols;
        private readonly bool r_PlayerTwoIsHuman;
        private readonly Game r_GameLogic;
        private int m_DisabledColButtons;
        
        public GameWindow(string i_PlayerOneName, string i_PlayerTwoName, int i_NumberOfRows, int i_NumberOfCols, bool i_PlayerTwoIsHuman)
        {
            this.r_PlayerOneName = i_PlayerOneName;
            this.r_PlayerTwoName = i_PlayerTwoName;
            this.r_NumberOfRows = i_NumberOfRows;
            this.r_NumberOfCols = i_NumberOfCols;
            this.r_PlayerTwoIsHuman = i_PlayerTwoIsHuman;
            r_GameLogic = new Game(i_PlayerOneName, i_PlayerTwoName, i_NumberOfRows, i_NumberOfCols, i_PlayerTwoIsHuman);
            r_BoardButtonArray = new Button[r_NumberOfRows, r_NumberOfCols];
            r_AllIndexColButton = new Button[r_NumberOfCols];
            r_FreeSpacesInEachCol = new int[r_NumberOfCols];
            m_DisabledColButtons = k_DefaultValueOfInt;
            InitializeComponent();
        }

        private void initLabelsScore()
        {
            this.labelHumanPlayersScore.Text = string.Format("Players {0} : {0}", k_DefaultValueOfInt);
            this.labelComputerScore.Text = string.Format("Computer: {0}", k_DefaultValueOfInt);
        }

        private void initColButtonClick()
        {
            for (int i = 0; i < r_NumberOfCols; i++)
            {
                r_AllIndexColButton[i].Enabled = true;
            }

            m_DisabledColButtons = k_DefaultValueOfInt;
        }

        private void initFreeSpaces()
        {
            for (int i = 0; i < r_NumberOfCols; i++)
            {
                r_FreeSpacesInEachCol[i] = r_NumberOfRows;
            }
        }

        private void createButtonBoard()
        {
            int xStartLocation = k_ButtonXStartLocation;
            int yStartLocation = k_BoardButtonYStartLocation;
            for (int i = 0; i < r_NumberOfRows; i++)
            {
                for (int j = 0; j < r_NumberOfCols; j++)
                {
                    r_BoardButtonArray[i, j] = createButton(string.Empty, j, i, xStartLocation, yStartLocation);
                }
            }
        }

        private void createColIndexButton()
        {
            int xStartLocation = k_ButtonXStartLocation;
            int yStartLocation = k_ColIndexButtonYStartLocation;
            for (int i = 0; i < r_NumberOfCols; i++)
            {
                r_AllIndexColButton[i] = createButton((i + 1).ToString(), i, k_DefaultValueOfInt, xStartLocation, yStartLocation);
                r_AllIndexColButton[i].Click += colIndexButton_Click;
            }
        }

        private Button createButton(string i_Text, int i_XStep, int i_YStep, int i_XStartLocation, int i_YStartLocation)
        {
            Button Button = new Button();
            Button.Location = new System.Drawing.Point(i_XStartLocation + (i_XStep * k_ButtonWidth), i_YStartLocation + (i_YStep * k_ButtonHeight));
            Button.Name = string.Format("{0}thButton", i_XStep + 1);
            Button.Size = new System.Drawing.Size(k_ButtonWidth, k_ButtonHeight);
            Button.Text = i_Text;
            Button.UseVisualStyleBackColor = true;
            Button.Enabled = false;
            this.Controls.Add(Button);
            return Button;
        }

        private void colIndexButton_Click(object sender, EventArgs e)
        {
            Button buttonSender = sender as Button;
            int.TryParse(buttonSender.Text, out int o_ButtonPos);
            r_GameLogic.PlayAMove(buttonSender.Text, out Player o_Winner, out char o_PlayerSymbol);
            updateBoard(o_ButtonPos, o_PlayerSymbol);
            o_ButtonPos = o_ButtonPos - 1;
            r_FreeSpacesInEachCol[o_ButtonPos] = r_FreeSpacesInEachCol[o_ButtonPos] - 1;
            if (o_Winner != null)
            {
                printWinner(o_Winner);
                return;
            }
            else
            {
                checkedIfToEnableButton(buttonSender);
            }

            // $G$ DSN-999 (-5) the ui should not know what is AI - the game manger in the logic section should use ai in computer turns.
            if (!r_PlayerTwoIsHuman)
            {
                int computerPos = r_GameLogic.ChooseRandomlyColForComputerTurn();
                int computerMove = computerPos + 1;
                r_GameLogic.PlayAMove(computerMove.ToString(), out o_Winner, out o_PlayerSymbol);
                updateBoard(computerMove, o_PlayerSymbol);
                r_FreeSpacesInEachCol[computerPos] = r_FreeSpacesInEachCol[computerPos] - 1;
                if (o_Winner != null)
                {
                    printWinner(o_Winner);
                    return;
                }
                else
                {
                    checkedIfToEnableButton(r_AllIndexColButton[computerPos]);
                }
            }
        }

        private void updateBoard(int i_CurrentMove, char i_PlayerSymbol)
        {
            int colPos = i_CurrentMove - 1;
            for (int i = r_NumberOfRows - 1; i >= 0; i--)
            {
                if (r_BoardButtonArray[i, colPos].Text == string.Empty)
                {
                    r_BoardButtonArray[i, colPos].Text = i_PlayerSymbol.ToString();
                    break;
                }
            }
        }

        private void printWinner(Player i_Winner)
        {
            string playerWhoWonIndex = "Player";
            if (i_Winner.PlayerName == r_PlayerOneName)
            {
                playerWhoWonIndex += k_PlayerOneIndex.ToString();
            }
            else
            {
                playerWhoWonIndex += k_PlayerTwoIndex.ToString();
            }

            printWinnerDialog(playerWhoWonIndex);
        }

        private void printWinnerDialog(string i_PlayerWhoWonIndex)
        {
            string winDialogMessage = string.Format("{0} Won!! {1}Another Round?", i_PlayerWhoWonIndex, Environment.NewLine);
            string winDialogTitle = "A Win!";
            MessageBoxButtons winDialogButtons = MessageBoxButtons.YesNo;
            DialogResult winMessageDialogResult = MessageBox.Show(winDialogMessage, winDialogTitle, winDialogButtons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (winMessageDialogResult == DialogResult.Yes)
            {
                updateScore();
                resetGame();
            }
            else
            {
                Close();
            }
        }

        private void updateScore()
        {
            if (r_PlayerTwoIsHuman)
            {
                this.labelHumanPlayersScore.Text = string.Format("Players {0} : {1}", r_GameLogic.PlayerOne.Score.ToString(), r_GameLogic.PlayerTwo.Score.ToString());
            }
            else
            {
                this.labelHumanPlayersScore.Text = string.Format("Players {0} : 0", r_GameLogic.PlayerOne.Score.ToString());
                this.labelComputerScore.Text = string.Format("Computer: {0}", r_GameLogic.PlayerTwo.Score.ToString());
            }
        }

        private void resetGame()
        {
            initFreeSpaces();
            initColButtonClick();
            initButtonArray();
            r_GameLogic.InitGame();
        }

        private void initButtonArray()
        {
            foreach (Button boardButton in r_BoardButtonArray)
            {
                boardButton.Text = string.Empty;
            }
        }

        private void checkedIfToEnableButton(Button i_ButtonSender)
        {
            int.TryParse(i_ButtonSender.Text, out int o_ButtonPos);
            o_ButtonPos = o_ButtonPos - 1;
            if (r_FreeSpacesInEachCol[o_ButtonPos] == k_DefaultValueOfInt)
            {
                i_ButtonSender.Enabled = !i_ButtonSender.Enabled;
                m_DisabledColButtons = m_DisabledColButtons + 1;
            }

            if (m_DisabledColButtons == r_NumberOfCols)
            {
                printTieDialog();
            }
        }

        private void printTieDialog()
        {
            string tieDialogMessage = string.Format("Tie!! {0}Another Round?", Environment.NewLine);
            string tieDialogTitle = "A Tie!";
            MessageBoxButtons tieDialogButtons = MessageBoxButtons.YesNo;
            DialogResult TieMessageDialogResult = MessageBox.Show(tieDialogMessage, tieDialogTitle, tieDialogButtons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (TieMessageDialogResult == DialogResult.Yes)
            {
                resetGame();
            }
            else
            {
                Close();
            }
        }

        private void gameWindow_Load(object sender, EventArgs e)
        {
            this.Width = (k_ButtonWidth * r_NumberOfCols) + k_WindowWidthToAdd;
            this.Height = (k_ButtonHeight * r_NumberOfRows) + k_WindowHeightToAdd;
            initLabelsScore();
            createButtonBoard();
            initFreeSpaces();
            createColIndexButton();
            initColButtonClick();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Button buttonSender = sender as Button;
            r_GameLogic.PlayAMove(buttonSender.Text, out Player o_Winner, out char o_PlayerSymbol);
            printWinner(o_Winner);
        }
    }
}
