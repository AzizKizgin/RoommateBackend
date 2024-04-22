# Roommate

Roommate is a web application designed to help users find roommates and share accommodations. It allows users to create accounts, post room advertisements, and save listings for future reference. The app is built using ASP.NET Core Web API.

## Features

- **User Authentication**: Secure user authentication system allowing users to create accounts and log in securely.
- **Room Advertisement Creation**: Easily create and post room advertisements with details like location, rent, amenities, and more.
- **Save Favorite Listings**: Users can save their favorite room listings to quickly access them later.
- **API Integration**: Utilizes ASP.NET Core Web API for backend functionality, ensuring robust and efficient communication between the client and server.

## Technologies Used

- **ASP.NET Core Web API**: Provides the backend framework for handling HTTP requests and responses.
- **C#**: The primary programming language used for developing the backend logic.
- **Entity Framework Core**: Used for data access and database management.

## Getting Started
1. **Clone the Repository:**
   ```bash
   git clone https://github.com/AzizKizgin/RoommateBackend.git
   ```
2. **Navigate to the Project Directory:**
   ```bash
   cd RoommateBackend
   ```
3. **Install Dependencies:**
   ```bash
   dotnet restore
   ```
4. **Change Database Connection String in appsettings.json:**
    ```bash
    "ConnectionStrings": {
    "sqlConnection": "your connection string"
    },
   ```
6. **Add Migrations and Update Database:**
   ```bash
   dotnet ef migrations add 'InitialCreate'
   dotnet ef database update
   ```
7. **Run the Application:**
   ```bash
   dotnet run
   ```
8. **Access the App:**
  Open your web browser and navigate to `http://localhost:5031`.

## Frontend
You can find roommate app for iOS [here](https://github.com/AzizKizgin/Roommate)
