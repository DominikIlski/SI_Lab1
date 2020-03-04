
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Win32;

namespace Algorytm_Ewolucyjny.Services
{
    public class FileService
    {

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
                filePath = "Problem With filePath";
            }

            return filePath;

        }

        public 


    }
}
