using System;

namespace NotVerySmartTV
{
	class NameStored
	{
		string username;
		public string shortUsername;

		public NameStored()
		{
			username = String.Empty;
			shortUsername = String.Empty;
		}

		public string Set()
		{ 
			string result = String.Empty;
			shortUsername = String.Empty;
			username = Console.ReadLine();
			while (username.IndexOf(" ") == -1)
			{
				result = "\nError. Please enter name following by surname and sepparated by 'space'\n";
				return result;
			}
			string[] usernameSplit = username.Split(' ');
			shortUsername = usernameSplit[0] + " " + usernameSplit[1][0] + ".";
			return result;
		}

		public string ShowName()
		{
			if (String.IsNullOrWhiteSpace(shortUsername))
			{
				return "\nPlease set name first.\n";
			}
			else
			{
				return shortUsername;
			}

		}
	}
}
