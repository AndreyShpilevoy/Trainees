﻿using System;
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

namespace WpfExample
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void loadDataButton_Click(object sender, RoutedEventArgs e)
		{
			var s = new Service();
			textBox.IsEnabled = true;
			textBox.Text = s.ReadFile(textBox.Text);
		}
	}

	class Service
	{
		public string ReadFile(string path)
		{

			return path + "OLOLOLO";
		}
	}
}
