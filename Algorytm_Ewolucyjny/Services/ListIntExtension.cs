using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Algorytm_Ewolucyjny.Models
{
    public static class ListIntExtension
    {

        private static Random rng = new Random();

        public static void Shuffle(this List<Town> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Town value = (Town)list[k].Clone();
                list[k] = (Town)list[n].Clone();
                list[n] = value;
            }
        }


    }
}
