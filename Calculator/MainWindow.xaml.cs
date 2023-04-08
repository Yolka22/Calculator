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
using System.Data;

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static string Main_Text(string input)
        {

            string tmp = input.Replace(',', '.');
            return tmp;
        }

        private void Result_Button_Click(object sender, RoutedEventArgs e)
        {
            string value = new DataTable().Compute(Main_Text(main_textbox.Text), null).ToString();

            main_textbox.Text = value;
        }

        private void Clear_Button_Click(object sender, RoutedEventArgs e)
        {
            main_textbox.Clear();
        }

        private void Left_Bracket_Button_Click(object sender, RoutedEventArgs e)
        {
            main_textbox.Text += "(";
        }

        private void Right_Bracket_Button_Click(object sender, RoutedEventArgs e)
        {
            main_textbox.Text += ")";
        }

        private void Devide_Button_Click(object sender, RoutedEventArgs e)
        {
            main_textbox.Text += "/";
        }

        private void Seven_Button_Click(object sender, RoutedEventArgs e)
        {
            main_textbox.Text += "7";
        }

        private void Eight_Button_Click(object sender, RoutedEventArgs e)
        {
            main_textbox.Text += "8";
        }

        private void Nine_Button_Click(object sender, RoutedEventArgs e)
        {
            main_textbox.Text += "9";
        }

        private void Multiply_Button_Click(object sender, RoutedEventArgs e)
        {
            main_textbox.Text += "*";
        }

        private void Four_Button_Click(object sender, RoutedEventArgs e)
        {
            main_textbox.Text += "4";
        }

        private void Five_Button_Click(object sender, RoutedEventArgs e)
        {
            main_textbox.Text += "5";
        }

        private void Sixe_Button_Click(object sender, RoutedEventArgs e)
        {
            main_textbox.Text += "6";
        }

        private void Minus_Button_Click(object sender, RoutedEventArgs e)
        {
            main_textbox.Text += "-";
        }

        private void One_Button_Click(object sender, RoutedEventArgs e)
        {
            main_textbox.Text += "1";
        }

        private void Two_Button_Click(object sender, RoutedEventArgs e)
        {
            main_textbox.Text += "2";
        }

        private void Three_Button_Click(object sender, RoutedEventArgs e)
        {
            main_textbox.Text += "3";
        }

        private void Plus_Button_Click(object sender, RoutedEventArgs e)
        {
            main_textbox.Text += "+";
        }

        private void Zero_Button_Click(object sender, RoutedEventArgs e)
        {
            main_textbox.Text += "0";
        }

        private void Coma_Button_Click(object sender, RoutedEventArgs e)
        {
            main_textbox.Text += ",";
        }

    }
}
