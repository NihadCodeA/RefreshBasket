namespace AdminPanelCRUD.ViewModels
{
    public class BasketItemViewModel
    {
        public int BookId { get; set; }
        public int Count { get; set; }

        public double Price { get; set; }
        public double Discount { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
