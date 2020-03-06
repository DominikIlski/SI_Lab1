using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Algorytm_Ewolucyjny.Models
{
    public class Town : IEquatable<int>
    {
        public int Numer { private set; get; }
        public double X { private set; get; }
        public double Y { private set; get; }

        public Town(int number, double  x, double y)
        {
            Numer = number;
            X = x;
            Y = y;
        }

        public Town()
        {
            Numer = 0;
            X = 0;
            Y = 0;
        }

        public Town(string number, string x, string y)
        {
            Numer = int.Parse(number);
            X = double.Parse(x.Replace('.', ','));
            Y =double.Parse(x.Replace('.', ','));
        }


        public bool Equals(int other)
        {

            if (other == 0) return false;
            return (this.Numer.Equals(other));

        }
    }
}
