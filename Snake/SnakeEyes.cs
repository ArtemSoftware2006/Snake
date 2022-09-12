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
    class SnakeEyes
    {
        const float VALUE_SIDE_BLOCK = 40;
        float sizeEyes;
        float distanseFromSide;
        RectangleF[] eyesSnake = new RectangleF[2];
        PointF deltaFirstEye;
        PointF deltaSecondEye;
        enum Direction
        {
            Up,
            Down,
            Right,
            Left
        }
        public SnakeEyes(float sizeEyes,float distanseFromSide)
        {
            this.distanseFromSide = distanseFromSide;
            this.sizeEyes = sizeEyes;
            eyesSnake[0].Width = sizeEyes;
            eyesSnake[1].Width = sizeEyes;
            eyesSnake[0].Height = sizeEyes;
            eyesSnake[1].Height = sizeEyes;
        }
        public void SetEyes(int direct,  Rectangle[] snakeBody)
        {
            SetDeltaEyes(direct);
            eyesSnake[0].X = snakeBody[0].X + deltaFirstEye.X;
            eyesSnake[0].Y = snakeBody[0].Y + deltaFirstEye.Y;
            eyesSnake[1].X = snakeBody[0].X + deltaSecondEye.X;
            eyesSnake[1].Y = snakeBody[0].Y + deltaSecondEye.Y;
        }
        void SetDeltaEyes(int direct)
        {
            switch (direct)
            {
                case (int)Direction.Up:
                    deltaFirstEye = new PointF(distanseFromSide, distanseFromSide);
                    deltaSecondEye = new PointF(VALUE_SIDE_BLOCK - distanseFromSide - sizeEyes, distanseFromSide);
                    break;
                case (int)Direction.Down:
                    deltaFirstEye = new PointF(distanseFromSide, VALUE_SIDE_BLOCK - distanseFromSide - sizeEyes);
                    deltaSecondEye = new PointF(VALUE_SIDE_BLOCK - distanseFromSide - sizeEyes, VALUE_SIDE_BLOCK
                        - distanseFromSide - sizeEyes);
                    break;
                case (int)Direction.Right:
                    deltaFirstEye = new PointF(VALUE_SIDE_BLOCK - distanseFromSide - sizeEyes, distanseFromSide);
                    deltaSecondEye = new PointF(VALUE_SIDE_BLOCK - distanseFromSide - sizeEyes, VALUE_SIDE_BLOCK
                       - distanseFromSide - sizeEyes);
                    break;
                case (int)Direction.Left:
                    deltaFirstEye = new PointF(distanseFromSide, VALUE_SIDE_BLOCK - distanseFromSide - sizeEyes);
                    deltaSecondEye = new PointF(distanseFromSide, distanseFromSide);
                    break;
                default:
                    break;
            }
        }
        public RectangleF GetEyes(int index)
        {
            return eyesSnake[index];
        }
    }
}
