using System.ComponentModel.DataAnnotations;

namespace GameStore.PL.ViewModels
{
    public class EditGenreModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int ParentGenreId { get; set; }
    }
}
