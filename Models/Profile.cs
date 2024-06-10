using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatingSite.Models
{
    public class Profile
    {
        [Key, ForeignKey("Account")]
        public int ProfileId { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public DateTime Birthdate { get; set; }
        public string? Picture { get; set; }
        public string Nickname { get; set; }
        public bool Gender { get; set; }
        public Account Account { get; set; }
        public List<Like> ReceivedLikes { get; set; }
    }
}
