# GulfVillas 🏝️

A modern web application for managing and showcasing Gulf Villas, implemented using **Clean Architecture** principles in ASP.NET Core.

## 🏗️ Project Structure

This solution follows the **Clean Architecture** pattern inspired by [DotNetMastery’s Clean Architecture series](https://www.youtube.com/watch?v=CAwpmoA7sno&t=7813s). The solution is divided into the following four projects:

GulfVillas ├── GulfVillas.Application # Handles application logic and use cases ├── GulfVillas.Domain # Contains domain models and core business logic ├── GulfVillas.Infrastructure # Deals with data access, external services, and configurations └── GulfVillas.Web # Presentation layer (ASP.NET Core MVC or Razor Pages)

Here is database [Backup File Link](https://drive.google.com/file/d/1ohRG-1NW7GCLYfRMkU-oWuTvhFQgh-nC/view?usp=drive_link)

### 📁 GulfVillas.Application
- Contains interfaces, DTOs, and service implementations that are core to the business use cases.
- Depends only on the Domain layer.
- Typically contains CQRS logic using MediatR.

### 📁 GulfVillas.Domain
- Represents the core of the application.
- Contains entity models, enums, and domain-specific rules.
- This project is completely independent and should not reference other layers.

### 📁 GulfVillas.Infrastructure
- Provides implementation for interfaces defined in the Application layer.
- Responsible for persistence (EF Core, external APIs, etc.).

### 📁 GulfVillas.Web
- The entry point of the application.
- Hosts the presentation logic, controllers, Razor Pages or Views.
- Configures dependency injection and middleware pipeline.

---

## 🧠 Inspiration & Learning Source

This architecture and implementation were heavily inspired by the brilliant video by DotNetMastery:

📺 [Clean Architecture - .NET 6 | Full Course](https://www.youtube.com/watch?v=CAwpmoA7sno&t=7813s)

---

## 🚀 Getting Started

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/en-us/download)
- SQL Server or any supported DBMS
- Visual Studio or VS Code

### Steps to Run the Application
1. Clone the repository
2. Set the `GulfVillas.Web` project as the startup project.
3. Update `appsettings.json` with your database connection string.
4. Run `Update-Database` in the Package Manager Console to apply migrations.
5. Hit `F5` or run `dotnet run` to start the app.

---

## 🔍 Features

- ✅ Modular and scalable architecture
- ✅ Clean separation of concerns
- ✅ Easy to test and maintain
- ✅ Follows SOLID principles and CQRS pattern

---

## 🤝 Contribution

Feel free to fork this repository and contribute improvements. Open a pull request with a detailed explanation.

---

## 📜 License

This project is open-source and available under the MIT License.

---

## 🙌 Acknowledgments

Big thanks to **DotNetMastery** for the educational content and inspiration!
