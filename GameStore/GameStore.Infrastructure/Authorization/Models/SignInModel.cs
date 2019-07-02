using System.ComponentModel.DataAnnotations;

namespace GameStore.Infrastructure.Authorization.Models
{
    public  class SignInModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
