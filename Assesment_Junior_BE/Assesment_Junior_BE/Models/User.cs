using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assesment_Junior_BE.Models
{
    [Table("User")]

    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }
        public DateTime Date { get; set; }

        public string Email { get; set; }
        public string PhotoFileName { get; set; }
        public int JogId { get; set; }
        public Joging Joging { get; set; }
    }
}
