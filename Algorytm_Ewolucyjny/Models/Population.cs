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


        

        public bool CreatNewGeneration(List<List<Town>> generation)
        {
            bool result = true;

           
           

            if (generation is null)
                result = false;
            else
            {

                var specimenElement = Agglomeration.GetAgglomeration();
                generation = Enumerable.Repeat(specimenElement, PopSize).ToList();

                

                foreach (var rawSpecimen in generation)
                {

                    rawSpecimen.Shuffle();

                }
               

            }


            return result;

        }


        





    }
}
