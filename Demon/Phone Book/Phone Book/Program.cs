using System;

namespace Phone_Book
{
	class Program
	{
		static void Main()
		{
			ReadWrite readWrite = new ReadWrite();
			string command = string.Empty;
			readWrite.OpenFile();

			Console.WriteLine("Welcome to Phone Book v0.1\nFor show list of commands enter \"Help\"\n");

			while (command != "exit")
			{
				command = Console.ReadLine().ToLower();

				switch (command)
				{
					case "add":
						{
							Console.WriteLine("Enter the contact name");
							var newContactName =Console.ReadLine();
							var newContactNumber = String.Empty;
							var newContactDescription = String.Empty;
							var enteredDataIsValid = false;
							while (!enteredDataIsValid)
							{
								Console.WriteLine("Enter the contact number without +");
								var contactNumber = Console.ReadLine();
								if (readWrite.NumberValidator(contactNumber))
								{
									newContactNumber = contactNumber;
									enteredDataIsValid = true;
								}
								else
								{
									Console.WriteLine("Phone number can contain only numbers");
								}
							}

							enteredDataIsValid = false;
							while (!enteredDataIsValid)
							{
								Console.WriteLine("Enter the contact description");
								var contactDescription = Console.ReadLine();
								if (readWrite.DescriptionValidator(contactDescription))
								{
									newContactDescription = contactDescription;
									enteredDataIsValid = true;
								}

								else
								{
									Console.WriteLine("Description can not contain more than 10 symbols");
								}

							}
							var newContact = new Contact(newContactName, newContactNumber, newContactDescription);
							readWrite.AddNewContact(newContact);
							Console.Clear();
							break;
						}

					case "edit":
						{
							Console.WriteLine("Enter the name of the contact to edit");
							var indexForEdit = readWrite.SearchIndexByName(Console.ReadLine());
							if (indexForEdit == -1)
							{
								Console.WriteLine("Wrong name");
								break;
							}
							var editedModel = readWrite.GetContactByIndex(indexForEdit);

							Console.WriteLine("\nEnter \"name\" if you want to edit contact name."+
											  "\nEnter \"number\" if you want to edit contact number."+
											  "\nEnter \"description\" if you want to edit contact description.");
							string selection = Console.ReadLine();
							switch (selection)
							{
								case "name":
									{
										Console.WriteLine("Enter new contact name");
										editedModel.Name = Console.ReadLine();
										break;
									}

								case "number":
									{
										var enteredDataIsValid = false;
										while (!enteredDataIsValid)
										{
											Console.WriteLine("Enter new contact number");
											var contactNumber = Console.ReadLine();
											if (readWrite.NumberValidator(contactNumber))
											{
												editedModel.Number = Int64.Parse(contactNumber);
												enteredDataIsValid = true;
											}

											else
											{
												Console.WriteLine("Please enter correct phone number");
											}
										}
										break;
									}

								case "description":
									{
										var enteredDataIsValid = false;
										while (!enteredDataIsValid)
										{
											Console.WriteLine("Enter new contact description");
											var contactDescription = Console.ReadLine();
											if (readWrite.DescriptionValidator(contactDescription))
											{
												editedModel.Description = contactDescription;
												enteredDataIsValid = true;
											}

											else
											{
												Console.WriteLine("Description can not contain more than 10 symbols");
											}

										}
										break;
									}
							}
							Console.Clear();
							break;
						}

					case "delete":
						{
							Console.WriteLine("Enter the name of the contact to delete");
							var indexForDelete = readWrite.SearchIndexByName(Console.ReadLine());
							if (indexForDelete == -1)
							{
								Console.WriteLine("Wrong name");
								break;
							}
							readWrite.DeleteContact(indexForDelete);
							Console.Clear();
							break;
						}

					case "showall":
						{
							var allContacts = readWrite.GetAllContacts();
							foreach (var contact in allContacts)
							{
								Console.WriteLine($"{contact.Name}\t+{contact.Number}");
							}
							break;
						}

					case "showcontact":
						{
							Console.WriteLine("Enter the name of the contact to show");
							var contact = readWrite.SearchContactByName(Console.ReadLine());
							Console.WriteLine($"{contact.Name}\t+{contact.Number}\t{contact.Description}");
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