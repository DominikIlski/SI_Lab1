using System;
using System.Collections.Generic;
using System.Text;

namespace Algorytm_Ewolucyjny.Models
{
    public class Town
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

        public Town(string number, string x, string y)
        {
            Numer = int.Parse(number);
            X = double.Parse(x);
            Y = double.Parse(y);
        }
    }
}
