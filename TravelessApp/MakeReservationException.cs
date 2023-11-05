using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelessApp
{
    public class MakeReservationException : Exception
    {
        public MakeReservationException() : base()
        {
            // Default constructor
        }

        public MakeReservationException(string message) : base(message)
        {
            // Constructor with message
        }

        public static MakeReservationException NoFlightSelected()
        {
            return new MakeReservationException("Please select a flight to make a reservation.");
        }

        public static MakeReservationException EmptyNameField()
        {
            return new MakeReservationException("Name field cannot be empty.");
        }

        public static MakeReservationException EmptyCitizenshipField()
        {
            return new MakeReservationException("Citizenship field cannot be empty.");
        }
    }
}
