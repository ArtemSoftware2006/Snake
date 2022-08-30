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
    class SmallApple : Apples
    {
        const int SIZE_APPLE = 20;
        Rectangle apple = new Rectangle();
        public override Rectangle Apple 
        { 
            get => apple; 
        }
        public override void AddApple()
        {
            base.NewApple();
            CreateSmallAple();
        }
       protected void CreateSmallAple()
        {
            apple.Width = SIZE_APPLE;
            apple.Height = SIZE_APPLE;

            apple.X = Location.X + SIZE_APPLE / 2 - 1;
            apple.Y = Location.Y + SIZE_APPLE / 2 - 1;
           
        }
        
    }
}
