using System;

namespace WPF_Book
{
	public class Contact
	{

		public Contact(string name, long number, string description)
		{
			Name = name;
			Number = number;
			Description = description;
		}

		public Contact(string name, string number, string description)
		{
			Name = name;
			Description = description;
			long numberParsed;
			if (Int64.TryParse(number.Trim('+'), out numberParsed))
			{
				Number = numberParsed;
			}
			else
			{
				Number = 0;
			}
		}

		public string Name { get; set; }
		public long Number { get; set; }
		public string Description { get; set; }
	}
}