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

namespace Prob9
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

        static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];

            // index of smaller element 
            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                // If current element is smaller  
                // than the pivot 
                if (arr[j] < pivot)
                {
                    i++;

                    // swap arr[i] and arr[j] 
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            // swap arr[i+1] and arr[high] (or pivot) 
            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            return i + 1;
        }

        static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {

                int pi = Partition(arr, low, high);

                // Recursively sort elements before 
                // partition and after partition 
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
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

            QuickSort(intArray, 0, intArray.Length -1);

            strArray = ConvertToStringArray(intArray);

            TextFieldSorted.Text = strArray;
        }
    }
}
