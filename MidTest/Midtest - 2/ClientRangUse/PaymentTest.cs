using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ClientRang;

namespace ClientRangUse
{
    public class PaymentTest
    {
        static void Main(string[] args)
        {
            //a)
            List<Client> clients = new List<Client> { new Client(), new Client(), new Client() };

            //b)
            clients.Add(new GoldClient());
            clients.Add(new GoldClient());
            clients.Add(new GoldClient());

            //c)
            Trader trader = new Trader(clients);
            
            //d)
            trader.SellProducts();
            
            //e
            Console.WriteLine("BEFORE CLIENTS UPGRADE:");
            Console.WriteLine(trader);
            foreach (var client in trader.Clients)
            {
                ((IUpgradable)client).Upgrade(new Action<IUpgradable>(trader.UpgradeRules));
            }

            //d)
            Console.WriteLine("AFTER CLIENTS UPGRADE:");
            Console.WriteLine(trader);
            
        }
    }
}