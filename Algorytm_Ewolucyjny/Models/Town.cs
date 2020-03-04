using System;
using System.Collections.Generic;
using System.Text;

namespace Algorytm_Ewolucyjny.Models
{
    public class Town
    {
        int Numer { set; get; }
        float X { set; get; }
        float Y { set; get; }

        public Town(int number, float x, float y)
        {
            Numer = number;
            X = x;
            Y = y;
        }

        public Town(string number, string x, string y)
        {
            Numer = int.Parse(number);
            X = float.Parse(x.Replace('.', ','));
            Y =float.Parse(x.Replace('.', ','));
        }
    }
}
