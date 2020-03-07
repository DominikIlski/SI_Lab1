using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorytm_Ewolucyjny.Models
{
    public class Agglomeration
    {
       
        public string Name { private set; get; }
        public string Type { private set; get; }
        public string Comment { private set; get; }
        public int Dimension { private set;  get; }
        public string EdgeWeightType { private set; get; }
        public string DisplayDataType { private set; get; }
        public List<Town> Towns { private set; get; }

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

        public List<Town> GetAgglomeration()
        {
            return Towns;
        }

    }
}
