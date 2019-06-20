using System.ComponentModel.DataAnnotations;

namespace GameStore.PL.ViewModels
{
    public class CreatePublisherViewModel
    {
        [Required]
        public string Name { get; set; }
    }
}
