using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace DataForma
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        #region Fields
        private string label1;
        private string label2;
        private string button1;
        private string button2;
        #endregion

        #region Events
        public event SaveActionEventHandler Save;
        public event SaveActionEventHandler Request;
        #endregion

        #region Constructors
        public UserControl1()
        {
            InitializeComponent();
            Label1 = "Filename";
            Label2 = "File Contents";
            Button1 = "Save";
            Button2 = "Request";
        }
        #endregion

        #region Properties
        public string Label1
        {
            get { return label1; }
            set
            {
                label1 = value;
                Lbl1.Content = value;
            }
        }
        public string Label2
        {
            get { return label2; }
            set
            {
                label2 = value;
                Lbl2.Content = value;
            }
        }
        public string Button1
        {
            get { return button1; }
            set
            {
                button1 = value;
                Btn1.Content = value;
            }
        }
        public string Button2
        {
            get { return button2; }
            set
            {
                button2 = value;
                Btn2.Content = value;
            }
        }
        #endregion

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            Save?.Invoke(this, new SaveActionEventArgs("save", TxtBx.Text, RchTxtBx.Text));
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            Request?.Invoke(this, new SaveActionEventArgs("save", TxtBx.Text, RchTxtBx.Text));
        }
    }

    public class SaveActionEventArgs : EventArgs
    {
        public string Command { get; set; }
        public string FirstTextBox { get; set; }
        public string SecondTextBox { get; set; }

        public SaveActionEventArgs(string command, string firstTextBox, string secondTextBox)
        {
            Command = command;
            FirstTextBox = firstTextBox;
            SecondTextBox = secondTextBox;
        }
    }

    public delegate void SaveActionEventHandler(object o, SaveActionEventArgs e);

    public class RequestActionEventArgs : EventArgs
    {
        public string Command { get; set; }
        public string FirstTextBox { get; set; }
        public string SecondTextBox { get; set; }

        public RequestActionEventArgs(string command, string firstTextBox, string secondTextBox)
        {
            Command = command;
            FirstTextBox = firstTextBox;
            SecondTextBox = secondTextBox;
        }
    }

    public delegate void RequestActionEventHandler(object o, SaveActionEventArgs e);
}