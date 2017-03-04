using System;

namespace Console_Smart_TV
{
	class User
	{
		public string userNameInput;
		public string userEmailInput;
		private int temp;
		public int indexName;
		public int indexEmail;

		public User()
		{
			UserName = "Unknown";
			UserEmail = "Unknown";
			userNameInput = string.Empty;
			userEmailInput = string.Empty;
		}

		public string UserName { private get; set; }

		public string UserEmail { private get; set; }

		public void ShowUserNameMask()
		{
			var index = UserName.IndexOf(" ");
			Console.Write("\nUser name: ");
			for (var i = 0; i <= index + 1; i++)
			{
				Console.Write(UserName[i]);
			}
			Console.Write(".");

		}

		public void ShowUserEmailMask()
		{
			int index;
			index = UserEmail.IndexOf("@");
			Console.Write("\nUser email: ");
			for (int i = 0; i <= 2; i++)
			{
				Console.Write(UserEmail[i]);
			}

			for (int i = 3; i < index; i++)
			{
				Console.Write("*");
			}
			Console.Write("@");

			for (int i = index + 1; i < UserEmail.Length - 3; i++)
			{
				Console.Write("*");
			}
			for (int i = UserEmail.Length - 3; i < UserEmail.Length; i++)
			{
				Console.Write(UserEmail[i]);
			}
		}

		public bool UserNameValidate()
		{
			var userNameValid = !Int32.TryParse(userNameInput, out temp) &&
								userNameInput.IndexOf(" ") > 0 &&
								userNameInput.LastIndexOf(" ") != userNameInput.Length-1;
			return userNameValid;
		}

		public bool UserEmailValidate()
		{
			var userEmailValid = userEmailInput.IndexOf("@") > 0 &&
								 userEmailInput.IndexOf("@") != userEmailInput.Length - 1 &&
								 userEmailInput.IndexOf(".") > 0 &&
								 userEmailInput.LastIndexOf(".") != userEmailInput.Length - 1;
			return userEmailValid;
		}
	}
}