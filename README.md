# NC2025 Minimal API - ASP.NET Core 9 Demo Project

This project was created as a demo for the session presented at the [Rome .NET Conference 2025](https://www.dotnetconf.it), dedicated to **Minimal APIs** in **ASP.NET Core 9**.

The demo explores the new features introduced in the upcoming version of the platform and provides a complete, functional example of how to structure a modern, lightweight, and efficient API with a modular and best-practices-oriented architecture.

📖 Read the full article here: [ASP.NET Core 9 Minimal APIs Demo Project](https://www.ryadel.com/en/asp-net-core-9-minimal-apis-demo-project/)

## 🎯 Project Goals

- Demonstrate how to build a **Minimal API** with ASP.NET Core 9
- Compare Minimal APIs with traditional Controller-based Web APIs
- Explore the new features of ASP.NET Core 9
- Provide a solid foundation for building microservices and RESTful backends
- Perform performance testing with interactive tools

## 🧱 Key Features

- ✅ **Pure Minimal API**, no controllers
- ⚙️ **Entity Framework Core** with **Code-First** approach and **SQLite** database
- 🧩 **Repository Pattern** with generic and specific interfaces
- 🎲 **Automatic database seeding** using [Bogus](https://github.com/bchavez/Bogus) (Faker.js port for .NET)
- 📚 Integrated **OpenAPI support** with:
  - Swagger UI (default)
  - ReDoc
  - Scalar
- 🔐 JWT Authentication (placeholder for future integration)
- 🧪 **Interactive benchmarking** with Postman and [nBomber](https://nbomber.com)

## 📁 Project Structure

```
NC2025_MinimalAPI_NET9/
├── Program.cs                   # Entry point with service registration and endpoint mapping
├── Extensions/                  # Extension methods for builder and app configuration
├── Models/                      # EF Core data models
├── Repositories/                # Interfaces and implementations for data access
├── Data/                        # DbContext, Seeder, DbInitializer
├── Configuration/               # Swagger, CORS, OpenAPI setup
├── Properties/launchSettings.json
└── README.md
```

## 🚀 How to Run the Project

### Prerequisites

- [.NET 9 SDK (Preview)](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- Visual Studio 2022+ (Preview) or VS Code with the C# extension

### Running the App

1. Clone the repository:

   ```bash
   git clone https://github.com/Ryadel/NC2025_MinimalAPI_NET9.git
   cd NC2025_MinimalAPI_NET9
   ```

2. Run the application:

   ```bash
   dotnet run
   ```

3. Open your browser and navigate to:

   ```
   https://localhost:7053/swagger
   ```

   Or access `/docs` for ReDoc and `/scalar` for Scalar.

## 🧪 Testing and Benchmarking

- Use **Postman** to invoke endpoints and inspect the API structure
- Run **stress tests** and benchmarks with [nBomber](https://nbomber.com)

## 📖 Topics Covered in the NC2025 Session

- Minimal APIs: what they are and how they work
- Differences and similarities with Controller-based Web APIs
- Pros, cons, and typical use cases
- What’s new in ASP.NET Core 9
- Native OpenAPI and Swagger support
- Improved performance (up to 93% memory usage reduction)
- Hands-on demo and live coding
- Modular architecture with EF Core, Bogus, Repository Pattern
- OpenAPI tooling: Swagger UI, ReDoc, Scalar
- API benchmarking with Postman and nBomber

## 📝 License

This project is licensed under the [MIT License](LICENSE).

## 🙌 Credits

Developed by [Ryadel](https://www.ryadel.com) for the .NET community.  
Created for the **Rome .NET Conference 2025** session.
