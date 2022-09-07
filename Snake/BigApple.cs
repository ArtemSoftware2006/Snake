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
    class BigApple : SmallApple
    {
        const int SIZE_APPLE_BIG = 30;
        Rectangle appleBigView = new Rectangle();

        public override void AddApple()
        {
            base.SetLocation();
            CreateBigApple();
        }
        void CreateBigApple()
        {
            appleBigView.Width = SIZE_APPLE_BIG;
            appleBigView.Height = SIZE_APPLE_BIG;

            appleBigView.X = Location.X + 5;
            appleBigView.Y = Location.Y + 5;

            apple = appleBigView;
        }
        
        public void NextViewOfBigApple(ref BigApple apple)
        {
            if (apple.apple == appleBigView)
            {
                CreateSmallApple();
            }
            else
            {
                CreateBigApple();
            }
        }
        
    }
}
