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
        private PointF location;
        private Random randomLocation = new Random();
        private RectangleF _Apple;
        private PointF UpperleftCornerApple;
        public Apple(int sizeApple)
        {
            this.sizeApple = sizeApple;
        }
        public PointF UpperleftCorner
        {
            get { return UpperleftCornerApple; ; }
            private set { UpperleftCornerApple = value; }
        }
        public RectangleF apple
        {
            get { return _Apple; }
            set { _Apple = value; }
        }

        public PointF Location
        {
            get { return location; }
            private set { location = value; }
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
            UpperleftCornerApple.X = (SIZE_BLOCK - sizeApple) / 2;
            UpperleftCornerApple.Y = (SIZE_BLOCK - sizeApple) / 2;

            apple = new RectangleF(UpperleftCornerApple.X + location.X, UpperleftCornerApple.Y + location.Y, sizeApple, sizeApple);
        }
    }
}
