using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatingSite.Models
{
    public class Profile
    {
        [Key, ForeignKey("Account")]
        public int ProfileId { get; set; }//from account
        public int? Height { get; set; }//ProfilePage Editform
        public int? Weight { get; set; }//ProfilePage Editform
        public DateOnly Birthdate { get; set; }//From account
        public string? Picture { get; set; } //no funtionality yet
        public string Nickname { get; set; }//ProfilePage Editform
        public bool Gender { get; set; }//ProfilePage Editform
        public bool IsDeleted { get; set; } = false;//substitution for having to write a funtion to delete the profile
        public Account Account { get; set; }//
        public List<Like> ReceivedLikes { get; set; }
    }
}
