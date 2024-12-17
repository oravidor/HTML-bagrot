using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using Bagrot_HTML.DataModel;
using Bagrot_HTML.Pages;
using System.Reflection;
using System.Data.Common;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;



namespace ClassicCarsRazor.DataModel
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
        
    }
}


