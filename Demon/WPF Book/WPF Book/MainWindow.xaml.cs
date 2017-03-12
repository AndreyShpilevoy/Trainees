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
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private ReadWrite _readWrite = new ReadWrite();
		private int editDeleteShowIndex;
		public MainWindow()
		{
			InitializeComponent();
			_readWrite.OpenFile();
		}

		public int EditDeleteShowGetIndex()
		{
			return editDeleteShowIndex;
		}

		private void Load_data_Click(object sender, RoutedEventArgs e)
		{
			var allContacts = _readWrite.GetAllContacts();
			contactList.Text = String.Empty;
			foreach (var contact in allContacts)
			{
				contactList.Text += ($"{contact.Name}\t+{contact.Number}\n");
			}
		}

		private void Add_contact_Click(object sender, RoutedEventArgs e)
		{
			AddContactWindow addWindow = new AddContactWindow(_readWrite);
			addWindow.ShowDialog();
		}

		private void Edit_contact_Click(object sender, RoutedEventArgs e)
		{
			editDeleteShowIndex = 0;
			SearchContactWindow searchWindow = new SearchContactWindow(this, _readWrite);
			searchWindow.ShowDialog();
		}

		private void Delete_contact_Click(object sender, RoutedEventArgs e)
		{
			editDeleteShowIndex = 1;
			SearchContactWindow searchWindow = new SearchContactWindow(this, _readWrite);
			searchWindow.ShowDialog();
		}

		private void Show_contact_Click(object sender, RoutedEventArgs e)
		{
			SearchContactWindow searchWindow = new SearchContactWindow(this, _readWrite);
			searchWindow.ShowDialog();
		}

		private void Show_all_Contacts_Click(object sender, RoutedEventArgs e)
		{
			var allContacts = _readWrite.GetAllContacts();
			foreach (var contact in allContacts)
			{
				contactList.Text = ($"{contact.Name}\t+{contact.Number}");
			}
		}

		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
