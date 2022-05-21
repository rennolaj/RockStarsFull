# CleanArchitecture-Template
This is a solution template for [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) and CQRS implementation with ASP.NET Core

![CleanArchitecture](https://user-images.githubusercontent.com/42376112/110762993-a61b1580-8266-11eb-9ac1-438072319971.jpg)

## Give a Star! ⭐
If you like or are using this project to learn or start your solution, please give it a star. Thanks!

## Technologies used:

* ASP.NET Core
* Entity Framework Core
* MediatR
* Swagger
* Redis (for distributed caching)
* Jwt Token Authentication
* Custom Asp.Net Identity
* Api Versioning
* FluentValidation
* PolyCache (for caching)
* Serilog
* Elasticsearch (for writing Logs)
* AutoMapper
* Docker

## Software Development Best Practices and Design Principles used:

* Clean Architecture
* Clean Code
* CQRS
* Authentication and Authorization
* Distributed caching
* Solid Principles
* Separate ReadOnly and Write DbContext
* Separate ReadOnly and Write Repository
* REST API Naming Conventions
* Use multiple environments in ASP.NET Core (Development,Production,Staging,etc)
* Modular Design
* Custom Exceptions
* Custom Exception Handling
* PipelineBehavior for Validation and Performance tracking.

# Create your project
### Create an empty folder and run cmd and then paste the following code:
### Enter your project name instead of MyNewRockStars

```ruby
  > dotnet new ASPNETRockStars -n MyNewRockStars
  ```

# For Database Migration:
  ### First:
  Set default project to Persistence
  ### Second:
  Run following code in Package Manager Console
  ```ruby
  > Update-Database -Context AppDbContext
  ```
## Read More
1. https://virgool.io/@ahmadpooromid/%D9%85%D9%81%D9%87%D9%88%D9%85-%D9%88-%D9%BE%DB%8C%D8%A7%D8%AF%D9%87-%D8%B3%D8%A7%D8%B2%DB%8C-scalability-%D8%AF%D8%B1-cqrs-peixkgrbdgff
2. https://medium.com/@omid-ahmadpour/clean-architecture-template-with-net-and-its-importance-e5b3b97a6e48
