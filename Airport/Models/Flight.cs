using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string Direction { get; set; }
        public string FlightNumber { get; set; }
        public string PlaneModel { get; set; }
        public string Airline { get; set; }
        public string ArrivalTime { get; set; }
        public string DepartureTime { get; set; }
    }
}
