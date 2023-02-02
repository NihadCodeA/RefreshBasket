namespace AdminPanelCRUD.Models
{
    public class BookImages
    {
        public int Id { get; set; }
        public int BookId {get;set;}
        public string? Image { get; set;}
        public bool? IsPoster { get; set;}
        public Book Book {get;set;}
    }
}
