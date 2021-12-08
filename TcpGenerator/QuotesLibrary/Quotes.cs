using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpGenerator
{
    [Serializable]
    public class Quotes
    {
        public List<string> QuotesList;
        
        public string Quote { get; set; }
        public Quotes()
        {
            QuotesList = new List<string>
            {
                "Жениться совсем не трудно, трудно быть женатым.",
                "Не умершего следует вам оплакивать, а рождающегося для тяжкой борьбы с невзгодами жизни.",
                "Свои способности человек может узнать, только попытавшись применять их на деле.",
                "Быть богатым отнюдь не означает быть счастливым, как обладать женщиной отнюдь не означает любить её.",
                "Когда все желания людей сбываются - не лучше им."
            };
            Quote = QuotesList[new Random().Next(QuotesList.Count)];
        }

        public void GetAll()
        {
            for (int i = 0; i < QuotesList.Count; i++)
            {
                Console.WriteLine($"{QuotesList[i]}");
            }
        }
    }
}
