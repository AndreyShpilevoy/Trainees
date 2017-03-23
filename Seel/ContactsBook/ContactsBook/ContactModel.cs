using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactsBook
{
	public class ContactModel
	{
		private string _contactName;
		private string _contactNumber;
		private string _contactComment;

        public ContactModel()
        {
            _contactName = String.Empty;
            _contactNumber = String.Empty;
            _contactComment = String.Empty;
        }

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
				if (value != String.Empty)
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
				if (!value.Any(char.IsLetter) && value != String.Empty)
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
				_contactComment = value;				
			}
		}

}
}
