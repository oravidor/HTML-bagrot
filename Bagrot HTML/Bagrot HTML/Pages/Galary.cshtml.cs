using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bagrot_HTML.Pages
{
    public class GalaryModel : PageModel
    {
        public IActionResult OnGet()
        {
            var hasVisited = Request.Cookies["VisitedGallery"];

            if (string.IsNullOrEmpty(hasVisited))
            {
                Response.Cookies.Append("VisitedGallery", "true", new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddHours(1),
                    HttpOnly = true
                });
            }

            return Page();
        }
    }
}
