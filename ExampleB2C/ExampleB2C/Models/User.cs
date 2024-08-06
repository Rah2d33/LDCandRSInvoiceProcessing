namespace ExampleB2C.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string B2CUserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        public ICollection<Session> Sessions { get; set; }
        public ICollection<Document> Documents { get; set; }
    }
}
