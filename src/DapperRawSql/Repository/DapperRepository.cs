using System.Data;
using System.Data.SqlClient;

namespace DapperRawSql.Repository
{
    public class DapperRepository
    {
        private readonly IDbConnection _connection;

        public DapperRepository()
        {
            _connection = new SqlConnection("Server=localhost;Database=DapperRawSql;Trusted_Connection=True;User Id=sa;password=sql!123456;MultipleActiveResultSets=true;Integrated Security=False");
        }

        public IDbConnection Connection
        {
            get { return _connection; }
        }

        public void Dispose()
        {
            if (_connection != null)
                _connection.Dispose();
        }
    }
}