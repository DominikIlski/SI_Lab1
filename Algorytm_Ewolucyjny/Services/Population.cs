using Algorytm_Ewolucyjny.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorytm_Ewolucyjny.Services
{
    class Population
    {
        int PopSize { set; get; }

        Agglomeration Agglomeration { set; get; }

        public Population(int popSize)
        {
            PopSize = popSize;
            Agglomeration = new Agglomeration();
        }


        public bool SetAgglomeration(Agglomeration agglomeration)
        {

            Agglomeration = agglomeration ?? new Agglomeration();
            return !Agglomeration.Name.Equals("Error Creating Agglomeration");

        }

    }
}
