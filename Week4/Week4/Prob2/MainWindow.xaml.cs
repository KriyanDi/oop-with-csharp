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

namespace Prob2
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

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnCode_Click(object sender, RoutedEventArgs e)
        {
            outputText.Text = TransCipher.Code(inputText.Text, int.Parse(inputCipherKey.Text));
            inputText.Text = "";
            inputCipherKey.Text = "";
        }

        private void btnDecode_Click(object sender, RoutedEventArgs e)
        {
            outputText.Text = TransCipher.Decode(inputText.Text, int.Parse(inputCipherKey.Text));
            inputText.Text = "";
            inputCipherKey.Text = "";
        }
    }
}
