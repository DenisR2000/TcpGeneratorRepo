using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using TcpGenerator;

namespace Client
{
    class ClientSender
    {
        TcpClient client;
        StreamReader sr;
        StreamWriter sw;
        const string localhost = "127.0.0.1";
        const int port = 25444;
        string Nick;
        public ClientSender()
        {
            Console.Write("Enter your nick: ");
            Nick = Console.ReadLine();
            client = new TcpClient();
            client.Connect(localhost, port);
            sr = new StreamReader(client.GetStream());
            sw = new StreamWriter(client.GetStream());
            sw.AutoFlush = true; // автоотправка стриму 
            sw.WriteLine($"{Nick}"); // сразу принимает строку с авторизированием
        }

        public void SendMessage()
        {
            Task.Run(() =>
            {
                try
                {
                    string Message = Console.ReadLine();
                    sw.WriteLine($"{Message}");
                    Message = "";
                }
                catch (Exception ex) {Console.WriteLine(ex.Message); }
            });
        }
        public void ResivMessage()
        {
            if (client.Connected)
            {
                NetworkStream ns = client.GetStream();
                BinaryFormatter bf = new BinaryFormatter();
                try
                {
                    //Quotes quote = bf.Deserialize(ns) as Quotes;
                    //Console.WriteLine(quote.Quote);
                    string quote = bf.Deserialize(ns) as string;
                    Console.WriteLine(quote);
                }
                catch { }
            }
            else { client.Close(); }
        }
    }
}
