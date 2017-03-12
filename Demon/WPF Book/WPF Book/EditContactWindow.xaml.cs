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
		private ReadWrite _readWrite;
		private int _index;
		public EditContactWindow(ReadWrite readWrite, int index)
		{
			_readWrite = readWrite;
			_index = index;
			InitializeComponent();
			var editModel = _readWrite.GetContactByIndex(_index);
			editName.Text = editModel.Name;
			editNumber.Text = editModel.Number.ToString();
			editDescription.Text = editModel.Description;
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			var editedModel = _readWrite.GetContactByIndex(_index);
			editedModel.Name = editName.Text;

			var contactNumber = editNumber.Text;
			if (_readWrite.NumberValidator(contactNumber))
			{
				editedModel.Number = Int64.Parse(contactNumber);
			}

			else
			{
				textBlock_WrongNumber.Text = "Please enter correct phone number";
			}

			var contactDescription = editDescription.Text;
			if (_readWrite.DescriptionValidator(contactDescription))
			{
				editedModel.Description = contactDescription;
			}

			else
			{
				textBlock_WrongDescription.Text = "Description can not contain more than 256 symbols";
			}

			if (_readWrite.DescriptionValidator(contactDescription)&& _readWrite.NumberValidator(contactNumber))
			{
				_readWrite.EditContact(_index, editedModel);
				Close();
			}
		}
	}
}
