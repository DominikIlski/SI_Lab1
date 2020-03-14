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

namespace Algorytm_Ewolucyjny
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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

        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {

            FileService.LoadData();

        }

      

      

        private void RunAlgorithm_Click(object sender, RoutedEventArgs e)
        {

            tester();

            AlgorithmCourse = new AlgorithmCourse(ParseInt(PopSize.Text), FileService.Agglomeration);
            AlgorithmCourse.SetAlgorithm(new Genetic(ParseDouble(Pm.Text), ParseDouble(Px.Text),
                SelectionAlgorithm, CrossingAlgorithm, MutationAlgorithm, ParseInt(NumberOfGenerations.Text)));
            AlgorithmCourse.Run();
            //var testt = AlgorithmCourse.GetScoreString();



        }

        public void tester()
        {
            MutationAlgorithm = new Swap();
            CrossingAlgorithm = new Ordered();
            SelectionAlgorithm = new Tournament(ParseInt(Tour.Text));

        }

        public static int ParseInt(string toParse) => int.Parse(toParse);
        public static double ParseDouble(string toParse) => double.Parse(toParse);

    }
}
