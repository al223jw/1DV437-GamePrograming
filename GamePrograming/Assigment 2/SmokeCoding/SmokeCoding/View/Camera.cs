using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmokeCoding.View
{
    class Camera
    {
        GraphicsDevice device;
        public Camera(GraphicsDevice device)
        {
            this.device = device;
        }

        public Vector2 getSmokeVisualPosition(Vector2 logPos, Texture2D smokeTexture)
        {
            return new Vector2((logPos.X * device.Viewport.Width) - smokeTexture.Bounds.Width / 2,
                               (logPos.Y * device.Viewport.Height) - smokeTexture.Bounds.Height / 2);
        }
    }
}
