# 🏨 HotelBooking


![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![.NET 9](https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![MySQL](https://img.shields.io/badge/MySQL-4479A1?style=for-the-badge&logo=mysql&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white)

A modern hotel booking system built with **ASP.NET Core 9.0** following **Clean Architecture** principles.  This application provides a robust and scalable solution for managing hotel reservations. 

---

## 📋 Table of Contents

- [🏨 HotelBooking](#-hotelbooking)
  - [📋 Table of Contents](#-table-of-contents)
  - [📖 Description](#-description)
  - [🛠️ Technologies](#️-technologies)
  - [📁 Project Structure](#-project-structure)
  - [⚙️ Installation](#️-installation)
  - [🚀 Usage](#-usage)

---

## 📖 Description

**HotelBooking** is a comprehensive hotel reservation management system designed to streamline the booking process for hotels. Built with a focus on maintainability and scalability, the application follows Clean Architecture patterns, ensuring separation of concerns and testability.

### ✨ Key Features

- 🛏️ Room booking and management
- 📅 Reservation scheduling
- 🔐 Secure authentication with ASP.NET Core Identity
- 📊 Clean Architecture design pattern
- 🐳 Docker containerization support
- 🗄️ MySQL database with Entity Framework Core

---

## 🛠️ Technologies

| Category | Technology |
|----------|------------|
| **Framework** | ASP. NET Core 9.0 |
| **Language** | C# 13 |
| **Database** | MySQL 8.0 |
| **ORM** | Entity Framework Core 9.0, Dapper |
| **Authentication** | ASP.NET Core Identity |
| **MySQL Provider** | Pomelo.EntityFrameworkCore.MySql |
| **Containerization** | Docker & Docker Compose |
| **Architecture** | Clean Architecture |

---

## 📁 Project Structure

```
HotelBooking/
├── 📂 src/
│   ├── 📂 HotelBooking.Domain/         # Enterprise business rules & entities
│   │   ├── 📂 Common/                  # Common base classes
│   │   ├── 📂 Entities/                # Domain entities
│   │   └── 📂 Enums/                   # Domain enumerations
│   ├── 📂 HotelBooking.Application/    # Application business rules & use cases
│   │   ├── 📂 Exceptions/              # Custom exceptions
│   │   ├── 📂 Interfaces/              # Service interfaces
│   │   ├── 📂 Models/                  # DTOs and view models
│   │   └── 📂 Services/                # Application services
│   ├── 📂 HotelBooking.Infrastructure/ # External concerns (DB, Identity)
│   │   ├── 📂 Context/                 # Database context
│   │   ├── 📂 Identity/                # Identity configuration
│   │   ├── 📂 Migrations/              # EF Core migrations
│   │   ├── 📂 Persistence/             # Persistence configurations
│   │   └── 📂 Repositories/            # Repository implementations
│   └── 📂 HotelBooking.Web/            # Presentation layer
│       ├── 📂 Controllers/             # API/MVC controllers
│       ├── 📂 Middleware/              # Custom middleware
│       └── 📂 Pages/                   # Razor Pages
├── 📄 Dockerfile
├── 📄 docker-compose. yml
├── 📄 HotelBooking. sln
└── 📄 . gitignore
```

---

## ⚙️ Installation

### Prerequisites

- [. NET 9.0 SDK](https://dotnet.microsoft. com/download/dotnet/9.0) or later
- [Docker](https://www.docker.com/get-started) (for containerized deployment)
- [MySQL 8.0](https://dev.mysql.com/downloads/) (for local development without Docker)

### Option 1: Using Docker (Recommended) 🐳

1. **Clone the repository**
   ```bash
   git clone https://github.com/kovalllllll/HotelBooking.git
   cd HotelBooking
   ```

2. **Start the application with Docker Compose**
   ```bash
   docker-compose up -d
   ```

3. **Access the application**
   - The application will be available at: `http://localhost:5000`
   - MySQL will be exposed on port `3307`

### Option 2: Manual Setup 🔧

1. **Clone the repository**
   ```bash
   git clone https://github.com/kovalllllll/HotelBooking.git
   cd HotelBooking
   ```

2. **Set up the MySQL database**
   - Create a database named `HotelBooking`
   - Update the connection string in `src/HotelBooking.Web/appsettings.json`

3. **Restore dependencies**
   ```bash
   dotnet restore
   ```

4. **Apply database migrations**
   ```bash
   dotnet ef database update --project src/HotelBooking.Infrastructure --startup-project src/HotelBooking. Web
   ```

5. **Run the application**
   ```bash
   dotnet run --project src/HotelBooking.Web
   ```

---

## 🚀 Usage

Once the application is running, you can: 

1. **Access the web application** at `http://localhost:5000`
2. **Register a new account** or log in with existing credentials
3. **Browse available rooms** and make reservations
4. **Manage bookings** through the user dashboard

### 🔌 Database Connection

When using Docker, connect to MySQL with:
| Parameter | Value |
|-----------|-------|
| Host | `localhost` |
| Port | `3307` |
| Database | `HotelBooking` |
| User | `root` |
| Password | `mysql` |

---

<p align="center">
  Made with ❤️ by <a href="https://github.com/kovalllllll">kovalllllll</a>
</p>
