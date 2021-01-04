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
using Prob1;

namespace Prob1_WPF
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

        private void btnCompare_Click(object sender, RoutedEventArgs e)
        {
            double[] point1 = new double[] { Convert.ToDouble(frstRectX.Text), Convert.ToDouble(frstRectY.Text) };
            double[] point2 = new double[] { Convert.ToDouble(scndRectX.Text), Convert.ToDouble(scndRectY.Text) };

            Rectangle rectangle1 = new Rectangle(
                new Point<double>(point1),
                Convert.ToDouble(frstRectL.Text),
                Convert.ToDouble(frstRectW.Text));

            Rectangle rectangle2 = new Rectangle(
                new Point<double>(new double[] { Convert.ToDouble(scndRectX.Text), Convert.ToDouble(scndRectY.Text) }),
                Convert.ToDouble(scndRectL.Text),
                Convert.ToDouble(scndRectW.Text));

            string result = "";

            if (rectangle1.Perimeter() > rectangle2.Perimeter())
            {
                result = "Rectangle1 has bigger Perimeter and ";
            }
            else if (rectangle1.Perimeter() == rectangle2.Perimeter())
            {
                result = "Rectangles has the same Perimeter and ";
            }
            else
            {
                result = "Rectangle2 has bigger Perimeter and ";
            }

            if (rectangle1.Area() > rectangle2.Area())
            {
                result += "Rectangle1 has bigger Area";
            }
            else if (rectangle1.Area() == rectangle2.Area())
            {
                result += "Rectangles has the same Area";
            }
            else
            {
                result += "Rectangle2 has bigger Area";
            }

            rslt.Text = result;
        }
    }
}
