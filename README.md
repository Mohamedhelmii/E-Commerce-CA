# E-Commerce Project (.NET 9 Web API)

A robust and scalable E-Commerce Backend System built with **ASP.NET Core 9**, following **Clean Architecture** principles and **Domain-Driven Design (DDD)**.

## 🏗️ Architecture Overview

The project is organized into distinct layers to ensure a clean separation of concerns:

- **Core Layer:** The heart of the system, containing Domain Entities, Enums, and Core logic.
- **Repository Layer (Infrastructure):** Handles data persistence, Entity Framework Core configurations, and database migrations.
- **Service Layer:** Acts as an intermediary between the API and Repository layers, containing the Business Logic and coordinating application tasks.
- **API Layer:** The presentation layer containing Controllers, Middlewares, and API configurations.

## 🚀 Key Features Implemented So Far

### 1. Domain Modeling (Entities)

Comprehensive database schema design:

- **Product Aggregate:** `Product`, `ProductBrand`, and `ProductCategory`.
- **Order Aggregate:** `Order`, `OrderItem`, and `DeliveryMethod`.
- **Identity & Location:** `Address` (implemented as an **Owned Type** within the Order).

### 2. Relationship Management

- Configured **One-to-Many** relationships for catalogs.
- Decoupled `Product` and `Order` using an **Associative Table (`OrderItem`)** to store historical snapshots (Price/Quantity at the time of purchase).

### 3. Database & Tools Setup

- Configured **Entity Framework Core 9.0** as the ORM.
- Integrated **SQL Server** as the database provider.
- Installed necessary EF Core packages (`SqlServer`, `Tools`, `Design`) compatible with **.NET 9**.

## 🛠️ Tech Stack

- **Framework:** .NET 9.0 (C#)
- **ORM:** Entity Framework Core 9.0
- **Database:** Microsoft SQL Server
- **Architecture:** Clean Architecture with Service & Repository Patterns.

## 📂 Current Progress

- ✅ Solution & Multi-layered Project Setup (API, Service, Repository, Core).
- ✅ Domain Entities & Relationship Mapping.
- ✅ NuGet Packages Installation & Version Compatibility.
- Database Context (`StoreContext`) Configuration.
- Initial Database Migration & Seeding.

---

_Developed by Mohamed Helmy Rashed Ahmed_
