using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

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
            //Create connection with default connection string in App.config
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        }

        public Database(string ConnectionString)
        {
            //create connection with provided connection string
            connection = new SqlConnection(ConnectionString);
        }

        public bool CheckConnection()
        {
            //Check of connection is working
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
            //Run Provided Select Query
            this.Query = Query;
            command = new SqlCommand(Query, connection);
            return ExecuteQuery();
        }

        public DataTable SelectAnd(string TableName, Dictionary<string, string> Where = null, List<string> OrderBy = null)
        {
            //Create SELECT Query from the TableName, Dictionary containing key-value pair for WHERE clause and ORDER BY
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

            //Create new command with generated query
            command = new SqlCommand(Query, connection);

            //Bind the paramter values
            BindParameters(Where);

            //Execute query and return DataTable
            return ExecuteQuery();
        }

        public DataTable SelectOr(string TableName, Dictionary<string, string> Where = null, List<string> OrderBy = null)
        {
            //Create SELECT Query from the TableName, Dictionary containing key-value pair for WHERE clause and ORDER BY
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

            //Create new command with generated query
            command = new SqlCommand(Query, connection);

            //Bind the paramter values
            BindParameters(Where);

            //Execute query and return DataTable
            return ExecuteQuery();
        }

        public void Insert(string TableName, Dictionary<string, string> Data)
        {
            //Generate INSERT Query with Data key-value pair dictionary
            Query = "INSERT INTO [" + TableName + "] " + GenerateColumnParameters(false, Data) + " VALUES " + GenerateColumnParameters(true, Data);

            //Create new command with generated query
            command = new SqlCommand(Query, connection);

            //Bind the paramter values
            BindParameters(Data);

            //Execute query
            ExecuteQuery();
        }

        public void Update(string TableName, Dictionary<string, string> Data, Dictionary<string, string> Where)
        {
            //Generate UPDATE Query with Data key-value pair dictionary and WHERE clause
            Query = "UPDATE [" + TableName + "] SET " + GenerateUpdateParameters(Data) + " WHERE " + GenerateWhere("AND", Where);

            //Create new command with generated query
            command = new SqlCommand(Query, connection);

            //Bind the paramter values
            BindParameters(Data);

            //Bind the paramter values for WHERE clause
            BindParameters(Where);

            //Execute query
            ExecuteQuery();
        }

        public void Delete(string TableName, Dictionary<string, string> Where)
        {
            //Generate DELETE Query with WHERE clause
            Query = "DELETE FROM [" + TableName + "] WHERE " + GenerateWhere("AND", Where);

            //Create new command with generated query
            command = new SqlCommand(Query, connection);

            //Bind the paramter values for WHERE clause
            BindParameters(Where);

            //Execute query
            ExecuteQuery();
        }

        private string GenerateWhere(string Operator, Dictionary<string, string> Where)
        {
            string WhereClause = "";
            foreach (var item in Where)
            {
                //Generate WHERE clause sub query
                WhereClause += " [" + item.Key + "] = @" + item.Key + " " + Operator;
            }
            WhereClause = WhereClause.Substring(0, WhereClause.Length - (Operator.Length + 1));

            //return WHERE clause sub query
            return WhereClause;
        }

        private string GenerateOrderBy(List<string> OrderBy)
        {
            string OrderByClause = "";
            foreach (var item in OrderBy)
            {
                //Generate ORDER BY clause sub query
                OrderByClause += " " + item + ",";
            }
            OrderByClause = OrderByClause.Substring(0, OrderByClause.Length - 1);

            //return ORDER BY clause sub query
            return OrderByClause;
        }

        private string GenerateUpdateParameters(Dictionary<string, string> Data)
        {
            string UpdateParameters = "";
            foreach (var item in Data)
            {
                //Generate UPDATE parameters
                UpdateParameters += "[" + item.Key + "] = @" + item.Key + ", ";
            }
            UpdateParameters = UpdateParameters.Substring(0, UpdateParameters.Length - 2);

            //return UPDATE parameters
            return UpdateParameters;
        }

        private string GenerateColumnParameters(bool IsParam, Dictionary<string, string> Data)
        {
            string ColumnParameters = "(";
            foreach (var item in Data)
            {
                if (!IsParam)
                {
                    //Generate column names for INSERT query
                    ColumnParameters += "[" + item.Key + "],";
                }
                else
                {
                    //Generate column parameters for INSERT query
                    ColumnParameters += "@" + item.Key + ",";
                }
            }
            ColumnParameters = ColumnParameters.Substring(0, ColumnParameters.Length - 1);
            ColumnParameters += ")";

            //return Column (name) parameters
            return ColumnParameters;
        }

        private DataTable ExecuteQuery()
        {
            //Create empty data table
            DataTable table = new DataTable();

            //Initialize adapter to fill the data table with generated command
            adapter = new SqlDataAdapter(command);

            //Fill the data table
            adapter.Fill(table);

            //return data table
            return table;
        }

        private void BindParameters(Dictionary<string, string> Parameters)
        {
            if (Parameters != null)
            {
                foreach (var Parameter in Parameters)
                {
                    //Bind the parameters in the generated query
                    command.Parameters.AddWithValue("@" + Parameter.Key, Parameter.Value);
                }
            }
        }

        public int CheckAvaliableCopies(int MovieID)
        {
            //Query to check available copies
            Query = "SELECT (SELECT Copies FROM Movies WHERE MovieID = @MovieID) - (SELECT ISNULL(COUNT(MovieIDFK), 0) FROM RentedMovies WHERE MovieIDFK = @MovieID AND DateReturned IS NULL)";

            //Create command
            command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@MovieID", MovieID);

            //Execute query and return the number of copies available
            return Convert.ToInt32(ExecuteQuery().Rows[0][0]);
        }

        public DataTable GetPendingRentals()
        {
            //Query to get pending rentals
            Query = "SELECT RMID, Customer.FirstName, Customer.LastName, Customer.[Address], Movies.Title, Movies.Rental_Cost, RentedMovies.DateRented, RentedMovies.DateReturned FROM RentedMovies INNER JOIN Movies ON RentedMovies.MovieIDFK = Movies.MovieID INNER JOIN Customer ON RentedMovies.CustIDFK = Customer.CustID WHERE RentedMovies.DateReturned IS NULL";

            //Create command
            command = new SqlCommand(Query, connection);
            
            //Execute query and return the data table
            return ExecuteQuery();
        }

        public DataTable GetBestCustomers()
        {
            //Query to get best customers
            Query = "SELECT *, ISNULL((SELECT COUNT(RMID) FROM RentedMovies WHERE CustIDFK = CustID), 0) AS RentedMovies FROM Customer ORDER BY RentedMovies DESC";

            //Create command
            command = new SqlCommand(Query, connection);

            //Execute query and return the data table
            return ExecuteQuery();
        }

        public DataTable GetBestMovies()
        {
            //Query to get best selling movies
            Query = "SELECT *, ISNULL((SELECT COUNT (RMID) FROM RentedMovies WHERE MovieIDFK = MovieID), 0) AS TimesRented FROM Movies ORDER BY TimesRented DESC";

            //Create command
            command = new SqlCommand(Query, connection);

            //Execute query and return the data table
            return ExecuteQuery();
        }
    }
}