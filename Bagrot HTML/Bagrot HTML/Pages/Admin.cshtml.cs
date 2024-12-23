using Bagrot_HTML.DataModel;
using ClassicCarsRazor.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Bagrot_HTML.Pages
{
    public class AdminModel : PageModel
    {
        public DataTable? DataTableUsers { get; set; }
        public string[] displayColumns { get; set; } = ["Id", "Email", "CityID", "PrefixID", "Phone", "FirstName", "LastName", "YearOfBirth", "Gender", "UserName", "Password"];

        public IActionResult OnGet()
        {
            DBHelper dBHelper = new DBHelper();
            string sqlQuery = $"SELECT * FROM {Utils.DB_USERS_TABLE}";
            DataTableUsers = dBHelper.RetrieveTable(sqlQuery, "UsersDB");
            return Page();
        }
    }
}
