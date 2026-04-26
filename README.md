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
- Decoupled `Product` and `Order` using an **Associative Table (`OrderItem`)** to store historical snapshots.

### 3. Database & Tools Setup

- Configured **Entity Framework Core 9.0** as the ORM.
- Integrated **SQL Server** as the database provider.
- Installed necessary EF Core packages (`SqlServer`, `Tools`, `Design`) compatible with **.NET 9**.

### 4. Advanced EF Core Mapping (Fluent API)

- **Data Snapshot Pattern:** Implemented a snapshot strategy in `OrderItem` to store `Price`, `ProductName`, and `ImageUrl` at the time of purchase. This prevents historical order data from changing when the product catalog is updated.
- **Global Query Filters:** Centralized configuration for **Soft Deletes** using a `BaseConfiguration` class, ensuring that "deleted" records are automatically excluded from all queries.
- **Owned Entity Types:** Optimized the `Order` table by embedding the `Address` entity directly into it using `OwnsOne`, improving performance and simplifying the database schema.

## 📊 Database Schema Insight

The database design prioritizes **Data Integrity**:

- **Order-OrderItem:** Configured with `DeleteBehavior.Cascade` to manage the lifecycle of order lines.
- **Product-OrderItem Link:** Established an explicit Foreign Key via `ProductItemId` to maintain a reference to the source product while keeping the data independent.

## 🛠️ Tech Stack

- **Framework:** .NET 9.0 (C#)
- **ORM:** Entity Framework Core 9.0
- **Database:** Microsoft SQL Server
- **Architecture:** Clean Architecture with Service & Repository Patterns.

## 📂 Current Progress

- ✅ Solution & Multi-layered Project Setup (API, Service, Repository, Core).
- ✅ Domain Entities & Relationship Mapping.
- ✅ NuGet Packages Installation & Version Compatibility.
- ✅ Fluent API Configurations (Relational Mapping & Constraints).
- ✅ Handling Ambiguous Relationships between `Order` and `OrderItem`.
- ✅ Database Migration successfully generated via `InitialCreate`.

---

_Developed by Mohamed Helmy Rashed Ahmed_
