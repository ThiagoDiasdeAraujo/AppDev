using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMediaPlayer
{
	public class MediaPlayer
	{
        public string CurrentMedia { get; set; }
		public int Volume { get; set; }
		public int IncreaseVolume { get; set; }
		public int DecreaseVolume { get; set; }

		public MediaPlayer(string currentMedia, int volume, int increaseVolume, int decreaseVolume)
		{
			CurrentMedia = currentMedia;
			Volume = volume;
			IncreaseVolume = increaseVolume;
			DecreaseVolume = decreaseVolume;
		}

		public virtual void Play()
		{
        }
		public virtual void Pause()
		{

		}
		public virtual void Stop()
		{
		}
	}

	
	
}
