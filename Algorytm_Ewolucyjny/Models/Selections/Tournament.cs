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
            double randomNumber = 0;

            for(int i = 0; i< ParticipantsNumber; i++)
            {
                randomNumber = Extensions.GenereteRandom() * list.Count;
                var parseHelper = (int)Math.Floor(randomNumber);
                var participant = list[parseHelper];
                var score = EvaluationFunction.EvaluateSpecimen(participant);
                var tuple = (participant, score);

                participants.Add(tuple);
            }

            var bestParticipant = BestParticipant(participants);

            return bestParticipant;
        }


        public List<Town> BestParticipant(List<(List<Town> Specimen, double Score)> participants)
        {
            participants.Sort((x, y) => y.Score.CompareTo(x.Score));


            

            //var newParticipant = participants[0].Specimen.ConvertAll(town => (Town)town.Clone()/*new Town(town.Numer, town.X, town.Y)*/ );

            return /*newP*/participants[participants.Count-1].Specimen;
        }
    }
}
