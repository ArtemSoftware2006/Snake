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
    class BigApple : Apples
    {
        const int SIZE_APPLE_SMALL = 25;
        const int SIZE_APPLE_BIG = 30;
        Rectangle apple = new Rectangle();
        Rectangle appleBigView = new Rectangle();
        Rectangle appleSmallView = new Rectangle();

        public override Rectangle Apple
        {
            get => apple;
        }
        public override void AddApple()
        {
            base.NewApple();
            CreateSmallApple();
        }
        void CreateBigApple()
        {
            appleBigView.Width = SIZE_APPLE_BIG;
            appleBigView.Height = SIZE_APPLE_BIG;

            appleBigView.X = Location.X + 5;
            appleBigView.Y = Location.Y + 5;

            apple = appleBigView;
        }
        void CreateSmallApple()
        {
            appleSmallView.Width = SIZE_APPLE_SMALL;
            appleSmallView.Height = SIZE_APPLE_SMALL;

            appleSmallView.X = Location.X + 8;
            appleSmallView.Y = Location.Y + 8;

            apple = appleSmallView;
        }
        public void NextViewOfBigApple(ref BigApple apple)
        {
            if (apple.apple == appleSmallView)
            {
                CreateBigApple();
            }
            else
            {
                CreateSmallApple();
            }
        }
        
    }
        
    
}
