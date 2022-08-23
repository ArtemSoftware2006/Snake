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
    abstract class Apples
    {
        Rectangle apple = new Rectangle();
        Point Location;
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
        abstract public void CreateApple();
        public void AddApple()
        {
            SetLocation();
            CreateApple();
            Snake.GetLocationApple(Location);
        }
        abstract public Rectangle GetApple();
        
    }
}
