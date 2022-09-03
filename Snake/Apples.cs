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
       
        protected Point location;
        protected Random randomLocation = new Random();
        abstract public Rectangle Apple
        {
            get;
        }
        protected Point Location
        {
            get { return location; }
            set { location = value; }
        }
        abstract public void AddApple();

        protected  void SetLocation()
        {
            location.X = randomLocation.Next(1, 13) * 40;
            location.Y = randomLocation.Next(1, 13) * 40;
        }
        public Point GetLocation()
        {
            return location;
        }    
    }
}
