using System;
using System.Windows;
using System.Windows.Controls;

namespace Prob2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double input1, input2, result;

        private enum Operation
        { PLUS, MINUS, MULT, DIV, NO_OPERATION };

        private Operation operation;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void BtnNumber_Click(object sender, RoutedEventArgs e)
        {
            string entry = (string)((Button)sender).Content;

            if (TextField.Text == "0")
            {
                if (entry == ".")
                {
                    TextField.Text = TextField.Text + ".";
                }
                else
                {
                    TextField.Text = entry;
                }
            }
            else
            {
                if (entry == "." && TextField.Text.Contains("."))
                {
                    return;
                }

                TextField.Text = TextField.Text + entry;
            }
        }

        private void BtnAritmeticOperation_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TextField.Text, out input1))
            {
                TextField.Text = "0";

                switch ((string)((Button)sender).Content)
                {
                    case "+":
                        operation = Operation.PLUS;
                        break;
                    case "-":
                        operation = Operation.MINUS;
                        break;
                    case "*":
                        operation = Operation.MULT;
                        break;
                    case "/":
                        operation = Operation.DIV;
                        break;
                    default:
                        operation = Operation.NO_OPERATION;
                        break;
                }
            }
            else
            {
                MessageBox.Show($"{TextField.Text} is incorrect! Please correct the number!");
            }
        }

        private void BtnEquals_Click(object sender, RoutedEventArgs e)
        {
            if (operation != Operation.NO_OPERATION)
            {
                if (double.TryParse(TextField.Text, out input2))
                {
                    switch (operation)
                    {
                        case Operation.PLUS:
                            result = input1 + input2;
                            break;
                        case Operation.MINUS:
                            result = input1 - input2;
                            break;
                        case Operation.MULT:
                            result = input1 * input2;
                            break;
                        case Operation.DIV:
                            result = input1 / input2;
                            break;
                        case Operation.NO_OPERATION:
                            break;
                        default:
                            break;
                    }

                    TextField.Text = "" + result;
                    input1 = 0;
                    input2 = 0;
                    result = 0;
                    operation = Operation.NO_OPERATION;
                }
                else
                {
                    MessageBox.Show($"{TextField.Text} is incorrect! Please correct the number!");
                }
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TextField.Text = "0";
        }

        private void BtnClearAll_Click(object sender, RoutedEventArgs e)
        {
            input1 = 0;
            input2 = 0;
            operation = Operation.NO_OPERATION;
            TextField.Text = "0";
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void BtnMathFunction_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TextField.Text, out input1))
            {
                switch ((string)((Button)sender).Content)
                {
                    case "EXP":
                        result = Math.Exp(input1);
                        break;
                    case "SQRT":
                        result = Math.Sqrt(input1);
                        break;
                    case "SIN":
                        result = Math.Sin(input1);
                        break;
                    case "COS":
                        result = Math.Cos(input1);
                        break;
                    case "LOG":
                        result = Math.Log(input1);
                        break;
                    case "1/X":
                        result = 1 / input1;
                        break;
                    default:
                        break;
                }

                TextField.Text = "" + result;
                input1 = 0;
            }
            else
            {
                MessageBox.Show($"{TextField.Text} is incorrect! Please correct the number!");
            }

        }
    }
}
