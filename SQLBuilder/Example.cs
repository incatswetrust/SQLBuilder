namespace SQLBuilder;
class Example
{

    //example class
    class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
    
    User user = new User
    {       
        Id = 1,
        FirstName = "John",
        LastName = "Doe",
        Email = "john.doe@example.com"
    };

    ISqlQueryGenerator queryGenerator = new SqlQueryGenerator();

    //commands strings
    string insertQuery = queryGenerator.GenerateInsertQuery(user);
    string selectQuery = queryGenerator.GenerateSelectQuery<User>();
    string updateQuery = queryGenerator.GenerateUpdateQuery(user);
    string deleteQuery = queryGenerator.GenerateDeleteQuery(user);

    Console.WriteLine(insertQuery);
    Console.WriteLine(selectQuery);
    Console.WriteLine(updateQuery);
    Console.WriteLine(deleteQuery);
}
