using Bagrot.DataModel;
using Bagrot_HTML.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Bagrot_HTML.Pages
{
    public class UserDetailsModel : PageModel
    {
        [BindProperty]
        public User? user { get; set; }
        public string errorMessage { get; set; } = "";

        public DataTable dtPrefix { get; set; } = new DataTable();
        public DataTable dtCityID { get; set; } = new DataTable();


        public string UserEmail { get; set; } = "";
        [BindProperty]
        public string UserCity { get; set; } = "";
        [BindProperty]
        public string UserPrefix { get; set; } = "";
        public string UserPhone { get; set; } = "";
        public string UserFirstName { get; set; } = "";
        public string UserLastName { get; set; } = "";
        public int UserYearOfBirth { get; set; } = 1900;
        public string UserGender { get; set; } = "";
        public string UserPassword { get; set; } = "";
        public string UserUserName { get; set; } = "";


        public IActionResult OnGet()
        {
            DBHelper dBHelper = new DBHelper();

            int Id = int.Parse(HttpContext.Session.GetString("UserId"));

            user = dBHelper.RetrieveUser(Id, Utils.DB_USERS_TABLE);
            if (user == null)
            {
                errorMessage = "User not found";
                Id = -1;
                return Page();
            }

            user.Id = Id;
            UserEmail = user.Email;
            UserCity = user.City;
            UserPrefix = user.Prefix.ToString();
            UserPhone = user.Phone;
            UserFirstName = user.FirstName;
            UserLastName = user.LastName;
            UserYearOfBirth = user.YearOfBirth;
            UserGender = user.Gender;
            UserPassword = user.Password;
            UserUserName = user.UserName;

            string tableNamePrefix = "dtPrefix";
            string sqlQueryPrefix = $"SELECT * FROM {tableNamePrefix}";
            dtPrefix = dBHelper.RetrieveTable(sqlQueryPrefix, tableNamePrefix);

            string tableNamedCityID = "dtCityID";
            string sqlQuerydtCityID = $"SELECT * FROM {tableNamedCityID}";
            dtCityID = dBHelper.RetrieveTable(sqlQuerydtCityID, tableNamedCityID);

            return Page();
        }


        public IActionResult OnPost()
        {
            DBHelper dB = new DBHelper();

            user.Id = int.Parse(HttpContext.Session.GetString("UserId"));
            user.Admin = bool.Parse(HttpContext.Session.GetString("Admin"));

            int numRowsAffected = dB.Update(user, Utils.DB_USERS_TABLE);
                if (numRowsAffected == -1)
                {
                    errorMessage = "Id not found";
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
