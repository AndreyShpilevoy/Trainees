using System;

namespace NotVerySmartTV
{
	class VolumeControl
	{
		int _mutedLevel;
		int _level;

		public VolumeControl()
		{
			_mutedLevel = -1;
			_level = 10;
		}

		public int Level
		{
			get
			{
				return _level;
			}
			set
			{
				if (value >= 0 && value <= 100)
				{
					_level = value;
				}
				else
				{
					_level = value < 0 ? 0 : 100;
				}
			}
		}

		public string SetLevel()
		{
			int input;
			while (Int32.TryParse(Console.ReadLine(), out input) != true)
			{
				return "Error. Please use number from 1 to 100 to set volume level.";
			}
			Level = input;
			return null;
		}

		public void Mute()
		{
			if (_level == 0)
			{
				Level = _mutedLevel == -1 ? 0 : _mutedLevel;
				if (_mutedLevel != -1)
				{
					_mutedLevel = Level;
				}
			}
			else
			{
				_mutedLevel = Level;
				Level = 0;
			}
		}
	}
}
