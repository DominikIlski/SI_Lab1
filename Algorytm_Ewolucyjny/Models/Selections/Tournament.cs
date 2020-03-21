using Algorytm_Ewolucyjny.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorytm_Ewolucyjny.Models.Selections
{
    class Tournament : SelectionAlgorithm
    {
      

        public override(List<Town> geneticCode , double? score) Selection(List<(List<Town> geneticCode , double? score)> list)
        {

            var participants = new List<(List<Town> Specimen, double Score)>();
            
           (List<Town> geneticCode , double? score) bestParticipant = new(List<Town> geneticCode , double? score)(list[0]);
            var score = Double.MaxValue;
            for(int i = 0; i< list.Count; i++)
            {
                var randomNumber = Extensions.GenereteRandom() * list.Count;
                var parseHelper = (int)Math.Floor(randomNumber);
                var scoreHelper = EvaluationFunction.EvaluateSpecimen(list[parseHelper]);
                if(scoreHelper < score)
                {
                    bestParticipant = new(List<Town> geneticCode , double? score)(list[parseHelper]);
                    score = scoreHelper;
                }


            }

            

            return bestParticipant;
        }


        private(List<Town> geneticCode , double? score) BestParticipant(List<(List<Town> Specimen, double Score)> participants)
        {
            


            

            //var newParticipant = participants[0].Specimen.ConvertAll(town => (Town)town.Clone()/*new Town(town.Numer, town.X, town.Y)*/ );

            return /*newP*/participants[participants.Count-1].Specimen;
        }
    }
}
