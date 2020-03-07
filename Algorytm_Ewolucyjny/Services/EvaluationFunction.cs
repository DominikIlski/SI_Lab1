using Algorytm_Ewolucyjny.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorytm_Ewolucyjny.Services
{
    class  EvaluationFunction
    {
        
      
        public EvaluationFunction()
        {
            
        }

        public double EvaluateSpecimen(List<Town> specimen)
        {
            double score = 0;
            for (int i = 1; i < specimen.Count; i++)
            {
                score += CountDistance(specimen[i - 1], specimen[i]);
            }
            return score;
        }


        private double CountDistance(Town current, Town next)
        {

            var minX = Math.Min(current.X, next.X);
            var maxX = Math.Max(current.X, next.X);

            var minY = Math.Min(current.Y, next.Y);
            var maxY = Math.Max(current.Y, next.Y);

            var distance = Math.Sqrt(Math.Pow((maxX - minX), 2) + Math.Pow((maxY - minY), 2));

            return distance;

        }



    }
}
