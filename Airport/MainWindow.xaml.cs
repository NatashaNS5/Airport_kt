using Airport.Data;
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

namespace Airport
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadFlights();
        }

        private void LoadFlights()
        {
            using var db = new AppDbContext();
            FlightsGrid.ItemsSource = db.Flights.ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var edit = new EditFlightWindow();
            edit.ShowDialog();
            LoadFlights();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (FlightsGrid.SelectedItem is Flight flight)
            {
                var edit = new EditFlightWindow(flight.Id);
                edit.ShowDialog();
                LoadFlights();
            }
        }
    }
}