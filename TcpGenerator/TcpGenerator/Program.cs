using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            new Server().Start();
            //Quotes quotes = new Quotes();
            //string message = quotes.GetRandomQuotes();
            //Console.WriteLine(message);
            Console.ReadKey();
        }
    }
}
