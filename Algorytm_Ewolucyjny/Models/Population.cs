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


        

        public List<List<Town>> CreatNewGeneration()
        {
            
            var specimenElement = Agglomeration.GetAgglomeration();
            var generation = new List<List<Town>>();
            
            for (int i = 0; i < PopSize; i++)
            {
                generation.Add(new List<Town>(specimenElement));
            }
            foreach (var specimen in generation)
            {

                specimen.Shuffle();

            }

            return generation;

        }


        





    }
}
