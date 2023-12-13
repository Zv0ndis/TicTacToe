using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    internal class GameLogic
    {
        public static void WhichPlayerMoves(ref bool isCrossTurn)
        {
            isCrossTurn = !isCrossTurn;
        }

        public static bool IsWin(Character[,] table)
        {
            int size = 20;
            int consecutiveCount = 5;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col <= size - consecutiveCount; col++)
                {
                    bool isWinningRow = true;
                    for (int i = 0; i < consecutiveCount; i++)
                    {
                        if (table[row, col + i].TypeOf() != table[row, col].TypeOf() || table[row, col].TypeOf() == 0)
                        {
                            isWinningRow = false;
                            break;
                        }
                    }

                    if (isWinningRow)
                    {
                        if (isWinningRow)
                        {
                            // Set IsSelected to true for winning characters in the row
                            for (int i = 0; i < consecutiveCount; i++)
                            {
                                table[row, col + i].SetSelected(true);
                            }
                            return true;
                        }
                        return true;
                    }
                }
            }

            for (int col = 0; col < size; col++)
            {
                for (int row = 0; row <= size - consecutiveCount; row++)
                {
                    bool isWinningColumn = true;
                    for (int i = 0; i < consecutiveCount; i++)
                    {
                        if (table[row + i, col].TypeOf() != table[row, col].TypeOf() || table[row, col].TypeOf() == 0)
                        {
                            isWinningColumn = false;
                            break;
                        }
                    }

                    if (isWinningColumn)
                    {
                        for (int i = 0; i < consecutiveCount; i++)
                        {
                            table[row + i, col].SetSelected(true);
                        }
                        return true;
                    }
                }
            }

            for (int row = 0; row <= size - consecutiveCount; row++)
            {
                for (int col = 0; col <= size - consecutiveCount; col++)
                {
                    bool isWinningDiagonal1 = true;
                    bool isWinningDiagonal2 = true;

                    for (int i = 0; i < consecutiveCount; i++)
                    {
                        if (table[row + i, col + i].TypeOf() != table[row, col].TypeOf() || table[row, col].TypeOf() == 0)
                        {
                            isWinningDiagonal1 = false;
                        }

                        if (table[row + i, col + consecutiveCount - 1 - i].TypeOf() != table[row, col + consecutiveCount - 1].TypeOf() || table[row, col + consecutiveCount - 1].TypeOf() == 0)
                        {
                            isWinningDiagonal2 = false;
                        }
                    }

                    if (isWinningDiagonal1)
                    {
                        for (int i = 0; i < consecutiveCount; i++)
                        {
                            table[row + i, col + i].SetSelected(true);
                        }
                        return true;
                    }

                    if (isWinningDiagonal2)
                    {
                        for (int i = 0; i < consecutiveCount; i++)
                        {
                            table[row + i, col + consecutiveCount - 1 - i].SetSelected(true);
                        }

                        return true;
                    }
                }
            }

            return false;
        }

        public static void NewGame(Character[,] table,ref bool isCrossTurn)
        {
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    table[x, y] = new Character(new Point(20 * x, 20 * y), 0);
                }
            }

            isCrossTurn = true;

        }

    }
}


