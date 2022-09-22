using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class Player
    {
        private const int k_IntDefaultValue = 0;
        private const int k_DefaultValueForSelectedMove = -1;
        private readonly Chip r_Chip;
        private readonly bool r_IfHuman;
        private readonly string r_Name;
        private int m_Score;
        private Random m_RandomMove;

        public Player(string i_PlayerName, bool i_IfHuman, Chip i_Chip)
        {
            Score = k_IntDefaultValue;
            r_Name = i_PlayerName;
            r_Chip = i_Chip;
            r_IfHuman = i_IfHuman;
            m_RandomMove = new Random();
        }

        public bool IfHuman
        {
            get
            {
                return r_IfHuman;
            }
        }

        public Chip Chip
        {
            get
            {
                return r_Chip;
            }
        }

        public int Score
        {
            get
            {
                return m_Score;
            }

            set
            {
                m_Score = value;
            }
        }

        public string PlayerName
        {
            get
            {
                return r_Name;
            }
        }

        public int ChooseRandomly(Board i_Board)
        {
            int smartMove = aiLogic(i_Board);
            if (smartMove == k_IntDefaultValue)
            {
                smartMove = m_RandomMove.Next(1, i_Board.Col + 1);
            }

            return smartMove;
        }

      
        private int aiLogic(Board i_Board)
        {
            int smartMove = k_DefaultValueForSelectedMove;
            for (int i = 0; i < i_Board.Col; i++)
            {
                if (i_Board.CheckIfColIsFull(i))
                {
                    continue;
                }

                for (int j = 1; j < i_Board.Row; j++)
                {
                    if (i_Board.Matrix[j, i].Symbol == r_Chip.Symbol && i_Board.Matrix[j - 1, i].Symbol == ' ')
                    {
                        smartMove = i;
                        break;
                    }
                }

                if (smartMove > k_DefaultValueForSelectedMove)
                {
                    break;
                }
            }

            for (int i = 1; i < i_Board.Col && smartMove == k_DefaultValueForSelectedMove; i++)
            {
                if (i_Board.CheckIfColIsFull(i - 1))
                {
                    continue;
                }

                for (int j = 1; j < i_Board.Row; j++)
                {
                    if (i_Board.Matrix[j, i].Symbol == r_Chip.Symbol && i_Board.Matrix[j - 1, i - 1].Symbol == ' ' && i_Board.Matrix[j - 1, i - 1].Symbol != ' ')
                    {
                        smartMove = i - 1;
                        break;
                    }
                }

                if (smartMove > k_DefaultValueForSelectedMove)
                {
                    break;
                }
            }

            for (int i = 0; i < i_Board.Col - 1 && smartMove == k_DefaultValueForSelectedMove; i++)
            {
                if (i_Board.CheckIfColIsFull(i))
                {
                    continue;
                }

                for (int j = i_Board.Row - 2; j > 0; j--)
                {
                    if (j == 0)
                    {
                        continue;
                    }

                    if (i_Board.Matrix[j, i].Symbol == r_Chip.Symbol && i_Board.Matrix[j, i + 1].Symbol != ' ' && i_Board.Matrix[j + 1, i + 1].Symbol == ' ')
                    {
                        smartMove = i + 1;
                        break;
                    }
                }

                if (smartMove > k_DefaultValueForSelectedMove)
                {
                    break;
                }
            }

            return smartMove + 1;
        }
    }
}
