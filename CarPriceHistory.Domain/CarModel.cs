namespace CarPriceHistory.Domain
{
    public class CarModel : Entity
    {
        public string Name { get; set; } = String.Empty;
        public int CarMakerId { get; set; }
        public CarMaker CarMaker { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
