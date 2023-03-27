namespace JWTAuth.WebApi.Models
{
    public class CompanyInfo
    {
        public int CompanyID { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyTitle { get; set; }
        public DateTime StartingDate { get; set; }
    }
}
