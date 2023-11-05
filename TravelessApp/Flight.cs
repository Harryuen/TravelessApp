public class Flight
{
    public string FlightCode { get; set; }
    public string Airline { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public string DayOfFlight { get; set; }
    public string FlightTime { get; set; }
    public int TotalSeat { get; set; }
    public decimal CostPerSeat { get; set; }
    public bool IsDomestic { get; }

    public Flight()
    {
    }

    public Flight(string flightCode, string airline, string from, string to, string dayOfFlight, string flightTime, int totalSeat, decimal costPerSeat)
    {
        FlightCode = flightCode;
        From = from;
        To = to;
        DayOfFlight = dayOfFlight;
        FlightTime = flightTime;
        TotalSeat = totalSeat;
        CostPerSeat = costPerSeat;
        //AirlineCode = code.Split('-')[0];
        //FlightNumber = int.Parse(code.Split('-')[1]);
        IsDomestic = DetermineIfDomestic(from, to);
    }

    public bool Equals(Flight other)
    {
        return this.FlightCode == other.FlightCode && this.Airline == other.Airline;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Flight))
        {
            return false;
        }

        Flight other = (Flight)obj;
        return Equals(other);
    }

    private bool DetermineIfDomestic(string from, string to)
    {
        return from.Substring(0, 2) == to.Substring(0, 2);
    }
}
