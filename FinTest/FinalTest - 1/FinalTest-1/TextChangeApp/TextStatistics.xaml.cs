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
using System.Windows.Shapes;
using TextChangeLib;

namespace TextChangeApp
{
    /// <summary>
    /// Interaction logic for TextStatistics.xaml
    /// </summary>
    public partial class TextStatistics : Window
    {
        public TextStatistics()
        {
            InitializeComponent();
            TextGenerator.TextChange += TextChanged;
        }

        private void TextChanged(object o, TextChangeEventArgs e)
        {
            string wholeString = "";
            foreach (var item in e.Code)
            {
                wholeString = wholeString + item + Environment.NewLine;
            }

            TxtCds.Text = wholeString;
        }

        private void BtnSrtFreq_Click(object sender, RoutedEventArgs e)
        {
            string wholeText = TxtCds.Text.Replace(Environment.NewLine, "");

            var letterHistogram = wholeText
                .GroupBy(letter => letter)
                .Select(group => new { letter = group.Key, numberOfLetters = group.Count()})
                .OrderByDescending(el => el.numberOfLetters);

            string histogram = "";
            foreach (var item in letterHistogram)
            {
                histogram = histogram + $"Letter {item.letter}: {item.numberOfLetters} times" + Environment.NewLine;   
            }

            TxtFreqTable.Text = histogram;
        }
    }
}
