using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameStore.PL.ViewModels
{
    public class UserChangeRoleViewModel
    {
        [Required]
        public string UserId { get; set; }

        public IList<string> Roles { get; set; }
    }
}
