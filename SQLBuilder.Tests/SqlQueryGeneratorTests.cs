using Xunit;

namespace SQLBuilder.Tests;

public class SqlQueryGeneratorTests
{
    private readonly ISqlQueryGenerator _sqlQueryGenerator;

    public SqlQueryGeneratorTests()
    {
        _sqlQueryGenerator = new SqlQueryGenerator();
    }

    [Fact]
    public void GenerateInsertQuery_ShouldGenerateCorrectQuery()
    {
        var user = new User
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com"
        };
        string result = _sqlQueryGenerator.GenerateInsertQuery(user);
        string expected = "INSERT INTO User (Id, FirstName, LastName, Email) VALUES ('1', 'John', 'Doe', 'john.doe@example.com');";
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GenerateSelectQuery_ShouldGenerateCorrectQuery()
    {
        string result = _sqlQueryGenerator.GenerateSelectQuery<User>();
        string expected = "SELECT Id, FirstName, LastName, Email FROM User;";
        Assert.Equal(expected, result);
    }

    [Fact]
    public void GenerateUpdateQuery_ShouldGenerateCorrectQuery()
    {
        var user = new User
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com"
        };
        string result = _sqlQueryGenerator.GenerateUpdateQuery(user);
        string expected = "UPDATE User SET Id = '1', FirstName = 'John', LastName = 'Doe', Email = 'john.doe@example.com' WHERE Id = 1;";
        Assert.Equal(expected, result);
    }
    [Fact]
    public void GenerateDeleteQuery_ShouldGenerateCorrectQuery()
    {
        var user = new User
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com"
        };
        string result = _sqlQueryGenerator.GenerateDeleteQuery(user);
        string expected = "DELETE FROM User WHERE Id = 1;";
        Assert.Equal(expected, result);
    }
}