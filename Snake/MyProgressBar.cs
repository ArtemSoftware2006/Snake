using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Snake
{
    class MyProgressBar
    {
        Button progressBar = new Button();
        public int WidghStep { get; set; }
        public int Maximum { get; set; }
        public int Step { get; set; }
        private int value;

        public int Value
        {
            get { return value; }
            set 
            {
                this.value = value;
                progressBar.Width = value;
            }
        }

        int direction;
        int counterStep = 1;

        public MyProgressBar(int wieght,int height,Color color, Point location)
        {
            progressBar.Width = wieght;
            progressBar.Height = height;
            progressBar.BackColor = color;
            progressBar.Location = location;
        }
        public int Direction
        {
            get { return direction; }
            set
            {
                if (value == -1 )
                {
                    direction = value;
                    ProgressBarDecrease();
                }
                else if(value == 1)
                {
                    direction = value;
                    ProgressBarIncrease();
                } 
                else
                    throw new Exception("Можно вводить только 1 и -1\n1 - progressBar увеличивается\n-1 - progressbar умеьшается");
            }
        }
        void ProgressBarDecrease()
        {
            progressBar.Width = Maximum * WidghStep;
            value = progressBar.Width;
        }
        void ProgressBarIncrease()
        {
            value = Maximum * WidghStep;
            progressBar.Width = 1;
        }
        public void PerformStep()
        {
            progressBar.Width = Value + Step * counterStep * WidghStep * direction;
            counterStep++;
            if(progressBar.Width >= Maximum * WidghStep)
            {
                progressBar.Width = Maximum;
            }
        }
        public void StopAndUpdatingProdBar()
        {
            counterStep = 1;
            if (direction == 1)
            {
                ProgressBarIncrease();
            }
            else
            {
                ProgressBarIncrease();
            }
        }

        public void ShowProgressBar()
        {
            progressBar.Visible = true;
        }
        public void HideProgressBar()
        {
            if(progressBar.Width >= Maximum)
            {
                progressBar.Visible = false;
            }
        }
        public ref Button GetProgressBar()
        {
            return ref progressBar;
        }
    }
}
