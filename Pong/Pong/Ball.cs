using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Ball
    {
        private Vector2 velocity;
        private Rectangle screen;
        private Rectangle ball;
        private Paddle paddle; 
        public Paddle PaddleBox {
            get { return this.paddle;}
            set { this.paddle = value; }
            }
        public Ball(int ballSize, int screenWidth, int screenHeight, int speedX, int speedY)
        {
            velocity.X = speedX;
            velocity.Y = speedY;
            screen = new Rectangle(0, 0, screenWidth, screenHeight);
            ball = new Rectangle((screenWidth / 2) - (ballSize / 2), ballSize, ballSize, ballSize);
            
        }

        public Rectangle BallBox
        {
            get { return ball; }
        }
        public void Move()
        {
            if (ball.Intersects(paddle.PaddleBox)) {
                Bounce(2);
            }
            //Top left
            if (ball.Y + velocity.Y < 0 && ball.X + velocity.X < 0)
            {
                ball.X = 0;
                ball.Y = 0;
                Bounce(0);
            }
            
            //Top Right
            else if (ball.Y + velocity.Y < 0 && screen.Width - (ball.X + velocity.X) < 0)
            {
                ball.X = screen.Width - ball.Width;
                ball.Y = 0;
                Bounce(0);
            }
            
            //Left
            else if (ball.X + velocity.X < 0)
            {
                ball.X = 0;
                ball.Y += (int)velocity.Y;
                Bounce(1);
            }
            
            //Right
            else if (screen.Width - (ball.X + velocity.X) < 0)
            {
                ball.X = screen.Width - ball.Width;
                ball.Y += (int)velocity.Y;
                Bounce(1);
            }
            
            //top
            else if (ball.Y + velocity.Y < 0)
            {
                ball.X += (int)velocity.X;
                ball.Y = 0;
                Bounce(2);
            }
            
            //Bottom -- End Game
            else if (ball.Y + velocity.Y > screen.Height) {
                ball.Y = screen.Height - ball.Height;
                velocity.X = 0;
                velocity.Y = 0;
            }
            
            else
            {
                ball.X += (int)velocity.X;
                ball.Y += (int)velocity.Y;
            }
          
        }

        public void Bounce(int dir)
        {
            switch (dir)
            {
                case 0:
                    velocity.X *= -1;
                    velocity.Y *= -1;
                    break;
                case 1:
                    velocity.X *= -1;
                    break;
                case 2:
                    velocity.Y *= -1;
                    break;
            }
        }

        public void reset() {
            velocity.X = 5;
            velocity.Y = 5;
            ball.X = (screen.Width / 2) - (ball.Width / 2);
            ball.Y = 0;
        }
    }
}
