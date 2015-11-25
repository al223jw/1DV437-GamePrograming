using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExplotionCoding.View
{
    class ExplotionUpdater
    {
        private int frameX;
        private int frameY;

        private const int numFramesX = 4;

        private const int numberOfFrames = 24;

        private float totalExplotionTime;

        private const float maxTime = 0.5f;


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
            totalExplotionTime += timeElapsed;

            float precentAnimated = totalExplotionTime / maxTime;
            int frame = (int)(precentAnimated * numberOfFrames);

            frameX = frame % numFramesX;
            frameY = frame / numFramesX;
        }

        public void ResetExplotion()
        {
            totalExplotionTime = 0;
        }

    }
}
