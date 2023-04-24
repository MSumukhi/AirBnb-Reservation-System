using System;
/// <summary>
/// Booking class
/// </summary>
public class Booking
{
    public string TravelerName { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
}
/// <summary>
///Property Owner Class 
/// </summary>

public class PropertyOwner
{
    private string _name;

    public PropertyOwner(string name)
    {
        _name = name;
    }

    public string Name
    {
        get { return _name; }
    }

    public event EventHandler<Booking> BookingReceived;
    /// <summary>
    ///Method to display receive bookings on console
    /// </summary>
    /// <param name="booking"></param>
    public void ReceiveBooking(Booking booking)
    {
        Console.WriteLine("{0} received a booking from {1} for {2} to {3}.", Name, booking.TravelerName, booking.CheckInDate, booking.CheckOutDate);

        if (BookingReceived != null)
        {
            BookingReceived(this, booking);
        }
    }
    /// <summary>
    /// Method to display the accept booking
    /// </summary>
    /// <param name="booking"></param>
    public void AcceptBooking(Booking booking)
    {
        Console.WriteLine("{0} accepted a booking from {1} for {2} to {3}.", Name, booking.TravelerName, booking.CheckInDate, booking.CheckOutDate);
    }
    /// <summary>
    /// Method to display the Reject booking
    /// </summary>
    /// <param name="booking"></param>
    public void RejectBooking(Booking booking)
    {
        Console.WriteLine("{0} rejected a booking from {1} for {2} to {3}.", Name, booking.TravelerName, booking.CheckInDate, booking.CheckOutDate);
    }
}
/// <summary>
/// Method to populate traveller
/// </summary>
public class Traveler
{
    private string _name;

    public Traveler(string name)
    {
        _name = name;
    }

    public string Name
    {
        get { return _name; }
    }

    public void BookProperty(PropertyOwner owner, DateTime checkInDate, DateTime checkOutDate)
    {
        Booking booking = new Booking()
        {
            TravelerName = Name,
            CheckInDate = checkInDate,
            CheckOutDate = checkOutDate
        };

        owner.ReceiveBooking(booking);
    }
}
/// <summary>
/// Main program to invoke different methods
/// </summary>
public class Program
{
    public static void Main()
    {
        PropertyOwner owner = new PropertyOwner("Ranjith");
        Traveler traveler = new Traveler("Harish");

        owner.BookingReceived += (sender, booking) =>
        {
            
            Console.WriteLine("Do you want to accept or reject the booking? (A/R) ");
            string inputa = Console.ReadLine();

            if (inputa.ToUpper() == "A")
            {
                owner.AcceptBooking(booking);
            }
            else if (inputa.ToUpper() == "R")
            {
                owner.RejectBooking(booking);
            }
        };

        traveler.BookProperty(owner, DateTime.Parse("2023-04-01"), DateTime.Parse("2023-04-05"));
    }
}
