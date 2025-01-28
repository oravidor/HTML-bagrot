namespace Bagrot_HTML.DataModel
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int PrefixID { get; set; }
        public string Phone { get; set; } = string.Empty;
        public int CityID { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public int YearOfBirth { get; set; }

    }
}
