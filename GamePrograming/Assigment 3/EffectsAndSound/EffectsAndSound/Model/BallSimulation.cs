using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EffectsAndSound.Model
{
    class BallSimulation
    {
        private List<Ball> balls;

        public List<Ball> getBalls()
        {
            return this.balls;
        }

        public BallSimulation()
        {
            Random rnd = new Random();
            balls = new List<Ball>(10);
            for (int i = 0; i < 10; i++)
            {
                balls.Add(new Ball(rnd));
            }

        }

        public void Update(float timeElapsed)
        {
            foreach (Ball b in balls)
            {
                b.UpdateLocation(timeElapsed);
                CheckCollision(b);
            }
        }

        private void CheckCollision(Ball ball)
        {
            if (ball.BallLogicCords.X + ball.BallLogicDiameter >= 1 || ball.BallLogicCords.X <= 0)
            {
                ball.CollisionVerticalWall();
            }

            if (ball.BallLogicCords.Y + ball.BallLogicDiameter >= 1 || ball.BallLogicCords.Y <= 0)
            {
                ball.CollisionHorizontalWall();
            }
        }

        public void CheckIfHit(Vector2 explosionLocation, float aimRadius)
        {

            foreach (Ball b in balls)
            {
                if (b.BallLogicCords.X + b.BallLogicDiameter / 2 <= explosionLocation.X + aimRadius &&
                    b.BallLogicCords.X + b.BallLogicDiameter / 2 >= explosionLocation.X - aimRadius &&
                    b.BallLogicCords.Y + b.BallLogicDiameter / 2 <= explosionLocation.Y + aimRadius &&
                    b.BallLogicCords.Y + b.BallLogicDiameter / 2 >= explosionLocation.Y - aimRadius)
                {
                    b.Dead();
                }
            }
        }
    }
}
