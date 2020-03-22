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

        

        public override Individual Selection(List<Individual> list)
        {

            var bestIndex = 0;
            var score = Double.MaxValue;
            for(int i = 0; i< ParticipantsNumber; i++)
            {
                
                var randomNumber = (int)Math.Floor(Extensions.GenereteRandom() * list.Count);

                var scoreOfParticipant = list[randomNumber].Score ?? 0;

                if (scoreOfParticipant is 0) throw new Exception("Problem with participant score");

                if (scoreOfParticipant < score)
                {
                    bestIndex = randomNumber;
                    score = scoreOfParticipant;
                }
               

            }

            return new Individual(list[bestIndex]);
        }


        public List<Town> BestParticipant(List<(List<Town> Specimen, double Score)> participants)
        {
            


            

            //var newParticipant = participants[0].Specimen.ConvertAll(town => (Town)town.Clone()/*new Town(town.Numer, town.X, town.Y)*/ );

            return /*newP*/participants[participants.Count-1].Specimen;
        }
    }
}
