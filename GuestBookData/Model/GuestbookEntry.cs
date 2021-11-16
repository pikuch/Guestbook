using System;
using System.ComponentModel.DataAnnotations;

namespace GuestbookData.Model
{
    public class GuestbookEntry
    {
        public int Id { get; set; }

        [Display(Name="Your name")]
        [Required]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Name length should be in range (1, 30)")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Display(Name="Your email")]
        [Required]
        [EmailAddress(ErrorMessage = "Wrong email address format")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name="Your comment")]
        [Required]
        [StringLength(120, MinimumLength = 10, ErrorMessage = "Comment length should be in range (10, 120)")]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
