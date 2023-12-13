using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{

    public partial class Form1 : Form
    {
        public static Graphics graphics;
        public bool isCrossTurn = true;
        //Declaration of tableOfPoints
        Character[,] tableOfPoints = new Character[20, 20];

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            graphics = panel1.CreateGraphics();
            //Labels on X and Y axis
            CharacterDrawer.CreateLabelsForTable(panel1,Controls);
            //Creates an array full of Empty Characters in 20x20 grid 
            GameLogic.NewGame(tableOfPoints,ref isCrossTurn);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //lines on X and Y
            for (int x = 0; x < 21; x++)
            {
                graphics.DrawLine(Pens.Black, 20 * x, 0, 20 * x,400 );

            }

            for (int x = 0; x < 21; x++)
            {
                graphics.DrawLine(Pens.Black, 0, 20 * x, 400,20 * x);

            }

            //characters 
            foreach(var Character in tableOfPoints)
            {
                switch(Character.TypeOf())
                {
                    case 1:
                        if (Character.IsSelected())
                        {
                            CharacterDrawer.DrawRedCrossSelected(graphics, Character.GetX(), Character.GetY());
                        }
                        else
                        {
                            CharacterDrawer.DrawRedCross(graphics, Character.GetX(), Character.GetY());
                        }

                        break;

                    case 2:

                        if (Character.IsSelected())
                        {
                            CharacterDrawer.DrawBlueCircleSelected(graphics, Character.GetX(), Character.GetY());
                        }
                        else
                        {
                            CharacterDrawer.DrawBlueCircle(graphics, Character.GetX(), Character.GetY());
                        }
                        break;
                    case 0: break;

                }

            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (var Character in tableOfPoints)
            {
                    if ((e.X - Character.GetX()) < 19 && ( e.Y - Character.GetY()) < 19 && isCrossTurn)
                    {
                        if (Character.TypeOf() == 0)
                        {
                            Character.SetType(1);
                            CharacterDrawer.DrawRedCross(graphics, Character.GetX(), Character.GetY());
                            GameLogic.WhichPlayerMoves(ref isCrossTurn);
                            break;
                        }
                     break;
                    }
                    else if (Math.Abs(e.X - Character.GetX()) < 19 && Math.Abs(e.Y - Character.GetY()) < 19 && !isCrossTurn)
                    {
                        if (Character.TypeOf() == 0)
                        {
                            CharacterDrawer.DrawBlueCircle(graphics, Character.GetX(), Character.GetY());
                            Character.SetType(2);
                            GameLogic.WhichPlayerMoves(ref isCrossTurn);
                            break;
                        }
                        break;
                    }
            }

            if(GameLogic.IsWin(tableOfPoints))
            {
                Refresh();
                if (GameLogic.IsWin(tableOfPoints))
                {
                    DialogResult result = MessageBox.Show("Congratulations! You won! Do you want to start a new game?", "Game Won", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        GameLogic.NewGame(tableOfPoints, ref isCrossTurn); // Assuming tableOfPoints is your 2D array of Character
                        Refresh();
                    }
                    else
                    {
                        Close();
                    }
                }
            }
        }
    }
}
