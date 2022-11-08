namespace MyNewMVC.Models
{
    public class ModelProductForView
    {
        public int TotalPages { get; set; }
        public int Count { get; set; }
        public int Page { get; set; }
        public int PageMinus1 { get; set; }
        public int PageMinus2   { get; set; }
        public int PagePlus1 { get; set; }
        public int PagePlus2 { get; set; }
        public List<ProductForView> Products { get; set; } = new List<ProductForView>();
    }
}
