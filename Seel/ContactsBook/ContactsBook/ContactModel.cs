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
			ContactName = incomingName;
			ContactNumber = incomingNumber;
			ContactComment = incomingComment;
		}

		public bool Validation()
		{
			if (_contactName != "Unspecified name" && _contactNumber != "Unspecified number")
			{ return true; }
			else { return false; }
		}

		public string ContactName
		{
			get
			{
				return _contactName;
			}
			set
			{
				if (value.IndexOf(":") == -1 && value != String.Empty)
				{
					_contactName = value;
				}
				else
				{
					_contactName = "Unspecified name";
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
				if (value.IndexOf(":") == -1 && !value.Any(char.IsLetter) && value != String.Empty)
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
				else
				{
					_contactComment = value.Replace(":", "-");
				}
			}
		}

}
}
