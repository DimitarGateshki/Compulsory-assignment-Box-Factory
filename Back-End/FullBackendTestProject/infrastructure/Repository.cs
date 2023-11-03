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
        var sql = $@"select * from test_schema.boxes;";
        using(var conn = _dataSource.OpenConnection())
        {
            return conn.Query<Box>(sql);
        }
    }

    public Box GetBoxByID(int id)
    {
        var sql = $@"select * from test_schema.boxes where id=@id;";

        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirstOrDefault<Box>(sql, new {id});
        }
    }
    public IEnumerable<SearchBoxItem> SearchBoxes(string searchTerm, int pageSize)
    {
        var sql = @"SELECT id as BoxId, name as BoxName, category as BoxCategory
                FROM test_schema.boxes
                WHERE LOWER(name) LIKE @searchTerm
                LIMIT @pageSize;";

        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Query<SearchBoxItem>(sql, new { searchTerm = "%" + searchTerm.ToLower() + "%", pageSize });
        }
    }


    public Box CreateBox(string name, DateTime date, string category)
    {
        var sql = @"INSERT INTO test_schema.boxes (name, date_of_creation, category)
                VALUES (@name, @date, @category)
                RETURNING *";

        using (var conn = _dataSource.OpenConnection())
        {
            var parameters = new { name = name, date = date, category = category };
            
            return conn.QueryFirstOrDefault<Box>(sql, parameters);
        }
    }

    public Box UpdateBox(int boxId, string name, DateTime date, string category)
    {
        var sql = @"UPDATE test_schema.boxes SET name = @name, date_of_creation = @date,
                        category = @category WHERE id = @boxId;";

        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirstOrDefault<Box>(sql, new { boxId, name, date, category });
        }
    }

    public bool DeleteBox(int boxId)
    {
        var sql = @"delete from test_schema.boxes where id = @boxId";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Execute(sql, new { boxId }) == 1;
        }
    }


}