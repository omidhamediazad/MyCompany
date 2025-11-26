# 🛍️ Shop API Project

## 📖 Overview
A simple e-commerce API built with ASP.NET Core and Entity Framework Core.  
This project uses a layered architecture with four main projects: **Domain**, **Application**, **Infrastructure**, and **Api**.

---

## 📂 Project Structure
- **Domain** → Entities and core business logic  
- **Application** → Commands, Queries, and Validation (MediatR + FluentValidation)  
- **Infrastructure** → Database context and EF Core configuration  
- **Api** → Controllers, Swagger UI for testing endpoints  

---

## ✅ Steps Completed
1. Created solution and added 4 projects (Domain, Application, Infrastructure, Api).  
2. Installed and configured MediatR and FluentValidation in Application layer.  
3. Configured `ShopDbContext` with SQL Server in Infrastructure.  
4. Added `Product` entity with properties: Id, Name, Price, Stock, CreatedAt.  
5. Created `ProductsController` with CRUD endpoints.  
6. Ran EF Core migrations and created database `ShopDb`.  
7. Tested CRUD endpoints successfully in Swagger (Create, Read, Update, Delete).  

---

## 🔜 Next Step
Implement **JWT authentication** for user accounts to secure API endpoints.

---

## 🚀 How to Run
1. Clone the repository.  
2. Update connection string in `appsettings.json` with your SQL Server settings.  
3. Run migrations:  
   ```powershell
   Update-Database -Project MyCompany.Shop.Infrastructure -StartupProject MyCompany.Shop.Api
