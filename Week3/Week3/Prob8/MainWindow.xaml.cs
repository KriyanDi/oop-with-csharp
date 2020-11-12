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

namespace Prob8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random randomNumber = new Random();
        int headsCounter = 0, tailsCounter = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private bool Flip()
        {
            //false -> Tails & true -> Heads
            int flipResult = randomNumber.Next(0,2);

            if(flipResult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void UpdateScore()
        {
            TailsLabel.Content = $"Tails: {tailsCounter}";
            HeadsLabel.Content = $"Tails: {headsCounter}";
        }

        private void BtnToss_Click(object sender, RoutedEventArgs e)
        {
            if(Flip())
            {
                headsCounter++;
            }
            else
            {
                tailsCounter++;
            }

            UpdateScore();
        }
    }
}
