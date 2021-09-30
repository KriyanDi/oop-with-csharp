using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows;

namespace FileServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //MultiThread Server
        private Socket connection;
        private Thread processingThread;
        private Dictionary<Thread, BinaryWriter> users;
        private Dictionary<Thread, Socket> connections;
        
        public MainWindow()
        {
            InitializeComponent();
            InitializeMultiServerComponents();
        }

        //Initialize the multithread server components
        private void InitializeMultiServerComponents()
        {
            users = new Dictionary<Thread, BinaryWriter>();
            connections = new Dictionary<Thread, Socket>();
            processingThread = new Thread(new ThreadStart(RunServer));
            processingThread.Start();
        }

        //Run server
        public void RunServer()
        {
            try
            {
                IPAddress local = IPAddress.Parse("127.0.0.1");

                TcpListener listener;
                listener = new TcpListener(local, 50000);
                listener.Start();

                while (true)
                {
                    DisplayMessage("Waiting for connection\r\n");
                   
                    connection = listener.AcceptSocket();
                    DisplayMessage("Connection received.\r\n");
                    ThreadPool.QueueUserWorkItem(RunClient, connection);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        //Run client
        public void RunClient(object socket)
        {
            Socket connection = (Socket)socket;
            NetworkStream socketStream = new NetworkStream(connection);
            BinaryWriter sender = new BinaryWriter(socketStream);
            BinaryReader receiver = new BinaryReader(socketStream);

            users.Add(Thread.CurrentThread, sender);
            connections.Add(Thread.CurrentThread, connection);

            sender.Write("SERVER> Connection successful!");

            string operation;

            do
            {
                try
                {
                    operation = receiver.ReadString();

                    if (operation == "request")
                    {
                        users[Thread.CurrentThread].Write("Send filename");
                        string fileName = receiver.ReadString();

                        if (File.Exists(fileName))
                        {
                            string fileContent = File.ReadAllText(fileName);
                            users[Thread.CurrentThread].Write(fileContent);
                        }
                        else
                        {
                            users[Thread.CurrentThread].Write("\r\nSERVER> File doesn't exist\r\n");
                        }
                    }
                    else
                    if (operation == "save")
                    {
                        string fileName = receiver.ReadString();
                        string content = receiver.ReadString();

                        DisplayMessage("\r\n" + operation + "\r\n" + fileName + "\r\n" + content);

                        File.WriteAllText("C:\\Users\\Kristiyan Dimitrov.DESKTOP-AO174QD\\Desktop\\" + fileName, content);
                        //users[Thread.CurrentThread].Write("\r\nSERVER> File saved successfuly!\r\n");
                        sender.Write("\r\nSERVER> File saved successfuly!\r\n");
                    }

                    connections[Thread.CurrentThread].Close();
                    DisplayMessage("\r\nConnection Closed\r\n");
                }
                catch (Exception)
                {
                    break;
                }
            } while (connection.Connected);

            users.Remove(Thread.CurrentThread);
            connections.Remove(Thread.CurrentThread);

            sender?.Close();
            receiver?.Close();
            socketStream?.Close();
            connection?.Close();
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

        //Window close
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
        } 
    }
}
