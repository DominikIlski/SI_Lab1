using System;
using System.Collections.Generic;
using System.Text;

namespace Algorytm_Ewolucyjny.Models.Mutations
{
    class Swap : MutationAlgorithm
    {


        public override List<Town> Mutate(List<Town> specimen, double Pm)
        {
            var random1 = Extensions.GenereteRandom();
            var random2 = Extensions.GenereteRandom();
            var newSpecimen = specimen;
            if(random1 < Pm)
            {
                newSpecimen = new List<Town>(specimen);

                random1 *= specimen.Count;
                random2 *= specimen.Count;

                newSpecimen.Swap((int)random1, (int)random2);

            }
            return newSpecimen;
        }
            
            


    }
}
