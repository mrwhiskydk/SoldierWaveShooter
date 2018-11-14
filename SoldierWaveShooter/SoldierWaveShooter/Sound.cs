using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoldierWaveShooter
{
    public class Sound
    {
        SoundEffect sound;

        public Sound(string sound)
        {
            this.sound = Gameworld.ContentManager.Load<SoundEffect>(sound);
        }

        public void Play()
        {
            sound.Play();
        }
    }
}
