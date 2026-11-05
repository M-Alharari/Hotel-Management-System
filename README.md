# Hotel Management System API

A backend RESTful API for managing hotel operations, built with **ASP.NET Core (.NET 10)** and **Entity Framework Core**.

The project aims to provide a structured backend solution for managing hotel reservations, guests, rooms, and hotel services, following software engineering principles and maintainable architecture practices.

## Technologies

- C#
- ASP.NET Core Web API (.NET 10)
- Entity Framework Core
- SQL Server
- MediatR
- CQRS
- FluentValidation
- Swagger / OpenAPI
- Dependency Injection

## Architecture

The project follows a layered architecture inspired by **Clean Architecture**, with separation of concerns between the main components:

| Layer | Responsibility |
|---|---|
| API | HTTP endpoints and request handling |
| Application | Business use cases, CQRS, commands, queries, and handlers |
| Domain | Core entities and business rules |
| Infrastructure | Database access, EF Core configurations, and repositories |
| Service | Supporting application services |

### Design Patterns and Principles

- CQRS (Command Query Responsibility Segregation)
- Repository Pattern
- Dependency Injection
- Separation of Concerns
- Manual Object Mapping

## Main Modules

- **Guest Management:** Managing guest information and personal details.
- **Room Management:** Managing hotel rooms and room types.
- **Reservation Management:** Creating and managing reservations, checking room availability, and handling reservation statuses.
- **Hotel Services:** Managing services offered by the hotel.
- **Service Usage:** Tracking services used by guests.

## Database

The application uses **Microsoft SQL Server** with **Entity Framework Core** for data access and database management.

## Getting Started

### Prerequisites

- .NET 10 SDK
- Microsoft SQL Server
- Visual Studio or Visual Studio Code

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/M-Alharari/Hotel-Management-System.git
   ```

2. Navigate to the project directory:

   ```bash
   cd Hotel-Management-System
   ```

3. Configure your SQL Server connection string in `appsettings.json`:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER;Database=HotelDB;Trusted_Connection=True;TrustServerCertificate=True;"
     }
   }
   ```

4. Apply database migrations:

   ```bash
   dotnet ef database update
   ```

5. Run the application:

   ```bash
   dotnet run
   ```

6. Open Swagger UI to explore and test the API endpoints.

## Project Goals

This project is part of my journey in backend software development, focusing on:

- Building maintainable ASP.NET Core Web APIs.
- Applying Clean Architecture concepts and layered design.
- Implementing CQRS with MediatR.
- Understanding Entity Framework Core and relational database design.
- Writing structured, reusable, and maintainable code.

## Status

The project is under active development, with additional modules and improvements planned.

## Author

**M. Alharari**

[GitHub Profile](https://github.com/M-Alharari)
