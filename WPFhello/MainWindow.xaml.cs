using System;
using System.Windows;
using System.Windows.Controls;

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListBoxItem james = new ListBoxItem();
            james.Content = "James";
            peopleListBox.Items.Add(james);
            ListBoxItem david = new ListBoxItem();
            david.Content = "David";
            peopleListBox.Items.Add(david);

            peopleListBox.SelectedItem = james;
        }

        private void btnHello_Click(object sender, RoutedEventArgs e)
        {
            string s = null;
            foreach (var item in mainGrid.Children)
            {
                if (item is TextBox)
                {
                    s = s + ((TextBox)item).Text;
                    s = s + '\n';
                }
            }

            Console.WriteLine(s);
            if (txtName.Text.Length >= 2)
            {
                MessageBox.Show("Здрасти, " + txtName.Text + "!!! \nТова е твоята първа програма на Visual Studio 2022!");
            }
            else
            {
                MessageBox.Show("Потребителското име трябва да е поне 2 символа.");

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is Windows Presentation Foundation!");

            textBlock1.Text = DateTime.Now.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string greetingMessage;

            greetingMessage = (peopleListBox.SelectedItem as ListBoxItem).Content.ToString();

            MyMessage secondWindow = new MyMessage();
            secondWindow.Show();
        }
    }
}
