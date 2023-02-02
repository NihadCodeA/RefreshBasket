using AdminPanelCRUD.Models;

namespace AdminPanelCRUD.ViewModels
{
    public class BookDetailViewModel
    {
        public Book Book { get; set; }
        public List<Book> RelatedBooks { get; set; }
    }
}
