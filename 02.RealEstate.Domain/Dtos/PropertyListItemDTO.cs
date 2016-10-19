using System.ComponentModel.DataAnnotations;

namespace _02.RealEstate.Domain.Dtos
{
    public class PropertyListItemDTO
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string PreviewImageUrl { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Location { get; set; }
    }
}
