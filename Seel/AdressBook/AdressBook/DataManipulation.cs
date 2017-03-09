using System;
using System.Collections.Generic;
using System.IO;

namespace AdressBook
{
	class DataManipulation
	{
		string pathToFile;
		string[] fileContent;
		List<string[]> parsedFile;

		public DataManipulation()
		{
			pathToFile = @"..\..\..\PhoneNumbers.txt";
			fileContent = File.ReadAllLines(pathToFile);
			parsedFile = new List<string[]>();

			foreach (string line in fileContent)
			{
				string[] parsedLine = line.Split(':');
				parsedFile.Add(parsedLine);
			}
		}

		public List<string[]> GetFileContent()
		{
			return parsedFile;
		}

		public string[] GetContact(int index)
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
			string tempString = name + ":" + number + ":" + comment;
			File.AppendAllLines(pathToFile, new[] { tempString });
			parsedFile.Add(new string[] { name, number, comment });
		}

		public void Edit(int editableContact, int editableField, string changeTo)
		{
			switch (editableField)
			{
				case 0:
					string[] constructedContact0 = { changeTo, parsedFile[editableContact][1], parsedFile[editableContact][2] };
					parsedFile[editableContact] = constructedContact0;
					break;
				case 1:
					string[] constructedContact1 = { parsedFile[editableContact][0], changeTo, parsedFile[editableContact][2] };
					parsedFile[editableContact] = constructedContact1;
					break;
				case 2:
					string[] constructedContact2 = { parsedFile[editableContact][0], parsedFile[editableContact][1], changeTo };
					parsedFile[editableContact] = constructedContact2;
					break;
			}
			File.WriteAllText(pathToFile, String.Empty);
			foreach (string[] line in parsedFile)
			{
				File.AppendAllLines(pathToFile, new[] { line[0] + ":" + line[1] + ":" + line[2] });
			}
		}

	}
}
