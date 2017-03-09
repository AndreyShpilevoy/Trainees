using System;
using System.Collections.Generic;
using System.IO;

namespace AdressBook
{
	class DataManipulation
	{
		private string _pathToFile;
		private string[] _fileContent;
		private List<string[]> _parsedFile;

		public DataManipulation()
		{
			_pathToFile = @"..\..\..\PhoneNumbers.txt";
			CheckFile();
			_fileContent = File.ReadAllLines(_pathToFile);
			_parsedFile = new List<string[]>();

			foreach (string line in _fileContent)
			{
				string[] parsedLine = line.Split(':');
				_parsedFile.Add(parsedLine);
			}
		}

		public List<string[]> GetFileContent()
		{
			return _parsedFile;
		}

		public string[] GetContact(int index)
		{
			return _parsedFile[index];
		}

		public void CheckFile()
		{
			if (!File.Exists(_pathToFile))
			{
				File.AppendAllLines(_pathToFile, new[] { "Aleksandr:+79162305724:Asshole" });
			}
			var fileContent = File.ReadAllText(_pathToFile);
			File.WriteAllText(_pathToFile, fileContent);
		}

		public void AddNewContact(string name, string number, string comment)
		{
			string tempString = name + ":" + number + ":" + comment;
			File.AppendAllLines(_pathToFile, new[] { tempString });
			_parsedFile.Add(new string[] { name, number, comment });
		}

		public void Edit(int editableContact, int editableField, string changeTo)
		{
			string[] constructedContact = null;
			switch (editableField)
			{
				case 0:
					constructedContact = new string[]{ changeTo, _parsedFile[editableContact][1], _parsedFile[editableContact][2] };
					break;
				case 1:
					constructedContact = new string[] { _parsedFile[editableContact][0], changeTo, _parsedFile[editableContact][2] };
					break;
				case 2:
					constructedContact = new string[] { _parsedFile[editableContact][0], _parsedFile[editableContact][1], changeTo };
					break;
			}
			_parsedFile[editableContact] = constructedContact;

			File.WriteAllText(_pathToFile, String.Empty);
			foreach (string[] line in _parsedFile)
			{
				File.AppendAllLines(_pathToFile, new[] { line[0] + ":" + line[1] + ":" + line[2] });
			}
		}

	}
}
