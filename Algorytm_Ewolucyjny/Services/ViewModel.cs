using System;
using System.Collections.Generic;
using System.Text;

namespace Algorytm_Ewolucyjny.Services
{
    class ViewModel
    {

        public class ScoresC
        {

            public double BestScore { get; set; }
            public double AvarageScore { get; set; }
            public double WorstScore { get; set; }
            public double index { get; set; }

            public ScoresC(double bestScore, double avarageScore, double worstScore, double index)
            {
                BestScore = bestScore;
                AvarageScore = avarageScore;
                WorstScore = worstScore;
                this.index = index;
            }

        }

        //public List<(double BestScore, double AvarageScore, double WorstScore)> Scores { set; get; }
        public List<ScoresC> Data { set; get; }

        public ViewModel()
         {
            /*Scores = new List<(double BestScore, double AvarageScore, double WorstScore)>();
            Scores.Add((2000, 1500, 1000));
            Scores.Add((2000, 1500, 1000));
            Scores.Add((1500, 1000, 500));
            Scores.Add((1000, 500, 250));
            Scores[0].ToTuple();*/
            Data = new List<ScoresC>()
            {
                new ScoresC(2000, 1500, 1000, 0),
                new ScoresC(2000, 1500, 1000, 1), 
                new ScoresC(1500, 1000, 500,  2), 
                new ScoresC(1500, 1000, 500,  3),
                new ScoresC(500, 1500, 1000,  4)
            };

        }

        public ViewModel(List<ScoresC> Scores)
        {
            this.Data = Scores;
        }


        /*public ViewModel(List<(double BestScore, double AvarageScore, double WorstScore)> Scores)
        {
            this.Scores = Scores;
        }*/

    }
}
