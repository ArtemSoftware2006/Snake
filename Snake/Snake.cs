﻿using System;
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

        public bool CheckSnakeRIP()
        {
            for (int i = 1; i < SnakeLenght; i++)
            {
                if (LocationSnakeBody[0] == LocationSnakeBody[i])
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
        public void GetLastDirection(int direct)
        {
            switch (direct)
            {
                case (int)Direction.Up:
                    BanDirect = Direction.Down;
                    break;
                case (int)Direction.Down:
                    BanDirect = Direction.Up;
                    break;
                case (int)Direction.Left:
                    BanDirect = Direction.Right;
                    break;
                case (int)Direction.Right:
                    BanDirect = Direction.Left;
                    break;
                default:
                    break;
            }

        }
        public int GetDerection()
        {
            return (int)direct;
        }
        public Rectangle[] InitializingSnake()
        {
            for (int i = 0; i < SnakeLenght; i++)
            {
                SnakeBody.Add(new Rectangle(new Point(240 + (i * VALUE_SIDE_BLOCK), 240), SizeBlock));
                LocationSnakeBody.Add( new Point(SnakeBody[i].X, SnakeBody[i].Y) );
            }
            SnakeBody.CopyTo(ArrSnakeBody = new Rectangle[SnakeLenght]);
            return ArrSnakeBody;
        }

        public Rectangle[] SnakeUp()
        {
            SnakeBody.Insert(0, new Rectangle(new Point(SnakeBody[0].X, SnakeBody[0].Y - VALUE_SIDE_BLOCK),SizeBlock));
            LocationSnakeBody.Insert(0, new Point(SnakeBody[0].X, SnakeBody[0].Y));
            CheckEatSnakeApple();
            SnakeBody.CopyTo(ArrSnakeBody = new Rectangle[SnakeLenght]);
            return ArrSnakeBody;
        }
        public Rectangle[] SnakeDown()
        {
            SnakeBody.Insert(0, new Rectangle(new Point(SnakeBody[0].X, SnakeBody[0].Y + VALUE_SIDE_BLOCK), SizeBlock));
            LocationSnakeBody.Insert(0, new Point(SnakeBody[0].X, SnakeBody[0].Y));
            CheckEatSnakeApple();
            SnakeBody.CopyTo(ArrSnakeBody = new Rectangle[SnakeLenght]);
            return ArrSnakeBody;
        }
        public Rectangle[] SnakeLeft()
        {
            SnakeBody.Insert(0, new Rectangle(new Point(SnakeBody[0].X - VALUE_SIDE_BLOCK, SnakeBody[0].Y ), SizeBlock));
            LocationSnakeBody.Insert(0, new Point(SnakeBody[0].X, SnakeBody[0].Y));
            CheckEatSnakeApple();
            SnakeBody.CopyTo(ArrSnakeBody = new Rectangle[SnakeLenght]);
            return ArrSnakeBody;
        }
        public Rectangle[] SnakeRight()
        {
            SnakeBody.Insert(0, new Rectangle(new Point(SnakeBody[0].X + VALUE_SIDE_BLOCK, SnakeBody[0].Y ), SizeBlock));
            LocationSnakeBody.Insert(0, new Point(SnakeBody[0].X, SnakeBody[0].Y));
            CheckEatSnakeApple();
            SnakeBody.CopyTo(ArrSnakeBody = new Rectangle[SnakeLenght]);
            return ArrSnakeBody;
        }
    }
}
