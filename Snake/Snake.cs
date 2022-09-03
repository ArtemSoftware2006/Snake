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
        Point? locationApple;
        public Rectangle GetHeadSnake()
        {
            return snakeBody[0];
        }
        public Rectangle[] GetSnake()
        {
            return ConvertListSnakeToArray();
        }
        public bool IsSnakeRIP()
        {
            for (int i = 1; i < snakeLenght; i++)
            {
                if (snakeBody[0] == snakeBody[i] || snakeBody[0].X >= 520 ||
                    snakeBody[0].X <= 0 || snakeBody[0].Y >= 520 || snakeBody[0].Y <= 0 )
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsSnakeEatApple()
        {
            if (locationApple == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        void CheckEatSnakeApple()
        {
            if(locationApple != new Point(snakeBody[0].X, snakeBody[0].Y))
            {
                snakeBody.RemoveAt(snakeLenght);
                //locationSnakeBody.RemoveAt(snakeLenght);
            }
            else
            {
                locationApple = null;
                snakeLenght++;
            }
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
                //locationSnakeBody.Add( new Point(snakeBody[i].X, snakeBody[i].Y) );
            }
        }
        
        public void SnakeUp()
        {
            snakeBody.Insert(0, new Rectangle(new Point(snakeBody[0].X, snakeBody[0].Y - VALUE_SIDE_BLOCK),sizeBlock));
            //locationSnakeBody.Insert(0, new Point(snakeBody[0].X, snakeBody[0].Y));
            CheckEatSnakeApple();
        }
        public void SnakeDown()
        {
            snakeBody.Insert(0, new Rectangle(new Point(snakeBody[0].X, snakeBody[0].Y + VALUE_SIDE_BLOCK), sizeBlock));
            //locationSnakeBody.Insert(0, new Point(snakeBody[0].X, snakeBody[0].Y));
            CheckEatSnakeApple();
        }
        public void SnakeLeft()
        {
            snakeBody.Insert(0, new Rectangle(new Point(snakeBody[0].X - VALUE_SIDE_BLOCK, snakeBody[0].Y ), sizeBlock));
            //locationSnakeBody.Insert(0, new Point(snakeBody[0].X, snakeBody[0].Y));
            CheckEatSnakeApple();
        }
        public void SnakeRight()
        {
            snakeBody.Insert(0, new Rectangle(new Point(snakeBody[0].X + VALUE_SIDE_BLOCK, snakeBody[0].Y ), sizeBlock));
            //locationSnakeBody.Insert(0, new Point(snakeBody[0].X, snakeBody[0].Y));
            CheckEatSnakeApple();
        }
    }
}
