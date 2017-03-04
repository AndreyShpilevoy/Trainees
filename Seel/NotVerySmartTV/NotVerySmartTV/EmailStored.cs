using System;

namespace NotVerySmartTV
{
	class EmailStored
	{
		string email;
		public string emailHidden;

		public EmailStored()
		{
			email = String.Empty;
			emailHidden = String.Empty;
		}

		public string Set()
		{
			string result = String.Empty;
			emailHidden = String.Empty;
			email = Console.ReadLine();
			while (email.IndexOf("@") == -1 || email.IndexOf(".") == -1 || email.IndexOf("@") != email.LastIndexOf("@") 
				|| email.IndexOf("@")+1 >= email.LastIndexOf(".") || email.IndexOf(".") == email.Length 
				|| email.IndexOf(" ")!=-1)
			{
				result = "\nError. Email adress must comply to format: \n<account_name>@<hosting_name>.<domain_name>\n";
				return result;
			}
			string[] emailSplit = email.Split('@');
			emailHidden = emailHidden + email[0] + email[1];
			while (emailHidden.Length < emailSplit[0].Length)
			{
				emailHidden = emailHidden + "*";
			}
			emailHidden = emailHidden + "@";
			while (emailHidden.Length < email.Length - 2)
			{
				emailHidden = emailHidden + "*";
			}
			emailHidden = emailHidden + email[email.Length - 2] + email[email.Length - 1];
			return result;
		}

		public string ShowEmail()
		{
			if (String.IsNullOrWhiteSpace(emailHidden))
			{
				return "\nPlease set email first.\n"; 
			}
			else
			{
				return emailHidden;
			}
			
		}
	}
}