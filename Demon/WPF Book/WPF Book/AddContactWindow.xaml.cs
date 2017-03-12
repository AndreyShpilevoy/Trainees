using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Book
{
	/// <summary>
	/// Interaction logic for Page1.xaml
	/// </summary>
	public partial class AddContactWindow : Window
	{
		private ReadWrite _readWrite = new ReadWrite();

		public AddContactWindow()
		{
			InitializeComponent();
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			var newContactNumber = String.Empty;
			var newContactDescription = String.Empty;

			var contactNumber = textBoxNumber.Text;

			//Number validation
			if (_readWrite.NumberValidator(contactNumber))
			{
				newContactNumber = contactNumber;
			}

			else
			{
				textBlock_WrongNumber.Text = "Wrong number.Please try again";
			}

			var contactDescription = textBoxDescription.Text;
			//Description validation
			if (_readWrite.DescriptionValidator(contactDescription))
			{
				newContactDescription = contactDescription;
			}

			else
			{
				textBlock_WrongDescription.Text = "Wrong Description.Please try again";
			}

			if (_readWrite.NumberValidator(contactNumber)&& _readWrite.DescriptionValidator(contactDescription))
			{
				var newContact = new Contact(textBoxName.Text, newContactNumber, newContactDescription);
				_readWrite.AddNewContact(newContact);
				Close();
			}	
		}
	}
}
