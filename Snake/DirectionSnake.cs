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
    class DirectionSnake
    {
        Direction directSnake = Direction.Left; // Потому что при инициализации глаза змейки смотрят на лево
        Direction banDirect;
        enum Direction
        {
            Up,
            Down,
            Right,
            Left
        }
        public void SetDerection(int direct)
        {
            SetBanDirect(direct);
            switch (direct)
            {
                case (int)Direction.Up:
                    if (direct != (int)banDirect)
                    {
                        directSnake = Direction.Up;
                    }
                    break;
                case (int)Direction.Down:
                    if (direct != (int)banDirect)
                    {
                        directSnake = Direction.Down;
                    }
                    break;
                case (int) Direction.Right:
                    if (direct != (int)banDirect)
                    {
                        directSnake = Direction.Right;
                    }
                    break;
                case (int)Direction.Left:
                    if (direct != (int)banDirect)
                    {
                        directSnake = Direction.Left;
                    }
                    break;
                default:
                    break;
            };
        }
        public int GetDerection()
        {
            return (int)directSnake;
        }
        void SetBanDirect(int currentDirect)
        {
            switch (currentDirect)
            {
                case (int)Direction.Up:
                    banDirect = Direction.Down;
                    break;
                case (int)Direction.Down:
                    banDirect = Direction.Up;
                    break;
                case (int)Direction.Right:
                    banDirect = Direction.Left;
                    break;
                case (int)Direction.Left:
                    banDirect = Direction.Right;
                    break;
                default:
                    break;
            };
        }
    }
}
