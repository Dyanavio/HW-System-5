using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HW_System_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Queue<int> places = new Queue<int>();
        private SortedList<int, ProgressBar> results = new SortedList<int, ProgressBar>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Start(object sender, RoutedEventArgs e)
        {
            places.Enqueue(1);
            places.Enqueue(2);
            places.Enqueue(3);
            places.Enqueue(4);
            places.Enqueue(5);

            Task[] tasks = 
            { 
                UpdateProgressAsync(horse1),
                UpdateProgressAsync(horse2), 
                UpdateProgressAsync(horse3), 
                UpdateProgressAsync(horse4), 
                UpdateProgressAsync(horse5)
            };

            await Task.WhenAll(tasks);

            MessageBox.Show($"{results.Keys[0]} - {results.Values[0].Name}\n" +
                $"{results.Keys[1]} - {results.Values[1].Name}\n" +
                $"{results.Keys[2]} - {results.Values[2].Name}\n" +
                $"{results.Keys[3]} - {results.Values[3].Name}\n" +
                $"{results.Keys[4]} - {results.Values[4].Name}\n");
            this.Close();
        }
        private async Task UpdateProgressAsync(ProgressBar progressBar)
        {
            for (int i = 0; i < 100; i++)
            {
                progressBar.Value++;
                await Task.Delay(new Random().Next(200, 500));
            }
            if (progressBar.Value == 100)
            {
                results.Add(places.Dequeue(), progressBar);
            }
        }
    }
}