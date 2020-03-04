
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Algorytm_Ewolucyjny.Models;
using Microsoft.Win32;

namespace Algorytm_Ewolucyjny.Services
{
    public class FileService
    {
        private readonly string FILEPATH_ERROR = "Problem With filePath";

        public string ChooseFileToOpen()
        {
            string filePath;
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "D:\\gitProjects\\SI_Lab1\\Algorytm_Ewolucyjny\\EA DATA\\",
                Filter = "TSP files (*.tsp)|*.tsp|All files (*.*)| *.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                filePath =  openFileDialog.FileName;
            }
            else
            {
                filePath = FILEPATH_ERROR;
            }

            return filePath;

        }

        public Agglomeration LoadAglomeration(string filePath)
        {
            string[] fileData;
            Agglomeration agglomeration;
            if (filePath != FILEPATH_ERROR)
            {
                fileData = File.ReadAllLines(filePath);
                
                agglomeration = new Agglomeration(GetName(fileData[0]), GetType(fileData[1]), 
                    GetComment(fileData[2]), GetDimension(fileData[3]), GetEdgeWeightType(fileData[4]), GetDisplayDataType(fileData[5]), GetTowns(fileData));
               
            }
            else
            {
                fileData = new string[0];
                agglomeration = new Agglomeration();
            }

            return agglomeration;
        }


        #region privateMethods

        private string GetName(string name) => name.Split(':')[1];
        
        private string GetType(string type) => type.Split(':')[1];
        
        private string GetComment(string commeny) => commeny.Split(':')[1];
        
        private int GetDimension(string dimension) => int.Parse(dimension.Split(':')[1]);
        
        private string GetEdgeWeightType(string weighType) => weighType.Split(':')[1];
        
        private string GetDisplayDataType(string dataType) => dataType.Split(':')[1];


        private List<Town> GetTowns(string[] fileData)
        {
            List<Town> towns = new List<Town>();
            string[] splitOutcome;
            string[]? separator = { " ", "  " };
            for (int i = 7; i < towns.Count; i++)
            {
                splitOutcome = fileData[i].Split(separator, StringSplitOptions.RemoveEmptyEntries);
               
                towns.Add(new Town(splitOutcome[0], splitOutcome[1], splitOutcome[2]));
                if (towns[i + 1].Equals("EOF")) break;

            }


            return towns;
        }

        #endregion
    }
}
