using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmokeCoding.View
{
    class Smoke
    {
        private Vector2 position;
        private Vector2 direction;

        private float rotation;
        private float rotationSpeed;

        private float timeLived;
        private float maxTimeToLive;

        private const float maxSize = 10f;
        private const float minSize = 0f;
        private float size;

        private const float maxSpeed = 0.3f;
        private const float minSpeed = 0.1f;
        private float speedModifier;

        private float fade;

        public float Size
        {
            get { return size; }
        }

        public float Rotation
        {
            get{ return rotation; }
        }

        public float Fade
        {
            get{ return fade; }
        }

        public Vector2 Position
        {
            get{ return position; }
        }

        public void GenerateNewCloudStats(Random rand)
        {
            fade = 1f;
            timeLived = 0f;
            size = 0f;

            position = new Vector2(0.5f, 0.9f);

            rotation = (float)rand.Next(0, 20) / 10f;
            rotationSpeed = (float)rand.NextDouble();

            maxTimeToLive = (float)rand.Next(30, 45) / 10f;

            speedModifier = (float)rand.Next((int)(minSpeed * 10), (int)(maxSpeed * 10)) / 10f;

            direction = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 0.5f);
            direction.Normalize();
            direction = direction * ((float)rand.NextDouble() * maxSpeed);
        }

            public bool UpdateSmoke(float timeEffect)
            {
                timeLived += timeEffect;

                position.X += direction.X * timeEffect * speedModifier;
                position.Y += direction.Y * timeEffect * speedModifier;

                rotation += rotationSpeed * timeEffect;

                float lifePercent = timeLived / maxTimeToLive;

                fade = 1f - lifePercent;

                size = minSize + lifePercent * maxSize;

                direction.Y -= timeEffect;

                if(lifePercent >= 1)
                {
                    return true;
                }
                return false;
            }
        }
    }

