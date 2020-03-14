using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Algorytm_Ewolucyjny.Models
{
    public static class Extensions
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

        public static void Swap<T>(this IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }


        public static double GenereteRandom()
        {

            /*using RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider();
            
            byte[] rno = new byte[9];
            rg.GetBytes(rno);
            var value = BitConverter.ToDouble(rno, 0);
            return Math.Abs(value);*/


            Random r = new Random();
            double rDouble = r.NextDouble();
            return rDouble;


        }

        public static List<T> Splice<T>(this List<T> source, int index, int count)
        {
            var items = source.GetRange(index, count);
            source.RemoveRange(index, count);
            return items;
        }

    }
}
