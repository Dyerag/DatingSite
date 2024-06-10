using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatingProgram.Models
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }
        [ForeignKey("Account")]
        public int SenderId { get; set; }
        [ForeignKey("Profile")]
        public int ReceiverId { get; set; }
        public Account Sender { get; set; }
        public Profile Receiver { get; set; }
        public int Status { get; set; } = 0;
    }
}
