using System.IO;

namespace FileReadAndWrite
{
	class Program
	{
		static void Main()
		{
			var pathToFile = @"C:\Git\Trainees\Examples\FileReadAndWrite\FileReadAndWrite\PhoneNumbers.txt";
			var fileContent = File.ReadAllText(pathToFile);
			fileContent = fileContent.Replace(":", "-");
			File.WriteAllText(pathToFile, fileContent);
		}
	}
}
