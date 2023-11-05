using System;
using System.Collections.Generic;
using System.IO; // Import the System.IO namespace for file operations
using System.Text.Json;


namespace TravelessApp
{
    public class ReservationManager
    {
        public List<Reservation> Reservations { get; private set; } 

        private const string RESERVATION_JSON_FILE = "reservations.json";
        private List<Reservation> _reservations;

        public ReservationManager()
        {
            _reservations = new List<Reservation>();
            Reservations = _reservations;
            LoadFromFile();
        }

        public Reservation FindReservationByCode(string code)
        {
            return _reservations.FirstOrDefault(reservation => reservation.Code == code);
        }


        public int AvailableSeats(Flight flight)
        {
            if (flight == null)
            {
                throw new ArgumentNullException(nameof(flight), "Flight cannot be null.");
            }

            // Find the total number of reservations made for this flight
            int totalReservations = _reservations.Count(r => r.Flight.FlightCode == flight.FlightCode);

            // Calculate available seats by subtracting reservations from total seats
            int availableSeats = flight.TotalSeat - totalReservations;

            return availableSeats;
        }

        public Reservation MakeReservation(Flight flight, string name, string citizenship)
        {
            if (AvailableSeats(flight) > 0)
            {
                string code = Reservation.GenerateReservationCode();
                var reservation = new Reservation(code, flight, name, citizenship, true);
                _reservations.Add(reservation);
                Save();
                return reservation;
            }
            else
            {
                throw new MakeReservationException("No available seats for this flight.");
            }
        }

        public void Save()
        {
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", RESERVATION_JSON_FILE);
                string json = JsonSerializer.Serialize(_reservations);
                File.WriteAllText(filePath, json);

                App.Current.MainPage.DisplayAlert("Save", "Reservations Done", "OK");
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Failed to save reservations", "Reservations Fail", "OK");
            }
        }

        public void LoadFromFile()
        {
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", RESERVATION_JSON_FILE);

                if (File.Exists(filePath))
                {
                    string jsonString = File.ReadAllText(filePath);
                    _reservations = JsonSerializer.Deserialize<List<Reservation>>(jsonString);
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("File Not Found", "Failed to find the reservations file.", "OK");
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Failed to load reservations", "Failed to load reservations: " + ex.Message, "OK");
            }
        }

    }
}
