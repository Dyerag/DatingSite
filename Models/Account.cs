using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace DatingSite.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        [ForeignKey("City")]
        public int Zipcode { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public DateOnly CreatedDate { get; set; }
        [Required]
        public DateOnly Birthdate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public City City { get; set; }
        public List<Like> SentLikes { get; set; }
        
    }
}
