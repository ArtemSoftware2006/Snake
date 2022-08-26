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
    public partial class Fm_game_place : Form
    {
        List<string> ListMessages = new List<string>()
        {
            "Счёт: ",
            "До начала игры: ",
            "Игра окончена",
        };
        SmallApple apple = new SmallApple();
        Snake snake = new Snake();
        GameSpace pole;
        Graphics g;
        Bitmap bmp;
        Pen pen = new Pen(Color.Black, 4.0F);
        SolidBrush brash = new SolidBrush(Color.Red);
        int countDown;
        int pointsForSmallApple = 1;
        int allPoints = 0;
        enum Direction
        {
            Up,
            Down,
            Right,
            Left
        }
        public Fm_game_place()
        {
            InitializeComponent();
            pole = new GameSpace(pictureBox1.Width, pictureBox1.Height);
            StartingTimers();
            Beginning_game();
        }
        void StartingTimers()
        {
            countDown = 3;
            timer_starting_game.Interval = 1000;
            timer_starting_game.Start();
        }
        private void Beginning_game()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            Initializingpole();
            g.FillRectangles(brash, snake.InitializingSnake());
            apple.AddApple();
            pictureBox1.Image = bmp;
            
        }
        public void Initializingpole()
        {
            for (int i = 0; i < 13; i++)
            {
                g.DrawLine(pen, pole.GetGorizontalLine()[i, 0], pole.GetGorizontalLine()[i, 1]);
                g.DrawLine(pen, pole.GetVerticalsLines()[i, 0], pole.GetVerticalsLines()[i, 1]);
            }
        }
        private void timer_starting_game_Tick(object sender, EventArgs e)
        {
            LabelScore.Text = $"{ListMessages[1] + countDown}";
            if (countDown == 0)
            {
                timer_starting_game.Stop();
                LabelScore.Text = ListMessages[0] + "0";
                timer_game_cycle.Start();
            }
            countDown--;
        }
        void Game_Over()
        {
            timer_game_cycle.Stop();
            LabelScore.Text = ListMessages[2];
        }
        private void Fm_game_place_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.W:
                    snake.SetDerection((int)Direction.Up);
                    break;
                case (char)Keys.D:
                    snake.SetDerection((int)Direction.Right);
                    break;
                case (char)Keys.S:
                    snake.SetDerection((int)Direction.Down);
                    break;
                case (char)Keys.A:
                    snake.SetDerection((int)Direction.Left);
                    break;
                default:
                    break;
            }
        }
        
        private void timer_game_cycle_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            Initializingpole();
            switch (snake.GetDerection())
            {
                case (int)Direction.Up:
                    g.FillRectangles(brash, snake.SnakeUp());
                    break;
                case (int)Direction.Down:
                    g.FillRectangles(brash, snake.SnakeDown());
                    break;
                case (int)Direction.Left:
                    g.FillRectangles(brash, snake.SnakeLeft());
                    break;
                case (int)Direction.Right:
                    g.FillRectangles(brash, snake.SnakeRight());
                    break;
                default:
                    break;
            }
            if (snake.IsSnakeEatApple())
            {
                allPoints += pointsForSmallApple;
                LabelScore.Text = ListMessages[0] + Convert.ToString(allPoints);
                apple.AddApple();
            }

            g.FillEllipse(brash, apple.Apple);
            pictureBox1.Image = bmp;

            if (snake.CheckSnakeRIP())
            {

                Game_Over();
            }
        }
    }
}
