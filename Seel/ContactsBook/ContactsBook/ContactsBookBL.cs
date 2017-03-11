using System;
using System.Collections.Generic;
using System.IO;

namespace ContactsBook
{
	internal class ContactsBookBL
	{
		string pathToFile;
		string[] fileContent;
		List<ContactModel> parsedFile;


		public ContactsBookBL()
		{
			pathToFile = @"..\..\..\PhoneNumbers.txt";
			CheckFile();
			fileContent = File.ReadAllLines(pathToFile);
			parsedFile = new List<ContactModel>();

			foreach (string line in fileContent)
			{
				string[] parsedLine = line.Split(':');
				parsedFile.Add(new ContactModel(parsedLine[0], parsedLine[1], parsedLine[2]));
			}
		}

		public List<ContactModel> GetFileContent()
		{
			return parsedFile;
		}

		public ContactModel GetContact(int index)
		{
			return parsedFile[index];
		}

		public void CheckFile()
		{
			if (!File.Exists(pathToFile))
			{
				File.AppendAllLines(pathToFile, new[] { "Aleksandr:+79162305724:Asshole" });
			}
			var fileContent = File.ReadAllText(pathToFile);
			File.WriteAllText(pathToFile, fileContent);
		}

		public void AddNewContact(string name, string number, string comment)
		{
			File.AppendAllLines(pathToFile, new[] { name + ":" + number + ":" + comment });
			parsedFile.Add(new ContactModel(name, number, comment));
		}

		public void Edit(int editableContact, string editableField, string changeTo)
		{
			switch (editableField)
			{
				case "name":
					parsedFile[editableContact].ContactName = changeTo;
					break;
				case "number":
					parsedFile[editableContact].ContactNumber = changeTo;
					break;
				case "comment":
					parsedFile[editableContact].ContactComment = changeTo;
					break;
			}
			File.WriteAllText(pathToFile, String.Empty);
			foreach (ContactModel contact in parsedFile)
			{
				File.AppendAllLines(pathToFile, new[] { contact.ContactName + ":" 
					+ contact.ContactNumber + ":" 
					+ contact.ContactComment });
			}
		}

		public void Edit(int editableContact, string newName, string newNumber, string newComment )
		{
			parsedFile[editableContact].ContactName = newName;
			parsedFile[editableContact].ContactNumber = newNumber;
			parsedFile[editableContact].ContactComment = newComment;
			File.WriteAllText(pathToFile, String.Empty);
			foreach (ContactModel contact in parsedFile)
			{
				File.AppendAllLines(pathToFile, new[] { contact.ContactName + ":"
					+ contact.ContactNumber + ":"
					+ contact.ContactComment });
			}
		}

	}
}
