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
using System.Globalization;
using System.Threading;
using Calculator.Properties;
using System.Windows.Threading;
using System.Timers;

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();

        DateTime _d = DateTime.Now;

        TimeSpan Working_Time = TimeSpan.Zero;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateUI();

            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void UpdateUI()
        {
            Work_day.Content = CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(_d.DayOfWeek);
            History_Button.Content = language.history;
            Work_time.Content = language.work_time;
        }

        private void timerTick(object sender, EventArgs e)
        {
            Work_timer.Content = Working_Time += timer.Interval;
        }

        private void Menu_Ru_Click(object sender, RoutedEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru");
            UpdateUI();

            Work_day.Content = CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat.GetDayName(_d.DayOfWeek);
        }

        private void Menu_En_Click(object sender, RoutedEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            UpdateUI();

            Work_day.Content = CultureInfo.GetCultureInfo("en").DateTimeFormat.GetDayName(_d.DayOfWeek);
        }

        private void Menu_Fr_Click(object sender, RoutedEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr");
            UpdateUI();

            Work_day.Content = CultureInfo.GetCultureInfo("fr").DateTimeFormat.GetDayName(_d.DayOfWeek);
        }

        static bool Is_Brackets_Closed(string input)
        {
            int left_brackets = 0;
            int right_brackets = 0;


            for (int i = 0; i < input.Length; i++)
            {

                if (input[i]=='(')
                {
                    left_brackets++;
                }

                if (input[i]==')')
                {
                    right_brackets++;
                }

            }

            if (left_brackets == right_brackets)
            {
                return true;
            }
            else return false;

        }

        static bool Is_Contains_Actions(string input)
        {


            if (input.Contains('+') | input.Contains('-') | input.Contains('*') | input.Contains('/'))
            {
                return true;
            }else return false;

        }

        static string Main_Text(string input)
        {

            string tmp = input.Replace(',', '.');
            return tmp;
        }

        private void Result_Button_Click(object sender, RoutedEventArgs e)
        {

            if (Is_Contains_Actions(main_textbox.Text))
            {
                if (Is_Brackets_Closed(main_textbox.Text))
                {

                    try { 
                        string value = new DataTable().Compute(Main_Text(main_textbox.Text), null).ToString();

                        string action = main_textbox.Text + " = " + value;

                        main_textbox.Text = value;

                        History_ListBox.Items.Add(action);
                    } 
                    catch{
                        MessageBox.Show("Синтаксическая ошибка");
                    }
                }
                else MessageBox.Show("Круглые скобки не закрыты");

            }
            else MessageBox.Show("В примере нет математических действий");

            
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

        private void History_Button_Click(object sender, RoutedEventArgs e)
        {

            if (History_ListBox.Visibility == Visibility.Hidden)
            {
                History_ListBox.Visibility = Visibility.Visible;
            }
            else
            {
                History_ListBox.Visibility = Visibility.Hidden;
            }
        }

        private void History_ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            string filtred = History_ListBox.SelectedItem.ToString().Substring(History_ListBox.SelectedItem.ToString().IndexOf('=')+2);

            main_textbox.Text = filtred;

        }


    }
}
