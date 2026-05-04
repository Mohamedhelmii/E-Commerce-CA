# E-Commerce Project (.NET 9 Web API)

A robust and scalable E-Commerce Backend System built with **ASP.NET Core 9**, following **Clean Architecture** principles and **Domain-Driven Design (DDD)**.

## 🏗️ Architecture Overview

The project is organized into distinct layers to ensure a clean separation of concerns:

- **Core Layer:** The heart of the system, containing Domain Entities, Specifications, and Core logic.
- **Repository Layer (Infrastructure):** Handles data persistence, Entity Framework Core configurations, and Specification evaluation.
- **Service Layer:** Acts as an intermediary, containing Business Logic and coordinating application tasks.
- **API Layer:** The presentation layer containing Controllers, Middlewares, and API configurations.

## 🚀 Key Features & Progress

### 1. 🏗️ Architectural Patterns (Advanced Implementation)

To ensure a loosely coupled architecture and high maintainability, we implemented the following patterns:

- **Generic Repository Pattern**: Created a centralized `IGenericRepository<T>` to handle common CRUD operations for all domain entities.
- **Specification Pattern**: Developed a flexible query building system to handle complex data fetching logic (Filtering, Including) outside the controllers, adhering to the **Open-Closed Principle**.
- **Performance Optimization**: Integrated `.AsNoTracking()` in all read-only operations to reduce memory overhead and improve response times.

### 2. 📂 Data Layer & Specification Logic

- **Eager Loading**: Configured specifications to include related data (Brands and Categories) in a single database round-trip, ensuring `Product` data is always complete.
- **Automated Data Seeding**: Implemented a robust seeding system using `System.Text.Json` to populate initial data from JSON files.
- **GUID Identity System**: Standardized on `Guid` for Primary Keys across all entities for better scalability.
- **Auto-Migration**: Integrated automatic database migration on application startup.

### 3. 🧠 Database Design Philosophy

- **Snapshot Pattern**: `OrderItem` stores a snapshot of product details (`Price`, `Name`) at the time of purchase to maintain historical accuracy.
- **Owned Entity Types**: Optimized the `Order` table by embedding the `Address` entity directly using `OwnsOne`.
- **Global Query Filters**: Centralized configuration for **Soft Deletes** to automatically exclude "deleted" records from queries.

## 🛣️ Implemented API Endpoints

| Resource     | Method | Endpoint               | Description                                   |
| ------------ | ------ | ---------------------- | --------------------------------------------- |
| **Products** | GET    | `/api/products`        | Get all products with Brands and Categories.  |
| **Products** | GET    | `/api/products/{id}`   | Get specific product details (Included data). |
| **Brands**   | GET    | `/api/brands`          | List all available product brands.            |
| **Brands**   | GET    | `/api/brands/{id}`     | Get specific brand details.                   |
| **Category** | GET    | `/api/categories`      | List all available product categories.        |
| **Category** | GET    | `/api/categories/{id}` | Get specific category details.                |

## 🛠️ Tech Stack & Tools

- **Framework:** .NET 9.0 (C#)
- **ORM:** Entity Framework Core 9.0
- **Database:** Microsoft SQL Server
- **Serialization:** Configured `ReferenceHandler.IgnoreCycles` to handle complex entity relationships gracefully.
- **Documentation:** Swagger UI for interactive API testing.

## ✅ Current Status: Phase 1 Completed

- [x] Solution & Multi-layered Project Setup.
- [x] Domain Entities & Fluent API Mapping.
- [x] Generic Repository & Specification Pattern Implementation.
- [x] Refactored Controllers to use Specification logic.
- [x] Resolved Object Cycle issues in JSON serialization.

---

_Developed by Mohamed Helmy Rashed Ahmed_
