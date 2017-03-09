namespace AdressBook
{
	class Program
	{
		static void Main()
		{
			var data = new DataManipulation();
			var input = new InputOutput(data);
			input.ConsoleControl();
		}
	}
}
