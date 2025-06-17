# ShoppingCart API – Authenticated .NET 8 Web API  
Hrishav Tiwari • Student ID: A00286173

An educational project that demonstrates how to build a simple, authenticated Shopping-Cart REST API with ASP.NET Core 8, Entity Framework Core, ASP.NET Identity, xUnit unit-tests, and Swagger for interactive documentation.

---

## ✨ Key Features
| Area | Highlights |
|------|------------|
| **Authentication** | ASP.NET Identity “minimal API endpoints” with bearer tokens (<code>/register</code>, <code>/login</code>, <code>/refresh</code>) |
| **Models** | `Product`, `Category`, `ShoppingCart` (EF-Core POCOs) |
| **Persistence** | EF Core 8 – uses **In-Memory** provider by default (swap to SQL Server or SQLite via `Program.cs`) |
| **API Endpoints** | `GET /api/Product`, `POST /api/Product`, cart add/remove endpoints, all protected with `[Authorize]` |
| **Testing** | 12 xUnit tests (4 per model) ensure property/default-value integrity and basic collection behaviour |
| **Docs & Try-It-Out** | Auto-generated Swagger UI (`/swagger`) including bearer-token “Authorize” lock button |

---

## 🏗️ Getting Started

### Prerequisites
* **.NET 8 SDK** (https://dotnet.microsoft.com/download)
* **Visual Studio 2022** or VS Code + C# extension  
  _(project was built with VS 2022 17.9+)_

### Clone & Run

```bash
git clone https://github.com/<your-github-user>/ShoppingCartAPI.git
cd ShoppingCartAPI

# Restore & run
dotnet restore
dotnet run --project ShoppingCartAPI
