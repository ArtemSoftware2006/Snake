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
        public override Rectangle Apple => throw new NotImplementedException();
        protected override void CreateApple()
        {
            throw new NotImplementedException();
        }
    }
}
