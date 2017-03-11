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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactsBook
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private ContactsBookBL contactBook = new ContactsBookBL();
		public MainWindow()
		{
			InitializeComponent();
			
		}

		private void readFromFileButton_Click(object sender, RoutedEventArgs e)
		{
			textBox.Text = String.Empty;
			foreach (ContactModel contact in contactBook.GetFileContent())
			{
				textBox.Text += contact.ContactName + ":" + contact.ContactNumber + ":" + contact.ContactComment + "\n";
			}
		}

		private void editContactButton_Click(object sender, RoutedEventArgs e)
		{
			AddEditContact addEditContact = new AddEditContact(contactBook, Int32.Parse(textBox1.Text));
			addEditContact.ShowDialog();
		}

		private void addNewContactButton_Click(object sender, RoutedEventArgs e)
		{
			AddEditContact addEditContact = new AddEditContact(contactBook);
			addEditContact.ShowDialog();
		}
	}
}
