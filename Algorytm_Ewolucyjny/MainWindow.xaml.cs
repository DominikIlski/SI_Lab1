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
            Console.WriteLine("dupa");

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
            AlgorithmCourse = new AlgorithmCourse(1, FileService.Agglomeration);
            txtTest.Text = AlgorithmCourse.Test() + "";
        }

        private void setThemeBlack_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
