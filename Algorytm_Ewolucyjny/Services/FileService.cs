
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Algorytm_Ewolucyjny.Models;
using Microsoft.Win32;

namespace Algorytm_Ewolucyjny.Services
{
    public class FileService
    {
        private readonly string FILEPATH_ERROR = "Problem With filePath";

        public Agglomeration Agglomeration {private set; get; }

        public FileService()
        {
            Agglomeration = new Agglomeration();
        }

        private string ChooseFileToOpen()
        {
            string filePath;
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "D:\\gitProjects\\SI_Lab1\\Algorytm_Ewolucyjny\\EA DATA\\",
                Filter = "TSP files (*.tsp)|*.tsp|All files (*.*)| *.*",
                FilterIndex = 1,
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

        private bool LoadAgglomeration(string filePath)
        {
            string[] fileData;
            bool result;
            if (filePath != FILEPATH_ERROR)
            {
                fileData = File.ReadAllLines(filePath);
                
                Agglomeration = new Agglomeration(GetName(fileData[0]), GetType(fileData[1]), 
                    GetComment(fileData[2]), GetDimension(fileData[3]), EstimateTownType(GetEdgeWeightType(fileData[4])), GetDisplayDataType(fileData[5]), GetTowns(fileData));
                result = true;
            }
            else
            {
                fileData = new string[0];
                Agglomeration = new Agglomeration();
                result = false;
            }

            return result;
        }

        public bool LoadData()
        {
            bool result;
            string filePath = ChooseFileToOpen();
            result = LoadAgglomeration(filePath);
            return result;
           
        }



        public void SaveFile(List<(double BestScore, double AvarageScore, double WorstScore)> Scores)
        {
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Zapisz wyniki algorytmu";
            saveFileDialog.FileName = "wyniki_algorytmu";
            saveFileDialog.DefaultExt = "csv";
            saveFileDialog.AddExtension = true;
            saveFileDialog.ShowDialog();
            // If the file name is not an empty string open it for saving.
            if (saveFileDialog.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                using Stream fs = saveFileDialog.OpenFile();

                using StreamWriter streamWriter = new StreamWriter(fs);

                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.



                streamWriter.WriteLine(ScoresString(Scores));

                //File.WriteAllText(saveFileDialog.FileName, ddd);




            }
        }


        #region privateMethods

        private string GetName(string name) => name.Split(": ")[1];
        
        private string GetType(string type) => type.Split(": ")[1];
        
        private string GetComment(string commeny) => commeny.Split(": ")[1];
        
        private int GetDimension(string dimension) => int.Parse(dimension.Split(": ")[1]);
        
        private string GetEdgeWeightType(string weighType) => weighType.Split(": ")[1];


        private string ScoresString(List<(double BestScore, double AvarageScore, double WorstScore)> socres)
        {


            StringBuilder st = new StringBuilder();

            var scoreStringList = socres.Select((x, Index) => $"{Index}; {x.BestScore}; {x.AvarageScore}; {x.WorstScore};;;").ToArray();

            

            var scoresString = "Generation;Best Score;Avarage Score;Worst Score;;;\n" + String.Join('\n', scoreStringList);


            return scoresString;
        }


        private TownType EstimateTownType(string townType)
        {

            TownType type = TownType.ERROR;
            if (townType.Equals("GEO"))
                type = TownType.GEO;

            if (townType.Equals("EUC_2D"))
                type = TownType.EUC_2D;
           
            if(type == TownType.ERROR)
                throw new Exception("Problem with TownType");

            return type;

        }

        private string GetDisplayDataType(string dataType) => dataType.Split(": ")[1];


        private List<Town> GetTowns(string[] fileData)
        {
            List<Town> towns = new List<Town>();
            string[] splitOutcome;
            string[]? separator = { " ", "  " };
            for (int i = 7; i < fileData.Length; i++)
            {
                splitOutcome = fileData[i].Split(separator, StringSplitOptions.RemoveEmptyEntries);
               
                towns.Add(new Town(splitOutcome[0], splitOutcome[1], splitOutcome[2]));
                if (fileData[i + 1].Equals("EOF")) break;

            }


            return towns;
        }



        #endregion
    }
}
