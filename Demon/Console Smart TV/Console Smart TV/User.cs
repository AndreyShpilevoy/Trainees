using System;

namespace Console_Smart_TV
{
	class User
	{
		private string userName;
		private string userEmail;
		public string userNameInput;
		public string userEmailInput;
		private int temp;
		public int indexName;
		public int indexEmail;

		public User()
		{
			userName = "Unknown";
			userEmail = "Unknown";
			userNameInput = string.Empty;
			userEmailInput = string.Empty;
		}

		public string SaveUserName
		{
			private get
			{
				return userName;
			}
			set
			{
				userName = value;
			}
		}

		public string SaveUserEmail
		{
			private get
			{
				return userEmail;
			}
			set
			{
				userEmail = value;
			}
		}

		public void ShowUserNameMask()
		{
			int index;
			index = SaveUserName.IndexOf(" ");
			Console.Write("\nUser name: ");
			for (int i = 0; i <= index + 1; i++)
			{
				Console.Write(SaveUserName[i]);
			}
			Console.Write(".");

		}

		public void ShowUserEmailMask()
		{
			int index;
			index = userEmail.IndexOf("@");
			Console.Write("\nUser email: ");
			for (int i = 0; i <= 2; i++)
			{
				Console.Write(userEmail[i]);
			}

			for (int i = 3; i < index; i++)
			{
				Console.Write("*");
			}
			Console.Write("@");

			for (int i = index + 1; i < userEmail.Length - 3; i++)
			{
				Console.Write("*");
			}
			for (int i = userEmail.Length - 3; i < userEmail.Length; i++)
			{
				Console.Write(userEmail[i]);
			}
		}

		public bool UserNameValidate()
		{
			var userNameValid =!(Int32.TryParse(userNameInput, out temp) && userNameInput.IndexOf(" ") <= 0
				&& userNameInput.LastIndexOf(" ") == userNameInput.Length);
			return !userNameValid;
		}

		public bool UserEmailValidate()
		{
			var userEmailValid = !((userEmailInput.IndexOf("@") <= 0 || userEmailInput.IndexOf("@") == userEmailInput.Length-1)
				|| (userEmailInput.IndexOf(".") <= 0 || userEmailInput.LastIndexOf(".") == userEmailInput.Length-1));
			return !userEmailValid;
		}

		public int UserEmailInput()
		{
			SaveUserEmail = userEmailInput;
			indexEmail = SaveUserEmail.IndexOf("@");
			return indexEmail;
		}

		public int UserNameInput()
		{
			SaveUserName = userNameInput;
			indexName = SaveUserName.LastIndexOf(" ");
			return indexName;
		}

		public bool UserNameCompare()
		{
			if (userNameInput == string.Empty)
			{
				return true;
			}
			return false;
		}

		public bool UserEmailCOmpare()
		{
			if (userEmailInput == string.Empty)
			{
				return true;
			}
			return false;
		}
	}
}