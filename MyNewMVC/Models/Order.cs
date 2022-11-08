namespace MyNewMVC.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsPayed { get; set; }
        public DateTime? Created { get; set; }
        public User? User { get; set; }
        public Product? Product { get; set; }
    }
}
