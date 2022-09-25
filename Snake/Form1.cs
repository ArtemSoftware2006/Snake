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
            "Вы поставили новый рекорд ",
        };
        RecordstManager records = RecordstManager.GetInstance();
        MyProgressBar progressbar = new MyProgressBar(1, 18, Color.Red, new Point(85, 18));
        Snake snake = new Snake();
        GameSpace pole;
        Graphics g;
        Bitmap bmp;
        Pen pen = new Pen(Color.Black, 4.0F);
        SolidBrush brash = new SolidBrush(Color.Red);
        SolidBrush eyesBrash = new SolidBrush(Color.Blue);
        SnakeEyes snakeEyes = new SnakeEyes(8,5);
        DirectionSnake directSnake = new DirectionSnake();
        Apple smlApple = new Apple(20);
        Apple bgApple = new Apple(35);
        RectangleF currentApple;
        PointF locationApple;
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
        enum Levels
        {
            Easy,
            Normal,
            Hard
        }
        enum LevelsTiming
        {
            Easy = 1000,
            Normal = 666,
            Hard = 450
        }
        public Fm_game_place()
        {
            InitializeComponent();
            pole = new GameSpace(pictureBox1.Width, pictureBox1.Height);
            StartingTimers();
            Beginning_game();
        }
        void SetCurrentApple(ref Apple apple)
        {
            currentApple = apple.apple;
            locationApple = apple.Location;
        }
        private void Beginning_game()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            Initializingpole();
            snake.InitializingSnake();
            g.FillRectangles(brash, snake.GetSnake());
            NewAppleOnForm(ref smlApple);
            DisplaySnakeEyes();
            pictureBox1.Image = bmp;
            currentApple = smlApple.apple;
        }
        void StartingTimers()
        {
            countDown = 3;
            timer_starting_game.Interval = 1000;
            timer_starting_game.Start();
        }
        void CheckLocationApple(ref Apple apple)
        {
            for (int i = 0; i < snake.GetSnake().Length; i++)
            {
                if (apple.apple.X == snake.GetSnake()[i].X && (apple.apple.Y == snake.GetSnake()[i].Y))
                {
                    NewAppleOnForm(ref apple);
                    break;
                }
            }
        }
        void NewAppleOnForm(ref Apple apple)
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
                FixedTimingGameCycle();
                timer_game_cycle.Start();
            }
            countDown--;
        }
       void FixedTimingGameCycle()
        {
            switch (records.Level)
            {
                case (int)Levels.Easy:
                    timer_game_cycle.Interval = (int)LevelsTiming.Easy;
                    break;
                case (int)Levels.Normal:
                    timer_game_cycle.Interval = (int)LevelsTiming.Normal;
                    break;
                case (int)Levels.Hard:
                    timer_game_cycle.Interval = (int)LevelsTiming.Hard;
                    break;
                default:
                    throw new Exception("Ошибка системы, выбранного сложности уровня нет");
            }
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
            SnakeSetDirection();
            CheckIsSnakeEatApple();
            GameOneCadr();

            IsAddBigApple();

            g.FillEllipse(brash, currentApple);

            pictureBox1.Image = bmp;
            CheckIsSnakeRIP();
        }
        
        void GameOneCadr()
        {
            g.Clear(Color.White);
            Initializingpole();
            g.FillRectangles(brash, snake.GetSnake());
            DisplaySnakeEyes();
        }
        void IsAddBigApple()
        {
            if (counterEatedApple % 2 == 0)
            {
                NewAppleOnForm(ref bgApple);
                AddBigappleFlag = true;

                timer_of_big_apple.Interval = 500;
                timer_of_big_apple.Start();

                counterEatedApple++;
                SetCurrentApple(ref bgApple);

                LabelScore.Visible = false;

                progressbar.WidghStep = 20;
                progressbar.Maximum = 20;
                progressbar.Value = 0;
                progressbar.Direction = -1;
                progressbar.Step = 1;
                progressbar.ShowProgressBar();
                this.Controls.Add(progressbar.GetProgressBar());

                timer_progressbar.Interval = 1000;
                timer_progressbar.Start();
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
                    NewAppleOnForm(ref smlApple);
                    snake.SnakeMoveAndGrow();
                    AddBigappleFlag = false;
                    ShowLabelScore();
                    timer_progressbar.Stop();
                    TimeForEatBigApple = 20.0F;
                }
                else
                {
                    allPoints += pointsForSmallApple;
                    LabelScore.Text = ListMessages[0] + Convert.ToString(allPoints);
                    counterEatedApple++;
                    snake.SnakeMoveAndGrow();
                    NewAppleOnForm(ref smlApple);
                }
                SetCurrentApple(ref smlApple);
            }
            else
            {
                snake.SnakeMove();
            }
        }
        void DisplaySnakeEyes()
        {
            snakeEyes.SetEyes(directSnake.GetDerection(), snake.GetSnake());
            g.FillEllipse(eyesBrash, snakeEyes.GetEyes(0));
            g.FillEllipse(eyesBrash, snakeEyes.GetEyes(1));
        }
        void SnakeSetDirection()
        {
            switch (directSnake.GetDerection())
            {
                case (int)Direction.Up:
                    snake.SnakeUp();
                    directSnake.SetBanDirect();
                    break;
                case (int)Direction.Down:
                    snake.SnakeDown();
                    directSnake.SetBanDirect();
                    break;
                case (int)Direction.Left:
                    snake.SnakeLeft();
                    directSnake.SetBanDirect();
                    break;
                case (int)Direction.Right:
                    snake.SnakeRight();
                    directSnake.SetBanDirect();
                    break;
                default:
                    break;
            }
        }
        void FlashingApple(ref RectangleF apple, ref Apple firstApple, ref Apple secondApple)
        {
            if (apple.Width == firstApple.apple.Width && apple.Height == firstApple.apple.Height)
            {
                currentApple.X = locationApple.X + secondApple.UpperleftCorner.X;
                currentApple.Y = locationApple.Y + secondApple.UpperleftCorner.Y;
                currentApple.Height = secondApple.apple.Height;
                currentApple.Width = secondApple.apple.Width;
            }
            else
            {
                currentApple.Height = firstApple.apple.Height;
                currentApple.Width = firstApple.apple.Width;
                currentApple.X = locationApple.X + firstApple.UpperleftCorner.X;
                currentApple.Y = locationApple.Y + firstApple.UpperleftCorner.Y;
            }
        }
        private void timer_of_big_apple_Tick(object sender, EventArgs e)
        {
            if (TimeForEatBigApple <= 0.0F)
            {
                timer_of_big_apple.Stop();
                SetPointsForBigApple();
                NewAppleOnForm(ref smlApple);
                TimeForEatBigApple = 20.0F;
                ShowLabelScore();
                timer_progressbar.Stop();
            }
            GameOneCadr();
            FlashingApple(ref currentApple,ref smlApple, ref bgApple);
            g.FillEllipse(brash, currentApple);
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
                    break;
                }
            }
        }
        void Game_Over()
        {
            ShowLabelScore();
            records.SetRecord(allPoints);
            if (records.GetRecords()[records.GetRecords().Count - 1] <= allPoints)
            {
                LabelScore.Text = ListMessages[3] + Convert.ToString(allPoints);
            }
            else
            {
                LabelScore.Text = ListMessages[2] + ListMessages[0] + Convert.ToString(allPoints);
            }
            records.UpdatingRecords();
            timer_game_cycle.Stop();
            timer_of_big_apple.Stop();
            timer_progressbar.Stop();
        }
        void ShowLabelScore()
        {
            progressbar.HideProgressBar();
            progressbar.StopAndUpdatingProdBar();
            LabelScore.Visible = true;
        }
        private void LabelScore_SizeChanged(object sender, EventArgs e)
        {
            LabelScore.Left = this.Width / 2 - LabelScore.Width / 2;
        }

        private void Fm_game_place_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressbar.PerformStep();
        }
    }
}
