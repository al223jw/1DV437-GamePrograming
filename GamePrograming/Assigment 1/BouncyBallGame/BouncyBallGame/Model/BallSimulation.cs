using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BouncyBallGame.Model
{
    class BallSimulation
    {
        //The logical cords for the walls, these cords represent the STARTING point for being drawn (aka the top left corner)
        private Vector2 northWall = new Vector2(0, 0);
        private Vector2 eastWall = new Vector2(1, 0);
        private Vector2 southWall = new Vector2(0, 1);
        private Vector2 westWall = new Vector2(0, 0);

        private Ball ball;

        //values respresenting the time stamps
        double CurrentTime;
        double LastTimeMoved;

        private const int wallThickness = 5;
        private const int dissort = 10;

        private float logicalWallThicknessX;
        private float logicalWallThicknessY;
        private float logicalDissortX;
        private float logicalDissortY;

        private float highestPossibleLogicYCord;
        private float lowestPossibleLogicYCord;
        private float highestPossibleLogicXCord;
        private float lowestPossibleLogicXCord;

        public int WallThickness
        {
            get { return wallThickness; }
        }
        public int Dissort
        {
            get { return dissort; }
        }

        public Ball getBall()
        {
            return this.ball;
        }

        public Vector2 NorthWall
        {
            get { return northWall; }
        }
        public Vector2 EastWall
        {
            get { return eastWall; }
        }
        public Vector2 SouthWall
        {
            get { return southWall; }
        }
        public Vector2 WestWall
        {
            get { return westWall; }
        }

        public bool CanTakeCommand
        {
            get;
            set;
        }

        //initiates a new instance of the Ball class and calls the UpdateGameResolution to set base values.
        public BallSimulation(GraphicsDevice device)
        {
            ball = new Ball();
            UpdateGameResolution(device);
        }

        public void UpdateGameResolution(GraphicsDevice device)
        {
            logicalWallThicknessX = (float)wallThickness / (float)(device.Viewport.Width - dissort * 2);
            logicalWallThicknessY = (float)wallThickness / (float)(device.Viewport.Height - dissort * 2);
            logicalDissortX = (float)dissort / (float)(device.Viewport.Width - dissort * 2);
            logicalDissortY = (float)dissort / (float)(device.Viewport.Height - dissort * 2);

            highestPossibleLogicXCord = 1f - ball.BallLogicDiameter / 2 + logicalWallThicknessX;
            lowestPossibleLogicXCord = 0f + ball.BallLogicDiameter / 2 + logicalDissortX + logicalWallThicknessX;
            highestPossibleLogicYCord = 1f - ball.BallLogicDiameter / 2 + logicalWallThicknessY;
            lowestPossibleLogicYCord = 0f + ball.BallLogicDiameter / 2 + logicalDissortY + logicalWallThicknessY;
        }

        //Updates the game:
        //- Updates ball position
        //- Checks for collisions
        public void Update(double timeSpan)
        {
            CurrentTime = timeSpan;
            if (CurrentTime > LastTimeMoved)
            {
                float diff = (float)(CurrentTime - LastTimeMoved);
                this.ball.UpdateLocation(diff);
                CheckCollision();
                LastTimeMoved = CurrentTime;
            }
        }

        //checks if the ball has collided with any wall, if so then it's direction is changed.
        private void CheckCollision()
        {
            if (ball.BallLogicCords.X >= highestPossibleLogicXCord)
            {
                ball.CollisionVerticalWall(highestPossibleLogicXCord);
            }

            else if (ball.BallLogicCords.X <= lowestPossibleLogicXCord)
            {
                ball.CollisionVerticalWall(lowestPossibleLogicXCord);
            }

            if (ball.BallLogicCords.Y >= highestPossibleLogicYCord)
            {
                ball.CollisionHorizontalWall(highestPossibleLogicYCord);
            }

            else if (ball.BallLogicCords.Y <= lowestPossibleLogicYCord)
            {
                ball.CollisionHorizontalWall(lowestPossibleLogicYCord);
            }
        }

        //Makes user abel to execute a command again
        public void ResetTimeForCommand()
        {
            CanTakeCommand = true;
        }

        //initiates a cooldown for taking commands form the user
        public void SetCoolDownForCommand()
        {
            CanTakeCommand = false;

            //Resets the boolean after 500 milliseconds.
            System.Threading.Timer timer = null;
            timer = new System.Threading.Timer((obj) =>
            {
                ResetTimeForCommand();
                timer.Dispose();
            }, null, 500, System.Threading.Timeout.Infinite);
        }
    }
}
