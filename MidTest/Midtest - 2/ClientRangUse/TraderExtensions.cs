using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientRang;

namespace ClientRangUse
{
    public static class TraderExtensions
    {
        /// <summary>
        /// Upgrade the client's status
        /// </summary>
        /// <param name="trader"></param>
        /// <param name="client"></param>
        public static void UpgradeRules(this Trader trader, IUpgradable client)
        {
            if(client is GoldClient goldenClient)
            {
                var sumOfAllPurchases = goldenClient.Purchases.Sum(purchase => purchase);
                goldenClient.Credit += sumOfAllPurchases * 0.03M;
            }
            else if(client is Client basicClient)
            {
                if(55 <= basicClient.AvergePurchases())
                {
                    trader[basicClient.ID] = new GoldClient(basicClient.Purchases, 0.0M);
                }
            }
        }
    }
}