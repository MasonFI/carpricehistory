namespace CarPriceHistory.Domain
{
    public class Car : Entity
    {
        public int ModelYear { get; set; }
        public int FirstRegistrationYear { get; set; }
        public string RegisterNumber { get; set; } = String.Empty;
        public DateTime LastSeen { get; set; }
        public int CarModelId { get; set; }
        public CarModel CarModel { get; set; }
    }
}
