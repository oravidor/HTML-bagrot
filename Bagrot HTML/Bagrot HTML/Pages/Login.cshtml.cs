using Bagrot_HTML.DataModel;
using ClassicCarsRazor.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Bagrot_HTML.Pages
{
    public class LoginModel : PageModel
    {
        public string message { get; set; } = "";
        public IActionResult OnPost()
        {
            string logEmail = Request.Form["log_email"];
            string logPassword = Request.Form["log_password"];

            string sqlQuery = $"SELECT * FROM {Utils.DB_USERS_TABLE} WHERE Email = '{logEmail}' AND Password = '{logPassword}'";

            DBHelper dB = new DBHelper();
            DataTable resultTable = dB.RetrieveTable(sqlQuery, Utils.DB_USERS_TABLE);
            if (resultTable.Rows.Count == 1)
            {
                message = "logged in";
                return RedirectToPage("/Home");
            }
            else
            {
                message = "one or more inputs are wrong";
                return Page();
            }
        }
    }
}