using System;

namespace Console_Smart_TV
{
	class Volume
	{
		public int volumeLevel;
		public int muteSound;
		public int soundSettingsNumber;
		public int muteSoundValue;

		public Volume()
		{
			volumeLevel = 0;
			muteSound = 0;
			soundSettingsNumber = 0;
			muteSoundValue = 0;
		}

		public bool VolumeValidate(bool volumeValid, int volumeLevel)
		{
			return volumeValid && (volumeLevel >= 0 && volumeLevel <= 100);
		}

		public bool SetVolume()
		{
			return Int32.TryParse(Console.ReadLine(), out volumeLevel);
		}

		public void Swap(ref int volume, ref int mute)
		{
			volume = volume + mute;
			mute = volume - mute;
			volume = volume - mute;
		}
	}
}

