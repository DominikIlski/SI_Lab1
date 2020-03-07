using Algorytm_Ewolucyjny.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorytm_Ewolucyjny.Services
{
    class  EvaluationFunction
    {
        Agglomeration Agglomeration { set; get; }
      
        public EvaluationFunction(Agglomeration agglomeration)
        {
            Agglomeration = agglomeration;
        }

        public double EvaluateSpecimen(List<int> specimen)
        {
            double score = 0;
            for (int i = 1; i < specimen.Count; i++)
            {
                score += CountDistance(specimen[i - 1], specimen[i]);
            }
            return score;
        }


        private double CountDistance(int current, int next)
        {
            var agglomeration = Agglomeration.Towns;

            var currentTown = agglomeration.Find(t => t.Numer == current) ?? new Town();
            var nextTown = agglomeration.Find(t => t.Numer == next) ?? new Town();
            HashSet<Town> test = new HashSet<Town>();

            


            var minX = Math.Min(currentTown.X, nextTown.X);
            var maxX = Math.Max(currentTown.X, nextTown.X);

            var minY = Math.Min(currentTown.Y, nextTown.Y);
            var maxY = Math.Max(currentTown.Y, nextTown.Y);

            var distance = Math.Sqrt(Math.Pow((maxX - minX), 2) + Math.Pow((maxY - minY), 2));

            return distance;

        }



    }
}
