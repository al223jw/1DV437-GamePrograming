using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleCoding.View
{
    class Camera
    {
        private GraphicsDevice device;

        public Camera(GraphicsDevice device)
        {
            this.device = device;
        }

        public Vector2 getExposionOrgin()
        {
            return new Vector2(this.device.Viewport.Width / 2, this.device.Viewport.Height / 2);
        }

        public Vector2 getVisualCords(Vector2 logicPos)
        {
            float x = logicPos.X * device.Viewport.Width;
            float y = logicPos.X * device.Viewport.Height;

            return new Vector2(x, y);
        }

        public Vector2 getParticleVisualCord(Vector2 particlePos)
        {
            return getExposionOrgin() + getVisualCords(particlePos);
        }
    }
}
