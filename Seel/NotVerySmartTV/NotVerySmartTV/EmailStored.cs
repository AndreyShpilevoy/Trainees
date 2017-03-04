using System;
using System.Text;

namespace NotVerySmartTV
{
	class EmailStored
	{
		private string _email;
		private string _maskedEmail;

		public EmailStored()
		{
			_email = String.Empty;
			_maskedEmail = String.Empty;
		}

		public string MaskedEmail
		{
			get {
				return String.IsNullOrWhiteSpace(_maskedEmail) ? "\nPlease set email first.\n" : _maskedEmail;
			}
		}

		public string SetEmail(string incomingEmail)
		{
			string result = String.Empty;
			if (ValidateEmail(incomingEmail))
			{
				_email = incomingEmail;
				string[] emailSplit = _email.Split('@');
				var maskedEmailBuilder = new StringBuilder($"{_email[0]}{_email[1]}");

				while (maskedEmailBuilder.Length < emailSplit[0].Length)
				{
					maskedEmailBuilder.Append("*");
				}

				maskedEmailBuilder.Append("@");

				while (maskedEmailBuilder.Length < _email.Length - 2)
				{
					maskedEmailBuilder.Append("*");
				}
				_maskedEmail = maskedEmailBuilder.ToString() + _email[_email.Length - 2] + _email[_email.Length - 1];
			}
			else
			{
				result = "\nError. Email adress must comply to format: \n<account_name>@<hosting_name>.<domain_name>\n";
			}
			return result;
		}

		private bool ValidateEmail(string incomingEmail)
		{
			return incomingEmail.IndexOf("@") != -1 && incomingEmail.IndexOf(".") != -1 &&
				   incomingEmail.IndexOf("@") == incomingEmail.LastIndexOf("@") &&
				   incomingEmail.IndexOf("@") + 1 < incomingEmail.LastIndexOf(".") &&
				   incomingEmail.IndexOf(".") != incomingEmail.Length - 1 && incomingEmail.IndexOf(" ") == -1;
		}
	}
}