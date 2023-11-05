using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelessApp
{
    public class Reservation
    {
        public string Code { get; set; }
        public Flight Flight { get; set; }
        public string Name { get; set; }
        public string Citizenship { get; set; }
        public bool IsActive { get; set; }

        public Reservation()
        {
            // Default constructor
        }

        public Reservation(string code, Flight flight, string name, string citizenship, bool isActive)
        {
            Code = code;
            Flight = flight;
            Name = name;
            Citizenship = citizenship;
            IsActive = isActive;
        }

        public bool Equals(Reservation other)
        {
            return this.Code == other.Code && this.Flight.Equals(other.Flight);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Reservation))
            {
                return false;
            }

            Reservation other = (Reservation)obj;
            return Equals(other);
        }

        public override string ToString()
        {
            return $"Reservation Code: {Code}, Flight: {Flight.FlightCode}, Name: {Name}, Citizenship: {Citizenship}, IsActive: {IsActive}";
        }

        public static string GenerateReservationCode()
        {
            // Generate a random letter
            Random random = new Random();
            char randomLetter = (char)('A' + random.Next(0, 26)); // Assuming uppercase letters are required
            int randomNumber = random.Next(1000, 10000);
            string reservationCode = $"{randomLetter}{randomNumber}";// 
            return reservationCode;
        }

    }

}
