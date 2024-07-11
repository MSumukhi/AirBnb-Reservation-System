# Airbnb Reservation System

## Project Overview
The Airbnb Reservation System is a web application built using ASP.NET Core that allows users to browse, book, and manage reservations for properties listed on the platform. The system also includes features for property owners to manage their listings and track reservations.

## Features
- User authentication and authorization (customers and property owners)
- Search for available properties based on location, date, and price
- View reservation status by ID
- Receive reservation confirmation emails
- Suggest best prices for nearby places
- Admin panel for managing user accounts, property listings, and reservations

## Technologies Used
- **Programming Language:** C#
- **Framework:** ASP.NET Core
- **Front-end:** Razor Pages, HTML, CSS
- **Back-end:** ASP.NET MVC
- **Database:** SQL Server
- **Version Control:** Git
- **Tools:** Visual Studio, Entity Framework Core
- **Deployment:** Docker, GitHub Actions

## Installation
### Prerequisites
- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Docker](https://www.docker.com/get-started) (optional for deployment)
- [Git](https://git-scm.com/)

### Steps
1. **Clone the repository:**
   ```bash
   git clone https://github.com/MSumukhi/AirbnbReservationSystem.git
   cd AirbnbReservationSystem
   
2. **Set up the database:**
    Update the appsettings.json with your SQL Server connection string.
    Run the following command to apply migrations:
    ```bash
      dotnet ef database update

3. **Build and run the application:**
    ```bash
      dotnet build
      dotnet run

## Usage
- Navigate to https://localhost:5001 in your web browser.
- Register and log in as a customer or property owner.
- Browse available properties, make reservations, and manage your bookings.

## Project Structure
- Controllers: Handle HTTP requests and return appropriate views or JSON data.
- Models: Define the structure of the data used in the application.
- Repositories: Implement data access logic using Entity Framework Core.
- Services: Contain business logic and interact with repositories.
- Views: Razor Pages for the front-end UI.
- wwwroot: Static files such as CSS, JavaScript, and images.

## Database Schema
- Users: Stores user information (ID, Name, Email, PasswordHash, Role)
- Properties: Stores property details (ID, OwnerID, Name, Description, Location, Price)
- Reservations: Stores reservation details (ID, UserID, PropertyID, StartDate, EndDate, Status)

## Author
Sumukhi Sri Sai Mathapati

## Acknowledgements
- ASP.NET Core: Framework for building web applications.
- Entity Framework Core: Object-relational mapper for .NET.
- Docker: Platform for developing, shipping, and running applications.
- GitHub Actions: CI/CD platform for automating workflows.
