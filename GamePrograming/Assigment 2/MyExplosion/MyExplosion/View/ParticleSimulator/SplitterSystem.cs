using MyExplosion.View.Particles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyExplosion.View.ParticleSimulator
{
    class SplitterSystem
    {
        private float timeElapsedTime;
        private float lastUpdate;
        private float ExplosionScale;

        private List<SplitterParticle> particles;

        private const float gravitation = 1f;

        private const int amountOfParticles = 100;

        public float Gravitation
        {
            get { return gravitation; }
        }

        public SplitterSystem(float ExplosionScale)
        {
            this.ExplosionScale = ExplosionScale;
        }

        public void generateParticles()
        {
            Random rand = new Random();
            particles = new List<SplitterParticle>(100);

            for (int i = 0; i < amountOfParticles; i++)
            {
                particles.Add(new SplitterParticle(rand, ExplosionScale));
            }

        }

        public List<SplitterParticle> Particles
        {
            get { return particles; }
        }

        public void UpdateParticleLocation(float timePassed)
        {
            timeElapsedTime += timePassed;

            if (timeElapsedTime > lastUpdate)
            {
                float timeDiff = timeElapsedTime - lastUpdate;

                foreach (SplitterParticle p in particles)
                {
                    p.UpdatePosition(timeDiff);
                }

                lastUpdate = timeElapsedTime;
            }
        }
    }
}
