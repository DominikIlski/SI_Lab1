using Algorytm_Ewolucyjny.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //remebmer to test if makeMixedWorks
            Generation = new List<Individual>(population.CreateMixedPopulation());
            Scores = MakeGenetic(Generation);
            FinalScore = Scores;

        }


        public List<(double BestScore, double AvarageScore, double WorstScore)> MakeGenetic(List<Individual> generation)
        {
            var newPopulation = new List<Individual>();
            var finalScoreList = new List<(double BestScore, double AvarageScore, double WorstScore)>();
            double BestScore;
            double WorstScore;
            var ScoreList = new List<double>();
            double AvarageScore;
            Individual? bestIndiv = null;
            while (NumberOfGenerations>0)
            {
                BestScore = Double.MaxValue;
                WorstScore = 0;

                /*if (bestIndiv != null)
                    generation.Add(bestIndiv);*/

                while(newPopulation.Count < generation.Count)
                {

                    var P1 = SelectionAlgorithm.Selection(generation);
                    var P2 = SelectionAlgorithm.Selection(generation);
                    Individual O1;
                    Individual O2;

                    double randomNumber = Extensions.GenereteRandom();

                    if (randomNumber < Px)
                        (O1, O2)  = CrossingAlgorithm.Crossover(P1, P2);
                    else
                        (O1, O2) = (P1, P2);

                    O1 = MutationAlgorithm.Mutate(O1, Pm);
                    O2 = MutationAlgorithm.Mutate(O2, Pm);

                    if (!O1.Score.HasValue)
                        EvaluationFunction.EvaluateIndividual(O1);


                    if (!O2.Score.HasValue)
                        EvaluationFunction.EvaluateIndividual(O2);

                    


                    newPopulation.Add(new Individual(O1));
                    newPopulation.Add(new Individual(O2));

                    if (!O1.Score.HasValue) throw new Exception("Problem with scores");
                    if (!O2.Score.HasValue) throw new Exception("Problem with scores");


                    BestScore = AssumeBestScore(O1, BestScore);
                    BestScore = AssumeBestScore(O2, BestScore);


                    WorstScore = AssumeWorstScore(O1, WorstScore);
                    WorstScore = AssumeWorstScore(O2, WorstScore);



                    if(BestScore  is 0) throw new Exception("Problem with scores");
                    if(WorstScore is 0) throw new Exception("Problem with scores");

                    ScoreList.Add(O1.Score ?? 0);
                    ScoreList.Add(O2.Score ?? 0);



                }

                generation = new List<Individual>(newPopulation);
                AvarageScore = Queryable.Average(ScoreList.AsQueryable());
                finalScoreList.Add((BestScore, AvarageScore, WorstScore));
                newPopulation.Clear();
                ScoreList.Clear();
                NumberOfGenerations--;

            }




            return finalScoreList;
        }


        private double AssumeBestScore(Individual indiv, double BestScore) => (indiv.Score ?? 0) < BestScore? (indiv.Score ?? 0) : BestScore;

        private double AssumeWorstScore(Individual indiv, double WorstScore) => (indiv.Score ?? 0) > WorstScore ? (indiv.Score ?? 0) : WorstScore;

    }
}
