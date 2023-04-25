using System;
using System.Collections.Generic;

class Hotel
{
	public string Name { get; set; }
	public string Location { get; set; }
	public decimal Price { get; set; }
	public int Rating { get; set; }
}

class Reservation
{
	public int Id { get; set; }
	public DateTime CheckIn { get; set; }
	public DateTime CheckOut { get; set; }
	public Hotel Hotel { get; set; }
	public decimal TotalPrice { get; set; }
}

class Program
{
	static void Main(string[] args)
	{
		// Get customer location
		string customerLocation = "New York City";

		// Get nearby hotels
		List<Hotel> nearbyHotels = GetNearbyHotels(customerLocation);

		// Sort hotels by price
		nearbyHotels.Sort((h1, h2) => h1.Price.CompareTo(h2.Price));

		// Display top 5 hotels with best prices
		for (int i = 0; i < 5 && i < nearbyHotels.Count; i++)
		{
			Console.WriteLine($"Hotel name: {nearbyHotels[i].Name}");
			Console.WriteLine($"Location: {nearbyHotels[i].Location}");
			Console.WriteLine($"Price: {nearbyHotels[i].Price:C}");
			Console.WriteLine($"Rating: {nearbyHotels[i].Rating}");
			Console.WriteLine();
		}
	}

	static List<Hotel> GetNearbyHotels(string location)
	{

		return new List<Hotel>
		{
			new Hotel { Name = "Hotel A", Location = "New York City", Price = 100, Rating = 4 },
			new Hotel { Name = "Hotel B", Location = "New York City", Price = 120, Rating = 3 },
			new Hotel { Name = "Hotel C", Location = "New York City", Price = 80, Rating = 5 },
			new Hotel { Name = "Hotel D", Location = "New York City", Price = 150, Rating = 4 },
			new Hotel { Name = "Hotel E", Location = "New York City", Price = 90, Rating = 4 },
			new Hotel { Name = "Hotel F", Location = "New York City", Price = 200, Rating = 3 }
		};
	}
}