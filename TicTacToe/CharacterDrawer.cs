using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    internal class CharacterDrawer
    {

        public static void DrawTurn(Graphics g, ref bool IsCrossTurn)
        {
            Pen redPen = new Pen(Color.Red, 4);
            Pen greenPen = new Pen(Color.Green, 4);
            Pen bluePen = new Pen(Color.Blue, 4);
            Pen BlackPen = new Pen(Color.Black, 4);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int Size = 50;

            if (IsCrossTurn)
            {
                g.DrawLine(redPen, 20, 20, 20 + Size, 20 + Size);
                g.DrawLine(redPen, 20 + Size, 20, 20, 20 + Size);

                g.DrawEllipse(bluePen, 20, 70, Size, Size);
                g.DrawRectangle(BlackPen, 20, 70, Size, Size);

                g.DrawRectangle(greenPen, 20, 20, Size, Size);
                bluePen.Dispose();
                redPen.Dispose();
                greenPen.Dispose();
            }
            else
            {
                g.DrawRectangle(BlackPen, 20, 20, Size, Size);
                g.DrawLine(redPen, 20, 20, 20 + Size, 20 + Size);
                g.DrawLine(redPen, 20 + Size, 20, 20, 20 + Size);

                g.DrawEllipse(bluePen, 20, 70, Size, Size);
                g.DrawRectangle(greenPen,20 , 70, Size, Size);

                bluePen.Dispose();
                greenPen.Dispose();
            }

        }
        public static void DrawRedCross(Graphics graphics, int leftCornerX, int leftCornerY)
        {
            int crossSize = 20;
            Pen redPen = new Pen(Color.Red, 2);

            graphics.DrawLine(redPen, leftCornerX, leftCornerY, leftCornerX + crossSize, leftCornerY + crossSize);
            graphics.DrawLine(redPen, leftCornerX + crossSize, leftCornerY, leftCornerX, leftCornerY + crossSize);
            redPen.Dispose();
        }

        public static void DrawRedCrossSelected(Graphics graphics, int leftCornerX, int leftCornerY)
        {
            int crossSize = 20;

            Pen redPen = new Pen(Color.Red, 2);
            Pen greenPen = new Pen(Color.Green, 4);

            graphics.DrawLine(redPen, leftCornerX, leftCornerY, leftCornerX + crossSize, leftCornerY + crossSize);
            graphics.DrawLine(redPen, leftCornerX + crossSize, leftCornerY, leftCornerX, leftCornerY + crossSize);

            graphics.DrawRectangle(greenPen, leftCornerX, leftCornerY, crossSize, crossSize);
            redPen.Dispose();
            greenPen.Dispose();
        }

        public static void DrawBlueCircle(Graphics graphics, int leftCornerX, int leftCornerY)
        {
            int circleSize = 18;

            Pen bluePen = new Pen(Color.Blue, 2);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            graphics.DrawEllipse(bluePen, leftCornerX + 1, leftCornerY + 1, circleSize, circleSize);
            bluePen.Dispose();
        }

        public static void DrawBlueCircleSelected(Graphics graphics, int leftCornerX, int leftCornerY)
        {
            int circleSize = 18;

            Pen bluePen = new Pen(Color.Blue, 2);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Pen greenPen = new Pen(Color.Green, 4);

            graphics.DrawEllipse(bluePen, leftCornerX + 1, leftCornerY + 1, circleSize, circleSize);

            graphics.DrawRectangle(greenPen, leftCornerX, leftCornerY, circleSize, circleSize);

            bluePen.Dispose();
            greenPen.Dispose();
        }

        public static void CreateLabelsForTable(Panel panel1, Control.ControlCollection control )
        {
            for (int i = 0; i < 20; i++)
            {
                Label label = new Label();
                label.Text = $"{i + 1}";
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Location = new Point(panel1.Location.X + 20 * i, 38 - label.Font.Height * 2);
                label.Width = 20;
                label.ForeColor = Color.Black;
                label.BackColor = Color.Transparent;
                control.Add(label);
            }
            for (int i = 0; i < 20; i++)
            {
                Label label = new Label();
                label.Text = $"{i + 1}";
                label.TextAlign = ContentAlignment.MiddleLeft;
                label.Location = new Point(panel1.Location.X - 20, panel1.Location.Y + 20 * i);
                label.Height = 20;
                label.ForeColor = Color.Black;
                label.BackColor = Color.Transparent;
                control.Add(label);
            }

        }

    }
}
