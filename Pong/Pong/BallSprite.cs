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
    public class BallSprite : DrawableGameComponent
    {
        private Ball ball;

        private SpriteBatch spriteBatch;
        private Texture2D imageBall;
        private PongGame game;
        private PaddleSprite paddle;
        private KeyboardState oldState;
        private int counter;
        private int threshold;
        public void addPaddle(PaddleSprite paddle){
            this.paddle = paddle;
        }
        public BallSprite(PongGame game)
        : base(game)
        {
            this.game = game;
            this.spriteBatch = game.SpriteBatchS;

        }
        public override void Initialize()
        {

            base.Initialize();

        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            imageBall = game.Content.Load<Texture2D>("ball");
            ball = new Ball(imageBall.Width, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, 5, 5);
            ball.PaddleBox = paddle.PaddleBox;
            base.LoadContent();


        }
        public override void Update(GameTime gameTime)
        {
            checkInput();
            ball.Move();
            base.Update(gameTime);

        }
        private void checkInput()
        {
            KeyboardState newState = Keyboard.GetState();
            if (newState.IsKeyDown(Keys.A))
            {
                // If not down last update, key has just been pressed.
                if (!oldState.IsKeyDown(Keys.A))
                {
                    ball.reset();
                    counter = 0; //reset counter with every new keystroke
                }
                else
                {
                    counter++;
                    if (counter > threshold)
                        ball.reset();
                }
            }
            oldState = newState;
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(imageBall, new Vector2(ball.BallBox.X, ball.BallBox.Y),
Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }


    }
}
