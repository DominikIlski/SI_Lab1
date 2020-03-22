using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorytm_Ewolucyjny.Models.Crossings
{
    class Ordered : CrossingAlgorithm
    {

        public override (Individual O1, Individual O2) Crossover(Individual P1, Individual P2) 
        {

            var specimenSize = P1.Chromosome.Count;
            
            
            var randomNumber1 = Extensions.GenereteRandom();
            var randomNumber2 = Extensions.GenereteRandom();
            
            var minH = Math.Min(randomNumber1, randomNumber2) * specimenSize;
            var maxH = Math.Max(randomNumber1, randomNumber2) * specimenSize;

            int min = (int) minH ;
            int max = (int) maxH ;

            

            var germ1 = P1.Chromosome.GetRange(min, max-min);
            var P1indexes = germ1.Select((town) => town.Numer).ToList();
            var germ2 = P2.Chromosome.FindAll(town => !P1indexes.Contains(town.Numer));
            var child1 = germ2.Take(min).ToList();
            
            child1.AddRange(germ1);
           
            child1.AddRange(germ2.Skip(min));
            


            var child2 = germ1.Take(min).ToList();
            child2.AddRange(germ2);
            child2.AddRange(germ1.Skip(min));

            if (child1.Count != child2.Count) throw new Exception("childs lenght does not match");


            return (new Individual(child1), new Individual(child2));


        }





    }
}
