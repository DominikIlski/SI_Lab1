using Algorytm_Ewolucyjny.Models;
using Algorytm_Ewolucyjny.Models.Algorithms;
using Algorytm_Ewolucyjny.Models.Crossings;
using Algorytm_Ewolucyjny.Models.Mutations;
using Algorytm_Ewolucyjny.Models.Selections;
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
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;
using Microsoft.Win32;
using System.IO;

namespace Algorytm_Ewolucyjny
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public SeriesCollection SeriesCollection { get; set; }
        
        public Func<double, string> Formatter { get; set; }
        public List<(double BestScore, double AvarageScore, double WorstScore)> Scores;
        FileService FileService;
        AlgorithmCourse AlgorithmCourse;
        MutationAlgorithm MutationAlgorithm;
        CrossingAlgorithm CrossingAlgorithm;
        SelectionAlgorithm SelectionAlgorithm;
        public MainWindow()
        {
            InitializeComponent();
            FileService = new FileService();
            AlgorithmCourse = new AlgorithmCourse(0, new Agglomeration());
            MutationAlgorithm = new MutationAlgorithm();
            CrossingAlgorithm = new CrossingAlgorithm();
            SelectionAlgorithm = new SelectionAlgorithm();
            Scores = new List<(double BestScore, double AvarageScore, double WorstScore)>();

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<ObservableValue>
                    {
                        new ObservableValue(4),
                        new ObservableValue(2),
                        new ObservableValue(8),
                        new ObservableValue(2),
                        new ObservableValue(3),
                        new ObservableValue(0),
                        new ObservableValue(1),
                    },

                },
                 new LineSeries
                {
                    Values = new ChartValues<ObservableValue>
                    {
                        new ObservableValue(4),
                        new ObservableValue(2),
                        new ObservableValue(8),
                        new ObservableValue(2),
                        new ObservableValue(3),
                        new ObservableValue(0),
                        new ObservableValue(1),
                    },

                },
                  new LineSeries
                {
                    Values = new ChartValues<ObservableValue>
                    {
                        new ObservableValue(4),
                        new ObservableValue(2),
                        new ObservableValue(8),
                        new ObservableValue(2),
                        new ObservableValue(3),
                        new ObservableValue(0),
                        new ObservableValue(1),
                    },

                }
            };



            Formatter = value => value +" ";

            DataContext = this;


        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {

            FileService.LoadData();

        }

      

      

        private void RunAlgorithm_Click(object sender, RoutedEventArgs e)
        {
         

            

            

            var iterationsData = new List<(double BestScore, double AvarageScore, double WorstScore)>();

            var numberOfCals = ParseInt(NumberOfCals.Text);

            for (int i = 0; i < numberOfCals; i++)
            {
                tester();

                AlgorithmCourse = new AlgorithmCourse(ParseInt(PopSize.Text), FileService.Agglomeration);
                AlgorithmCourse.SetAlgorithm(new Genetic(ParseDouble(Pm.Text), ParseDouble(Px.Text),
                    SelectionAlgorithm, CrossingAlgorithm, MutationAlgorithm, ParseInt(NumberOfGenerations.Text)));

                AlgorithmCourse.Run();
                var finalScores = AlgorithmCourse.GetScores();
                Scores = finalScores;
                InitializeChart(finalScores);
                iterationsData.Add(finalScores[finalScores.Count-1]);
            }

            if (numberOfCals > 1) Scores = iterationsData;

        }

        public void tester()
        {
            MutationAlgorithm = new Swap();
            CrossingAlgorithm = new Ordered();
            if (Turniej.IsChecked.Value)
            {
                SelectionAlgorithm = new Tournament();
            }
            else
            {
                SelectionAlgorithm = new Roulette();
            }

            

        }

        private void InitializeChart(List<(double BestScore, double AvarageScore, double WorstScore)> scores)
        {

            SeriesCollection.Clear();

            var r = new Random();
            var seriesBest = new LineSeries();
            var seriesAvg = new LineSeries();
            var seriesWorst = new LineSeries();


            seriesBest.Fill = System.Windows.Media.Brushes.Transparent;
            
            seriesAvg.Fill = System.Windows.Media.Brushes.Transparent;
            seriesWorst.Fill = System.Windows.Media.Brushes.Transparent;

            seriesBest.Title = "Best value";
            seriesAvg.Title = "Avarage value";
            seriesWorst.Title = "Worst value";
            seriesAvg.Values = new ChartValues<ObservableValue>();
            seriesBest.Values = new ChartValues<ObservableValue>();
            seriesWorst.Values = new ChartValues<ObservableValue>();

            SeriesCollection.Add(seriesWorst);
            SeriesCollection.Add(seriesAvg);
            SeriesCollection.Add(seriesBest);

            
          
            foreach (var specimen in scores)
            {

                seriesBest.Values.Add(new ObservableValue(specimen.BestScore));
                seriesAvg.Values.Add(new ObservableValue(specimen.AvarageScore));
                seriesWorst.Values.Add(new ObservableValue(specimen.WorstScore));


            }
            
            

          


        }

        public static int ParseInt(string toParse) => int.Parse(toParse);
        public static double ParseDouble(string toParse) => double.Parse(toParse);

        private void saveFileButton_Click(object sender, RoutedEventArgs e)
        {

            FileService.SaveFile(Scores);

        }

       
    }
}
