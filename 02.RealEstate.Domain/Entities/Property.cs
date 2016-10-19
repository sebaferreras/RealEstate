using System.ComponentModel.DataAnnotations;

namespace _02.RealEstate.Domain.Entities
{
    public class Property
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string PreviewImageUrl { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        public int Bedrooms { get; set; }

        public int Bathrooms { get; set; }

        [Required]
        public decimal AskingPrice { get; set; }

        // Foreign Key
        public int BrokerId { get; set; }

        // Navigation property
        public Broker Broker { get; set; }
    }
}
