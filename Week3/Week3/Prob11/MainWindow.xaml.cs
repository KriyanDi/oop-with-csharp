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

namespace Prob11
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

        void Merge(int[] arr, int left, int m, int right)
        {
            // Find sizes of two  
            // subarrays to be merged 
            int n1 = m - left + 1;
            int n2 = right - m;

            // Create temp arrays 
            int[] Left = new int[n1];
            int[] Right = new int[n2];
            int i, j;

            // Copy data to temp arrays 
            for (i = 0; i < n1; ++i)
            {
                Left[i] = arr[left + i];
            }

            for (j = 0; j < n2; ++j)
            {
                Right[j] = arr[m + 1 + j];
            }

            i = 0;
            j = 0;

            int k = left;
            while (i < n1 && j < n2)
            {
                if (Left[i] <= Right[j])
                {
                    arr[k] = Left[i];
                    i++;
                }
                else
                {
                    arr[k] = Right[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                arr[k] = Left[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                arr[k] = Right[j];
                j++;
                k++;
            }
        }

        void Mergesort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int m = (left + right) / 2;

                Mergesort(arr, left, m);
                Mergesort(arr, m + 1, right);

                Merge(arr, left, m, right);
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

            Mergesort(intArray, 0, intArray.Length - 1);

            strArray = ConvertToStringArray(intArray);

            TextFieldSorted.Text = strArray;
        }
    }
}
