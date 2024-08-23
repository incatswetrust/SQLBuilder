namespace SQLBuilder;

public interface ISqlQueryGenerator
{
    string GenerateInsertQuery<T>(T entity);
    string GenerateSelectQuery<T>();
    string GenerateUpdateQuery<T>(T entity);
    string GenerateDeleteQuery<T>(T entity);
}
