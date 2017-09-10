using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Pong
{
    public class PaddleSprite : DrawableGameComponent
    {
        private Paddle paddle;
        public Paddle PaddleBox
        {
            get { return paddle; }
            private set { this.paddle = value; }
        }
        private SpriteBatch spriteBatch;
        private Texture2D imagePaddle;
        private PongGame game;

        private KeyboardState oldState;
        private int counter;
        private int threshold;

        public PaddleSprite(PongGame game)
        : base(game)
        {
            this.game = game;
            this.spriteBatch = game.SpriteBatchS;

        }
        public override void Initialize()
        {
            oldState = Keyboard.GetState();
            threshold = 2;
            base.Initialize();

        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            imagePaddle = game.Content.Load<Texture2D>("paddle");  
            PaddleBox = new Paddle(imagePaddle.Width, imagePaddle.Height, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, 5);
            base.LoadContent();


        }

        public override void Update(GameTime gameTime)
        {
            checkInput();
            base.Update(gameTime);

        }
        private void checkInput()
        {
            KeyboardState newState = Keyboard.GetState();
            if (newState.IsKeyDown(Keys.Right))
            {
                // If not down last update, key has just been pressed.
                if (!oldState.IsKeyDown(Keys.Right))
                {
                    paddle.MoveRight();
                    counter = 0; //reset counter with every new keystroke
                }
                else
                {
                    counter++;
                    if (counter > threshold)
                        paddle.MoveRight();
                }
            }
            else if (newState.IsKeyDown(Keys.Left))
            {
                // If not down last update, key has just been pressed.
                if (!oldState.IsKeyDown(Keys.Left))
                {
                    paddle.MoveLeft();
                    counter = 0; //reset counter with every new keystroke
                }
                else
                {
                    counter++;
                    if (counter > threshold)
                        paddle.MoveLeft();
                }
            }
            oldState = newState;
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(imagePaddle, new Vector2(paddle.PaddleBox.X, paddle.PaddleBox.Y),
Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
