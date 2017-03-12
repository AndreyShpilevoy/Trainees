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
	/// Interaction logic for EditContactWindow.xaml
	/// </summary>
	public partial class EditContactWindow : Window
	{
		private ReadWrite readWrite=new ReadWrite();
		public EditContactWindow()
		{
			InitializeComponent();
			var editModel = readWrite.GetContactByIndex(SearchContactWindow.IndexForEdit());
			editName.Text = editModel.Name;
			editNumber.Text = editModel.Number.ToString();
			editDescription.Text = editModel.Description;
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			var editedModel = readWrite.GetContactByIndex(SearchContactWindow.IndexForEdit());
			editedModel.Name = editName.Text;

			var contactNumber = editNumber.Text;
			if (readWrite.NumberValidator(contactNumber))
			{
				editedModel.Number = Int64.Parse(contactNumber);
			}

			else
			{
				textBlock_WrongNumber.Text = "Please enter correct phone number";
			}

			var contactDescription = editDescription.Text;
			if (readWrite.DescriptionValidator(contactDescription))
			{
				editedModel.Description = contactDescription;
			}

			else
			{
				textBlock_WrongDescription.Text = "Description can not contain more than 256 symbols";
			}

			if (readWrite.DescriptionValidator(contactDescription)&& readWrite.NumberValidator(contactNumber))
			{
				readWrite.EditContact(SearchContactWindow.IndexForEdit(), editedModel);
				Close();
			}
		}
	}
}
