using System;

class Reservation
{
	public int Id { get; set; }
	public string Status { get; set; }
}

class ReservationChecker
{
	static void Main()
	{
		// Create some sample reservations
		Reservation[] reservations = {
			new Reservation { Id = 1, Status = "Confirmed" },
			new Reservation { Id = 2, Status = "Pending" },
			new Reservation { Id = 3, Status = "Cancelled" }
		};

		// Prompt the user to enter a reservation ID
		Console.Write("Enter reservation ID: ");
		int id = int.Parse(Console.ReadLine());

		// Search for the reservation with the specified ID
		Reservation reservation = null;
		foreach (Reservation r in reservations)
		{
			if (r.Id == id)
			{
				reservation = r;
				break;
			}
		}

		// Display the status of the reservation
		if (reservation == null)
		{
			Console.WriteLine("Reservation not found.");
		}
		else
		{
			Console.WriteLine("Reservation status: " + reservation.Status);
		}

		// Wait for the user to press a key before exiting
		Console.ReadKey();
	}
}
