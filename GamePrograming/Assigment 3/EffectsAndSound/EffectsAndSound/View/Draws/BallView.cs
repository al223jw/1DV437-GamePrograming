using EffectsAndSound.Model;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EffectsAndSound.View.Draws
{
    class BallView
    {
        private Vector2 northWall = new Vector2(0, 0);
        private Vector2 eastWall = new Vector2(1, 0);
        private Vector2 southWall = new Vector2(0, 1);
        private Vector2 westWall = new Vector2(0, 0);

        private SpriteBatch spriteBatch;
        private Camera camera;
        private BallSimulation ballSimulation;
        Texture2D BallTexture;
        Texture2D HorizontalWall;
        Texture2D VerticalWall;

        public BallView(SpriteBatch spriteBatch, Camera camera, ContentManager content, BallSimulation ballSimulation)
        {
            this.spriteBatch = spriteBatch;
            this.camera = camera;
            this.ballSimulation = ballSimulation;

            LoadGraphics(content);
        }


        public void DrawBalls()
        {
            spriteBatch.Begin();

            spriteBatch.Draw(VerticalWall, camera.GetWallVisualCord(westWall), null, Color.White, 0, new Vector2(0, 0), camera.GetVerticalWallScale(VerticalWall), SpriteEffects.None, 0f);

            spriteBatch.Draw(VerticalWall, camera.GetWallVisualCord(eastWall), null, Color.White, 0, new Vector2(0, 0), camera.GetVerticalWallScale(VerticalWall), SpriteEffects.None, 0f);

            spriteBatch.Draw(HorizontalWall, camera.GetWallVisualCord(northWall), null, Color.White, 0, new Vector2(0, 0), camera.GetHorizontalWallScale(HorizontalWall), SpriteEffects.None, 0f);

            spriteBatch.Draw(HorizontalWall, camera.GetWallVisualCord(southWall), null, Color.White, 0, new Vector2(0, 0), camera.GetHorizontalWallScale(HorizontalWall), SpriteEffects.None, 0f);

            List<Ball> balls = ballSimulation.getBalls();
            foreach (Ball b in balls)
            {
                spriteBatch.Draw(BallTexture,
                                 camera.GetBallVisualCord(BallTexture, b),
                                 null,
                                 new Color(b.Fade, b.Fade, b.Fade, b.Fade),
                                 0,
                                 new Vector2(0, 0),
                                 camera.GetBallScale(BallTexture, b),
                                 SpriteEffects.None,
                                 0f);
            }


            spriteBatch.End();
        }

        private void LoadGraphics(ContentManager content)
        {
            BallTexture = content.Load<Texture2D>("Ball.png");
            HorizontalWall = content.Load<Texture2D>("WallHorizontal.png");
            VerticalWall = content.Load<Texture2D>("WallVertical.png");
        }
    }
}
