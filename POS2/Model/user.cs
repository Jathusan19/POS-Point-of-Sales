using System.ComponentModel.DataAnnotations;

namespace POS2.Model
{
    public class user
    {
        [Key]
        public int Id { get; set; }
        public string? Username { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string? Password { get; set; }

        public string? ContactNo { get; set; }

         public bool IsAdmin { get; set; }
    }

   
}