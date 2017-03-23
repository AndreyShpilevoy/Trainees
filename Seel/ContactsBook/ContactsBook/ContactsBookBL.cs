using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ContactsBook
{
	internal class ContactsBookBL
	{
        string pathToFileXml;
		List<ContactModel> parsedFile;

		public void XmlSerializeAndWriteToFile()
		{
			var serializer = new XmlSerializer(typeof(List<ContactModel>));
			var streamWriter = new StreamWriter(pathToFileXml);
			serializer.Serialize(streamWriter, parsedFile);
			streamWriter.Close();
		}

		public void XmlDeserializeAndReadFromFile()
		{
			var serializer = new XmlSerializer(typeof(List<ContactModel>));
			var streamReader = new StreamReader(pathToFileXml);
			parsedFile = (List<ContactModel>)serializer.Deserialize(streamReader);
			streamReader.Close();
		}

		public void CheckFile()
		{
			if (!File.Exists(pathToFileXml))
			{
				parsedFile = null;
				parsedFile.Add(new ContactModel("Aleksandr", "+79162305724", "Asshole"));
				XmlSerializeAndWriteToFile();
			}
		}

		public ContactsBookBL()
		{
            pathToFileXml = @"..\..\..\PhoneNumbers.xml";
            CheckFile();
			parsedFile = new List<ContactModel>();
			XmlDeserializeAndReadFromFile();
		}

		public List<ContactModel> GetFileContent()
		{
			return parsedFile;
		}

		public ContactModel GetContact(int index)
		{
			return parsedFile[index];
		}

		public void AddNewContact(string name, string number, string comment)
		{
			parsedFile.Add(new ContactModel(name, number, comment));
			XmlSerializeAndWriteToFile();
		}

		public void DeleteContact(int index)
		{
			parsedFile.RemoveAt(index);
			XmlSerializeAndWriteToFile();
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
			XmlSerializeAndWriteToFile();
		}

		public void Edit(int editableContact, string newName, string newNumber, string newComment )
		{
			parsedFile[editableContact].ContactName = newName;
			parsedFile[editableContact].ContactNumber = newNumber;
			parsedFile[editableContact].ContactComment = newComment;
			XmlSerializeAndWriteToFile();
		}

		public bool ContainsIndex(int index)
		{
			return ((index > 0 && index < parsedFile.Count+1) ? true : false);
		}
	}


}

