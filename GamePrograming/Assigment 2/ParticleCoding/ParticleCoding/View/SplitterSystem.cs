using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleCoding.View
{
    class SplitterSystem
    {
        private double currentTime;
        private double lastUpdate;

        private List<SplitterParticle> particles;

        private const float gravitation = 1f;

        private const int ammontOfParticles = 100;

        public float Gravitation
        { 
            get
            {
                return gravitation;
            }
        }

        public void generateParticles()
        {
            Random rand = new Random();
            particles = new List<SplitterParticle>(100);

            for (int i = 0; i < ammontOfParticles; i++)
            {
                particles.Add(new SplitterParticle(rand));
            }
        }

        public List<SplitterParticle> Particles
        { 
            get
            {
                return particles;
            }
        }

        public void UpdateparticleLocation(double timePassed)
        {
            currentTime = timePassed;

            if (currentTime > lastUpdate && particles != null)
            {
                double timeDiff = currentTime - lastUpdate;
                double gravityEffect = gravitation * (timeDiff / 1000f);

                foreach (SplitterParticle p in particles)
                {
                    p.UpdatePosition((float)gravityEffect);
                }
            }

            lastUpdate = currentTime;
        }


    }
}
