using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Paddle
    {
        private int _speed;
        private int screenWidth;
        public Rectangle paddle;
        public Paddle(int paddleWidth, int paddleHeight, int screenWidth, int screenHeight, int speed)
        {
            _speed = speed;
            this.screenWidth = screenWidth;
            paddle = new Rectangle((screenWidth/2) - (paddleWidth /2),screenHeight - paddleHeight,paddleWidth,paddleHeight);
        }

        public Rectangle PaddleBox{
            get { return paddle; }

        }

        public void MoveLeft() {
            paddle.X = MathHelper.Clamp(PaddleBox.X - _speed, 0, screenWidth);
        }
        public void MoveRight() {
            paddle.X = MathHelper.Clamp(paddle.X + _speed, 0, screenWidth - paddle.Width);
        }
    }
}
