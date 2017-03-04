using System;

namespace Console_Smart_TV
{
	class Program
	{
		static void Main()
		{
			var mainMenuNumber = 0;
			var volumeSettingsNumber = 0;
			var volumeSettingsMenuNumber = 0;
			var userDataNumber = 0;
			var userNameNumber = 0;
			var userEmailNumber = 0;

			Volume newVolume = new Volume();

			//main menu
			while (mainMenuNumber != 3)
			{
				Console.WriteLine("\t Main menu\n1.For sound settings menu enter \"1\""
					+ "\n2.For manage user data enter \"2\"\n3.Type \"3\" to exit the program\n");
				Int32.TryParse(Console.ReadLine(), out mainMenuNumber);
				Console.Clear();

				switch (mainMenuNumber)
				{
					case 1:
						{
							//sound settings menu
							while (volumeSettingsMenuNumber != 3)
							{
								Console.WriteLine("\tSound settings menu\n1.For set volume level enter \"1\""
									+ "\n2.For mute sound enter \"2\"\n3.For return to main menu emter \"3\"\n");
								Int32.TryParse(Console.ReadLine(), out volumeSettingsMenuNumber);

								switch (volumeSettingsMenuNumber)
								{
									case 1:
										{
											//set volume

											while (volumeSettingsNumber != 2)
											{

												Console.WriteLine("\nVolume: " + newVolume.volumeLevel +
																"\nEnter volume from 0 to 100");

												if (newVolume.VolumeValidate(newVolume.SetVolume(), newVolume.volumeLevel))
												{
													Console.Clear();
													Console.WriteLine("\nVolume: " + newVolume.volumeLevel +
														"\n\n1.For set new volume level enter \"1\"" +
														"\n2.For return to sound settings enter \"2\"");
													Int32.TryParse(Console.ReadLine(), out volumeSettingsNumber);
												}
												else
												{
													newVolume.volumeLevel = 0;
													Console.WriteLine("Error.Incorrect volume. Please try again");
												}
											}
											Console.Clear();
											volumeSettingsNumber = 0;
											break;
										}

									case 2:
										{
											Console.Clear();
											newVolume.Swap(ref newVolume.volumeLevel, ref newVolume.muteSound);
											if (newVolume.volumeLevel == 0)
											{
												Console.WriteLine("sound mute");
											}
											else
											{
												Console.WriteLine("Sound: " + newVolume.volumeLevel);
											}
											break;
										}
								}
							}
							Console.Clear();
							volumeSettingsMenuNumber = 0;
							break;
						}

					//User personal data
					case 2:
						{
							//user data menu
							User newUser = new User();
							while (userDataNumber != 5)
							{
								Console.WriteLine("\tUser data settings");
								Console.WriteLine("1.For enter you name enter \"1\"\n2.For enter your email enter \"2\"" +
									"\n3.For show user name enter \"3\"\n4.For show user email enter \"4\""
									+ "\n5.For return to main menu enter \"5\"\n");
								Int32.TryParse(Console.ReadLine(), out userDataNumber);

								switch (userDataNumber)
								{
									case 1:
										{
											while (userNameNumber != 2)
											{
												Console.WriteLine("\nEnter your first name and surname");
												newUser.userNameInput = Console.ReadLine();

												if (newUser.UserNameValidate())
												{
													Console.Clear();
													newUser.UserName = newUser.userNameInput;
													newUser.ShowUserNameMask();
													Console.WriteLine("\n1.For set new user name enter \"1\""
														+ "\n2.For return to user data settings enter \"2\"");
													Int32.TryParse(Console.ReadLine(), out userNameNumber);
												}

												else
												{
													Console.Clear();
													Console.WriteLine("Please enter correct user name and surname");
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
												Console.WriteLine("\nEnter your email");
												newUser.userEmailInput = Console.ReadLine();

												if (newUser.UserEmailValidate())
												{
													newUser.UserEmail = newUser.userEmailInput;
													newUser.ShowUserEmailMask();
													Console.WriteLine("\n1.For set new user email enter \"1\""
																	  + "\n2.For return to user data settings enter \"2\"");
													Int32.TryParse(Console.ReadLine(), out userEmailNumber);
												}
												else
												{
													Console.WriteLine("\nError.Please enter correct email");
												}
											}
											Console.Clear();
											userEmailNumber = 0;
											break;
										}

									case 3:
										{
											Console.Clear();
											if (string.IsNullOrWhiteSpace(newUser.userNameInput))
											{
												Console.WriteLine("User name: Unknown. Please enter user name");
											}

											else
											{
												newUser.ShowUserNameMask();
												Console.WriteLine();
											}
											break;
										}

									case 4:
										{
											Console.Clear();
											if (string.IsNullOrWhiteSpace(newUser.userEmailInput))
											{
												Console.WriteLine("User email: Unknown. Please enter user email");
											}

											else
											{
												newUser.ShowUserEmailMask();
												Console.WriteLine();
											}
											break;
										}
								}
							}
							Console.Clear();
							userDataNumber = 0;
						}
						mainMenuNumber = 0;
						break;
				}
			}
		}
	}
}

