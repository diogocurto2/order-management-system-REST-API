# Order Management System REST API

## Objective
The goal of this project is to build an exemplary project with the specifications provided in the section: `The code Challenge`.

## Compose sample application: ASP.NET with MS SQL server database
```
.
├── API
│   ├── OrderManagement.Api
|   └── OrderManagement.Domain
|   └── OrderManagement.Infra
|   └── OrderManagement.UseCases
├── api.Tests
│   ├── OrderManagement.Api.Tests
|   └── OrderManagement.Domain.Tests
|   └── OrderManagement.Infra.Tests
|   └── OrderManagement.UseCases.Tests
└── DB
    ├── OrderManagement.Database
```

### OrderManagement.Database
The database project contains the entire structure for creating database tables, stored procedures, and performing the initial data load.

### The code
This project's structure follows the principles of Clean Architecture, aiming to create a well-organized and maintainable system by clearly separating responsibilities. The architecture is designed with concentric layers, each serving a specific purpose, and dependency flow moving from the core to the periphery. Below is a breakdown of the project structure in line with these principles:

#### OrderManagement.Domain
This is the heart of the application. It houses the entities and business rules. It stands independently from other layers, avoiding dependencies on them. In this layer, domain models are defined, along with the main operations the application is designed to perform.

#### OrderManagement.UseCases
Focused on application use cases, this layer orchestrates external actions. It relies on the domain layer and applies business rules to address user needs. Each use case can leverage domain services to achieve its objectives.

#### OrderManagement.Infra
Implementations of interfaces defined in the domain and use cases reside here. This layer handles technical aspects like database access, and Stored Procedure calls. While it relies on both domain and use cases layers, they remain independent of this layer.

#### OrderManagement.Api
The outermost layer interacts with the external world, handling HTTP requests. This layer depends on the use cases and infrastructure layers to execute its tasks.

### Tests
NUnit was used as the testing framework. Each layer has its own set of unit tests. The tests included in the "OrderManagement.Infra.Tests" project are integration tests for the database access layer with the actual database. Therefore, it's necessary for the database to be up and running for these tests to be executed.

## Getting Started

This project was developed using Visual Studio 2022. The steps to initiate the project were set up to run in this environment.
To get started with the project, follow these steps:

1. Clone this repository.
2. Download and Install the SQL server or create a docker with the SQL server
3. Build and publish "OrderManagement.Database" to SQL server
4. Set the startup project to "OrderManagement.Api"
5. Adjust the SQL server connection string on "OrderManagement.Api" "appsettings.json"
6. Run [f5] to start the application.

Visual Studio will launch the project's Swagger UI, where you can execute API functions through the "Try out" feature.

To test the "CreateOrder" function, it's necessary to first use the "Login" function and then utilize the bearer token. The other GET functions do not require login.

# The Code Challenge

This project requires you to develop a simplified Order Management System using C#, .NET, Microsoft SQL Server, Entity Framework, T-SQL, and stored procedures.

The system will have REST API endpoints to create and read data for two entities: Products, and Orders.
Please be sure to read through all of the Overview, Specifications and Optional Extras before you begin work.
You should implement SOLID principles and at least the following design patterns:
● Dependency Injection (DI)
● Repository Pattern
● Unit of work

This project will allow the candidate to demonstrate their knowledge and skills in C#, .NET, Entity Framework, T-SQL, stored procedures, and REST API design.

** Note: Project must be well organized following GitHub repository structure best practices and include a comprehensive README.md **

The project should take approximately one hour and a half to complete.

Setting up the project and designing the database schema: ~15 minutes
Writing the API endpoints and implementing the data access code: ~55 minutes
Writing the stored procedure: ~10 minutes
Writing the limited set of tests: ~10 minutes

## Specifications

### Entity Design

● Product: Products have an ID, name, and price.
● Order: Orders have an ID, a customer ID, a product ID, quantity of the product, and total cost.

### API Endpoints

● Product: A GET endpoint to read a product by its ID.
● Order: A POST endpoint to create a new order and a GET endpoint to read an order by its ID.

### Database Access

● You should use Microsoft SQL Server (either SQL Server Management Studio or just Microsoft SQL Server docker image) and Entity Framework to interact with the database.

 This includes defining the DbContext and the DbSet for each entity, and writing LINQ queries to perform the read operations.

● T-SQL will be used to create the tables and pre-populate them with some initial data.

### Data Persistence

You will write a stored procedure to calculate the total cost and create a new order.

Call this stored procedure from your C# code using Entity Framework when the POST endpoint for creating a new order is hit.

### Authentication

At least the POST endpoint must require authentication; you should use ASP.NET Identity with JWT.

 Optional: role-based authorization (no specifications for roles)

### Data Validation

At least validate that product ID exists when creating an order and that the quantity is positive.

### Testing

Write critical unit tests to validate the functionality of the API endpoints and the stored procedure.

 Suggested testing framework: xUnit.

Note: we have considerably reduced the scope of this topic so candidate can focus on the main areas of the project.

The critical areas to test are:

● Database access methods
○ Minimum: test create order

● API endpoints
○ Minimum: test POST endpoint

● Error handling
○ Minimum: test error handling for non existent products

### Optional Extras

Here is a list with some improvements that you can use to highlight your work.

#### Entity Design

● Add the Customers entity

#### Testing

● Integration testing to test the stored procedure.
● Mocking database operations.

#### Authentication

● Use JWT authentication for the POST endpoint 

#### Pagination and sorting using query parameters

● Paginate and sort all GET endpoints

#### Logging

● Implement logging with Serilog or NLog

#### Dockerize the application

#### API documentation using Swagger

#### Create a basic web client using TypeScript
