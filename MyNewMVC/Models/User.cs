namespace MyNewMVC.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal MoneyBalance { get; set; }
        public int? AllCountOrders { get; set; }
        public decimal? TotalAmount { get; set; }
        public List<Order>? UserOrders { get; set; }
    }
}
