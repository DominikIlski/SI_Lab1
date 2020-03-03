
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
            var filePath = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "D:\\gitProjects\\SI_Lab1\\Algorytm_Ewolucyjny\\EA DATA\\";
            openFileDialog.Filter = "TSP files (*.tsp)|*.tsp|All files (*.*)| *.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if(openFileDialog.ShowDialog().GetValueOrDefault())
            {
                filePath =  openFileDialog.FileName;
            }
            else
            {
                filePath = "Problem With filePath";
            }

            return filePath;

        }

    }
}
