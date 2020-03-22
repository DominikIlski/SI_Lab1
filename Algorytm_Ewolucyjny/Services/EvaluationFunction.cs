using Algorytm_Ewolucyjny.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorytm_Ewolucyjny.Services
{
    class  EvaluationFunction
    {
        
        public TownType TownType { private set; get; }

        public EvaluationFunction(TownType townType)
        {
            TownType = townType;


        }

        public void EvaluateIndividual(Individual individual)
        {
            var chromosome = individual.Chromosome;         
            double score = 0;
            for (int i = 1; i < chromosome.Count; i++)
            {
                score += CountDistance(chromosome[i - 1], chromosome[i]);
            }
            score += CountDistance(chromosome[chromosome.Count - 1], chromosome[0]);
            individual.Score = score;
        }


        public double CountDistance(Town current, Town next)
        {
            double distance = 0;

            

            if (TownType == TownType.EUC_2D)
                distance = CalculateEuc2D(current, next);

            if (TownType == TownType.GEO)
                distance = CalcualteGeo(current, next);


            return distance;

        }

        private double CalculateEuc2D(Town current, Town next) =>
           Math.Sqrt(Math.Pow((current.X - next.X), 2) + Math.Pow((current.Y - next.Y), 2));

        private double CalcualteGeo(Town current, Town next)
        {

            var deg = Math.Floor(current.X);
            var min = current.X - deg;
            var latitudeI = (Math.PI * (deg + (5.0 * min) / 3.0)) / 180.0;

            deg = Math.Floor(current.Y);
            min = current.Y - deg;
            var longitudeI = (Math.PI * (deg + (5.0 * min) / 3.0)) / 180.0;

            deg = Math.Floor(next.X);
            min = next.X - deg;
            var latitudeJ = (Math.PI * (deg + (5.0 * min) / 3.0)) / 180.0;

            deg = Math.Floor(next.Y);
            min = next.Y - deg;
            var longitudeJ = (Math.PI * (deg + (5.0 * min) / 3.0)) / 180.0;

            var RRR = 6378.388;
            var q1 = Math.Cos(longitudeI - longitudeJ);
            var q2 = Math.Cos(latitudeI - latitudeJ);
            var q3 = Math.Cos(latitudeI + latitudeJ);
            return Math.Round(
                RRR * Math.Acos(0.5 * ((1.0 + q1) * q2 - (1.0 - q1) * q3)) + 1.0);

        }

        

    }
}
