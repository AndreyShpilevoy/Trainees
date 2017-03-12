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
	/// Interaction logic for Page2.xaml
	/// </summary>
	public partial class SearchContactWindow : Window
	{
		private static int indexForEdit=0;
		private ReadWrite readWrite=new ReadWrite();
		private MainWindow mainWindow=new MainWindow();
		public SearchContactWindow()
		{
			InitializeComponent();
		}

		public static int IndexForEdit()
		{
			return indexForEdit;
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			var indexContact = readWrite.SearchIndexByName(textBoxSearchContact.Text);
			if (indexContact == -1)
			{
				textBlockError.Text = "Contact not found";
			}

			else
			{
				if (mainWindow.EditDeleteShowGetIndex() == 0)
				{
					EditContactWindow editContact = new EditContactWindow();
					editContact.ShowDialog();
					Close();
				}

				else if(mainWindow.EditDeleteShowGetIndex() == 1)
				{
					readWrite.DeleteContact(indexContact);
					Close();
				}

				else 
				{
					var contact = readWrite.SearchContactByName(textBoxSearchContact.Text);
					mainWindow.contactList.Text = $"{contact.Name}:+{contact.Number}  {contact.Description}";
				}
			}
		}
	}
}
