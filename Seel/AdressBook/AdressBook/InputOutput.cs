using System;
using System.Linq;

namespace AdressBook
{
	enum UserCommands
	{
		ShowAll,
		ShowContact,
		AddNew,
		Edit,
		Clear,
		Help
	}

	class InputOutput
	{
		private string _contactName;
		private string _contactNumber;
		private string _contactComment;
		private DataManipulation  _data;

		public InputOutput(DataManipulation data)
		{
			_contactName = String.Empty;
			_contactNumber = String.Empty;
			_contactComment = String.Empty;
			_data = data;
		}

		public string ContactName
		{
			get
			{
				return _contactName;
			}
			set
			{
				if (value.IndexOf(":") == -1)
				{
					_contactName = value;
				}
			}
		}

		public string ContactNumber
		{
			get
			{
				return _contactNumber;
			}
			set
			{
				if (value.IndexOf(":") == -1 && !value.Any(char.IsLetter))
				{
					_contactNumber = value;
				}
				else
				{
					_contactNumber = "Unspecified number";
				}
			}
		}

		public string ContactComment
		{
			get
			{
				return _contactComment;
			}
			set
			{
				if (value.IndexOf(":") == -1)
				{
					_contactComment = value;
				}
			}
		}

		public void ConsoleAddNewContact()
		{
			Console.WriteLine("Please enter name for a new contact.");
			ContactName = Console.ReadLine();
			Console.WriteLine("Please enter number for a new contact.");
			ContactNumber = Console.ReadLine();
			Console.WriteLine("Please enter comment for a new contact.");
			ContactComment = Console.ReadLine();
			_data.AddNewContact(ContactName, ContactNumber, ContactComment);
		}

		public void ConsoleEdit()
		{
			Console.WriteLine("Please enter number of a contact you want to change.");
			int editableContact = Int32.Parse(Console.ReadLine())-1;
			Console.WriteLine("Please enter what information you want to change: 'name' OR 'number' OR 'comment'");
			string editableField = Console.ReadLine();

			string changeTo;
			switch (editableField)
			{
				case "name":
					changeTo = Console.ReadLine();
					Console.WriteLine("Enter new name");
					_data.Edit(editableContact, 0, changeTo);
					break;
				case "number":
					changeTo = Console.ReadLine();
					Console.WriteLine("Enter new number");
					_data.Edit(editableContact, 1, changeTo);
					break;
				case "comment":
					changeTo = Console.ReadLine();
					Console.WriteLine("Enter new comment");
					_data.Edit(editableContact, 2, changeTo);
					break;
				default:
					Console.WriteLine("Unavailable command. Type 'help' to see list of commands.");
					break;
			}
			Console.WriteLine("Please enter new value");
			ConsoleControl();
		}

		public void ConsoleDisplayAll()
		{
			var listContent = _data.GetFileContent();
			foreach (string[] line in listContent)
			{
				Console.WriteLine($"{listContent.IndexOf(line) + 1}) {line[0]} :\t {line[1]}");
			}
		}

		public void ConsoleDisplaySpecific(int index)
		{
			var contact = _data.GetContact(index);
			Console.WriteLine(contact[0] + " :\t" + contact[1]);
			Console.WriteLine("If you want to return to adress book - type 'back'.\n" +
				"If you want to edit this contact - type 'edit name' or 'edit number' or 'edit comment'");
			string input = null;
			while (input != "edit name" || input != "edit number" || input != "edit comment" || input != "back")
			{
				input = Console.ReadLine();
				switch (input)
				{
					case "edit name":
						{
							string changeTo = Console.ReadLine();
							_data.Edit(index, 0, changeTo);
							break;
						}
					case "edit number":
						{
							string changeTo = Console.ReadLine();
							_data.Edit(index, 1, changeTo);
							break;
						}
					case "edit comment":
						{
							string changeTo = Console.ReadLine();
							_data.Edit(index, 2, changeTo);
							break;
						}
					case "back":
						{
							Console.Clear();
							ConsoleHelp();
							ConsoleDisplayAll();
							break;
						}
				}
				if (input == "edit")
				{
					ConsoleEdit();
				}
				ConsoleControl();
			}
		}

		public void ConsoleControl()
		{
			Console.Clear();
			ConsoleHelp();
			ConsoleDisplayAll();
			string input = String.Empty;
			while (input != "exit")
			{
				input = Console.ReadLine();
				UserCommands enteredEnum;
				Enum.TryParse(input, out enteredEnum);

				if (enteredEnum == UserCommands.ShowAll)
				{
					ConsoleDisplayAll();
				}
				else if (enteredEnum == UserCommands.ShowContact)
				{
					Console.WriteLine("Enter index of contact you want to edit...");
					int index = Int32.Parse(Console.ReadLine())-1;
					ConsoleDisplaySpecific(index);
				}
				else if (enteredEnum == UserCommands.AddNew)
				{
					ConsoleAddNewContact();
				}
				else if (enteredEnum == UserCommands.Edit)
				{
					ConsoleEdit();
				}
				else if (enteredEnum == UserCommands.Clear)
				{
					Console.Clear();
					ConsoleHelp();
				}
				else if (enteredEnum == UserCommands.Help)
				{
					ConsoleHelp();
				}
				else
				{
					Console.WriteLine("Unavailable command. Type '" + UserCommands.Help + "' or " + 
						(int)UserCommands.Help + " to see list of commands...");
				}
			}
		}

		public void ConsoleHelp()
		{
			Console.WriteLine("List of commands: " +
									  "\n'" + UserCommands.ShowAll + "' or " + (int)UserCommands.ShowAll + 
									  " - used to display adress book" +
									  "\n'" + UserCommands.ShowContact + "' or " + (int)UserCommands.ShowContact + 
									  " - used to display specific contact with a comment" +
									  "\n'" + UserCommands.AddNew + "' or " + (int)UserCommands.AddNew + 
									  " - add new contact to adress book" +
									  "\n'" + UserCommands.Edit + "' or " + (int)UserCommands.Edit + 
									  " - edit contact of specified index" +
									  "\n'" + UserCommands.Clear + "' or " + (int)UserCommands.Clear + 
									  " - used to clear console" +
									  "\n'" + UserCommands.Help + "' or " + (int)UserCommands.Help + 
									  " - used to display list of commands.\n");

		}
	}
}