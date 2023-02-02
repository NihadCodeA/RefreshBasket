using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanelCRUD.Models
{
    public class Book
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }

        [StringLength(maximumLength:20)]
        public string Name { get; set; }
        [StringLength(maximumLength:40)]
        public string Description { get; set; }
        [StringLength(maximumLength:100)]
        public string Detail { get; set; }
        [StringLength(maximumLength:10)]
        public string Code { get; set; }
        public bool IsAvaible { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsNew { get; set; }
        public double CostPrice { get; set; }
        public double SalePrice { get; set; }
        public double Discount { get; set; }
        public Author? Author { get; set; }
        public Genre? Genre { get; set; }
        [NotMapped]
        public IFormFile? PosterImgFile { get; set; }
        [NotMapped]
        public IFormFile? HoverImgFile { get; set; }

        public List<BookImages>? BookImages { get; set; }
        
        [NotMapped]
        public List<int>? BookImageIds { get; set; }
        [NotMapped]
        public List<IFormFile>? ImageFiles { get; set; }

        public List<BasketItem>? BasketItems { get; set; }
    }
}
