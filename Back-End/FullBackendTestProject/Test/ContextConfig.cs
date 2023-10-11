using Npgsql;

namespace Test;


    public class ContextConfig
    {
        public static readonly NpgsqlDataSource DataSource; 
        public static readonly string ClientAppBaseUrl = "http://localhost:5000";
        public static readonly string ApiBaseUrl = "http://localhost:5000/box";

    }
