using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pong;
using Microsoft.Xna.Framework;

namespace PongTest
{
    [TestClass]
    public class PaddleAndBallTest
    {
        
        public Paddle CreatePaddle()
        {
            Paddle paddle = new Paddle(30,10,100,50,10);
            return paddle; 
        }

        [TestMethod]
        public void PaddleCreation() {
            Paddle paddle = CreatePaddle();

            Assert.AreEqual(35, paddle.PaddleBox.X);
            Assert.AreEqual(40, paddle.PaddleBox.Y);
        }
        [TestMethod]
        public void MoveLeftTest() {
            Paddle paddle = CreatePaddle();
            paddle.MoveLeft();
            Assert.AreEqual(25, paddle.PaddleBox.X);
            paddle.MoveLeft();
            paddle.MoveLeft();
            paddle.MoveLeft();
            Assert.AreEqual(0,paddle.PaddleBox.X);
        }
        [TestMethod]
        public void MoveRightTest()
        {
            Paddle paddle = CreatePaddle();
            paddle.MoveRight();
            Assert.AreEqual(45, paddle.PaddleBox.X);
            paddle.MoveRight();
            paddle.MoveRight();
            paddle.MoveRight();
            Assert.AreEqual(70, paddle.PaddleBox.X);
        }
        public Ball CreateBall()
        {
            Ball paddle = new Ball(10, 100, 50, 5, 10);
            return paddle;
        }

        [TestMethod]
        public void BallCreation()
        {
            Ball ball = CreateBall();
            

            Assert.AreEqual(45, ball.BallBox.X);
            Assert.AreEqual(10, ball.BallBox.Y);
        }
    }
}
