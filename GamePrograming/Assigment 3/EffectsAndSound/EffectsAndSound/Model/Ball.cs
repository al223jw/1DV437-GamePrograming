using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EffectsAndSound.Model
{
    class Ball
    {
        private Vector2 ballLogicCords;
        private float ballLogicSpeedX;
        private float ballLogicSpeedY;
        private const float ballLogicDiameter = 0.05f;

        private float fade;
        private bool isDead;
        Random rand;


        public Ball(Random rnd)
        {
            isDead = false;
            fade = 1f;
            this.rand = rnd;
            this.ballLogicCords = GenerateRandomLogicCords();
            ballLogicSpeedX = GenerateRandomSpeed();
            ballLogicSpeedY = GenerateRandomSpeed();

            if (rnd.Next(0, 2) == 0)
            {
                ballLogicSpeedX = -ballLogicSpeedX;
            }
            if (rnd.Next(0, 2) == 0)
            {
                ballLogicSpeedY = -ballLogicSpeedY;
            }
        }
        public Vector2 BallLogicCords
        {
            get { return ballLogicCords; }
        }

        public float BallLogicDiameter
        {
            get { return ballLogicDiameter; }
        }
        public float Fade
        {
            get { return fade; }
        }

        public void UpdateLocation(float time)
        {
            ballLogicCords.X += time * ballLogicSpeedX;
            ballLogicCords.Y += time * ballLogicSpeedY;
        } 

        public void CollisionHorizontalWall()
        {
            if (!isDead)
            {
                float NewSpeed = GenerateRandomSpeed();

                if (ballLogicCords.Y <= 0)
                {
                    ballLogicCords.Y = 0;
                    ballLogicSpeedY = NewSpeed;
                }
                else
                {
                    ballLogicCords.Y = 1 - ballLogicDiameter;
                    ballLogicSpeedY = -NewSpeed;
                }
            }
        }

        public void CollisionVerticalWall()
        {
            if (!isDead)
            {
                float NewSpeed = GenerateRandomSpeed();

                if (ballLogicCords.X <= 0)
                {
                    ballLogicCords.X = 0;
                    ballLogicSpeedX = NewSpeed;
                }
                else
                {
                    ballLogicCords.X = 1 - ballLogicDiameter;
                    ballLogicSpeedX = -NewSpeed;
                }
            }
        }

        private Vector2 GenerateRandomLogicCords()
        {
            int x = rand.Next(10, 90);
            int y = rand.Next(10, 90);
            float xCord = (float)x / 100f;
            float yCord = (float)y / 100f;
            return new Vector2(xCord, yCord);
        }

        private float GenerateRandomSpeed()
        {
            int speed = rand.Next(15, 105);
            return (float)speed / 100f;
        }

        internal void Dead()
        {
            isDead = true;
            ballLogicSpeedX = 0;
            ballLogicSpeedY = 0;
            fade = 0.5f;
        }
    }
}
