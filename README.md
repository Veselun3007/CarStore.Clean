# CarStore.Clean

This repository contains a sample implementation of a Car Store system built following Clean Architecture principles

## Purpose & Learning Goals
- Understand Clean Architecture by separating concerns into distinct layers: Domain, Application, Infrastructure, and Presentation (Web API).
- Implement Dependency Injection with proper lifecycle management via extension methods for each layer.
- Practice EF Core Code-First Development including entity modeling, relationships, and migrations.
- Containerize the application with Docker and Docker Compose to simplify deployment and testing.

## **Task 1.** Develop a solution according to Clean architecture:
- Solution should contain 4 projects: `CarStore.Domain`, `CarStore.Application`, 
`CarStore.Infrastructure` and `CarStore.WebApi`.
- Dependencies between projects should be established according to Clean architecture.
- Each project should have extension class to inject dependencies into IoC container 
(IServiceCollection).
- Each project should have extension class to update your application pipeline 
(IApplicationBuilder).
- Create a test entity with some related logic in Domain project (example: User, Car, etc.).
- Create a test service in Application project to create/update your entity.
- Create a test controller in WebApi project to call the test service.
- Inject all of the required dependencies into IoC container.
- Test the project using Swagger/Postman.

## Clean Architecture Implementation

The solution is structured according to `Clean Architecture principles` and consists of the following four projects:

- `CarStore.Clean.Domain`  
- `CarStore.Clean.Application`  
- `CarStore.Clean.Infrastructure`  
- `CarStore.Clean.WebApi`  

### Project Structure and Dependencies

- Projects are decoupled according to Clean Architecture layers.
- Each project includes:
  - An extension method for injecting dependencies into the IoC container (`IServiceCollection`).
  - An extension method for configuring the application pipeline (`IApplicationBuilder`).

---

## Domain Layer

Contains the core business entities and logic. For demonstration purposes, four simple entities were created with basic relationships:

```plaintext
Dealer 1 ────< Car >──── 1 Sale >──── 1 User
             |               |
             |               v
             +──────────── Car
```

> [!NOTE]
> The data model is simplified for testing and demonstration. It is not intended for production use.

## Application Layer

A sample service was implemented to handle create/update operations for the entities. This service demonstrates how business logic can be encapsulated without any dependency on infrastructure.

## Infrastructure Layer

Implements repositories using Entity Framework Core. The database is managed using the `code-first` approach with migrations.

## Web API Layer

A sample controllers was created to expose API endpoints that consume the application services.

> [!NOTE]
> - To avoid additional dependencies, native object mapping (manual property-to-property mapping) is used instead of external libraries like AutoMapper or Mapperly.
> - The `Template Method` pattern is applied to controllers to encapsulate shared logic and reduce boilerplate. This ensures consistency across CRUD-like controllers and improves maintainability.

## Testing & Swagger Integration

- The application is fully integrated with Swagger for interactive API testing.
- An operation filter is applied to inject test data examples directly into Swagger UI, making it easier to try out the endpoints without manual input.

## Running the Application

To run the project locally using Docker, use the following command:

```bash
docker-compose up --build
```

After a successful build, navigate to Swagger UI to interact with the API:

```txt
http://localhost:8080/swagger
```
