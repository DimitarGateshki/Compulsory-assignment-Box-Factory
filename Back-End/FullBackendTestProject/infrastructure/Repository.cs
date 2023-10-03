using Dapper;
using infrastructure.DataModels;
using Npgsql;

namespace infrastructure;

public class Repository
{
    private readonly NpgsqlDataSource _dataSource;

    public Repository(NpgsqlDataSource dataSource)
    {
        _dataSource = dataSource;
    }

    public IEnumerable<Box> GetAllBoxes()
    {
        var sql = $@"select * from public.boxes;";
        using(var conn = _dataSource.OpenConnection())
        {
            return conn.Query<Box>(sql);
        }
    }


    public Box CreateBox(string name, DateTime date, string category)
    {
        var sql = @"INSERT INTO public.boxes (name, date_of_creation, category)
                VALUES (@name, @date, @category)
                RETURNING *";

        using (var conn = _dataSource.OpenConnection())
        {
            var parameters = new { name = name, date = date, category = category };
            
            return conn.QueryFirstOrDefault<Box>(sql, parameters);
        }
    }


}