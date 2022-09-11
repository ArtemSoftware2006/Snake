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
        int deltaX = 0;
        int deltaY = 0;
        int snakeLenght = 3;
        public Rectangle[] GetSnake()
        {
            return ConvertListSnakeToArray();
        }
        public void SnakeMoveAndGrow()
        {
            snakeBody.Insert(0, new Rectangle(new Point(snakeBody[0].X + deltaX, snakeBody[0].Y + deltaY), sizeBlock));
            snakeLenght++;
        }
        public void SnakeMove()
        {
            snakeBody.RemoveAt(snakeLenght - 1);
            snakeBody.Insert(0, new Rectangle(new Point(snakeBody[0].X + deltaX, snakeBody[0].Y + deltaY), sizeBlock));
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
            deltaX = 0;
            deltaY = -1 * VALUE_SIDE_BLOCK;
        }
        public void SnakeDown()
        {
            deltaX = 0;
            deltaY = VALUE_SIDE_BLOCK;
        }
        public void SnakeLeft()
        {
            deltaX = -1 * VALUE_SIDE_BLOCK;
            deltaY = 0;
        }
        public void SnakeRight()
        {
            deltaX = VALUE_SIDE_BLOCK;
            deltaY = 0;
        }
    }
}
