using System.ComponentModel.DataAnnotations;

namespace GameStore.PL.ViewModels
{
    public class CreateGenreViewModel
    {
        [Required]
        public string Name { get; set; }

        public int ParentGenreId { get; set; }
    }
}
