using System;

namespace Phone_Book
{
	class Contact
	{
		public string newName;
		public long newNumber;
		public string newDescription;
		public string searchName;

		public Contact()
		{
			newName = string.Empty;
			newNumber = 0;
			newDescription = string.Empty;
			searchName= string.Empty;
		}
	}
}