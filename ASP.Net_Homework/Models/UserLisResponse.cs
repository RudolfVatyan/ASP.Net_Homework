namespace ASP.Net_Homework.Models
{
    public class UserListResponse
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int Total { get; set; }
        public int TotalPages { get; set; }
        public ICollection<User> Data { get; set; } = new List<User>();
    }
}
