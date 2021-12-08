using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (LoginsContext db = new LoginsContext())
            //{
            //    Logins login1 = new Logins { Name = "Denis" };
            //    Logins login2 = new Logins {  Name = "Roman" };
            //    Password password1 = new Password { PasswordNumber = "1234" };
            //    Password password2 = new Password { PasswordNumber = "4321" };
            //    db.Logins.Add(login1);
            //    db.Logins.Add(login2);
            //    db.Password.Add(password1);
            //    db.Password.Add(password2);
            //    db.SaveChanges();
            //}
            //Console.WriteLine("Created");
            //Console.Write("Enter your login: ");
            //string Login = "Denis";
            //string test = Console.ReadLine();
            //if (test == Login)
            {
                ClientSender client = new ClientSender();
                while (true)
                {
                    client.SendMessage();
                    client.ResivMessage();
                }
            }
           // else
            {
           //     Console.WriteLine("Vrong login!");
            }

            Console.ReadKey();
        }
    }
}
