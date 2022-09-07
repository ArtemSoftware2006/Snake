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
        //TODO Глаза змейке
        //Реализация ProgressBar
        //Смерть змейки от поворота себе в хвост
        //Переход к реализации Form2
        List<string> ListMessages = new List<string>()
        {
            "Счёт: ",
            "До начала игры: ",
            "Игра окончена",
        };
        SmallApple smallApple = new SmallApple();
        BigApple bigApple = new BigApple();
        Snake snake = new Snake();
        GameSpace pole;
        Graphics g;
        Bitmap bmp;
        Pen pen = new Pen(Color.Black, 4.0F);
        SolidBrush brash = new SolidBrush(Color.Red);
        SolidBrush eyesBrash = new SolidBrush(Color.Blue);
        SnakeEyes snakeEyes = new SnakeEyes();
        DirectionSnake directSnake = new DirectionSnake();
        Point locationApple;
        int countDown;
        int pointsForSmallApple = 3;
        int pointsForBidApple = 10;
        int allPoints = 0;
        int counterEatedApple = 1;
        float TimeForEatBigApple = 20.0F;
        bool AddBigappleFlag = false;
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
        private void Beginning_game()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            Initializingpole();
            snake.InitializingSnake();
            g.FillRectangles(brash, snake.GetSnake());
            NewAppleOnForm(smallApple);
            DisplaySnakeEyes();
            pictureBox1.Image = bmp;
        }
        void StartingTimers()
        {
            countDown = 3;
            timer_starting_game.Interval = 1000;
            timer_starting_game.Start();
        }
        void CheckLocationApple(ref Apples apple)
        {
            for (int i = 0; i < snake.GetSnake().Length; i++)
            {
                if (apple.Apple.X == snake.GetSnake()[i].X && (apple.Apple.Y == snake.GetSnake()[i].Y))
                {
                    NewAppleOnForm(apple);
                    break;
                }
            }
        }
        void NewAppleOnForm(Apples apple)
        {
            apple.AddApple();
            CheckLocationApple(ref apple);
            locationApple = apple.Location;
        }
        void Initializingpole()
        {
            for (int i = 0; i < 13; i++)
            {
                g.DrawLine(pen, pole.GetGorizontalLine()[i, 0], pole.GetGorizontalLine()[i, 1]);
                g.DrawLine(pen, pole.GetVerticalsLines()[i, 0], pole.GetVerticalsLines()[i, 1]);
            }
        }
        void timer_starting_game_Tick(object sender, EventArgs e)
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
       
        void Fm_game_place_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case (char)Keys.W:
                    directSnake.SetDerection((int)Direction.Up);
                    break;
                case (char)Keys.D:
                    directSnake.SetDerection((int)Direction.Right);
                    break;
                case (char)Keys.S:
                    directSnake.SetDerection((int)Direction.Down);
                    break;
                case (char)Keys.A:
                    directSnake.SetDerection((int)Direction.Left);
                    break;
                default:
                    break;
            }
        }
        
        private void timer_game_cycle_Tick(object sender, EventArgs e)
        {
            CheckIsSnakeEatApple();
            SnakeSetDirection();
            GameOneCadr();

            IsAddBigApple();

            DisplayApple();
            pictureBox1.Image = bmp;
            CheckIsSnakeRIP();
        }
        void DisplayApple()
        {
            if (AddBigappleFlag == true)
            {
                g.FillEllipse(brash, bigApple.Apple);
            }
            else
            {
                g.FillEllipse(brash, smallApple.Apple);
            }
        }
        void GameOneCadr()
        {
            g.Clear(Color.White);
            Initializingpole();
            DisplaySnakeEyes();
            g.FillRectangles(brash, snake.GetSnake());
        }
        void IsAddBigApple()
        {
            if (counterEatedApple % 4 == 0)
            {
                NewAppleOnForm(bigApple);
                AddBigappleFlag = true;
                timer_of_big_apple.Interval = 500;
                timer_of_big_apple.Start();
                counterEatedApple++;
            }
        }
        void SetPointsForBigApple()
        {
            allPoints += pointsForBidApple - (pointsForBidApple - (int)TimeForEatBigApple);
            LabelScore.Text = ListMessages[0] + Convert.ToString(allPoints);
        }
        void CheckIsSnakeEatApple()
        {
            if (snake.GetSnake()[0].X == locationApple.X && snake.GetSnake()[0].Y == locationApple.Y)
            {
                if (AddBigappleFlag == true)
                {
                    timer_of_big_apple.Stop();
                    SetPointsForBigApple();
                    NewAppleOnForm(smallApple);
                    snake.SnakeMoveAndGrow();
                    AddBigappleFlag = false;
                }
                else
                {
                    allPoints += pointsForSmallApple;
                    LabelScore.Text = ListMessages[0] + Convert.ToString(allPoints);
                    counterEatedApple++;
                    snake.SnakeMoveAndGrow();
                    NewAppleOnForm(smallApple);
                }
            }
            else
            {
                snake.SnakeMove();
            }
        }
        void DisplaySnakeEyes()
        {
            snakeEyes.SetEyes(directSnake.GetDerection(), snake.GetSnake());
            g.FillRectangle(eyesBrash, snakeEyes.GetEyes(0));
            g.FillRectangle(eyesBrash, snakeEyes.GetEyes(1));
        }
        void SnakeSetDirection()
        {
            switch (directSnake.GetDerection())
            {
                case (int)Direction.Up:
                    snake.SnakeUp();
                    break;
                case (int)Direction.Down:
                    snake.SnakeDown();
                    break;
                case (int)Direction.Left:
                    snake.SnakeLeft();
                    break;
                case (int)Direction.Right:
                    snake.SnakeRight();
                    break;
                default:
                    break;
            }
        }
        private void timer_of_big_apple_Tick(object sender, EventArgs e)
        {
            if (TimeForEatBigApple <= 0.0F)
            {
                timer_of_big_apple.Stop();
                SetPointsForBigApple();
                NewAppleOnForm(smallApple);
                TimeForEatBigApple = 20.0F;
            }
            GameOneCadr();
            bigApple.NextViewOfBigApple(ref bigApple);
            DisplayApple();
            pictureBox1.Image = bmp;
            TimeForEatBigApple -= 0.5F;
        }
        void CheckIsSnakeRIP()
        {
            for (int i = 1; i < snake.GetSnake().Length; i++)
            {
                if (snake.GetSnake()[0] == snake.GetSnake()[i] || snake.GetSnake()[0].X >= 520 || snake.GetSnake()[0].X <= 0 || snake.GetSnake()[0].Y >= 520 ||
                    snake.GetSnake()[0].Y <= 0)
                {
                    Game_Over();
                }
            }
        }
        void Game_Over()
        {
            timer_game_cycle.Stop();
            timer_of_big_apple.Stop();
            LabelScore.Text = ListMessages[2];
        }
        private void LabelScore_SizeChanged(object sender, EventArgs e)
        {
            LabelScore.Left = this.Width / 2 - LabelScore.Width / 2;
        }
    }
}
