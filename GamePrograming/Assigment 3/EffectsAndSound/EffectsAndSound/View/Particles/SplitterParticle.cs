using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EffectsAndSound.View.Particles
{
    class SplitterParticle
    {
        private Vector2 position;
        private Vector2 direction;

        private float MaxSpeed = 0.3f;
        private float LowestSpeed = 0.2f;

        private float MaxLifeSpan = 0.8f;
        private float TimeLived = 0f;

        private float Speed;
        private float size;

        public float Size
        {
            get { return size; }
        }

        public Vector2 Position
        {
            get { return position; }
        }

        public SplitterParticle(Random rand, float ExplosionScale)
        {
            direction = new Vector2((float)rand.NextDouble() - 0.5f, (float)rand.NextDouble() - 0.5f);
            direction.Normalize();
            direction *= ExplosionScale;

            Speed = (float)rand.Next((int)(LowestSpeed * 100), (int)(MaxSpeed * 100)) / 100f;

            size = 1;
            TimeLived = 0;
            position = new Vector2(0, 0);
        }

        public void UpdatePosition(float time)
        {
            position += (direction * time) * Speed;

            TimeLived += time;
            float lifePercentage = TimeLived / MaxLifeSpan;
            size = 1f - lifePercentage;
            if (lifePercentage >= 1)
            {
                size = 0;
            }

        }

    }
}
