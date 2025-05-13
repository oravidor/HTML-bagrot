using Bagrot_HTML.DataModel;
using Bagrot.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Bagrot_HTML.Pages
{
    public class LoginModel : PageModel
    {
        public string message { get; set; } = "";

        [BindProperty]
        public string? logEmail { get; set; }

        [BindProperty]
        public string? logPassword { get; set; }

        public IActionResult OnPost()
        {
            string sqlQuery = $"SELECT * FROM {Utils.DB_USERS_TABLE} WHERE Email = '{logEmail}' AND Password = '{logPassword}'";

            DBHelper dB = new DBHelper();
            DataTable userTable = dB.RetrieveTable(sqlQuery, Utils.DB_USERS_TABLE);
            if (userTable.Rows.Count != 1)
            {
                message = "one or more inputs are wrong";
                return Page();
            }

            DataRow row = userTable.Rows[0];
            HttpContext.Session.SetString("UserId", row["Id"].ToString());
            HttpContext.Session.SetString("UserEmail", row["Email"].ToString());
            HttpContext.Session.SetString("UserFirstName", row["FirstName"].ToString());
            HttpContext.Session.SetString("UserLastName", row["LastName"].ToString());
            HttpContext.Session.SetString("Admin", row["Admin"].ToString());

            return RedirectToPage("/Home");
        }
    }
}