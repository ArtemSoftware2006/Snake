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
        int directSnake = (int)Direction.Left; // Потому что при инициализации глаза змейки смотрят на лево
        Direction banDirect = Direction.Right;
        enum Direction
        {
            Up,
            Down,
            Right,
            Left
        }
        public void SetDerection(int direct)
        {
            if(direct != (int)banDirect)
            {
                directSnake = direct;
            }
        }
        public int GetDerection()
        {
            return directSnake;
        }
        public void SetBanDirect()
        {
            switch (directSnake)
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
