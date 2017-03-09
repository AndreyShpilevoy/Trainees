using System;
using System.IO;
using System.Collections.Generic;

namespace Phone_Book
{
	class ReadWrite
	{
		public int numberNext=0;
		int searchIndex = 0;
		public int searchNumber;
		private List<string> contact = new List<string>();
		private Contact newContact = new Contact();
		private string _pathToFile = @"E:\Admin\Documents\Trainees\Demon\Phone Book\Contacts.txt";
		public string[] _fileContent;
		public string[] split;
		public List<string> showAll = new List<string>();
		private long inputNumber;
		private string descriptionValid;

		public void OpenFile()
		{
			_fileContent = File.ReadAllLines(_pathToFile);
			for (var i = 0; i < _fileContent.Length; i++)
			{
				contact.Add(_fileContent[i]);
			}
		}

		public void AddNewName()
		{
			newContact.newName = Console.ReadLine();
		}

		public void AddNewNumber()
		{
			newContact.newNumber = inputNumber;
		}

		public void AddNewDescription()
		{
			newContact.newDescription = descriptionValid;
		}

		public void SaveNewContact()
		{
			contact.Add(String.Format("{0}\t+{1}\t{2}", newContact.newName, newContact.newNumber, newContact.newDescription));
			File.WriteAllLines(_pathToFile, contact);
		}

		public void SearchName()
		{			
			newContact.searchName = Console.ReadLine();
			for (searchNumber = 0; searchNumber < _fileContent.Length; searchNumber++)
			{
				searchIndex = _fileContent[searchNumber].IndexOf(newContact.searchName);
			}
		}
		
		public void SplitSearch()
		{
			if (searchIndex >= 0)
			{
				split = _fileContent[searchNumber-1].Split(new Char[] { '\t' });
			}
		}

		public void EditName()
		{
			split[0] = Console.ReadLine();
		}

		public void EditNumber()
		{
			split[1] =Convert.ToString(inputNumber);
		}

		public void EditDescription()
		{
			split[2] = Console.ReadLine();
		}

		public void SaveEditontact()
		{
			string edit = String.Format("{0}\t+{1}\t{2}", split[0], split[1], split[2]);
			contact.Insert(searchNumber - 1, edit);
			File.WriteAllLines(_pathToFile, contact);
		}

		public void DeleteContact()
		{
			contact.RemoveAt(searchNumber - 1);
			File.WriteAllLines(_pathToFile, contact);
		}

		public bool NumberValid()
		{
			var newNumber = Console.ReadLine();
			return Int64.TryParse(newNumber, out inputNumber);
		}

		public bool DescriptionValid()
		{
			descriptionValid = Console.ReadLine();
			return descriptionValid.Length <= 256;
		}

		public void ShowAll()
		{
			showAll.Clear();
			_fileContent = File.ReadAllLines(_pathToFile);
			for (var i = 0; i < _fileContent.Length; i++)
			{
				split = _fileContent[i].Split(new Char[] { '\t' });
				showAll.Add(String.Format("{0}\t{1}",split[0],split[1]));
			}
		}
	}
}