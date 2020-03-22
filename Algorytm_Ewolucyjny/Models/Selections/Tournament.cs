using Algorytm_Ewolucyjny.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorytm_Ewolucyjny.Models.Selections
{
    class Tournament : SelectionAlgorithm
    {
        readonly int  ParticipantsNumber;
        
        public Tournament(int participantsNumber)
        {

            ParticipantsNumber = participantsNumber;
            

        }

        

        public override List<Town> Selection(List<List<Town>> list)
        {

            var participants = new List<(List<Town> Specimen, double Score)>();
            
            List<Town> bestParticipant = new List<Town>(list[0]);
            var score = Double.MaxValue;
            for(int i = 0; i< ParticipantsNumber; i++)
            {
                var randomNumber = Extensions.GenereteRandom() * list.Count;
                var parseHelper = (int)Math.Floor(randomNumber);
                var scoreHelper = EvaluationFunction.EvaluateIndividual(list[parseHelper]);
                if(scoreHelper < score)
                {
                    bestParticipant = new List<Town>(list[parseHelper]);
                    score = scoreHelper;
                }


            }

            

            return bestParticipant;
        }


        public List<Town> BestParticipant(List<(List<Town> Specimen, double Score)> participants)
        {
            


            

            //var newParticipant = participants[0].Specimen.ConvertAll(town => (Town)town.Clone()/*new Town(town.Numer, town.X, town.Y)*/ );

            return /*newP*/participants[participants.Count-1].Specimen;
        }
    }
}
