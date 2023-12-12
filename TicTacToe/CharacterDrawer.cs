using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class CharacterDrawer
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
            graphics.DrawEllipse(bluePen, leftCornerX + 1, leftCornerY + 1, circleSize, circleSize);
            bluePen.Dispose();
        }
    }
}
