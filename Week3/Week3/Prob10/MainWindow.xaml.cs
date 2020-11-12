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

namespace Prob10
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

        static void SelectionSort(int[] arr)
        {
            int n = arr.Length;

            // One by one move boundary of unsorted subarray 
            for (int i = 0; i < n - 1; i++)
            {
                // Find the minimum element in unsorted array 
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (arr[j] < arr[min_idx])
                        min_idx = j;

                // Swap the found minimum element with the first 
                // element 
                int temp = arr[min_idx];
                arr[min_idx] = arr[i];
                arr[i] = temp;
            }
        }

        private int[] ConvertToIntArray(string array)
        {
            int[] numbers = array.Split(' ').Select(int.Parse).ToArray();

            return numbers;
        }

        private string ConvertToStringArray(int[] array)
        {
            string strArray = "";

            foreach (var item in array)
            {
                strArray = strArray + $"{item} ";
            }

            return strArray;
        }

        private void BtnClr_Click(object sender, RoutedEventArgs e)
        {
            TextFieldForSort.Text = "";
            TextFieldSorted.Text = "";
        }

        private void BtnSrt_Click(object sender, RoutedEventArgs e)
        {
            string strArray = TextFieldForSort.Text;

            int[] intArray = ConvertToIntArray(strArray);

            SelectionSort(intArray);

            strArray = ConvertToStringArray(intArray);

            TextFieldSorted.Text = strArray;
        }
    }
}
