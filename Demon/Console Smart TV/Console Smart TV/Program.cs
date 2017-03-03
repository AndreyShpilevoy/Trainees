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

	}

	class User
	{
		private string UserName;
		private string UserEmail;

		public User()
		{
			UserName = "Unknown";
			UserEmail = "Unknown";
		}

		public string SaveUserName
		{
			set
			{
				UserName=value;
			}
		}

		public string SaveUserEmail
		{
			set
			{
				UserEmail=value;
			}
		}

		public void ShowUserNameMask()
		{
			int index;
			index = UserName.IndexOf(" ");
			Console.Write("\nUser name: ");
			for (int i = 0; i <= index + 1; i++)
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
	}
	class Program
	{

		static void Main()
		{
			var mainMenuNumber = 0;
			var volumeSettingsNumber = 0;
			var userDataNumber = 0;
			var userNameNumber = 0;
			var userEmailNumber = 0;

			Volume volumeSettings = new Volume();

			//main menu
			while (mainMenuNumber != 3)
			{
				Console.WriteLine("\t Main menu\n1.For sound settings menu enter \"1\"\n2.For manage user data enter \"2\"\n3.Type \"3\" to exit the program\n");
				var mainMenuNumberValid = Int32.TryParse(Console.ReadLine(), out mainMenuNumber);

				switch (mainMenuNumber)
				{
					case 1:
						{
							//sound settings menu
							while (volumeSettings.soundSettingsNumber != 3)
							{
								Console.WriteLine("\n\tSound settings menu\n1.For set volume level enter \"1\"\n2.For mute sound enter \"2\"\n3.For return to main menu emter \"3\"\n");
								var soundSettingsValid = Int32.TryParse(Console.ReadLine(), out volumeSettings.soundSettingsNumber);

								switch (volumeSettings.soundSettingsNumber)
								{
									case 1:
										{
											//set volume
											while (volumeSettingsNumber != 2)
											{
												Console.WriteLine("\nVolume: " + volumeSettings.volumeLevel + "\nEnter volume from 0 to 100");
												var volumeValid = Int32.TryParse(Console.ReadLine(), out volumeSettings.volumeLevel);

												while (volumeSettingsNumber != 2)
												{
													if (VolumeValidate(volumeValid, volumeSettings.volumeLevel))
													{
														Console.WriteLine("\nVolume: " + volumeSettings.volumeLevel + "\n\n1.For set new volume level enter \"1\"\n2.For return to sound settings enter \"2\"");
														var volumeSettingsValid = Int32.TryParse(Console.ReadLine(), out volumeSettingsNumber);
													}
													else
													{
														Console.WriteLine("Error.Incorrect volume. Please try again");
													}
												}
											}
											volumeSettingsNumber = 0;
											break;
										}

									case 2:
										{
											Swap(ref volumeSettings.volumeLevel, ref volumeSettings.muteSound);
											if (volumeSettings.volumeLevel == 0)
											{
												Console.WriteLine("sound mute");
											}
											else
											{
												Console.WriteLine("Sound: " + volumeSettings.volumeLevel);
											}
											break;
										}
								}
							}
							Console.Clear();
							volumeSettings.soundSettingsNumber = 0;
							break;
						}

					//User personal data
					case 2:
						{
							//user data menu
							User newUser = new User();
							while (userDataNumber != 5)
							{
								Console.WriteLine("\n\n\tUser data settings");
								//newUser.ShowUserNameMask();
								//newUser.ShowUserEmail();
								Console.WriteLine("1.For edit you name enter \"1\"\n2.For edit your email enter \"2\"" +
									"\n3.For show user name enter \"3\"\n4.For show user email enter \"4\"\n5.For return to main menu enter \"5\"\n");
								var userDataValid = Int32.TryParse(Console.ReadLine(), out userDataNumber);

								switch (userDataNumber)
								{
									case 1:
										{
											while (userNameNumber != 2)
											{
												int temp;
												string userNameInput;
												Console.WriteLine("\nEnter your first name and surname");
												userNameInput = Console.ReadLine();
												var userNameValid = Int32.TryParse(userNameInput, out temp);

												if (userNameValid)
												{
													Console.WriteLine("Name can not contain numbers. Please try again");
												}

												else
												{
													while (userNameNumber != 2)
													{
														newUser.SaveUserName = userNameInput;
														int index;
														index = userNameInput.IndexOf(" ");
														if (index >= 0)
														{
															newUser.ShowUserNameMask();
															Console.WriteLine("\n1.For set new user name enter \"1\"\n2.For return to user data settings enter \"2\"");
															var nameChangeValid = Int32.TryParse(Console.ReadLine(), out userNameNumber);
														}

														else
														{
															Console.WriteLine("\nError.Please enter your surname");
														}
													}
												}
											}
											Console.Clear();
											userNameNumber = 0;
											break;
										}

									case 2:
										{
											while (userEmailNumber != 2)
											{
												string userEmailInput;
												Console.WriteLine("\nEnter your email");
												userEmailInput = Console.ReadLine();

												while (userEmailNumber != 2)
												{
													newUser.SaveUserEmail = userEmailInput;
													int index;
													index = userEmailInput.IndexOf("@");
													if (index >= 0 && userEmailInput.Length > 1)
													{
														newUser.ShowUserEmailMask();
														Console.WriteLine("\n1.For set new user email enter \"1\"\n2.For return to user data settings enter \"2\"");
														var nameChangeValid = Int32.TryParse(Console.ReadLine(), out userEmailNumber);
													}

													else
													{
														Console.WriteLine("\nError.Please enter correct email");
													}
												}

											}
											Console.Clear();
											userEmailNumber = 0;
											break;
										}

									case 3:
										{
											newUser.ShowUserNameMask();
											break;
										}

									case 4:
										{
											newUser.ShowUserEmailMask();
											break;
										}
								}
							}
							userDataNumber = 0;
						}
						mainMenuNumber = 0;
						break;
				}
			}
		}

		//Volume level validate
		private static bool VolumeValidate(bool volumeValid, int volumeLevel)
		{
			return volumeValid && volumeLevel >= 0 && volumeLevel <= 100;
		}

		private static void Swap(ref int volume, ref int mute)
		{
			volume = volume + mute;
			mute = volume - mute;
			volume = volume - mute;
		}

	}
}


