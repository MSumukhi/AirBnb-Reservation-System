using System;
using System.Net;
using System.Net.Mail;

class Program
{
	static void Main(string[] args)
	{
		string customerEmail = "harishgunturu248@gmail.com"; 
		string reservationNumber = "12345"; 
		string hotelName = "Holiday Inn";  
		string checkInDate = "2023-05-01"; 
		string checkOutDate = "2023-05-05"; 

		// configure email settings
		string senderEmail = "gvharish987@gmail.com.com"; 
		string senderPassword = "harish"; 
		string smtpServer = "Airbnb.com"; 
		int smtpPort = 587; 
		bool enableSsl = true;

		// create email message
		string subject = $"Reservation Confirmation ({reservationNumber})";
		string body = $"Dear Customer,\n\nThank you for choosing {hotelName}. Your reservation ({reservationNumber}) has been confirmed for the following dates:\n\nCheck-in date: {checkInDate}\nCheck-out date: {checkOutDate}\n\nIf you have any questions or concerns, please don't hesitate to contact us.\n\nBest regards,\nThe {hotelName} Team";

		MailMessage message = new MailMessage(senderEmail, customerEmail, subject, body);

		// configure SMTP client
		SmtpClient client = new SmtpClient(smtpServer, smtpPort);
		client.EnableSsl = enableSsl;
		client.Credentials = new NetworkCredential(senderEmail, senderPassword);

		// send email
		try
		{
			client.Send(message);
			Console.WriteLine("Reservation confirmation email sent to customer.");
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error sending reservation confirmation email: {ex.Message}");
		}
	}
}
