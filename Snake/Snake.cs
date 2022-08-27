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
        List<Rectangle> SnakeBody = new List<Rectangle>(3);
        Size SizeBlock = new Size(40, 40);
        const int VALUE_SIDE_BLOCK = 40;
        Rectangle[] ArrSnakeBody;
        int SnakeLenght = 3;
        static List<Point> LocationSnakeBody = new List<Point>(3);
        static Point? LocationApple;
        Direction direct;
        Direction BanDirect;
        enum Direction
        {
            Up,
            Down,
            Right,
            Left
        }

        public bool IsSnakeRIP()
        {
            for (int i = 1; i < SnakeLenght; i++)
            {
                if (LocationSnakeBody[0] == LocationSnakeBody[i] || LocationSnakeBody[0].X >= 520 || 
                    LocationSnakeBody[0].X <= 0 || LocationSnakeBody[0].Y >= 520 || LocationSnakeBody[0].Y <= 0 )
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsSnakeEatApple()
        {
            if (LocationApple == null)
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
            if(LocationApple != new Point(SnakeBody[0].X, SnakeBody[0].Y))
            {
                SnakeBody.RemoveAt(SnakeLenght);
                LocationSnakeBody.RemoveAt(SnakeLenght);
            }
            else
            {
                LocationApple = null;
                SnakeLenght++;
            }
        }
        public static void GetLocationApple(Point Location)
        {
            LocationApple = Location;
        }
        static public List<Point> GetLocationSnake()
        {
            return LocationSnakeBody;
        }
        public void SetDerection(int direct)
        {
            switch (direct)
            {
                case 0:
                    if (direct != (int)BanDirect)
                    {
                        this.direct = Direction.Up;
                    }
                    break;
                case 1:
                    if (direct != (int)BanDirect)
                    {
                        this.direct = Direction.Down;
                    }
                    break;
                case 2:
                    if (direct != (int)BanDirect)
                    {
                        this.direct = Direction.Right;
                    }
                    break;
                case 3:
                    if (direct != (int)BanDirect)
                    {
                        this.direct = Direction.Left;
                    }
                    break;
                default:
                    break;
            };
        }
        public int GetDerection()
        {
            return (int)direct;
        }
        Rectangle[] ConvertListSnakeToArray()
        {
            SnakeBody.CopyTo(ArrSnakeBody = new Rectangle[SnakeLenght]);
            return ArrSnakeBody;
        }
        public void InitializingSnake()
        {
            for (int i = 0; i < SnakeLenght; i++)
            {
                SnakeBody.Add(new Rectangle(new Point(240 + (i * VALUE_SIDE_BLOCK), 240), SizeBlock));
                LocationSnakeBody.Add( new Point(SnakeBody[i].X, SnakeBody[i].Y) );
            }
        }
        public Rectangle[] GetSnake()
        {
            return ConvertListSnakeToArray();
        }
        public void SnakeUp()
        {
            SnakeBody.Insert(0, new Rectangle(new Point(SnakeBody[0].X, SnakeBody[0].Y - VALUE_SIDE_BLOCK),SizeBlock));
            LocationSnakeBody.Insert(0, new Point(SnakeBody[0].X, SnakeBody[0].Y));
            BanDirect = Direction.Down;
            CheckEatSnakeApple();
        }
        public void SnakeDown()
        {
            SnakeBody.Insert(0, new Rectangle(new Point(SnakeBody[0].X, SnakeBody[0].Y + VALUE_SIDE_BLOCK), SizeBlock));
            LocationSnakeBody.Insert(0, new Point(SnakeBody[0].X, SnakeBody[0].Y));
            BanDirect = Direction.Up;
            CheckEatSnakeApple();
        }
        public void SnakeLeft()
        {
            SnakeBody.Insert(0, new Rectangle(new Point(SnakeBody[0].X - VALUE_SIDE_BLOCK, SnakeBody[0].Y ), SizeBlock));
            LocationSnakeBody.Insert(0, new Point(SnakeBody[0].X, SnakeBody[0].Y));
            BanDirect = Direction.Right;
            CheckEatSnakeApple();
        }
        public void SnakeRight()
        {
            SnakeBody.Insert(0, new Rectangle(new Point(SnakeBody[0].X + VALUE_SIDE_BLOCK, SnakeBody[0].Y ), SizeBlock));
            LocationSnakeBody.Insert(0, new Point(SnakeBody[0].X, SnakeBody[0].Y));
            BanDirect = Direction.Left;
            CheckEatSnakeApple();
        }
    }
}
