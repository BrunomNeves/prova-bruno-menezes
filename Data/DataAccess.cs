using System.Data.SqlClient;
using System.Data;




namespace prova_bruno_menezes.Data
{
    public class DataAccess 
    {
    
        private SqlConnection _connection;
        private string _connectionString;

        public DataAccess(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new SqlConnection(_connectionString);
        }

        private bool OpenConnection()
        {
            bool resp = true;
            try
            {

                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resp;
        }

        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open) _connection.Close();
        }

        public SqlDataReader ExecuteReader(SqlCommand command)
        {
            SqlDataReader reader;
            try
            {
                OpenConnection();
                command.Connection = _connection;
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return reader;
        }

        public int ExecuteNonQuery(string commandText)
        {
            int cte;
            try
            {
                if (_connection.State != ConnectionState.Open)
                    OpenConnection();
                SqlCommand command = new SqlCommand(commandText);
                command.Connection = _connection;
                cte = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cte;
        }

        public int ExecuteInsert(SqlCommand command)
        {
            int id;
            try
            {
                command.CommandText += ";SELECT SCOPE_IDENTITY()";
                OpenConnection();
                command.Connection = _connection;
                object resp = command.ExecuteScalar();
                id = int.Parse(resp.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;
        }


        public void Dispose()
        {
            if (_connection != null)
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
                _connection = null;
            }
        }


    }
}
