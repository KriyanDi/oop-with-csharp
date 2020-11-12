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

namespace Prob7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random randomNumber = new Random();

        int number1, number2, result;

        public MainWindow()
        {
            InitializeComponent();
            SetTask();
        }

        private string GenerateQuestion()
        {
            number1 = randomNumber.Next(1, 21);
            number2 = randomNumber.Next(1, 11);
            result = number1 * number2;

            string question = $"How much is {number1} times {number2} ?";

            return question;
        }

        private void SetTask()
        {
            TaskLabel.Content = GenerateQuestion(); 
        }

        private void BtnAnswr_Click(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(TextField.Text, out int answear))
            {
                if(answear == result)
                {
                    MessageBox.Show("Very good!");
                    SetTask();
                    TextField.Text = "";
                }
                else
                {
                    TaskLabel.Content = "No. Please try again";
                }
            }

        }

        private void BtnTryAgn_Click(object sender, RoutedEventArgs e)
        {
            TaskLabel.Content = $"How much is {number1} times {number2} ?";
            TextField.Text = "";
        }
    }
}
