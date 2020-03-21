using Algorytm_Ewolucyjny.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorytm_Ewolucyjny.Models.Selections
{
    class Roulette : SelectionAlgorithm
    {

        public override(List<Town> geneticCode , double? score) Selection(List<(List<Town> geneticCode , double? score)> population)
        {

           (List<Town> geneticCode , double? score) winner = new(List<Town> geneticCode , double? score)();

            var sumFitness = population.Sum(specimen => 1 / Math.Pow(EvaluationFunction.EvaluateSpecimen(specimen), 10));


            var random = Extensions.GenereteRandom();

            random *= sumFitness;

            double sum = 0;
                 
            foreach (var specimen in population)
            {

                sum += 1 / Math.Pow(EvaluationFunction.EvaluateSpecimen(specimen), 10);

                if (sum >= random)
                {
                    winner = specimen;
                    break;
                }
                

            }

            

            return winner.Count == 0 ? throw new Exception("There was noone selected") : winner;
        }

    }
}
