using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class Game
    {
        private const int k_InitToDefaultValueOfInt = 0;
        private const double k_RandomChoiceForBoolValue = 0.5;
        private const string k_MoveToQuit = "q";
        private readonly Random r_RandBoolCreator;
        private Board m_Board;
        private Player m_Player1;
        private Player m_Player2;
        private bool m_PlayerOneTurn;
      
        public Game(string i_PlayerOneName, string i_PlayerTwoName, int i_NumberOfRows, int i_NumberOfCols, bool i_IfTwoPlayersAreHuman)
        {
            r_RandBoolCreator = new Random();
            initGame(i_PlayerOneName, i_PlayerTwoName, i_NumberOfRows, i_NumberOfCols, i_IfTwoPlayersAreHuman);
        }

        public Player PlayerOne
        {
            get
            {
                return m_Player1;
            }
        }

        public Player PlayerTwo
        {
            get
            {
                return m_Player2;
            }
        }

        public void InitGame()
        {
            m_Board.InitMatrix();
            randomlyChooseIfPlayer1PlayFirst();
        }

        public void PlayAMove(string i_PlayerMove, out Player o_CurrentWinner, out char o_PlayerSymbol)
        {
            o_PlayerSymbol = ' ';
            o_CurrentWinner = null;
            Player currentPlayer;
            bool validTurn;
            int o_UserMove = k_InitToDefaultValueOfInt;

            if (m_Player2.IfHuman || m_PlayerOneTurn)
            {
                if (m_PlayerOneTurn)
                {
                    currentPlayer = m_Player1;
                }
                else
                {
                    currentPlayer = m_Player2;
                }

                if (i_PlayerMove.ToLower() == k_MoveToQuit)
                {
                    if (currentPlayer == m_Player1)
                    {
                        o_CurrentWinner = m_Player2;
                    }
                    else
                    {
                        o_CurrentWinner = m_Player1;
                    }

                    updateWinnerScore(o_CurrentWinner);

                    return;
                }

                validTurn = checkUserInput(1, m_Board.Col, i_PlayerMove);
                if (validTurn)
                {
                    int.TryParse(i_PlayerMove, out o_UserMove);
                    o_UserMove -= 1;
                    validTurn = checkIfColIfFull(o_UserMove);
                }
            }
            else
            {
                currentPlayer = m_Player2;
                int.TryParse(i_PlayerMove, out o_UserMove);
                o_UserMove -= 1;
                validTurn = !m_Board.CheckIfColIsFull(o_UserMove);
            }

            if (!validTurn)
            {
                return;
            }

            m_Board.InsertChip(o_UserMove, currentPlayer.Chip);
            o_PlayerSymbol = currentPlayer.Chip.Symbol;
            m_PlayerOneTurn = !m_PlayerOneTurn;
            if (m_Board.CheckIfPlayerWon(o_UserMove))
            {
                o_CurrentWinner = currentPlayer;
                updateWinnerScore(o_CurrentWinner);
            }
        }

        private void updateWinnerScore(Player i_CurrentWinner)
        {
            i_CurrentWinner.Score++;
        }

        public int ChooseRandomlyColForComputerTurn()
        {
            int computerChoice;
            bool validTurn;
            do
            {
                computerChoice = m_Player2.ChooseRandomly(m_Board);
                computerChoice -= 1;
                validTurn = !m_Board.CheckIfColIsFull(computerChoice);
            }
            while (!validTurn);

            return computerChoice;
        }

        private void randomlyChooseIfPlayer1PlayFirst()
        {
            if (!m_Player2.IfHuman)
            {
                m_PlayerOneTurn = true;
            }
            else
            {
                m_PlayerOneTurn = r_RandBoolCreator.NextDouble() >= k_RandomChoiceForBoolValue;
            }
        }

        private bool checkIfColIfFull(int i_UserMove)
        {
            bool checkUserInput = m_Board.CheckIfColIsFull(i_UserMove);

            return !checkUserInput;
        }

        private bool checkUserInput(int i_LowerBound, int i_UpperBound, string i_UserInputStr)
        {
            bool checkUserInputValidation = true;
            int.TryParse(i_UserInputStr, out int o_UserChoiceInt);
            if (o_UserChoiceInt < i_LowerBound || o_UserChoiceInt > i_UpperBound)
            {
                checkUserInputValidation = false;
            }

            return checkUserInputValidation;
        }

        private void initGame(string i_PlayerOneName, string i_PlayerTwoName, int i_NumberOfRows, int i_NumberOfCols, bool i_IfTwoPlayersAreHuman)
        {
            initPlayers(i_PlayerOneName, i_PlayerTwoName, i_IfTwoPlayersAreHuman);
            initBoard(i_NumberOfRows, i_NumberOfCols);
        }

        private void initBoard(int i_NumberOfRows, int i_NumberOfCols)
        {
            m_Board = new Board(i_NumberOfRows, i_NumberOfCols);
        }

        private void initPlayers(string i_PlayerOneName, string i_PlayerTwoName, bool i_IfTwoPlayersAreHuman)
        {
            var v_HumanPlayer = true;
            m_Player1 = new Player(i_PlayerOneName, v_HumanPlayer, new Chip('X'));
            m_Player2 = new Player(i_PlayerTwoName, i_IfTwoPlayersAreHuman, new Chip('O'));
            randomlyChooseIfPlayer1PlayFirst();
        }
    }
}
