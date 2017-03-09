using System;

namespace Phone_Book
{
	class Program
	{
		static void Main()
		{
			ReadWrite newFile = new ReadWrite();
			string command = string.Empty;
			newFile.OpenFile();

			Console.WriteLine("Welcome to Phone Book v0.1\nFor show list of commands enter \"Help\"\n");

			while (command != "exit")
			{
				command = Console.ReadLine().ToLower();

				switch (command)
				{
					case "add":
						{
							Console.WriteLine("Enter the contact name");
							newFile.AddNewName();

							while (newFile.numberNext==0)
							{
								Console.WriteLine("Enter the contact number without +");
								if (newFile.NumberValid())
								{
									newFile.AddNewNumber();
									newFile.SaveNewContact();
									newFile.numberNext = 1;
								}
								else
								{
									Console.WriteLine("Phone number can contain only numbers");
								}
							}
							newFile.numberNext = 0;
							
							while (newFile.numberNext == 0)
							{
								Console.WriteLine("Enter the contact description");
								if (newFile.DescriptionValid())
								{
									newFile.AddNewDescription();
									newFile.SaveNewContact();
									newFile.numberNext = 1;
								}

								else
								{
									Console.WriteLine("Description can not contain more than 10 symbols");
								}

							}
							newFile.numberNext = 0;
							Console.Clear();
							break;
						}

					case "edit":
						{
							Console.WriteLine("Enter the name of the contact to edit");
							newFile.SearchName();
							newFile.SplitSearch();
							Console.WriteLine("\nEnter \"name\" if you want to edit contact name."+
											  "\nEnter \"number\" if you want to edit contact number."+
											  "\nEnter \"description\" if you want to edit contact description.");
							string selection = Console.ReadLine();
							switch (selection)
							{
								case "name":
									{
										Console.WriteLine("Enter new contact name");
										newFile.EditName();
										newFile.DeleteContact();
										newFile.SaveEditontact();
										break;
									}

								case "number":
									{
										while (newFile.numberNext == 0)
										{
											Console.WriteLine("Enter new contact number");
											if (newFile.NumberValid())
											{
												newFile.EditNumber();
												newFile.DeleteContact();
												newFile.SaveEditontact();
												newFile.numberNext = 1;
											}

											else
											{
												Console.WriteLine("Please enter correct phone number");
											}
										}
										newFile.numberNext = 0;
										break;
									}

								case "description":
									{
										while (newFile.numberNext == 0)
										{
											Console.WriteLine("Enter new contact description");
											if (newFile.DescriptionValid())
											{
												newFile.EditDescription();
												newFile.DeleteContact();
												newFile.SaveEditontact();
												newFile.numberNext = 1;
											}

											else
											{
												Console.WriteLine("Description can not contain more than 10 symbols");
											}

										}
										newFile.numberNext = 0;
										break;
									}
							}
							Console.Clear();
							break;
						}

					case "delete":
						{
							Console.WriteLine("Enter the name of the contact to delete");
							newFile.SearchName();
							newFile.DeleteContact();
							Console.Clear();
							break;
						}

					case "showall":
						{
							newFile.ShowAll();
							for (var i = 0; i < newFile.showAll.Count; i++)
							{
								Console.WriteLine(newFile.showAll[i]);
							}

							break;
						}

					case "showcontact":
						{
							Console.WriteLine("Enter the name of the contact to show");
							newFile.SearchName();
							Console.WriteLine(newFile._fileContent[newFile.searchNumber-1]);
							break;
						}

					case "help":
						{
							Console.WriteLine("\nList of commands: " +
				  "\nAdd - used to add new contact" +
				  "\nEdit - used to edit contact" +
				  "\nDelete - used to delete contact" +
				  "\nShowAll - used to show all contacts(names only)" +
				  "\nShowContact - used to show full information about contact" +
				  "\nExit - used to exit programm\n");
							break;
						}
				}
			}
		}
	}
}