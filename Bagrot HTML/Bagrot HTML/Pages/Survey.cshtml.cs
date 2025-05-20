using Bagrot.DataModel;
using Bagrot_HTML.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Bagrot_HTML.Pages
{
    public class SurveyModel : PageModel
    {
        [BindProperty]
        public Survey? survey { get; set; }
        public int numRowsAffected { get; set; }
        public double Q1Average { get; set; } = 0;
        public double Q2Average { get; set; } = 0;
        public string averageAnswers { get; set; } = "";
        public string errorMessage { get; set; } = "";

        public IActionResult OnGet()
        {
            survey = new Survey();
            var userIdString = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userIdString))
            {
                errorMessage = "User ID is missing in session.";
                return Page();
            }
            survey.UserId = int.Parse(userIdString);
            DBHelper dB = new DBHelper();
            string SurveyTable = "SurveyData";
            numRowsAffected = dB.DidVote(survey, SurveyTable);
            if (numRowsAffected == -1)
            {
                errorMessage = "You already voted";

                Q1Average = dB.RetrieveSurveyAverage(SurveyTable, "CaloriesPerDay");
                Q2Average = dB.RetrieveSurveyAverage(SurveyTable, "glassesOfWaterPerDay");

                averageAnswers = $" <table class=\"average-table\">\r\n    <thead>\r\n        <tr>\r\n            <td colspan=\"2\">Survey Average Answers</td>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n        <tr>\r\n            <td>Average calories per day is {Q1Average}</td>\r\n        </tr>\r\n        <tr>\r\n            <td>Average glasses Of Water per day is {Q2Average}</td>\r\n        </tr>\r\n    </tbody>\r\n</table>";
                return Page();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            survey.UserId = int.Parse(HttpContext.Session.GetString("UserId"));

            DBHelper dB = new DBHelper();
            string SurveyTable = "SurveyData";
            int numRowsAffected = dB.Insert(survey, SurveyTable);
            if (numRowsAffected == -1)
            {
                errorMessage = "You already voted";
                return Page();
            }
            else if (numRowsAffected != 1)
            {
                errorMessage = "An unexpected error occurred";
                return Page();
            }
            return Page();
        }
    }
}
