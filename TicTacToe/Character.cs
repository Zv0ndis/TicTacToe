﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Character
    {
            private int Type;
            private Point LeftCornerInTable;

            public Character(Point LeftCornerInTable, int Type = 0)
            {
                this.Type = Type;
                this.LeftCornerInTable = LeftCornerInTable;
            }

            public int GetX()
            {
                return LeftCornerInTable.X;
            }
            public int GetY()
            {
                return LeftCornerInTable.Y;
            }

            public void SetType(int Type)
            {
                this.Type = Type;
            }

            public int TypeOf()
            {
                switch (Type)
                {
                    case 1: return 1;
                    case 2: return 2;
                }
                return 0;
            }

    }
}
