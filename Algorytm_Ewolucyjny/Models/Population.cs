using Algorytm_Ewolucyjny.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Algorytm_Ewolucyjny.Services
{
    class Population
    {
        public int PopSize { set; get; }

        Agglomeration Agglomeration { set; get; }
        

        public Population(int popSize, Agglomeration agglomeration)
        {
            PopSize = popSize;
            Agglomeration = agglomeration;
            
        }


        

        public bool CreatNewGeneration(ref List<List<int>> generation)
        {
            bool result = true;

           
           

            if (generation is null)
                result = false;
            else
            {

                var specimenElement = Agglomeration.GetAgglomeration();
                generation = Enumerable.Repeat(specimenElement, PopSize).ToList();

                generation.ForEach(Shuffle);

                /*foreach (var rawSpecimen in generation)
                {

                    rawSpecimen.Shuffle();

                }
               */

            }


            return result;

        }


        public static void Shuffle(List<int> list)
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
