using Bagrot_HTML.DataModel;
using ClassicCarsRazor.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Bagrot_HTML.Pages
{
    public class RegisterModel : PageModel
    {

        [BindProperty]
        public User? user { get; set; }
        public string st { get; set; } = "";
        public DataTable dtPrefix { get; set; } = new DataTable();
        public DataTable dtCityID { get; set; } = new DataTable();


        public void OnGet()
        {
            st = "";

            DBHelper dBHelper = new DBHelper();

            string tableNamePrefix = "dtPrefix";
            string sqlQueryPrefix = $"SELECT * FROM {tableNamePrefix}";
            dtPrefix = dBHelper.RetrieveTable(sqlQueryPrefix, tableNamePrefix);

            string tableNamedCityID = "dtCityID";
            string sqlQuerydtCityID = $"SELECT * FROM {tableNamedCityID}";
            dtCityID = dBHelper.RetrieveTable(sqlQuerydtCityID, tableNamedCityID);

        }


        public void OnPost()
        {
         
            
            
            st = "<table>";
            st += "<tr><td colspan='2' style='text-align:center'>Form Data</td></tr>";
            st += $"<tr><td>Id</td> <td>{user.Id}</td></tr>";
            st += $"<tr><td>User Name</td> <td>{user.UserName}</td></tr>";
            st += $"<tr><td>First Name</td> <td>{user.FirstName}</td></tr>";
            st += $"<tr><td>Last Name</td> <td>{user.LastName}</td></tr>";
            st += $"<tr><td>Email</td> <td>{user.Email}</td></tr>";
            st += $"<tr><td>city Id</td> <td>{user.CityID}</td></tr>";
            st += $"<tr><td>prefix Id</td> <td>{user.PrefixID}</td></tr>";
            st += $"<tr><td>phone</td> <td>{user.Phone}</td></tr>";
            st += $"<tr><td>year Of Birth</td> <td>{user.YearOfBirth}</td></tr>";
            st += $"<tr><td>gender</td> <td>{user.Gender}</td></tr>";
            st += $"<tr><td>password</td> <td>{user.Password}</td></tr>";
            st += "</table>";
        }

    }
}
