using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleCoding.View
{
    class SplitterParticle
    {
        private Vector2 position;
        private Vector2 direction;
        private const float maxSpeed = 0.5f;

        public Vector2 Position
        {
            get 
            {
                return position;
            }
        }

        public SplitterParticle(Random rand)
        {
            direction = new Vector2((float)rand.NextDouble() * maxSpeed);
            direction.Normalize();
            direction = direction * ((float)rand.NextDouble() * maxSpeed);

            position = new Vector2(0, 0);
        }

        public void UpdatePosition(float gravityEffect)
        {
            position = position + direction * gravityEffect;

            direction.Y += gravityEffect;
        }
    }
}
