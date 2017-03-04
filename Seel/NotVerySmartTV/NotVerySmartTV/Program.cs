using System;

namespace NotVerySmartTV
{

	class Program
	{
		static void Main()
		{
			VolumeControl Volume = new VolumeControl();
			EmailStored Email = new EmailStored();
			NameStored Name = new NameStored();
			string input = null;
			while (input != "exit")
			{
				input = Console.ReadLine();
				UserCommands enteredEnum;
				Enum.TryParse(input, out enteredEnum);
				if (enteredEnum == UserCommands.SetVolume)
				{
					Console.WriteLine(Volume.SetLevel());
					Console.WriteLine("Current volume level: " + Volume.Level + "\n");
				}
				else if (enteredEnum == UserCommands.Mute)
				{
					Volume.Mute();
					Console.WriteLine("Current volume level: " + Volume.Level + "\n");
				}
				else if (enteredEnum == UserCommands.Clear)
				{
					Console.Clear();
				}
				else if (enteredEnum == UserCommands.SetEmail)
				{
					string errorCodeEmail = Email.SetEmail(Console.ReadLine());
					if (errorCodeEmail == String.Empty)
					{
						Console.WriteLine("Email is set to: " + Email.MaskedEmail + "\n");
					}
					else
					{
						Console.WriteLine(errorCodeEmail);
					}
				}
				else if (enteredEnum == UserCommands.ShowEmail)
				{
					Console.WriteLine(Email.MaskedEmail + "\n");
				}
				else if (enteredEnum == UserCommands.SetName)
				{
					string errorCodeName = Name.Set();
					if (errorCodeName == String.Empty)
					{
						Console.WriteLine("Name is set to: " + Name.ShowName() + "\n");
					}
					else
					{
						Console.WriteLine(errorCodeName);
					}
				}
				else if (enteredEnum == UserCommands.ShowName)
				{
					Console.WriteLine(Name.ShowName() + "\n");
				}
				else if (enteredEnum == UserCommands.Help)
				{
					Console.WriteLine("List of commands: " +
									  "\n'" + UserCommands.SetVolume + "' or " + (int)UserCommands.SetVolume + " - used to set volume level to desired value from 0 to 100" +
									  "\n'" + UserCommands.SetEmail + "' or " + (int)UserCommands.SetEmail + " - used to define email adress of the user" +
									  "\n'" + UserCommands.SetName + "' or " + (int)UserCommands.SetName + " - used to define user name" +
									  "\n'" + UserCommands.Mute + "' or " + (int)UserCommands.Mute + " - used to mute and unmute volume" +
									  "\n'" + UserCommands.ShowEmail + "' or " + (int)UserCommands.ShowEmail + " - used to show partially hidden email as a reminder" +
									  "\n'" + UserCommands.ShowName + "' or " + (int)UserCommands.ShowName + " - used to show partially hidden name as a reminder" +
									  "\n'" + UserCommands.Clear + "' or " + (int)UserCommands.Clear + " - used to clear console\n");
				}
				else
				{
					Console.WriteLine("Unavailable command. Type '" + UserCommands.Help + "' or " + (int)UserCommands.Help + " to see list of commands...");
				}
			}
		}
	}

	enum UserCommands
	{
		Help,
		SetVolume,
		SetEmail,
		SetName,
		Mute,
		ShowEmail,
		ShowName,
		Clear
	}

}
