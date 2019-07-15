using System.ComponentModel.DataAnnotations;

namespace GameStore.PL.ViewModels
{
    public class EditPublisherModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
