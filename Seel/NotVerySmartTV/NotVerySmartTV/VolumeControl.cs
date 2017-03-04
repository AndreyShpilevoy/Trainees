using System;

namespace NotVerySmartTV
{
	class VolumeControl
	{
		int mutedLevel = -1;
		int level;

		public VolumeControl()
		{
			level = 10;
		}

		public int MyLevel
		{
			get
			{
				return level;
			}
			set
			{
				if (value >= 0 && value <= 100)
				{
					level = value;
				}
				else
				{
					level = (value < 0) ? 0 : 100;
				}
			}
		}

		public string Set()
		{
			int input;
			while (Int32.TryParse(Console.ReadLine(), out input) != true)
			{
				return "Error. Please use number from 1 to 100 to set volume level.";
			}
			this.MyLevel = input;
			return null;
		}

		public void Mute()
		{

			if (level != 0)
			{
				mutedLevel = this.MyLevel;
				this.MyLevel = 0;
			}
			else
			{
				this.MyLevel = (mutedLevel != -1 ? mutedLevel : 0);
				mutedLevel = (mutedLevel != -1) ? this.MyLevel : -1;
			}
		}

		public int ShowLevel()
		{
			return level;
		}
	}
}
