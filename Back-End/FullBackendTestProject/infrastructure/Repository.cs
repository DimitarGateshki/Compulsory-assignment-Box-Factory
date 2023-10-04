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

    public Box UpdateBox(int boxId, string name, DateTime date, string category)
    {
        var sql = @"UPDATE public.boxes SET name = @name, date_of_creation = @date,
                        category = @category WHERE id = @boxId;";

        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirstOrDefault<Box>(sql, new { boxId, name, date, category });
        }
    }

    public bool DeleteBox(int boxId)
    {
        var sql = @"delete from public.boxes where id = @boxId";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Execute(sql, new { boxId }) == 1;
        }
    }


}