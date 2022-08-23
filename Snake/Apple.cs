using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Snake;

namespace Snake
{
    class Apple 
    {
        Rectangle apple = new Rectangle();
        Point Location;
        const int SIZE_APPLE = 25;
        Random rnd = new Random();

        void SetLocation()
        {
            Location.X = rnd.Next(1, 13) * 40;
            Location.Y = rnd.Next(1, 13) * 40;

        }
        void CheckLocationApple()
        {
            for (int i = 0; i < Snake.GetLocationSnake().Count; i++)
            {
                if (Location.X == Snake.GetLocationSnake()[i].X && Location.Y == Snake.GetLocationSnake()[i].Y)
                {
                    SetLocation();
                    CheckLocationApple();
                    break;
                }
            }
        }
        void CreateApple()
        {
            apple.Width = SIZE_APPLE;
            apple.Height = SIZE_APPLE;

            apple.X = Location.X + SIZE_APPLE / 4 + 1;
            apple.Y = Location.Y + SIZE_APPLE / 4 + 1;
        }
        public void AddApple()
        {
            SetLocation();
            CreateApple();
            Snake.GetLocationApple(Location);
        }
        public Rectangle GetApple()
        {
            return apple;
        }
    }
}
