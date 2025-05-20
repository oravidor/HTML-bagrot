using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using Bagrot_HTML.DataModel;
using Bagrot_HTML.Pages;
using System.Reflection;
using System.Data.Common;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;



namespace Bagrot.DataModel
{
    public class DBHelper
    {
        private string conString;

        public DBHelper()
        {

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            conString = configuration.GetConnectionString(Utils.CONFIG_DB_FILE);
        }

        public DataTable RetrieveTable(string SQLStr, string table)
        // Gets A table from the data base acording to the SELECT Command in SQLStr;
        // Returns DataTable with the Table.
        {

            // connect to DataBase
            SqlConnection con = new SqlConnection(conString);

            // Build SQL Query
            SqlCommand cmd = new SqlCommand(SQLStr, con);

            // Build DataAdapter
            SqlDataAdapter ad = new SqlDataAdapter(cmd);


            //// Build DataSet to store the data
            //DataSet ds = new DataSet();
            //// Get Data form DataBase into the DataSet
            //ad.Fill(ds, table); // ad.Fill(ds);
            //return ds.Tables[table];

            // !!!!!!!  ALTERNATIVELY  the adapter returns just the table, not a DataSet (many tables)
            // Or just get just one table - not a DataSet (which includes many tables)
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }

        public User RetrieveUser(int Id, string table)
        {
            SqlConnection con = new SqlConnection(conString);

            string SQLStr = $"SELECT * FROM {table} WHERE Id = {Id}";
            SqlCommand cmd = new SqlCommand(SQLStr, con);

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            adapter.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                return null;
            }

            DataRow row = dt.Rows[0];

            User user = new User
            {
                Id = Convert.ToInt32(row["Id"]),
                Email = row["Email"].ToString(),
                Password = row["Password"].ToString(),
                FirstName = row["FirstName"].ToString(),
                LastName = row["LastName"].ToString(),
                Prefix = Convert.ToInt32(row["Prefix"]),
                Phone = row["Phone"].ToString(),
                City = row["City"].ToString(),
                Gender = row["Gender"].ToString(),
                UserName = row["UserName"].ToString(),
                YearOfBirth = Convert.ToInt32(row["YearOfBirth"]),
                Admin = Convert.ToBoolean(row["Admin"])
            };

            return user;
        }



        public int Insert(User user, string table)
        {
            SqlConnection con = new SqlConnection(conString);

            string SQLStr = $"SELECT * FROM {table} WHERE Email = '{user.Email}'";
            SqlCommand cmd = new SqlCommand(SQLStr, con);

            DataSet ds = new DataSet();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, table);

            if (ds.Tables[table].Rows.Count > 0)
            {
                return -1;
            }

            DataRow dr = ds.Tables[table].NewRow();
            dr["Email"] = user.Email;
            dr["Password"] = user.Password;
            dr["FirstName"] = user.FirstName;
            dr["LastName"] = user.LastName;
            dr["Prefix"] = user.Prefix;
            dr["Phone"] = user.Phone;
            dr["City"] = user.City;
            dr["Gender"] = user.Gender;
            dr["UserName"] = user.UserName;
            dr["YearOfBirth"] = user.YearOfBirth;

            ds.Tables[table].Rows.Add(dr);

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            int numRowsAffected = adapter.Update(ds, table);
            return numRowsAffected;
        }

        public int Update(User user, string table)
        {
            SqlConnection con = new SqlConnection(conString);

            string SQLStr = $"SELECT * FROM {table} WHERE Id = '{user.Id}'";
            SqlCommand cmd = new SqlCommand(SQLStr, con);

            DataSet ds = new DataSet();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, table);

            if (ds.Tables[table]?.Rows.Count == 0 || user.Id < 0)
            {
                return -1;
            }


            string SQL = $"UPDATE {table} " +
            $"SET Email ='{user.Email}', " +
            $"UserName = '{user.UserName}', " +
            $"Password = '{user.Password}', " +
            $"YearOfBirth = '{user.YearOfBirth}', " +
            $"Phone = '{user.Phone}', " +
            $"City = '{user.City}', " +
            $"FirstName = '{user.FirstName}', " +
            $"LastName = '{user.LastName}', " +
            $"Gender = '{user.Gender}', " +
            $"Prefix = '{user.Prefix}', " +
            $"Admin = '{user.Admin}' " +
            $"WHERE Id = '{user.Id}'";


            SqlCommand cmdUpdate = new SqlCommand(SQL, con);
            con.Open();
            int numRowsAffected = cmdUpdate.ExecuteNonQuery();
            con.Close();
            return numRowsAffected;
        }

        public int Insert(Survey survey, string table)
        {
            SqlConnection con = new SqlConnection(conString);

            string SQLStr = $"SELECT * FROM {table} WHERE UserId = '{survey.UserId}'";
            SqlCommand cmd = new SqlCommand(SQLStr, con);

            DataSet ds = new DataSet();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, table);

            if (ds.Tables[table].Rows.Count > 0)
            {
                return -1;
            }

            DataRow dr = ds.Tables[table].NewRow();
            dr["UserId"] = survey.UserId;
            dr["glassesOfWaterPerDay"] = survey.glassesOfWaterPerDay;
            dr["CaloriesPerDay"] = survey.CaloriesPerDay;

            ds.Tables[table].Rows.Add(dr);

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            int numRowsAffected = adapter.Update(ds, table);
            return numRowsAffected;
        }

        public int DidVote(Survey survey, string table)
        {
            SqlConnection con = new SqlConnection(conString);

            string SQLStr = $"SELECT * FROM {table} WHERE UserId = '{survey.UserId}'";
            SqlCommand cmd = new SqlCommand(SQLStr, con);

            DataSet ds = new DataSet();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds, table);

            if (ds.Tables[table].Rows.Count > 0)
            {
                return -1;
            }
            return 0;

        }
        public int RetrieveSurveyAverage(string table, string columnName)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                string SQLStr = $"SELECT AVG(CAST([{columnName}] AS FLOAT)) FROM {table}";
                SqlCommand cmd = new SqlCommand(SQLStr, con);
                con.Open();
                object result = cmd.ExecuteScalar();
                con.Close();

                if (result != DBNull.Value && result != null)
                {
                    return Convert.ToInt32(Math.Round(Convert.ToDouble(result)));
                }
                return 0;
            }
        }
    }
}