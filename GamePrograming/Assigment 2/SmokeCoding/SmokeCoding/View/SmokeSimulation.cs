using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmokeCoding.View
{
    class SmokeSimulation
    {
        private const int amontOfSmoke = 60;

        private float currentTime;
        private float lastUpdate;

        private List<Smoke> smoke;
        private Random random;

        public List<Smoke> getSmoke
        {
            get 
            {
                return smoke;
            }
        }

        public SmokeSimulation()
        {
            smoke = new List<Smoke>(amontOfSmoke);
            random = new Random();

            for(int i = 0; i < smoke.Capacity; i++)
            {
                Smoke s = new Smoke();
                s.GenerateNewCloudStats(random);
                smoke.Add(s);
            }
        }

        public void GenerateSmoke(float time)
        {
            currentTime = time;

            if(currentTime > lastUpdate)
            {
                float timeDiff = currentTime - lastUpdate;

                for(int i = 0; i < smoke.Count; i++)
                {
                    if(smoke[i].UpdateSmoke(timeDiff))
                    {
                        smoke[i].GenerateNewCloudStats(random);
                    }
                }

                lastUpdate = currentTime;
            }
        }
    }
}
