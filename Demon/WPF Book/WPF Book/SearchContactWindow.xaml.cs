using System.Windows;

namespace WPF_Book
{
	/// <summary>
	/// Interaction logic for Page2.xaml
	/// </summary>
	public partial class SearchContactWindow : Window
	{
		private ReadWrite _readWrite;
		private MainWindow _mainWindow;
		public SearchContactWindow(MainWindow mainWindow, ReadWrite readWrite)
		{
			_mainWindow = mainWindow;
			_readWrite = readWrite;
			InitializeComponent();
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			var indexContact = _readWrite.SearchIndexByName(textBoxSearchContact.Text);
			if (indexContact == -1)
			{
				textBlockError.Text = "Contact not found";
			}

			else
			{
				if (_mainWindow.EditDeleteShowGetIndex() == 0)
				{
					EditContactWindow editContact = new EditContactWindow(_readWrite, indexContact);
					editContact.ShowDialog();
					Close();
				}

				else if(_mainWindow.EditDeleteShowGetIndex() == 1)
				{
					_readWrite.DeleteContact(indexContact);
					Close();
				}

				else 
				{
					var contact = _readWrite.SearchContactByName(textBoxSearchContact.Text);
					_mainWindow.contactList.Text = $"{contact.Name}:+{contact.Number}  {contact.Description}";
				}
			}
		}
	}
}
