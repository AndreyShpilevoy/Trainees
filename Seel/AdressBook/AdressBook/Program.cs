using System;
using System.IO;

namespace AdressBook
{
	class Program
	{
		public const string pathToFile = @"..\..\..\PhoneNumbers.txt";
		static void Main()
		{
			InputOutput input = new InputOutput();
			DataManipulation data = new DataManipulation();
			data.CheckFile();
			input.consoleControl(data);
		}
	}
}
