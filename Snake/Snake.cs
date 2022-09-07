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
    class Snake
    {
        List<Rectangle> snakeBody = new List<Rectangle>(3);
        Size sizeBlock = new Size(VALUE_SIDE_BLOCK, VALUE_SIDE_BLOCK);
        const int VALUE_SIDE_BLOCK = 40;
        Rectangle[] arrSnakeBody;
        int snakeLenght = 3;
        public Rectangle[] GetSnake()
        {
            return ConvertListSnakeToArray();
        }
        public void SnakeMoveAndGrow()
        {
            snakeLenght++;
        }
        public void SnakeMove()
        {
            snakeBody.RemoveAt(snakeLenght - 1);
        }
        
        Rectangle[] ConvertListSnakeToArray()
        {
            snakeBody.CopyTo(arrSnakeBody = new Rectangle[snakeLenght]);
            return arrSnakeBody;
        }
        public void InitializingSnake()
        {
            for (int i = 0; i < snakeLenght; i++)
            {
                snakeBody.Add(new Rectangle(new Point(240 + (i * VALUE_SIDE_BLOCK), 240), sizeBlock));
            }
        }
        
        public void SnakeUp()
        {
            snakeBody.Insert(0, new Rectangle(new Point(snakeBody[0].X, snakeBody[0].Y - VALUE_SIDE_BLOCK),sizeBlock));
        }
        public void SnakeDown()
        {
            snakeBody.Insert(0, new Rectangle(new Point(snakeBody[0].X, snakeBody[0].Y + VALUE_SIDE_BLOCK), sizeBlock));
        }
        public void SnakeLeft()
        {
            snakeBody.Insert(0, new Rectangle(new Point(snakeBody[0].X - VALUE_SIDE_BLOCK, snakeBody[0].Y ), sizeBlock));
        }
        public void SnakeRight()
        {
            snakeBody.Insert(0, new Rectangle(new Point(snakeBody[0].X + VALUE_SIDE_BLOCK, snakeBody[0].Y ), sizeBlock));
        }
    }
}
