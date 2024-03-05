namespace CarPriceHistory.Domain
{
    public class Car : Entity
    {
        public int CarModelId { get; set; }
        public int ModelYear { get; set; }
        public int FirstRegistrationYear { get; set; }
        public string RegisterNumber { get; set; } = String.Empty;
        public DateTime LastSeen { get; set; }
        public int CarMakerId { get; set; }
        public CarMaker CarMaker { get; set; }
    }
}
