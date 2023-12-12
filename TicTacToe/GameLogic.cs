using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class GameLogic
    {
        public void WhichPlayerMoves(ref bool isCrossTurn)
        {
            isCrossTurn = !isCrossTurn;
        }


        public bool IsWin(ref Character[,] table)
        {
            int Counter = 0;
            foreach (var item in table) 
            {
                if (item.GetType())
                {

                }
            }
            return false;
        }
    }
}
