using Bagrot_HTML.DataModel;
using ClassicCarsRazor.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Xml.Linq;

namespace Bagrot_HTML.Pages
{
    public class RegisterModel : PageModel
    {

        [BindProperty]
        public User? user { get; set; }
        public string errorMessage { get; set; } = "";
        public DataTable dtPrefix { get; set; } = new DataTable();
        public DataTable dtCityID { get; set; } = new DataTable();


        public void OnGet()
        {

            DBHelper dBHelper = new DBHelper();

            string tableNamePrefix = "dtPrefix";
            string sqlQueryPrefix = $"SELECT * FROM {tableNamePrefix}";
            dtPrefix = dBHelper.RetrieveTable(sqlQueryPrefix, tableNamePrefix);

            string tableNamedCityID = "dtCityID";
            string sqlQuerydtCityID = $"SELECT * FROM {tableNamedCityID}";
            dtCityID = dBHelper.RetrieveTable(sqlQuerydtCityID, tableNamedCityID);
        }

        public IActionResult OnPost()
        {  
            DBHelper dB = new DBHelper();
            int numRowsAffected = dB.Insert(user, Utils.DB_USERS_TABLE);
            if (numRowsAffected == -1)
            {
                errorMessage = "This email is already registered";
                return Page();
            }
            else if (numRowsAffected != 1)
            {
                errorMessage = "An unexpected error occurred";
                return Page();
            }
            return RedirectToPage("/Home");
        }

    }
}
