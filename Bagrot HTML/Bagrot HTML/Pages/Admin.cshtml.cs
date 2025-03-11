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
        public DataTable dtFilterColumn { get; set; } = new DataTable();
        public string[] displayColumns { get; set; } = ["Id", "Email", "City", "PrefixID", "Phone", "FirstName", "LastName", "YearOfBirth", "Gender", "Password", "UserName"];

        public IActionResult OnGet()
        {
            DBHelper dBHelper = new DBHelper();

            string tableNameFilter = "dtFilterColumn";
            string sqlQueryPrefix = $"SELECT * FROM {tableNameFilter}";
            dtFilterColumn = dBHelper.RetrieveTable(sqlQueryPrefix, tableNameFilter);

            string sqlQuery = $"SELECT * FROM {Utils.DB_USERS_TABLE}";

            DataTableUsers = dBHelper.RetrieveTable(sqlQuery, $"{Utils.DB_USERS_TABLE}");
            return Page();
        }

        public IActionResult OnPost()
        {
            DBHelper dBHelper = new DBHelper();

            string sqlQueryFilter = "SELECT * FROM dtFilterColumn";
            dtFilterColumn = dBHelper.RetrieveTable(sqlQueryFilter, "dtFilterColumn") ?? new DataTable();

            string filterColumn = Request.Form["filterColumn"];
            string filterValue = Request.Form["filterValue"];
            string delete = Request.Form["delete"];
            string action = Request.Form["submit"];

            if (action == "Delete" && !string.IsNullOrEmpty(delete))
            {
                string deleteQuery = $"DELETE FROM {Utils.DB_USERS_TABLE} WHERE Id = {delete}";
                DataTableUsers = dBHelper.RetrieveTable(deleteQuery, $"{Utils.DB_USERS_TABLE}") ?? new DataTable();
            }

            string sqlQuery = $"SELECT * FROM {Utils.DB_USERS_TABLE}";
            if (action == "Search" && !string.IsNullOrEmpty(filterColumn) && !string.IsNullOrEmpty(filterValue))
            {
                sqlQuery += $" WHERE {filterColumn} LIKE '%{filterValue}%'";
            }

            DataTableUsers = dBHelper.RetrieveTable(sqlQuery, $"{ Utils.DB_USERS_TABLE}") ?? new DataTable();

            return Page();
        }


    }
}