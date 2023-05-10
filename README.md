# MediatR Demo Application
This demo application showcases the usage of MediatR in a C#.Net application. MediatR is a lightweight and extensible framework for handling and organizing application logic. It simplifies the implementation of the Mediator pattern and promotes loose coupling between application components.

## Prerequisites
Before running the application, ensure that the following software and tools are installed on your machine:

.NET Core SDK (.Net 6.0)

Visual Studio or any other C# IDE of your choice

## Installation
Clone the repository to your local machine.

Open the solution file in Visual Studio or your preferred C# IDE.

Build the solution.

## Usage
This demo application is a simple console application that demonstrates how MediatR can be used to handle and organize application logic. It includes examples of command and query handlers, as well as notification handlers.

It supports both following two types of Databases.
1. **Microsoft SQL Server** 
	* To use this, provide valid Connectionstring for "MediatRDbContext" into appsettings.json.
2. **InMemory Database**
	* To use this, provide empty Connectionstring for "MediatRDbContext" into appsettings.json or comment it out.


To run the application, simply execute the built executable from the command line. The application will display output demonstrating the usage of MediatR in the application.

## Code Structure
The demo application is organized into the following components:

#### 1. MediatRDemo.API
ASP.Net Core WebAPI Project exposing REST APIs
1. **Commands**: Contains classes representing commands that can be sent to the Mediator.
2. **Queries**: Contains classes representing queries that can be sent to the Mediator.
3. **Handlers**: Contains classes implementing command, query, and notification handlers.
4. **Notifications**: Contains classes representing notifications that can be sent to the Mediator.
	* I have handled notification by two handlers and shown message on console for demo purpose. Actual functionality can be different.

	MediatR is used throughout the application to handle and dispatch commands, queries, and notifications. The application demonstrates how MediatR promotes loose coupling between components and simplifies the implementation of the Mediator pattern.

#### 2. MediatRDemo.Data
.Net Core Class Library having Dbcontext and Repositories with IUnitOfWork.

## Testing
The demo application includes unit tests to ensure that the MediatR Query handlers are working correctly. To run the tests, simply execute the dotnet test command from the command line.

I have covered Unit Tests for Query Handlers only, but tests for Command and Notification handlers can be added easily.
## Limitations
This demo application is intended to be a simple showcase of MediatR usage and is not meant to be a complete application. It has limitations and may not be suitable for use in a production environment.

## License
This demo application is released under the [MIT License](https://en.wikipedia.org/wiki/MIT_License).

## Acknowledgments
This demo application uses the following third-party libraries:

* MediatR
* [Opticient.EFCore.Repository](https://www.nuget.org/packages/Opticient.EFCore.Repository)
* AutoMapper

## Contact
If you have any questions or feedback on this demo application, please feel free to contact the author at [Contact](contact.person@opticient.co.uk).