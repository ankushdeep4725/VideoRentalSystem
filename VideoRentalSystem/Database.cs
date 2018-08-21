using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace VideoRentalSystem
{
    public class Database
    {

        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private SqlCommand command;
        private string Query;

        public Database()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        }

        public Database(string ConnectionString)
        {
            connection = new SqlConnection(ConnectionString);
        }

        public bool CheckConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                return true;
            }
            else
            {
                connection.Open();
                bool Result = true;
                connection.Close();
                return Result;
            }
        }

        public DataTable SelectQuery(string Query)
        {
            this.Query = Query;
            command = new SqlCommand(Query, connection);
            return ExecuteQuery();
        }

        public DataTable SelectAnd(string TableName, Dictionary<string, string> Where = null, List<string> OrderBy = null)
        {
            Query = "SELECT * FROM [" + TableName + "]";
            if (Where != null)
            {
                if (Where.Count > 0)
                {
                    Query += " WHERE" + GenerateWhere("AND", Where);
                }
            }
            if (OrderBy != null)
            {
                if (OrderBy.Count > 0)
                {
                    Query += " ORDER BY" + GenerateOrderBy(OrderBy);
                }
            }

            command = new SqlCommand(Query, connection);
            BindParameters(Where);
            return ExecuteQuery();
        }

        public DataTable SelectOr(string TableName, Dictionary<string, string> Where = null, List<string> OrderBy = null)
        {
            Query = "SELECT * FROM [" + TableName + "]";
            if (Where != null)
            {
                if (Where.Count > 0)
                {
                    Query += " WHERE" + GenerateWhere("AND", Where);
                }
            }
            if (OrderBy != null)
            {
                if (OrderBy.Count > 0)
                {
                    Query += " ORDER BY" + GenerateOrderBy(OrderBy);
                }
            }

            command = new SqlCommand(Query, connection);
            BindParameters(Where);
            return ExecuteQuery();
        }

        public void Insert(string TableName, Dictionary<string, string> Data)
        {
            Query = "INSERT INTO [" + TableName + "] " + GenerateColumnParameters(false, Data) + " VALUES " + GenerateColumnParameters(true, Data);
            command = new SqlCommand(Query, connection);
            BindParameters(Data);
            ExecuteQuery();
        }

        public void Update(string TableName, Dictionary<string, string> Data, Dictionary<string, string> Where)
        {
            Query = "UPDATE [" + TableName + "] SET " + GenerateUpdateParameters(Data) + " WHERE " + GenerateWhere("AND", Where);
            command = new SqlCommand(Query, connection);
            BindParameters(Data);
            BindParameters(Where);
            ExecuteQuery();
        }

        public void Delete(string TableName, Dictionary<string, string> Where)
        {
            Query = "DELETE FROM [" + TableName + "] WHERE " + GenerateWhere("AND", Where);
            command = new SqlCommand(Query, connection);
            BindParameters(Where);
            ExecuteQuery();
        }

        private string GenerateWhere(string Operator, Dictionary<string, string> Where)
        {
            string WhereClause = "";
            foreach (var item in Where)
            {
                WhereClause += " [" + item.Key + "] = @" + item.Key + " " + Operator;
            }
            WhereClause = WhereClause.Substring(0, WhereClause.Length - (Operator.Length + 1));
            return WhereClause;
        }

        private string GenerateOrderBy(List<string> OrderBy)
        {
            string OrderByClause = "";
            foreach (var item in OrderBy)
            {
                OrderByClause += " " + item + ",";
            }
            OrderByClause = OrderByClause.Substring(0, OrderByClause.Length - 1);
            return OrderByClause;
        }

        private string GenerateUpdateParameters(Dictionary<string, string> Data)
        {
            string UpdateParameters = "";
            foreach (var item in Data)
            {
                UpdateParameters += "[" + item.Key + "] = @" + item.Key + ", ";
            }
            UpdateParameters = UpdateParameters.Substring(0, UpdateParameters.Length - 2);
            return UpdateParameters;
        }

        private string GenerateColumnParameters(bool IsParam, Dictionary<string, string> Data)
        {
            string ColumnParameters = "(";
            foreach (var item in Data)
            {
                if (!IsParam)
                {
                    ColumnParameters += "[" + item.Key + "],";
                }
                else
                {
                    ColumnParameters += "@" + item.Key + ",";
                }
            }
            ColumnParameters = ColumnParameters.Substring(0, ColumnParameters.Length - 1);
            ColumnParameters += ")";
            return ColumnParameters;
        }

        private DataTable ExecuteQuery()
        {
            DataTable table = new DataTable();
            adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            return table;
        }

        private void BindParameters(Dictionary<string, string> Parameters)
        {
            if (Parameters != null)
            {
                foreach (var Parameter in Parameters)
                {
                    command.Parameters.AddWithValue("@" + Parameter.Key, Parameter.Value);
                }
            }
        }

        public int CheckAvaliableCopies(int MovieID)
        {
            Query = "SELECT (SELECT Copies FROM Movies WHERE MovieID = @MovieID) - (SELECT ISNULL(COUNT(MovieIDFK), 0) FROM RentedMovies WHERE MovieIDFK = @MovieID AND DateReturned IS NULL)";

            command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@MovieID", MovieID);

            return Convert.ToInt32(ExecuteQuery().Rows[0][0]);
        }

        public DataTable GetPendingRentals()
        {
            Query = "SELECT RMID, Customer.FirstName, Customer.LastName, Customer.[Address], Movies.Title, Movies.Rental_Cost, RentedMovies.DateRented, RentedMovies.DateReturned FROM RentedMovies INNER JOIN Movies ON RentedMovies.MovieIDFK = Movies.MovieID INNER JOIN Customer ON RentedMovies.CustIDFK = Customer.CustID WHERE RentedMovies.DateReturned IS NULL";
            command = new SqlCommand(Query, connection);

            return ExecuteQuery();
        }

        public DataTable GetBestCustomers()
        {
            Query = "SELECT *, ISNULL((SELECT COUNT(RMID) FROM RentedMovies WHERE CustIDFK = CustID), 0) AS RentedMovies FROM Customer ORDER BY RentedMovies DESC";
            command = new SqlCommand(Query, connection);

            return ExecuteQuery();
        }

        public DataTable GetBestMovies()
        {
            Query = "SELECT *, ISNULL((SELECT COUNT (RMID) FROM RentedMovies WHERE MovieIDFK = MovieID), 0) AS TimesRented FROM Movies ORDER BY TimesRented DESC";
            command = new SqlCommand(Query, connection);

            return ExecuteQuery();
        }
    }
}