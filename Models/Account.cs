using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace DatingProgram.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        [ForeignKey("City")]
        public int Zipcode { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime Birthdate { get; set; }
        public City City { get; set; }
        public List<Like> SentLikes { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
