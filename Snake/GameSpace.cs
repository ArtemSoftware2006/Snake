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
        Point[,] ArrGorizontLines = new Point[13,2];
        Point[,] ArrVerticalsLines = new Point[13,2];
        const int VALUE_SIDE_BLOCK = 40;
        public GameSpace(int width, int height)
        {
            for (int i = 0; i < ArrGorizontLines.GetLength(0); i++)
            {
                 ArrGorizontLines[i, 0] = new Point(0, i * VALUE_SIDE_BLOCK);
                 ArrGorizontLines[i, 1] = new Point(height, i * VALUE_SIDE_BLOCK);

                 ArrVerticalsLines[i, 0] = new Point(i * VALUE_SIDE_BLOCK, 0);
                 ArrVerticalsLines[i, 1] = new Point(i * VALUE_SIDE_BLOCK, width);
            }
        }
        public Point[,] GetGorizontalLine()
        {
            return ArrGorizontLines;
        }
        public Point[,] GetVerticalsLines()
        {
            return ArrVerticalsLines;
        }
    }
}
