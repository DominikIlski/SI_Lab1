using System;
using System.Collections.Generic;
using System.Text;

namespace Algorytm_Ewolucyjny.Models.Mutations
{
    class Inversion : MutationAlgorithm
    {



        public Individual Mutate(Individual individual)
        {
            var newIndividual = new Individual(individual.Chromosome);

            var countOfChromosome = individual.Chromosome.Count;
            var firstIndex =  (int)Extensions.GenereteRandom() * countOfChromosome;
            var secondIndex = (int)Extensions.GenereteRandom() * countOfChromosome;


            if (firstIndex > secondIndex)
            {
                var temp = firstIndex;
                firstIndex = secondIndex;
                secondIndex = temp;
            }

            var tempList = new List<Town>();

            for (var i = firstIndex; i <= secondIndex; i++) 
                tempList.Add(newIndividual.Chromosome[i]);

            tempList.Reverse();

            for (var i = firstIndex; i <= secondIndex; i++) 
                newIndividual.Chromosome[i] = tempList[i - firstIndex];

            return newIndividual;
        }

    }
}
