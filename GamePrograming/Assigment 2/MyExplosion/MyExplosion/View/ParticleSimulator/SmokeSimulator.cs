using MyExplosion.View.Particles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyExplosion.View.ParticleSimulator
{
    class SmokeSimulator
    {
        private const int amountOfSmoke = 3;

        private float timeElapsed;
        private float lastUpdate;

        private List<Smoke> smoke;
        private Random rand;

        public List<Smoke> getSmoke
        {
            get { return smoke; }
        }

        public SmokeSimulator()
        {
            rand = new Random();
        }

        public void UpdateSmokeClouds(float time)
        {
            timeElapsed += time;

            if (timeElapsed > lastUpdate)
            {
                float timeDiff = timeElapsed - lastUpdate;

                for (int i = 0; i < smoke.Count; i++)
                {
                    smoke[i].UpdateSmoke(timeDiff);
                }

                lastUpdate = timeElapsed;
            }
        }

        public void GenerateSmoke()
        {
            smoke = new List<Smoke>(amountOfSmoke);
            for (int i = 0; i < smoke.Capacity; i++)
            {
                Smoke s = new Smoke();
                s.GenerateNewSmokeStats(rand);
                smoke.Add(s);
            }
        }
    }
}
