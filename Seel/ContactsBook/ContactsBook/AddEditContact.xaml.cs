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

		internal AddEditContact()
		{
			InitializeComponent();
		}

		internal AddEditContact(ContactsBookBL contactsBook)
		{
			InitializeComponent();
			_contactsBook = contactsBook;

		}

		internal AddEditContact(ContactsBookBL contactsBook, int editContactIndex)
		{
			InitializeComponent();
			_contactsBook = contactsBook;
			_editContactIndex = editContactIndex;

		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			_contactsBook.AddNewContact(textBox.Text, textBox1.Text, textBox2.Text);
		}

		private void button1_Click(object sender, RoutedEventArgs e)
		{
			button1.Visibility = System.Windows.Visibility.Visible;
			_contactsBook.Edit(_editContactIndex - 1, textBox1.Text, textBox1.Text, textBox2.Text);
		}
	}
}
