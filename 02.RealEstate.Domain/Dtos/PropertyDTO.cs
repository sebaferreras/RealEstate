namespace _02.RealEstate.Domain.Dtos
{
    public class PropertyDTO
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string PreviewImageUrl { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public int Bedrooms { get; set; }

        public int Bathrooms { get; set; }

        public decimal AskingPrice { get; set; }

        // Broker properties
        public int BrokerId { get; set; }

        public string BrokerName { get; set; }

        public string BrokerImageUrl { get; set; }

        public string BrokerPosition { get; set; }
    }
}
