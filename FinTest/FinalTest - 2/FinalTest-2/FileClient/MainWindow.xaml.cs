using Microsoft.Win32;
using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows;
using Test;

namespace FileClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //MultiThread Client 
        private Thread processingThread;
        private NetworkStream output;
        private BinaryWriter sender;
        private BinaryReader receiver;

        public MainWindow()
        {
            InitializeComponent();
            UsrCntrl.Label1 = "Filename";
            UsrCntrl.Label2 = "File Contents";
            UsrCntrl.Button1 = "Save";
            UsrCntrl.Button2 = "Request";

            UsrCntrl.Request += OnRequest;
            UsrCntrl.Save += OnSave;
        }

        //Request Action Client
        public void RequestActionClient(Test.RequestActionEventArgs e)
        {
            try
            {
                DisplayMessage("Attempting connection\r\n");

                TcpClient client = new TcpClient();
                client.Connect("127.0.0.1", 50000);

                output = client.GetStream();
                sender = new BinaryWriter(output);
                receiver = new BinaryReader(output);

                DisplayMessage("\r\nConnection to server successfull!\r\n");

                try
                {
                    sender.Write(e.Command);
                    string serverRespondToCommand = receiver.ReadString();

                    sender.Write(e.FirstTextBox);
                    string serverRespondToFileName = receiver.ReadString();

                    sender.Write(e.SecondTextBox);
                    string serverRespondToFileContent = receiver.ReadString();

                    UsrCntrl.RichTextBox = serverRespondToFileName;
                }
                catch (Exception)
                {
                    System.Environment.Exit(System.Environment.ExitCode);
                }

                sender?.Close();
                receiver?.Close();
                output?.Close();
                client?.Close();

                DisplayMessage("\r\nConnection closed\r\n");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString(), "Connection Error", MessageBoxButton.OK, MessageBoxImage.Error);
                System.Environment.Exit(System.Environment.ExitCode);
            }
        }

        //Save Action Client
        public void SaveActionClient(SaveActionEventArgs e)
        {
            try
            {
                DisplayMessage("Attempting connection\r\n");

                TcpClient client = new TcpClient();
                client.Connect("127.0.0.1", 50000);

                output = client.GetStream();
                sender = new BinaryWriter(output);
                receiver = new BinaryReader(output);

                DisplayMessage("\r\nConnection to server successfull!\r\n");

                try
                {
                    sender.Write(e.Command);

                    sender.Write(e.FirstTextBox);
                    sender.Write(e.SecondTextBox);

                    string serverRespondToFileName = receiver.ReadString();
                    DisplayMessage("\r\n" + serverRespondToFileName);
                    
                    serverRespondToFileName = receiver.ReadString();
                    DisplayMessage("\r\n" + serverRespondToFileName);
                }
                catch (Exception)
                {
                    //System.Environment.Exit(System.Environment.ExitCode);
                }

                sender?.Close();
                receiver?.Close();
                output?.Close();
                client?.Close();

                DisplayMessage("\r\nConnection closed\r\n");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString(), "Connection Error", MessageBoxButton.OK, MessageBoxImage.Error);
                System.Environment.Exit(System.Environment.ExitCode);
            }
        }

        //Display message
        private void DisplayMessage(string message)
        {
            if (!TxtDialog.Dispatcher.CheckAccess())
            {
                TxtDialog.Dispatcher.Invoke(new Action(() => TxtDialog.Text += message));
            }
            else
            {
                TxtDialog.Text += message;
            }
        }

        //Window_Closing - Closing=This
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
        }

        public void OnRequest(object o, RequestActionEventArgs e)
        {
            processingThread = new Thread(new ThreadStart(() => RequestActionClient(e)));
            processingThread.Start();
        }

        public void OnSave(object o, SaveActionEventArgs e)
        {
            processingThread = new Thread(new ThreadStart(() => SaveActionClient(e)));
            processingThread.Start();
        }
    }
}
