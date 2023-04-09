namespace Intership.Models.AdditionalModels
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal TotalSum { get; set; }
        public int TotalValue { get; set; }
        public double TotalWeight { get; set; }
    }
}
