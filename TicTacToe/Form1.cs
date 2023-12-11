using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        //Declaration of tableOfPoints
        Character[,] tableOfPoints = new Character[20, 20];
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Labels on X and Y axis
            for (int i = 0; i < 20; i++)
            {
                Label label = new Label();
                label.Text = $"{i + 1}";
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Location = new Point(200+20*i,0);
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
                label.Location = new Point(180, 20+ 20 * i);
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
                    tableOfPoints[x, y] = new Character(new Point(200+20*x, 20 + 20 * y));
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            //lines on X and Y
            for (int x = 0; x < 21; x++)
            {
                graphics.DrawLine(Pens.Black, 200 + 20 * x, 20, 200 + 20 * x, 420);

            }
            for (int x = 0; x < 21; x++)
            {
                graphics.DrawLine(Pens.Black, 200, 20 + 20 * x, 600, 20+20 * x);

            }

            CharacterDrawer.DrawBlueCircle(graphics, 20, 20);
            CharacterDrawer.DrawRedCross(graphics, 40, 20);

        }

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
            int circleSize = 20;

            Pen bluePen = new Pen(Color.Blue, 2);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.DrawEllipse(bluePen, leftCornerX, leftCornerY, circleSize, circleSize);
            bluePen.Dispose();
        }
    }

    //Class for storing information abotu Characters in tableOfPoints 
    class Character
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
        public int TypeOf()
        {
            switch (Type)
            {
                case 1: return 1;
                case 2: return 3;
            }
            return 0;
        }
    }
}
