using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedoAlienPrisonShootout
{
    public class Sound
    {
        SoundEffect sound;

        public Sound(string sound)
        {
            this.sound = Gameworld.ContentManager.Load<SoundEffect>(sound);
        }

        /// <summary>
        /// Play the sound file
        /// </summary>
        public void Play()
        {
            sound.Play();
        }
    }
}
