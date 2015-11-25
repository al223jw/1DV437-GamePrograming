using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExplotionCoding.View
{
    class ExplotionView
    {
        private const int numFramesX = 4;

        private const int numFramesY = 8;

        private Camera camera;
        private ExplotionUpdater explotionUpdater;

        private GraphicsDevice device;
        private ContentManager content;

        private Texture2D explotionTexture;

        private SpriteBatch spriteBatch;

        public ExplotionView(GraphicsDevice device,  ContentManager content, ExplotionUpdater explotionUpdater)
        {
            this.explotionUpdater = explotionUpdater;
            this.device = device;
            this.content = content;
            camera = new Camera(device);
            spriteBatch = new SpriteBatch(device);

            explotionTexture = content.Load<Texture2D>("explosion.png");
        }

        public void Draw()
        {
            spriteBatch.Begin();

            int spriteXChord = (explotionTexture.Bounds.Width / numFramesX) * explotionUpdater.FrameX;
            int spriteYChord = (explotionTexture.Bounds.Height / numFramesY) * explotionUpdater.FrameY;

            spriteBatch.Draw(explotionTexture,
                             camera.getVisualCords(new Vector2(0.5f, 0.5f), explotionTexture.Bounds.Width / numFramesX, explotionTexture.Bounds.Height / numFramesY),
                             new Rectangle(spriteXChord,
                                           spriteYChord,
                                           explotionTexture.Bounds.Width / numFramesX,
                                           explotionTexture.Bounds.Height / numFramesY),
                             Color.White,
                             0,
                             Vector2.Zero,
                             1,
                             SpriteEffects.None,
                             0);

            spriteBatch.End();
        }
    }
}
