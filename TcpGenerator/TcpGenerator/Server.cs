using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpGenerator
{
   
    class Server
    {
        TcpListener listener;
        const int port = 25444;
        const string localhost = "127.0.0.1";
        int count = 1;
        //List<string> QuotesList = new List<string>()
        //{
        //    "Жениться совсем не трудно, трудно быть женатым.",
        //    "Не умершего следует вам оплакивать, а рождающегося для тяжкой борьбы с невзгодами жизни.",
        //    "Свои способности человек может узнать, только попытавшись применять их на деле.",
        //    "Быть богатым отнюдь не означает быть счастливым, как обладать женщиной отнюдь не означает любить её.",
        //    "Когда все желания людей сбываются - не лучше им."
        //};
        public Server()
        {
            listener = new TcpListener(new IPEndPoint(IPAddress.Parse(localhost), port));
        }

        public string GetQuotes()
        {
            string[] readText = File.ReadAllLines("Quotes.txt", Encoding.UTF8);
            string quote = readText[new Random().Next(readText.Length)];
            return quote;
        }
        public void Start()
        {
            int limitClient = 0; //лимит клиентов 
            listener.Start();
            Console.WriteLine("Server started.");
            while(true)
            {
                try
                {
                    TcpClient client = listener.AcceptTcpClient();
                    Task.Factory.StartNew(() =>
                    {
                        int limit = 0;
                        StreamReader sr = new StreamReader(client.GetStream());
                        {
                            var line = sr.ReadLine();
                            Console.WriteLine($"Client number {count}\nName: {line} connected " + DateTime.Now);
                            count++;
                            BinaryFormatter bf = new BinaryFormatter();
                            if (limitClient > 3) //проверка на ограничение клиентов 
                            {
                                string error = "Sorry!\nThe Serever is overwhelmed.\nTry a little later.";
                                bf.Serialize(client.GetStream(), error);
                                Console.WriteLine("Client disconnected");
                                
                                limitClient--;
                                client.Close();
                            }
                            else // если клиентов меньше 3 
                            {
                                limitClient++;
                                
                                Task.Factory.StartNew(() =>
                                {
                                    while (client.Connected)
                                    {                                       
                                        try
                                        {
                                            var message = sr.ReadLine();

                                            if (limit > 5)
                                            {
                                                string messageQuots = "You have exceeded the limit";
                                                bf.Serialize(client.GetStream(), messageQuots);
                                                Console.WriteLine("Client disconnected");
                                                limitClient--;
                                                client.Close();
                                            }
                                            else
                                            {
                                                string quote = GetQuotes();
                                                bf.Serialize(client.GetStream(), quote);
                                                quote = "";
                                                Console.WriteLine($"Limit {limit}");
                                                limit++;
                                                Console.WriteLine($"Count limit {limit}");
                                            }
                                        }catch { }                                       
                                    }
                                });
                            }
                        }
                    });
                }
                catch { }
            }
        }

    }
}
