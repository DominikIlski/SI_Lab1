﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Algorytm_Ewolucyjny.Models
{
    public static class ListIntExtension
    {

        public static void Shuffle(this List<int> list)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                int value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}