using Airport.Data;
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
using System.Windows.Shapes;

namespace Airport
{
    /// <summary>
    /// Логика взаимодействия для EditFlightWindow.xaml
    /// </summary>
    public partial class EditFlightWindow : Window
    {
        private int? editingId = null;

        public EditFlightWindow(int? id = null)
        {
            InitializeComponent();
            editingId = id;

            if (id.HasValue)
            {
                using var db = new AppDbContext();
                var f = db.Flights.Find(id);
                if (f != null)
                {
                    DirectionBox.Text = f.Direction;
                    FlightNumberBox.Text = f.FlightNumber;
                    PlaneModelBox.Text = f.PlaneModel;
                    AirlineBox.Text = f.Airline;
                    ArrivalPicker.SelectedDate = f.ArrivalTime;
                    DeparturePicker.SelectedDate = f.DepartureTime;
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            using var db = new AppDbContext();

            Flight flight = editingId.HasValue ? db.Flights.Find(editingId) : new Flight();

            flight.Direction = DirectionBox.Text;
            flight.FlightNumber = FlightNumberBox.Text;
            flight.PlaneModel = PlaneModelBox.Text;
            flight.Airline = AirlineBox.Text;
            flight.ArrivalTime = ArrivalPicker.SelectedDate ?? DateTime.Now;
            flight.DepartureTime = DeparturePicker.SelectedDate ?? DateTime.Now;

            if (!editingId.HasValue)
                db.Flights.Add(flight);

            db.SaveChanges();
            this.Close();
        }
    }

}
