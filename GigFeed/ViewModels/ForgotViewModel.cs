using System.ComponentModel.DataAnnotations;

namespace GigFeed.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}