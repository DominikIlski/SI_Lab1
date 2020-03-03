using System;
using System.Collections.Generic;
using System.Text;

namespace Algorytm_Ewolucyjny.Models
{
    class Town
    {
        int Numer { set; get; }
        double X { set; get; }
        double Y { set; get; }

        public Town(int number, double x, double y)
        {
            Numer = number;
            X = x;
            Y = y;
        }
    }
}
