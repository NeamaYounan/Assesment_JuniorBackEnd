using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Assesment_Junior_BE.Models
{
    public class UserAngular
    {
    
    [Table("User_Angular")]
    
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int JogId { get; set; }
        public Joging Joging { get; set; }
        public string EmailId { get; set; }
        public DateTime DOJ { get; set; }
    }
}
