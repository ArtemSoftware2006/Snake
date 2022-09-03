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
        Size sizeBlock = new Size(40, 40);
        const int VALUE_SIDE_BLOCK = 40;
        Rectangle[] arrSnakeBody;
        Rectangle[] eyesSnake = new Rectangle[2];
        int snakeLenght = 3;
        List<Point> locationSnakeBody = new List<Point>(3);
        Point? locationApple;
        Direction direct;
        Direction banDirect;
        enum Direction
        {
            Up,
            Down,
            Right,
            Left
        }
        public Rectangle GetHeadSnake()
        {
            return snakeBody[0];
        }
        public Rectangle[] GetSnake()
        {
            return ConvertListSnakeToArray();
        }
        public Rectangle GetEyes(int index)
        {
            return eyesSnake[index];
        }
        void SetEyes(Direction direct)
        {
            switch (direct)
            {
                case Direction.Up:
                    eyesSnake[0].X = snakeBody[0].X + 3;
                    eyesSnake[0].Y = snakeBody[0].Y - 3;
                    eyesSnake[1].X = snakeBody[0].X + VALUE_SIDE_BLOCK - 3;
                    eyesSnake[1].Y = snakeBody[0].Y - 3;
                    break;
                case Direction.Down:
                    eyesSnake[0].X = snakeBody[0].X - 3;
                    eyesSnake[0].Y = snakeBody[0].Y + VALUE_SIDE_BLOCK - 3;
                    eyesSnake[1].X = snakeBody[0].X + VALUE_SIDE_BLOCK - 3;
                    eyesSnake[1].Y = snakeBody[0].Y + VALUE_SIDE_BLOCK - 3;
                    break;
                case Direction.Right:
                    eyesSnake[0].X = snakeBody[0].X + VALUE_SIDE_BLOCK - 3;
                    eyesSnake[0].Y = snakeBody[0].Y + 3;
                    eyesSnake[1].X = snakeBody[0].X + VALUE_SIDE_BLOCK - 3;
                    eyesSnake[1].Y = snakeBody[0].Y + VALUE_SIDE_BLOCK - 3;
                    break;
                case Direction.Left:
                    eyesSnake[0].X = snakeBody[0].X - 3;
                    eyesSnake[0].Y = snakeBody[0].Y + 3;
                    eyesSnake[1].X = snakeBody[0].X - 3;
                    eyesSnake[1].Y = snakeBody[0].Y + VALUE_SIDE_BLOCK - 3;
                    break;
                default:
                    break;
            }
            
        }
        public bool IsSnakeRIP()
        {
            for (int i = 1; i < snakeLenght; i++)
            {
                if (locationSnakeBody[0] == locationSnakeBody[i] || locationSnakeBody[0].X >= 520 || 
                    locationSnakeBody[0].X <= 0 || locationSnakeBody[0].Y >= 520 || locationSnakeBody[0].Y <= 0 )
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
                locationSnakeBody.RemoveAt(snakeLenght);
            }
            else
            {
                locationApple = null;
                snakeLenght++;
            }
        }
        public void SetDerection(int direct)
        {
            switch (direct)
            {
                case 0:
                    if (direct != (int)banDirect)
                    {
                        this.direct = Direction.Up;
                    }
                    break;
                case 1:
                    if (direct != (int)banDirect)
                    {
                        this.direct = Direction.Down;
                    }
                    break;
                case 2:
                    if (direct != (int)banDirect)
                    {
                        this.direct = Direction.Right;
                    }
                    break;
                case 3:
                    if (direct != (int)banDirect)
                    {
                        this.direct = Direction.Left;
                    }
                    break;
                default:
                    break;
            };
            SetEyes(this.direct);
        }
        public int GetDerection()
        {
            return (int)direct;
        }
        Rectangle[] ConvertListSnakeToArray()
        {
            snakeBody.CopyTo(arrSnakeBody = new Rectangle[snakeLenght]);
            return arrSnakeBody;
        }
        public void InitializingSnake()
        {
            eyesSnake[0].Width = 4;
            eyesSnake[0].Height = 6;
            eyesSnake[1].Width = 4;
            eyesSnake[1].Height = 6;

            SetDerection((int)Direction.Left);

            for (int i = 0; i < snakeLenght; i++)
            {
                snakeBody.Add(new Rectangle(new Point(240 + (i * VALUE_SIDE_BLOCK), 240), sizeBlock));
                locationSnakeBody.Add( new Point(snakeBody[i].X, snakeBody[i].Y) );
            }
        }
        
        public void SnakeUp()
        {
            snakeBody.Insert(0, new Rectangle(new Point(snakeBody[0].X, snakeBody[0].Y - VALUE_SIDE_BLOCK),sizeBlock));
            locationSnakeBody.Insert(0, new Point(snakeBody[0].X, snakeBody[0].Y));
            banDirect = Direction.Down;
            CheckEatSnakeApple();
        }
        public void SnakeDown()
        {
            snakeBody.Insert(0, new Rectangle(new Point(snakeBody[0].X, snakeBody[0].Y + VALUE_SIDE_BLOCK), sizeBlock));
            locationSnakeBody.Insert(0, new Point(snakeBody[0].X, snakeBody[0].Y));
            banDirect = Direction.Up;
            CheckEatSnakeApple();
        }
        public void SnakeLeft()
        {
            snakeBody.Insert(0, new Rectangle(new Point(snakeBody[0].X - VALUE_SIDE_BLOCK, snakeBody[0].Y ), sizeBlock));
            locationSnakeBody.Insert(0, new Point(snakeBody[0].X, snakeBody[0].Y));
            banDirect = Direction.Right;
            CheckEatSnakeApple();
        }
        public void SnakeRight()
        {
            snakeBody.Insert(0, new Rectangle(new Point(snakeBody[0].X + VALUE_SIDE_BLOCK, snakeBody[0].Y ), sizeBlock));
            locationSnakeBody.Insert(0, new Point(snakeBody[0].X, snakeBody[0].Y));
            banDirect = Direction.Left;
            CheckEatSnakeApple();
        }
    }
}
