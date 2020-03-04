using System;
using System.Collections.Generic;
using System.Text;

namespace Algorytm_Ewolucyjny.Models
{
    public class Agglomeration
    {
       
        public string Name { set; get; }
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
            DisplayDataType = displayDataType;
            Towns = new List<Town>(towns);
        }

        public Agglomeration()
        {
            Name = "Error Creating Agglomeration";
            Type = string.Empty;
            Comment = string.Empty;
            Dimension = 0;
            EdgeWeightType = string.Empty;
            DisplayDataType = string.Empty;
            Towns = new List<Town>(0);
        }

    }
}
