namespace SQLBuilder;

using System;
using System.Linq;
using System.Reflection;


/// <summary>
/// Implementation of ISqlQueryGenerator that generates SQL queries using reflection.
/// </summary>
public class SqlQueryGenerator : ISqlQueryGenerator
{
    /// <summary>
    /// Generates an SQL INSERT query for the given entity.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    /// <param name="entity">The entity to insert.</param>
    /// <returns>SQL INSERT query as a string.</returns>
    public string GenerateInsertQuery<T>(T entity)
    {
        Type type = typeof(T);
        PropertyInfo[] properties = type.GetProperties();

        string tableName = type.Name;
        string columns = string.Join(", ", properties.Select(p => p.Name));
        string values = string.Join(", ", properties.Select(p => $"'{p.GetValue(entity)}'"));

        return $"INSERT INTO {tableName} ({columns}) VALUES ({values});";
    }

    /// <summary>
    /// Generates an SQL SELECT query for the given entity type.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    /// <returns>SQL SELECT query as a string.</returns>
    public string GenerateSelectQuery<T>()
    {
        Type type = typeof(T);
        PropertyInfo[] properties = type.GetProperties();

        string tableName = type.Name;
        string columns = string.Join(", ", properties.Select(p => p.Name));

        return $"SELECT {columns} FROM {tableName};";
    }

    /// <summary>
    /// Generates an SQL UPDATE query for the given entity.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    /// <param name="entity">The entity to update.</param>
    /// <returns>SQL UPDATE query as a string.</returns>
    public string GenerateUpdateQuery<T>(T entity)
    {
        Type type = typeof(T);
        PropertyInfo[] properties = type.GetProperties();

        string tableName = type.Name;
        string setClause = string.Join(", ", properties.Select(p => $"{p.Name} = '{p.GetValue(entity)}'"));

        // It is assumed that the property Id is the key
        var idProperty = properties.FirstOrDefault(p => p.Name.ToLower() == "id");
        if (idProperty == null)
        {
            throw new InvalidOperationException("No Id property found");
        }
        string idValue = idProperty.GetValue(entity).ToString();

        return $"UPDATE {tableName} SET {setClause} WHERE Id = {idValue};";
    }

    /// <summary>
    /// Generates an SQL DELETE query for the given entity.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    /// <param name="entity">The entity to delete.</param>
    /// <returns>SQL DELETE query as a string.</returns>
    public string GenerateDeleteQuery<T>(T entity)
    {
        Type type = typeof(T);
        PropertyInfo[] properties = type.GetProperties();

        string tableName = type.Name;

        // It is assumed that the property Id is the key
        var idProperty = properties.FirstOrDefault(p => p.Name.ToLower() == "id");
        if (idProperty == null)
        {
            throw new InvalidOperationException("No Id property found");
        }
        string idValue = idProperty.GetValue(entity).ToString();

        return $"DELETE FROM {tableName} WHERE Id = {idValue};";
    }
}
