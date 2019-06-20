using System.ComponentModel.DataAnnotations;

namespace GameStore.PL.ViewModels
{
    public class EditGameModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public int PublisherId { get; set; }
    }
}
