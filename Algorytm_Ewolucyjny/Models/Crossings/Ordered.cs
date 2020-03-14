using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorytm_Ewolucyjny.Models.Crossings
{
    class Ordered : CrossingAlgorithm
    {

        public override List<Town> Crossover(List<Town> P1, List<Town> P2) 
        {

            var specimenSize = P1.Count;
            
            
            var randomNumber1 = Extensions.GenereteRandom();
            var randomNumber2 = Extensions.GenereteRandom();
            
            var min = (int)Math.Min(randomNumber1, randomNumber2);
            var max = (int)Math.Max(randomNumber1, randomNumber2);

            min *= specimenSize;
            max *= specimenSize;

            if (min == max)
            {
                min = specimenSize / 2;
                max = min++;
            }

            var germ1 = P1.GetRange(min, max-min);
            var P1indexes = germ1.Select((town) => town.Numer).ToList();
            var germ2 = P2.FindAll(town => !P1indexes.Contains(town.Numer));
            var child = germ2.Take(min).ToList();
            child.AddRange(germ1);
            child.AddRange(germ2.Skip(min));

            
            return child;


        }





    }
}
