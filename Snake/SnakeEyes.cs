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
    class SnakeEyes
    {
        const int VALUE_SIDE_BLOCK = 40;
        Rectangle[] eyesSnake = new Rectangle[2];
        enum Direction
        {
            Up,
            Down,
            Right,
            Left
        }
        public SnakeEyes()
        {
            eyesSnake[0].Width = 4;
            eyesSnake[0].Height = 6;
            eyesSnake[1].Width = 4;
            eyesSnake[1].Height = 6;
        }
        public void SetEyes(int direct, Rectangle[] snakeBody)
        {
            switch (direct)
            {
                case (int)Direction.Up:
                    eyesSnake[0].X = snakeBody[0].X + 3;
                    eyesSnake[0].Y = snakeBody[0].Y - 3;
                    eyesSnake[1].X = snakeBody[0].X + VALUE_SIDE_BLOCK - 3;
                    eyesSnake[1].Y = snakeBody[0].Y - 3;
                    break;
                case (int)Direction.Down:
                    eyesSnake[0].X = snakeBody[0].X - 3;
                    eyesSnake[0].Y = snakeBody[0].Y + VALUE_SIDE_BLOCK - 3;
                    eyesSnake[1].X = snakeBody[0].X + VALUE_SIDE_BLOCK - 3;
                    eyesSnake[1].Y = snakeBody[0].Y + VALUE_SIDE_BLOCK - 3;
                    break;
                case (int)Direction.Right:
                    eyesSnake[0].X = snakeBody[0].X + VALUE_SIDE_BLOCK - 3;
                    eyesSnake[0].Y = snakeBody[0].Y + 3;
                    eyesSnake[1].X = snakeBody[0].X + VALUE_SIDE_BLOCK - 3;
                    eyesSnake[1].Y = snakeBody[0].Y + VALUE_SIDE_BLOCK - 3;
                    break;
                case (int)Direction.Left:
                    eyesSnake[0].X = snakeBody[0].X - 3;
                    eyesSnake[0].Y = snakeBody[0].Y + 3;
                    eyesSnake[1].X = snakeBody[0].X - 3;
                    eyesSnake[1].Y = snakeBody[0].Y + VALUE_SIDE_BLOCK - 3;
                    break;
                default:
                    break;
            }
        }
        public Rectangle GetEyes(int index)
        {
            return eyesSnake[index];
        }
    }
}
