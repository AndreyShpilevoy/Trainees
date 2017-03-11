using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactsBook
{
	internal class ContactModel
	{
		private string _contactName;
		private string _contactNumber;
		private string _contactComment;

		public ContactModel(string incomingName, string incomingNumber, string incomingComment)
		{
			_contactName = incomingName;
			_contactNumber = incomingNumber;
			_contactComment = incomingComment;
		}

		public string ContactName
		{
			get
			{
				return _contactName;
			}
			set
			{
				if (value.IndexOf(":") == -1)
				{
					_contactName = value;
				}
			}
		}

		public string ContactNumber
		{
			get
			{
				return _contactNumber;
			}
			set
			{
				if (value.IndexOf(":") == -1 && !value.Any(char.IsLetter))
				{
					_contactNumber = value;
				}
				else
				{
					_contactNumber = "Unspecified number";
				}
			}
		}

		public string ContactComment
		{
			get
			{
				return _contactComment;
			}
			set
			{
				if (value.IndexOf(":") == -1)
				{
					_contactComment = value;
				}
			}
		}

}
}
