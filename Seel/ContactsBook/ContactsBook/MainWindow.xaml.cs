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
		private ContactsBookBL contactBookBl = new ContactsBookBL();
		public MainWindow()
		{
			InitializeComponent();
			DisplayInfoFromFile();
		}

		public void DisplayInfoFromFile()
		{
			textBox.Text = String.Empty;
			foreach (ContactModel contact in contactBookBl.GetFileContent())
			{
				textBox.Text += $"{contactBookBl.GetFileContent().IndexOf(contact) + 1}) {contact.ContactName} : {contact.ContactNumber}\n";
			}
		}

		private void readFromFileButton_Click(object sender, RoutedEventArgs e)
		{
			DisplayInfoFromFile();
		}

		private void editContactButton_Click(object sender, RoutedEventArgs e)
		{
			AddEditContact addEditContact = new AddEditContact(contactBookBl, Int32.Parse(textBox1.Text), this);
			addEditContact.button1.Visibility = System.Windows.Visibility.Visible;
			addEditContact.textBox.Text = contactBookBl.GetContact(Int32.Parse(textBox1.Text)-1).ContactName;
			addEditContact.textBox1.Text = contactBookBl.GetContact(Int32.Parse(textBox1.Text)-1).ContactNumber;
			addEditContact.textBox2.Text = contactBookBl.GetContact(Int32.Parse(textBox1.Text)-1).ContactComment;
			addEditContact.ShowDialog();
		}

		private void addNewContactButton_Click(object sender, RoutedEventArgs e)
		{
			AddEditContact addEditContact = new AddEditContact(contactBookBl, this);
			addEditContact.button.Visibility = System.Windows.Visibility.Visible;
			addEditContact.ShowDialog();
			addEditContact.button.IsEnabled = false;
		}

		private void displayContactButton_Click(object sender, RoutedEventArgs e)
		{
			AddEditContact addEditContact = new AddEditContact(contactBookBl, this);
			addEditContact.textBox.Text = contactBookBl.GetContact(Int32.Parse(textBox1.Text) - 1).ContactName;
			addEditContact.textBox1.Text = contactBookBl.GetContact(Int32.Parse(textBox1.Text) - 1).ContactNumber;
			addEditContact.textBox2.Text = contactBookBl.GetContact(Int32.Parse(textBox1.Text) - 1).ContactComment;
			addEditContact.textBox.IsEnabled = false;
			addEditContact.textBox1.IsEnabled = false;
			addEditContact.textBox2.IsEnabled = false;
			addEditContact.ShowDialog();
		}

		private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
		{
			int inputIndex;

			if (!Int32.TryParse(textBox1.Text, out inputIndex) || !contactBookBl.ContainsIndex(inputIndex))
			{
				editContactButton.IsEnabled = false;
				displayContactButton.IsEnabled = false;
				deleteContactButton.IsEnabled = false;
			}
			else
			{
				editContactButton.IsEnabled = true;
				displayContactButton.IsEnabled = true;
				deleteContactButton.IsEnabled = true;
			}
		}

		private void deleteContactButton_Click(object sender, RoutedEventArgs e)
		{
			AddEditContact addEditContact = new AddEditContact(contactBookBl);
			contactBookBl.DeleteContact(Int32.Parse(textBox1.Text)-1);
			DisplayInfoFromFile();
            if (Int32.Parse(textBox1.Text) > contactBookBl.GetFileContent().Count)
            {
                textBox1.Text = contactBookBl.GetFileContent().Count.ToString();
            }
		}
	}
}
