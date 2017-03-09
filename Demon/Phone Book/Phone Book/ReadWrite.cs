using System;
using System.IO;
using System.Collections.Generic;

namespace Phone_Book
{
	class ReadWrite
	{
		private List<Contact> _contactList = new List<Contact>();
		private string _pathToFile = @"..\..\..\Contacts.txt";

		public void OpenFile()
		{
			var fileContent = File.ReadAllLines(_pathToFile);
			for (var i = 0; i < fileContent.Length; i++)
			{
				var splitedContactString = fileContent[i].Split(new Char[] {'\t'});
				_contactList.Add(new Contact(splitedContactString[0], splitedContactString[1], splitedContactString[2]));
			}
		}
		
		public void AddNewContact(Contact newContact)
		{
			_contactList.Add(newContact);
			Save();
		}

		public void EditContact(int contactIndex, Contact newContact)
		{
			_contactList[contactIndex] = newContact;
			Save();
		}

		public int SearchIndexByName(string value)
		{
			int result = -1;
			for (var searchNumber = 0; searchNumber < _contactList.Count; searchNumber++)
			{
				if (_contactList[searchNumber].Name.IndexOf(value) != -1)
				{
					result = searchNumber;
				}
			}
			return result;
		}

		public Contact SearchContactByName(string value)
		{
			Contact result = null;
			for (var searchNumber = 0; searchNumber < _contactList.Count; searchNumber++)
			{
				if (_contactList[searchNumber].Name.IndexOf(value) != -1)
				{
					result = _contactList[searchNumber];
				}
			}
			return result;
		}

		public Contact GetContactByIndex(int value)
		{
			return _contactList[value];
		}

		public void DeleteContact(int contactIndex)
		{
			_contactList.RemoveAt(contactIndex);
			Save();
		}

		public bool NumberValidator(string value)
		{
			long inputNumber;
			return Int64.TryParse(value, out inputNumber);
		}

		public bool DescriptionValidator(string value)
		{
			return value.Length <= 256;
		}

		public List<Contact> GetAllContacts()
		{
			return _contactList;
		}

		private void Save()
		{
			var dataForFile = new List<string>();
			foreach (var contact in _contactList)
			{
				dataForFile.Add($"{contact.Name}\t+{contact.Number}\t{contact.Description}");
			}
			File.WriteAllLines(_pathToFile, dataForFile);
		}
	}
}