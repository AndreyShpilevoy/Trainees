using System;
using System.Text;
using System.Linq;
using AdressBook;

namespace AdressBook
{
	class InputOutput
	{
		string contactName;
		string contactNumber;
		string contactComment;
		enum UserCommands
		{
			ShowAll,
			ShowContact,
			AddNew,
			Edit,
			Clear,
			Help
		}

		public InputOutput()
		{
			contactName = String.Empty;
			contactNumber = String.Empty;
			contactComment = String.Empty;
		}

		public string ContactName
		{
			get
			{
				return contactName;
			}
			set
			{
				if (value.IndexOf(":") == -1)
				{
					contactName = value;
				}
			}

		}

		public string ContactNumber
		{
			get
			{
				return contactNumber;
			}
			set
			{
				if (value.IndexOf(":") == -1 && !value.Any(char.IsLetter))
				{
					contactNumber = value;
				}
				else
				{
					contactNumber = "Unspecified number";
				}
			}
		}

		public string ContactComment
		{
			get
			{
				return contactComment;
			}
			set
			{
				if (value.IndexOf(":") == -1)
				{
					contactComment = value;
				}
			}
		}

		public void consoleAddNewContact(DataManipulation data)
		{
			Console.WriteLine("Please enter name for a new contact.");
			ContactName = Console.ReadLine();
			Console.WriteLine("Please enter number for a new contact.");
			ContactNumber = Console.ReadLine();
			Console.WriteLine("Please enter comment for a new contact.");
			ContactComment = Console.ReadLine();
			data.AddNewContact(ContactName, ContactNumber, ContactComment);
		}

		public void consoleEdit(DataManipulation data)
		{
			Console.WriteLine("Please enter number of a contact you want to change.");
			int editableContact = Int32.Parse(Console.ReadLine())-1;
			Console.WriteLine("Please enter what information you want to change: 'name' OR 'number' OR 'comment'");
			string editableField = Console.ReadLine();

			switch (editableField)
			{
				case "name":
					Console.WriteLine("Enter new name");
					data.Edit(editableContact, 0, editableField);
					break;
				case "number":
					Console.WriteLine("Enter new number");
					data.Edit(editableContact, 1, editableField);
					break;
				case "comment":
					Console.WriteLine("Enter new comment");
					data.Edit(editableContact, 2, editableField);
					break;
				default:
					Console.WriteLine("Unavailable command. Type 'help' to see list of commands.");
					break;
			}
			Console.WriteLine("Please enter new value");
			string changeTo = Console.ReadLine();
			consoleControl(data);
		}

		public void consoleDisplayAll(DataManipulation data)
		{
			var listContent = data.GetFileContent();
			foreach (string[] line in listContent)
			{
				Console.WriteLine(String.Format("{0}) {1} :\t {2}", listContent.IndexOf(line) + 1, line[0], line[1]));
			}
		}

		public void consoleDisplaySpecific(DataManipulation data, int index)
		{
			var contact = data.GetContact(index);
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
							data.Edit(0, index, changeTo);
							break;
						}
					case "edit number":
						{
							string changeTo = Console.ReadLine();
							data.Edit(1, index, changeTo);
							break;
						}
					case "edit comment":
						{
							string changeTo = Console.ReadLine();
							data.Edit(2, index, changeTo);
							break;
						}
					case "back":
						{
							Console.Clear();
							consoleHelp();
							consoleDisplayAll(data);
							break;
						}
				}
				if (input == "edit")
				{
					consoleEdit(data);
				}
				consoleControl(data);
			}
		}

		public void consoleControl(DataManipulation data)
		{
			Console.Clear();
			consoleHelp();
			consoleDisplayAll(data);
			string input = String.Empty;
			while (input != "exit")
			{
				input = Console.ReadLine();
				UserCommands enteredEnum;
				Enum.TryParse(input, out enteredEnum);

				if (enteredEnum == UserCommands.ShowAll)
				{
					consoleDisplayAll(data);
				}
				else if (enteredEnum == UserCommands.ShowContact)
				{
					Console.WriteLine("Enter index of contact you want to edit...");
					int index = Int32.Parse(Console.ReadLine())-1;
					consoleDisplaySpecific(data, index);
				}
				else if (enteredEnum == UserCommands.AddNew)
				{
					consoleAddNewContact(data);
				}
				else if (enteredEnum == UserCommands.Edit)
				{
					consoleEdit(data);
				}
				else if (enteredEnum == UserCommands.Clear)
				{
					Console.Clear();
				}
				else if (enteredEnum == UserCommands.Help)
				{
					consoleHelp();
				}
				else
				{
					Console.WriteLine("Unavailable command. Type '" + UserCommands.Help + "' or " + 
						(int)UserCommands.Help + " to see list of commands...");
				}
			}
		}

		public void consoleHelp()
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