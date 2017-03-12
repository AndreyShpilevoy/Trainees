using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ContactsBook
{
	/// <summary>
	/// Interaction logic for AddEditContact.xaml
	/// </summary>
	public partial class AddEditContact : Window
	{
		private ContactsBookBL _contactsBook;
		private int _editContactIndex;
		private MainWindow _mainWindow;

		internal AddEditContact()
		{
			InitializeComponent();
		}

		internal AddEditContact(ContactsBookBL contactsBook)
		{
			InitializeComponent();
			_contactsBook = contactsBook;
		}

		internal AddEditContact(ContactsBookBL contactsBook, MainWindow mainWindow)
		{
			InitializeComponent();
			_contactsBook = contactsBook;
			_mainWindow = mainWindow;
		}

		internal AddEditContact(ContactsBookBL contactsBook, int editContactIndex, MainWindow mainWindow)
		{
			InitializeComponent();
			_contactsBook = contactsBook;
			_editContactIndex = editContactIndex;
			_mainWindow = mainWindow;
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			_contactsBook.AddNewContact(textBox.Text, textBox1.Text, textBox2.Text);
			Close();
			_mainWindow.DisplayInfoFromFile();
		}

		private void button1_Click(object sender, RoutedEventArgs e)
		{
			_contactsBook.Edit(_editContactIndex - 1, textBox.Text, textBox1.Text, textBox2.Text);
			Close();
			_mainWindow.DisplayInfoFromFile();	
		}

		private void textBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			ContactModel contactNew = new ContactModel(textBox.Text, textBox1.Text, textBox2.Text);

			if (contactNew.Validation())
			{
				button.IsEnabled = true;
				button1.IsEnabled = true;
			}
			else
			{
				button.IsEnabled = false;
				button1.IsEnabled = false;
			}			
		}

		private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
		{
			ContactModel contactNew = new ContactModel(textBox.Text, textBox1.Text, textBox2.Text);

			if (contactNew.Validation())
			{
				button.IsEnabled = true;
				button1.IsEnabled = true;
			}
			else
			{
				button.IsEnabled = false;
				button1.IsEnabled = false;
			}

		}
	}
}
