using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyExplosion.View.Particles
{
    class Smoke
    {
        private Vector2 position;
        private Vector2 direction;

        private float rotation;
        private float rotationSpeed;

        private float timeLived;
        private const float maxTimeToLive = 1f;

        private const float maxSize = 11f;
        private const float minSize = 0f;
        private float size;

        private float fade;

        public float Size
        {
            get { return size; }
        }
        public float Rotation
        {
            get { return rotation; }
        }
        public float Fade
        {
            get { return fade; }
        }
        public Vector2 Position
        {
            get { return position; }
        }

        public void GenerateNewSmokeStats(Random rand)
        {
            fade = 1f;
            timeLived = 0f;
            size = 0f;

            position = new Vector2(0f, 0f);

            rotation = (float)rand.Next(0, 20) / 10f;
            rotationSpeed = (float)rand.NextDouble();
        }

        public void UpdateSmoke(float timeEffect)
        {
            timeLived += timeEffect;

            rotation += rotationSpeed * timeEffect;

            float lifePercent = timeLived / maxTimeToLive;

            fade = 1f - lifePercent;

            size = minSize + lifePercent * maxSize;

            if (lifePercent >= 1)
            {
                size = 0;
            }
        }
    }
}
