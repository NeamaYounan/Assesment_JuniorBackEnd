using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assesment_Junior_BE.Models
{
    [Table("User")]
    public class Joging
    {
        [Key]
        public int UserId { get; set; }

        public string Distance { get; set; }
        public DateTime Date { get; set; }
    }
}
