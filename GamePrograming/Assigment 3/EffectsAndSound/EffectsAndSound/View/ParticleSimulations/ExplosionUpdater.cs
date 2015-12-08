using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EffectsAndSound.View.ParticleSimulations
{
    class ExplosionUpdater
    {
        private int frameX;
        private int frameY;
        private const int numFramesX = 4;
        private const int numberOfFrames = 24;
        private const float maxTime = 0.6f;
        private const int StartSplitter = 4;
        private const int StartSmoke = 10;

        private float totalTime;



        private SplitterSystem splitterSystem;
        private SmokeSimulator smokeSimulator;

        private bool hasParticlesSpawned;
        private bool hasSmokeSpawned;

        public ExplosionUpdater(SplitterSystem splitterSystem, SmokeSimulator smokeSimulator)
        {
            this.splitterSystem = splitterSystem;
            this.smokeSimulator = smokeSimulator;
            ResetExplosion();
        }


        public int FrameX
        {
            get { return frameX; }
        }
        public int FrameY
        {
            get { return frameY; }
        }

        public void UpdateFrame(float timeElapsed)
        {
            totalTime += timeElapsed;

            float percentAnimated = totalTime / maxTime;
            int frame = (int)(percentAnimated * numberOfFrames);

            frameX = frame % numFramesX;
            frameY = frame / numFramesX;

            if (!hasParticlesSpawned && frame >= StartSplitter)
            {
                hasParticlesSpawned = true;
                this.splitterSystem.generateParticles();
            }
            if (!hasSmokeSpawned && frame >= StartSmoke)
            {
                hasSmokeSpawned = true;
                this.smokeSimulator.GenerateSmoke();
            }
        }

        public void ResetExplosion()
        {
            hasSmokeSpawned = false;
            hasParticlesSpawned = false;
            totalTime = 0;
        }
    }
}
