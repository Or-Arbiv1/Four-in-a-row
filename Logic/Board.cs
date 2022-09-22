using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class Board
    {
        private const int k_InitToDefaultValueOfInt = 0;
        private const int k_FourChipsWithTheSameSymbolInARow = 4;
        private readonly int r_Row;
        private readonly int r_Col;
        private Chip[,] m_Matrix;

        public Board(int i_Row, int i_Col)
        {
            r_Row = i_Row;
            r_Col = i_Col;
            m_Matrix = new Chip[i_Row, i_Col];
            createMatrix();
        }

        public int Row
        {
            get
            {
                return r_Row;
            }
        }

        public int Col
        {
            get
            {
                return r_Col;
            }
        }

        public Chip[,] Matrix
        {
            get
            {
                return m_Matrix;
            }
        }

        public bool CheckIfColIsFull(int i_Col)
        {
            return m_Matrix[0, i_Col].Symbol != ' ';
        }

        public void InsertChip(int i_Col, Chip i_PlayerChip)
        {
            for (int i = r_Row - 1; i >= 0; i--)
            {
                if (m_Matrix[i, i_Col].Symbol == ' ')
                {
                    m_Matrix[i, i_Col] = i_PlayerChip;
                    break;
                }
            }
        }

        public bool CheckIfPlayerWon(int i_Col)
        {
            int row = findChipLocation(i_Col);
            bool playerWon = false;
            Chip playerSymbol = m_Matrix[row, i_Col];
            playerWon = checkRow(row, i_Col) || checkVertical(row, i_Col) || checkHorizonal(row, i_Col) || checkDiagonalFromLeft(row, i_Col) || checkDiagonalFromRight(row, i_Col);

            return playerWon;
        }

        public void InitMatrix()
        {
            createMatrix();
        }

        private void createMatrix()
        {
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    m_Matrix[i, j] = new Chip(' ');
                }
            }
        }

        private bool checkDiagonalFromRight(int i_Row, int i_Col)
        {
            int chipCounter = k_InitToDefaultValueOfInt;
            bool playerWon = false;
            for (int i = -3; i < 4; i++)
            {
                if ((i_Row - i >= 0) && (i_Row - i < r_Row) && (i_Col + i >= 0) && (i_Col + i < r_Col))
                {
                    if (m_Matrix[i_Row - i, i_Col + i] == m_Matrix[i_Row, i_Col])
                    {
                        chipCounter++;
                        if (chipCounter == k_FourChipsWithTheSameSymbolInARow)
                        {
                            playerWon = true;
                            break;
                        }
                    }
                    else
                    {
                        chipCounter = k_InitToDefaultValueOfInt;
                    }
                }
                else
                {
                    continue;
                }
            }

            return playerWon;
        }

        private bool checkDiagonalFromLeft(int i_Row, int i_Col)
        {
            int chipCounter = k_InitToDefaultValueOfInt;
            bool playerWon = false;
            for (int i = -3; i < 4; i++)
            {
                if ((i_Row + i >= 0) && (i_Row + i < r_Row) && (i_Col + i >= 0) && (i_Col + i < r_Col))
                {
                    if (m_Matrix[i_Row + i, i_Col + i] == m_Matrix[i_Row, i_Col])
                    {
                        chipCounter++;
                        if (chipCounter == k_FourChipsWithTheSameSymbolInARow)
                        {
                            playerWon = true;
                            break;
                        }
                    }
                    else
                    {
                        chipCounter = k_InitToDefaultValueOfInt;
                    }
                }
                else
                {
                    continue;
                }
            }

            return playerWon;
        }

        private bool checkHorizonal(int i_Row, int i_Col)
        {
            int chipCounter = k_InitToDefaultValueOfInt;
            bool playerWon = false;
            for (int i = 0; i < r_Col; i++)
            {
                if (m_Matrix[i_Row, i] == m_Matrix[i_Row, i_Col])
                {
                    chipCounter++;
                    if (chipCounter == k_FourChipsWithTheSameSymbolInARow)
                    {
                        playerWon = true;
                        break;
                    }
                }
                else
                {
                    chipCounter = k_InitToDefaultValueOfInt;
                }
            }

            return playerWon;
        }

        private bool checkVertical(int i_Row, int i_Col)
        {
            bool playerWon = false;
            if (i_Row + 3 < r_Row)
            {
                playerWon = true;
            }

            if (playerWon)
            {
                for (int i = 1; i < 4; i++)
                {
                    if (m_Matrix[i_Row + i, i_Col] != m_Matrix[i_Row, i_Col])
                    {
                        playerWon = false;
                        break;
                    }
                }
            }

            return playerWon;
        }

        private bool checkRow(int i_Row, int i_Col)
        {
            bool playerWon = true;
            if (i_Row - 3 < 0)
            {
                playerWon = false;
            }

            if (playerWon)
            {
                for (int i = 1; i < 4; i++)
                {
                    if (m_Matrix[i_Row, i_Col] != m_Matrix[i_Row - i, i_Col])
                    {
                        playerWon = false;
                        break;
                    }
                }
            }

            return playerWon;
        }

        private int findChipLocation(int i_Col)
        {
            int indexToRemember = k_InitToDefaultValueOfInt;
            for (int i = 0; i < r_Row; i++)
            {
                if (m_Matrix[i, i_Col].Symbol != ' ')
                {
                    indexToRemember = i;
                    break;
                }
            }

            return indexToRemember;
        }
    }
}
