using EffectsAndSound.View.ParticleSimulations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;

namespace EffectsAndSound.Controller
{
    class GameController
    {
        private bool CoolDown;
        List<Explosion> explosions;
        SoundEffect fireSoundEffect;

        private Vector2 explosionLocation;

        private float ExplosionScale;

        public List<Explosion> Explosions
        {
            get { return explosions; }
        }

        public Vector2 ExplosionLocation
        {
            get { return explosionLocation; }
        }
        public GameController(float ExplosionScale, ContentManager content)
        {
            CoolDown = true;
            this.ExplosionScale = ExplosionScale;
            explosions = new List<Explosion>(20);

            this.fireSoundEffect = content.Load<SoundEffect>("fire");
        }
        public bool ReadMouse()
        {
            if (CoolDown && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                CoolDown = false;
                explosionLocation = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
                explosions.Add(new Explosion(ExplosionScale, explosionLocation));
                fireSoundEffect.Play();
                CoolDownTimer();
                return true;
            }
            return false;
        }

        public void CoolDownTimer()
        {
            System.Threading.Timer timer = null;
            timer = new System.Threading.Timer((obj) =>
            {
                ResetCoolDown();
                timer.Dispose();
            }, null, 250, Timeout.Infinite);
        }

        public void ResetCoolDown()
        {
            CoolDown = true;
        }

        public void RemoveExplosion(Explosion explosion)
        {
            explosions.Remove(explosion);
        }
    }
}
