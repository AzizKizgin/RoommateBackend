# Storm

Roommate is a web application designed to help users find roommates and share accommodations. It allows users to create accounts, post room advertisements, and save listings for future reference. The app is built using ASP.NET Core Web API.

## Features

- **User Authentication**: Secure user authentication system allowing users to create accounts and log in securely.
- Real-time messaging
- Send and receive text messages

## Technologies Used

- **ASP.NET Core Web API**
- **C#**
- **Entity Framework Core**
- **SignalR**

## Documentation
- You can find it [here](https://azizkzgn2.github.io/StormBackend/)

## Getting Started
1. **Clone the Repository:**
   ```bash
   git clone https://github.com/AzizKizgin/StormBackend.git
   ```
2. **Navigate to the Project Directory:**
   ```bash
   cd StormBackend
   ```
3. **Install Dependencies:**
   ```bash
   dotnet restore
   ```
4. **Change Database Connection String in appsettings.json:**
    ```bash
   create a .env file to root of the project and add your database connection as:
    CONNECTION_STRING= "Your connection string"
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
  Open your web browser and navigate to `[http://localhost:5031](http://localhost:5117)`.

## Frontend
You can find roommate app for iOS [here](https://github.com/AzizKizgin/Storm)
