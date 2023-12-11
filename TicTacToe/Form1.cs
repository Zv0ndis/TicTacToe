using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
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
        CharacterSpace[,] tableOfPoints = new CharacterSpace[20, 20];
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
            for (int i = 0; i < 20; i++)
            {
                Label label = new Label();
                label.Text = $"{i + 1}";
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Location = new Point(panel1.Location.X+20*i,38-label.Font.Height*2);
                label.Width = 20;
                label.ForeColor = Color.Black;
                label.BackColor = Color.Transparent;
                Controls.Add(label);
            }
            for (int i = 0; i < 20; i++)
            {
                System.Windows.Forms.Label label = new Label();
                label.Text = $"{i + 1}";
                label.TextAlign = ContentAlignment.MiddleLeft;
                label.Location = new Point(panel1.Location.X-20, panel1.Location.Y+ 20 * i);
                label.Height = 20;
                label.ForeColor = Color.Black;
                label.BackColor = Color.Transparent;
                Controls.Add(label);
            }

            //Creates an array full of Empty Characters in 20x20 grid 
            for (int x = 0; x <20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    tableOfPoints[x, y] = new CharacterSpace(new Point(20*x,20 * y));
                }
            }
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

            foreach(var Character in tableOfPoints)
            {
                if (Character.TypeOf()==1)
                {
                    CharacterDrawer.DrawRedCross(graphics, Character.GetX(), Character.GetY());
                }
                else if(Character.TypeOf() == 2)
                {
                    CharacterDrawer.DrawBlueCircle(graphics, Character.GetX(), Character.GetY());
                }
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (var Character in tableOfPoints)
            {
                if(Character.TypeOf()==0)
                {
                    if (Math.Abs(e.X - Character.GetX()) < 19 && Math.Abs(e.Y - Character.GetY()) < 19 && isCrossTurn)
                    {
                        Character.SetType(1);
                        CharacterDrawer.DrawRedCross(graphics, Character.GetX(), Character.GetY());
                        break;

                    }
                    else if (Math.Abs(e.X - Character.GetX()) < 19 && Math.Abs(e.Y - Character.GetY()) < 19 && !isCrossTurn)
                    {
                        CharacterDrawer.DrawBlueCircle(graphics, Character.GetX(), Character.GetY());
                        Character.SetType(2);
                        break;
                    }
                }

            }
            WhichPlayerMoves();
        }

        public void WhichPlayerMoves()
        {
            isCrossTurn=!isCrossTurn;
        }
        //-----------USELESS--------
        private void Form1_Paint(object sender, PaintEventArgs e)
        {


        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }
        //------------!!!!!!!!--------
    }

    //Class for Drawing Crosses and Circles
    class CharacterDrawer
    {
        public static void DrawRedCross(Graphics graphics, int leftCornerX, int leftCornerY)
        {
            int crossSize = 20;

            Pen redPen = new Pen(Color.Red, 2);

            graphics.DrawLine(redPen, leftCornerX, leftCornerY, leftCornerX + crossSize, leftCornerY + crossSize);
            graphics.DrawLine(redPen, leftCornerX + crossSize, leftCornerY, leftCornerX, leftCornerY + crossSize);
            redPen.Dispose();
        }


        public static void DrawBlueCircle(Graphics graphics, int leftCornerX, int leftCornerY)
        {
            int circleSize = 18;

            Pen bluePen = new Pen(Color.Blue, 2);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.DrawEllipse(bluePen, leftCornerX+1, leftCornerY+1, circleSize, circleSize);
            bluePen.Dispose();
        }
    }

    //Class for storing information abotu Characters in tableOfPoints 
    class CharacterSpace
    {
        private int Type;
        private Point LeftCornerInTable;

        public CharacterSpace(Point LeftCornerInTable, int Type = 0)
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
            this.Type= Type;
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
