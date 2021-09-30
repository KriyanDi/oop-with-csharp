using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace TextChangeLib
{
    /// <summary>
    /// Interaction logic for TextGenerator.xaml
    /// </summary>
    public partial class TextGenerator : UserControl
    {
        public event TextChangeEventHandler TextChange;
        public List<string> codes;

        public TextGenerator()
        {
            InitializeComponent();

            codes = new List<string>();
        }

        private void BtnWrtToFile_Click(object sender, RoutedEventArgs e)
        {
            bool? result;
            string fileName;

            OpenFileDialog file = new OpenFileDialog();

            result = file.ShowDialog();
            fileName = file.FileName;

            if (result.HasValue)
            {
                if (fileName != string.Empty && File.Exists(fileName))
                {
                    File.AppendAllLines(fileName, codes);
                }
                else
                {
                    File.WriteAllLines(Directory.GetCurrentDirectory() + "tempName.txt", codes);
                }
            }
        }

        private void BtnRdFromFile_Click(object sender, RoutedEventArgs e)
        {
            bool? result;
            string fileName;

            OpenFileDialog file = new OpenFileDialog();

            result = file.ShowDialog();
            fileName = file.FileName;

            if (result.HasValue)
            {
                if (fileName != string.Empty && File.Exists(fileName))
                {
                    codes = File.ReadAllLines(fileName).ToList();
                }
            }
        }

        private void BtnQt_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void BtnGenRndCode_Click(object sender, RoutedEventArgs e)
        {
            char[] bulgarianAlphabet = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'ь', 'Ю', 'Я' };

            Random random = new Random();
            string randomGeneratedLetters = "";
            for (int i = 0; i < 50; i++)
            {
                randomGeneratedLetters += bulgarianAlphabet[random.Next(0, 30)].ToString();
            }

            codes.Add(randomGeneratedLetters);

            TextChange?.Invoke(this, new TextChangeEventArgs(codes));
        }
    }
}
