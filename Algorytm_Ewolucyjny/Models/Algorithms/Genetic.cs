using Algorytm_Ewolucyjny.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorytm_Ewolucyjny.Models.Algorithms
{
    class Genetic : Algorithm
    {
       
        SelectionAlgorithm SelectionAlgorithm { set; get; }
        public List<(double BestScore, double AvarageScore, double WorstScore)> Scores { set; get; }
        CrossingAlgorithm CrossingAlgorithm;
        MutationAlgorithm MutationAlgorithm;
        int NumberOfGenerations;
        public Genetic(double Pm, double Px, SelectionAlgorithm selection, CrossingAlgorithm crossingAlgorithm, MutationAlgorithm mutationAlgorithm, int numberOfGenerations)
        {

            this.Pm = Pm;
            this.Px = Px;
            SelectionAlgorithm = selection;
            
            CrossingAlgorithm = crossingAlgorithm;
            NumberOfGenerations = numberOfGenerations;
            MutationAlgorithm = mutationAlgorithm;
            Scores = new List<(double BestScore, double AvarageScore, double WorstScore)>();
        }

        public override void Evaluation(EvaluationFunction evaluationFunction, Population population) 
        {

            EvaluationFunction = evaluationFunction;
            SelectionAlgorithm.EvaluationFunction = EvaluationFunction;
            Generation = new List<List<Town>>(population.CreatNewGeneration());
            Scores = MakeGenetic(Generation);
            FinalScore = Scores;

        }


        public List<(double BestScore, double AvarageScore, double WorstScore)> MakeGenetic(List<List<Town>> generation)
        {
            var newPopulation = new List<List<Town>>();
            var finalScoreList = new List<(double BestScore, double AvarageScore, double WorstScore)>();
            double BestScore;
            double WorstScore;
            var ScoreList = new HashSet<double>();
            double AvarageScore;
            while (NumberOfGenerations>0)
            {
                BestScore = Double.MaxValue;
                WorstScore = 0;
                
                while(newPopulation.Count < generation.Count)
                {

                    var P1 = SelectionAlgorithm.Selection(generation);
                    var P2 = SelectionAlgorithm.Selection(generation);
                    List<Town> O1;
                    
                    double randomNumber = Extensions.GenereteRandom();

                    if (randomNumber < Px)
                        O1 = CrossingAlgorithm.Crossover(P1, P2);
                    else
                        O1 = P1;
                    O1 = MutationAlgorithm.Mutate(O1, Pm);
                    

                    newPopulation.Add(O1);
                   
                    var O1Score = EvaluationFunction.EvaluateSpecimen(O1);
                   

                    BestScore = O1Score < BestScore ? O1Score : BestScore;
                  
                    WorstScore = O1Score > WorstScore ? O1Score : WorstScore;
                    
                    ScoreList.Add(O1Score);
                   
                    

                }
                generation = new List<List<Town>>(newPopulation);
                AvarageScore = Queryable.Average(ScoreList.AsQueryable());
                finalScoreList.Add((BestScore, AvarageScore,WorstScore));
                newPopulation.Clear();
                NumberOfGenerations--;
            }




            return finalScoreList;
        }





    }
}
