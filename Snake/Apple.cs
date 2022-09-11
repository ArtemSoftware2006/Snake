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
    class Apple
    {
        const int SIZE_BLOCK = 40;
        private int sizeApple = 0;
        private Point location;
        private Random randomLocation = new Random();
        private Rectangle _Apple;

        public Apple(int sizeApple)
        {
            this.sizeApple = sizeApple;
        }
        public Rectangle apple
        {
            get { return _Apple; }
            set { _Apple = value; }
        }

        public Point Location
        {
            get { return location; }
            set { location = value; }
        }
         public void AddApple()
        {
            SetLocation();
            CreateApple();
        }

        private void SetLocation()
        {
            location.X = randomLocation.Next(1, 13) * SIZE_BLOCK;
            location.Y = randomLocation.Next(1, 13) * SIZE_BLOCK;
        }
        void CreateApple()
        {
            _Apple.Width = sizeApple;
            _Apple.Height = sizeApple;

            _Apple.X = Location.X + (SIZE_BLOCK - sizeApple) / 2;
            _Apple.Y = Location.Y + (SIZE_BLOCK - sizeApple) / 2;
        }
    }
}
