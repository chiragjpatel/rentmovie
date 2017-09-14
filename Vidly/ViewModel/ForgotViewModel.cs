using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModel
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}