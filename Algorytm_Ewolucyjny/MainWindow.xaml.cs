﻿using Algorytm_Ewolucyjny.Models;
using Algorytm_Ewolucyjny.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Algorytm_Ewolucyjny
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FileService FileService;
        AlgorithmCourse AlgorithmCourse;

        public MainWindow()
        {
            InitializeComponent();
            FileService = new FileService();
            AlgorithmCourse = new AlgorithmCourse(0, new Agglomeration());

        }

        private void menuOpen_Click(object sender, RoutedEventArgs e)
        {

            FileService.LoadData();

        }

        private void menuSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void setThemeWhite_Click(object sender, RoutedEventArgs e)
        {
            AlgorithmCourse = new AlgorithmCourse(1000, FileService.Agglomeration);
            AlgorithmCourse.SetAlgorithm(new Greedy());
            AlgorithmCourse.Run();
            var testt = AlgorithmCourse.GetScoreString();
            
            //txtTest.Text = testt;
        }

        private void setThemeBlack_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
