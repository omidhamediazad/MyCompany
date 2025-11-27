# MyCompany.Shop

A demo project showcasing **Clean Architecture** with **CQRS**, **MediatR**, **Entity Framework Core**, **FluentValidation**, and **Swagger**.

---

## 📂 Architecture

- **Domain**: Core business entities (`Product`, `Order`, `Payment`, `User`) and interfaces.
- **Application**: CQRS commands, queries, handlers, DTOs, validators, and pipeline behaviors.
- **Infrastructure**: EF Core DbContext, migrations, repositories, and persistence logic.
- **Api**: ASP.NET Core Web API with controllers, Swagger UI, and dependency injection.

---

## 🚀 Features

- Full CRUD for Products (Create, Read, Update, Delete).
- CQRS pattern with MediatR.
- Validation pipeline using FluentValidation.
- Swagger UI for testing endpoints.
- EF Core with migrations and seeding.

---

## 🛠️ Getting Started

### Prerequisites
- .NET 8 SDK
- SQL Server (or LocalDB)

### Setup
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/MyCompany.Shop.git
