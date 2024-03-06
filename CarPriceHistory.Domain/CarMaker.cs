namespace CarPriceHistory.Domain
{
    public class CarMaker : Entity
    {
        public string Name { get; set; } = String.Empty;
        public ICollection<CarModel> CarModels { get; set; }
    }
}
