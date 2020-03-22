using System;
using System.Collections.Generic;
using System.Text;

namespace Algorytm_Ewolucyjny.Models.Mutations
{
    class Swap : MutationAlgorithm
    {


        public override Individual Mutate(Individual individual, double Pm)
        {
            var random1 = Extensions.GenereteRandom();
            var random2 = Extensions.GenereteRandom();
            Individual newIndiv = individual;
            var newSpecimen = individual;
            if(random1 < Pm)
            {
                newSpecimen = new Individual(individual.Chromosome);

                random1 *= individual.Chromosome.Count;
                random2 *= individual.Chromosome.Count;

                newSpecimen.Chromosome.Swap((int)random1, (int)random2);

                newIndiv = new Individual(newSpecimen.Chromosome);

            }

            return newIndiv;
        }
            
            


    }
}
