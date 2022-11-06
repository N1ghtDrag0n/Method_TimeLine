using LiveCharts;
using LiveCharts.Wpf;
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

namespace Method_TimeLine
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }


        public double Algoritm_1(int a, int b, int c, int d) 
        {
            return (a+b+c+d)/4.0;
        }

        private void gen_Click(object sender, RoutedEventArgs e)
        {
            int[] arrayMonth = new int[11] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            int[] arrayX = new int[10] { 15, 20, 22, 14, 25, 28, 25, 28, 30, 31 };
            double[] arrayF = new double[11];

            for (int i = 4; i <= 10; i++)
            {
                arrayF[i] = Algoritm_1(arrayX[i - 4], arrayX[i - 3], arrayX[i - 2], arrayX[i - 1]);
            }

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Random",
                    Values = new ChartValues<double> { arrayF[4], arrayF[5], arrayF[6], arrayF[7], arrayF[8], arrayF[9], arrayF[10], },
                   
                },

                new LineSeries
                {
                    Title = "Real",
                    Values = new ChartValues<double> { arrayX[0], arrayX[1], arrayX[2], arrayX[3], arrayX[4], arrayX[5], arrayX[6], arrayX[7], arrayX[8], arrayX[9], }
                }
            };

            Labels = new[] { "1", "2", "3", "4","5", "6", "7", "8", "9", "10", "11" };
            

            DataContext = this;
        }
    }
}
