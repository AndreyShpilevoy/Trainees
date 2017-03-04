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
				input = Console.ReadLine().ToLower();
				switch (input)
				{
					case "set volume":
						Console.WriteLine(Volume.Set());
						Console.WriteLine("Current volume level: " + Volume.ShowLevel() + "\n");
						break;

					case "mute":
						Volume.Mute();
						Console.WriteLine("Current volume level: " + Volume.ShowLevel() + "\n");
						break;

					case "clear":
						Console.Clear();
						break;

					case "set email":
						string errorCodeEmail = Email.Set();
						if (errorCodeEmail == String.Empty)
						{
							Console.WriteLine("Email is set to: " + Email.ShowEmail() + "\n");
						}
						else
						{
							Console.WriteLine(errorCodeEmail);
						}
						break;

					case "show email":
						Console.WriteLine(Email.ShowEmail() + "\n");
						break;

					case "set name":
						string errorCodeName = Name.Set();
						if (errorCodeName == String.Empty)
						{
							Console.WriteLine("Name is set to: " + Name.ShowName() + "\n");
						}
						else
						{
							Console.WriteLine(errorCodeName);
						}
						break;

					case "show name":
						Console.WriteLine(Name.ShowName() + "\n");
						break;

					case "help":
						Console.WriteLine("List of commands: " +
							"\n'set volume' - used to set volume level to desired value from 0 to 100" +
							"\n'set email' - used to define email adress of the user" + 
							"\n'set name' - used to define user name" + 
							"\n'mute' - used to mute and unmute volume" + 
							"\n'show email' - used to show partially hidden email as a reminder" + 
							"\n'clear' - used to clear console\n");
						break;

					default:
						Console.WriteLine("Unavailable command. Type 'help' to see list of commands...");
						break;
				}
			}
		}
	}

}
