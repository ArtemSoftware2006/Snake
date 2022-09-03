using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class GameSpace
    {
        Point[,] arrGorizontLines = new Point[13,2];
        Point[,] arrVerticalsLines = new Point[13,2];
        const int VALUE_SIDE_BLOCK = 40;
        public GameSpace(int width, int height)
        {
            for (int i = 0; i < arrGorizontLines.GetLength(0); i++)
            {
                 arrGorizontLines[i, 0] = new Point(0, i * VALUE_SIDE_BLOCK);
                 arrGorizontLines[i, 1] = new Point(height, i * VALUE_SIDE_BLOCK);

                 arrVerticalsLines[i, 0] = new Point(i * VALUE_SIDE_BLOCK, 0);
                 arrVerticalsLines[i, 1] = new Point(i * VALUE_SIDE_BLOCK, width);
            }
        }
        public Point[,] GetGorizontalLine()
        {
            return arrGorizontLines;
        }
        public Point[,] GetVerticalsLines()
        {
            return arrVerticalsLines;
        }
    }
}
