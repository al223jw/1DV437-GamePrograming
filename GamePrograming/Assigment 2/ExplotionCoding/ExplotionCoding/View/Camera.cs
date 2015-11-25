using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExplotionCoding.View
{
    class Camera
    {
        private GraphicsDevice device;

        public Camera(GraphicsDevice device)
        {
            this.device = device;
        }

        public Vector2 getVisualCords(Vector2 logCords, float imageWidth, float imageHeight)
        {
            return new Vector2((this.device.Viewport.Width * logCords.X) - imageWidth / 2,
                                (this.device.Viewport.Height * logCords.Y) - imageHeight / 2);
        }
    }
}
