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

### 2.📂 Data Layer & Persistence

- **Automated Data Seeding**: Implemented a robust seeding system using `System.Text.Json` to populate the database with initial data (Products, Brands, Categories, and Delivery Methods) from JSON files.
- **GUID Identity System**: Transitioned to `Guid` for Primary Keys across all entities to ensure globally unique identifiers and prepare for scalable distributed architectures.
- **Entity Configuration**: Applied Fluent API for precise database mapping, including decimal precision for prices and relationship constraints.
- **Auto-Migration**: Integrated automatic database migration on application startup using `context.Database.MigrateAsync()` to ensure the schema is always up-to-date.

## 🧠 Database Design Philosophy & Relationships

In this project, we prioritize **Data Integrity** and **Auditability**. Below is the reasoning behind our core relationship mappings:

- Configured **One-to-Many** relationships for catalogs.
- Decoupled `Product` and `Order` using an **Associative Table (`OrderItem`)** to store historical snapshots.

### 1. The "Snapshot" Pattern (OrderItem ↔ Product)

- **Problem:** If a product's price or name changes in the catalog, historical orders should not be affected.
- **Solution:** Instead of a simple foreign key lookup, we store a **Snapshot** of the product (`Price`, `ProductName`, `PictureUrl`) directly inside the `OrderItem` table at the moment of purchase.
- **Benefit:** Ensures that financial records and customer receipts remain accurate and unchanged over time, even if the source product is deleted or updated.

### 2. Explicit Relationship Mapping (Avoid Shadow Properties)

- **Strategy:** We used **Fluent API** to explicitly define relationships (e.g., `OrderId` as a Foreign Key for `OrderItem`).
- **Why:** EF Core sometimes creates "Shadow Properties" (like `OrderId1`) when relationships are ambiguous. By being explicit, we ensure the database schema remains clean, predictable, and perfectly aligned with our Domain Entities.

### 3. Value Objects via Owned Types (Order ↔ Address)

- **Design:** The shipping `Address` is treated as a **Value Object**.
- **Implementation:** Using `builder.OwnsOne()`, we embed the address fields directly into the `Orders` table.
- **Why:** This avoids unnecessary `JOIN` operations and extra tables, improving database performance while maintaining a clean, object-oriented code structure in the Core layer.

---

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
