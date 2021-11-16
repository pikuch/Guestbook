using System;
using System.ComponentModel.DataAnnotations;

namespace GuestbookData.Model
{
    public class GuestbookEntry
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Name length should be in range (1, 30)")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Wrong email address format")]
        public string Email { get; set; }

        [Required]
        [StringLength(120, MinimumLength = 10, ErrorMessage = "Comment length should be in range (10, 120)")]
        public string Comment { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
