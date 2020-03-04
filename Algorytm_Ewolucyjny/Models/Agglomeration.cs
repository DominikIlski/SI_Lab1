using System;
using System.Collections.Generic;
using System.Text;

namespace Algorytm_Ewolucyjny.Models
{
    class Agglomeration
    {
       
        string Name { set; get; }
        string Type { set; get; }
        string Comment { set; get; }
        int Dimension { set; get; }
        string EdgeWeightType { set; get; }
        string DisplayDataType { set; get; }
        List<Town> Towns { set; get; }

        public Agglomeration(string name, string type, string comment, int dimension, 
                             string edgeWeightType, string displayDataType, List<Town> towns)
        {
            Name = name;
            Type = type;
            Comment = comment;
            Dimension = dimension;
            EdgeWeightType = edgeWeightType;
            Towns = new List<Town>(towns);
        }

    }
}
