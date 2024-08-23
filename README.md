# SQL Query Generator Library
## Overview
The SQL Query Generator Library is a lightweight, flexible library designed to dynamically generate SQL queries for CRUD (Create, Read, Update, Delete) operations using reflection. This library adheres to SOLID principles, making it easy to maintain, extend, and integrate into your existing .NET projects.

## Features
* Dynamic Query Generation: Automatically generates SQL queries based on your data models, reducing the need for manual SQL writing.
* CRUD Operations: Supports generating SQL queries for Create (INSERT), Read (SELECT), Update (UPDATE), and Delete (DELETE) operations.
* Reflection-Based: Utilizes reflection to inspect your data models, ensuring that queries are always in sync with your model definitions.
* SOLID Design: The library is built following SOLID principles, promoting clean, maintainable, and scalable code.

## Usage
### Installation
Add the library to your project by including the source files or by using a package manager (if available).

### Example
```csharp
public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}

var user = new User
{
    Id = 1,
    FirstName = "John",
    LastName = "Doe",
    Email = "john.doe@example.com"
};

ISqlQueryGenerator queryGenerator = new SqlQueryGenerator();

string insertQuery = queryGenerator.GenerateInsertQuery(user);
string selectQuery = queryGenerator.GenerateSelectQuery<User>();
string updateQuery = queryGenerator.GenerateUpdateQuery(user);
string deleteQuery = queryGenerator.GenerateDeleteQuery(user);

Console.WriteLine(insertQuery);
Console.WriteLine(selectQuery);
Console.WriteLine(updateQuery);
Console.WriteLine(deleteQuery);
```
### Output
```sql
INSERT INTO User (Id, FirstName, LastName, Email) VALUES ('1', 'John', 'Doe', 'john.doe@example.com');
SELECT Id, FirstName, LastName, Email FROM User;
UPDATE User SET Id = '1', FirstName = 'John', LastName = 'Doe', Email = 'john.doe@example.com' WHERE Id = 1;
DELETE FROM User WHERE Id = 1;
```
