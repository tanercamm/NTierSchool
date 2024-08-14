# NTierSchool ASP.NET Core Web API
- This project is a school management system that performs basic CRUD operations through an ASP.NET Core Web API.
 The project is built using the NTier architecture, which provides strong separation between different layers of the application.
## Architecture
The project is structured into the following layers:
- School.BLL (Business Logic Layer): This layer contains the business logic of the application. Business rules are defined here, and it interacts with the DAL (Data Access Layer).
- School.DAL (Data Access Layer): This layer handles direct interaction with the database. All database operations are performed here.
- School.Entity: This layer defines the core data models of the application.
- School.UI: This is the presentation layer of the API, where API requests are processed and responses are returned.
## Features
- Modular structure using NTier architecture.
- CRUD operations (Create, Read, Update, Delete).
- RESTful API adhering to industry standards.
- Integration with an MsSQL database using Entity Framework.
## Installation
### To clone and set up the project locally, use the following commands:
```
git clone https://github.com/tanercamm/NTierSchool.git
cd NTierSchool
```
### To install the required dependencies:
```
dotnet restore
```
### To run the project:
```
dotnet run
```
## Usage
- After running the project, you can access and test the API endpoints using Postman or a similar tool.
## API Endpoints
### School
- GET /api/School/Details => Retrieves the list of all schools with their details.
- GET /api/School => Retrieves a list of all schools.
- GET /api/School/{id} => Retrieves a specific school by ID.
- POST /api/School => Adds a new school.
- PUT /api/School/{id} => Updates an existing school by ID.
- DELETE /api/School/{id} => Deletes a specific school by ID.
### Class
- GET /api/Class/Details => Retrieves the list of all classes with their details.
- GET /api/Class => Retrieves a list of all classes.
- GET /api/Class/{id} => Retrieves a specific class by ID.
- POST /api/Class => Adds a new class.
- PUT /api/Class/{id} => Updates an existing class by ID.
- DELETE /api/Class/{id} => Deletes a specific class by ID.
### Teacher
- GET /api/Teacher/Details => Retrieves the list of all teachers with their details.
- GET /api/Teacher => Retrieves a list of all teachers.
- GET /api/Teacher/{id} => Retrieves a specific teacher by ID.
- POST /api/Teacher => Adds a new teacher.
- PUT /api/Teacher/{id} => Updates an existing teacher by ID.
- DELETE /api/Teacher/{id} => Deletes a specific teacher by ID.
### Student
- GET /api/Student/Details => Retrieves the list of all students with their details.
- GET /api/Student => Retrieves a list of all students.
- GET /api/Student/{id} => Retrieves a specific student by ID.
- POST /api/Student => Adds a new student.
- PUT /api/Student/{id} => Updates an existing student by ID.
- DELETE /api/Student/{id} => Deletes a specific student by ID.
##
