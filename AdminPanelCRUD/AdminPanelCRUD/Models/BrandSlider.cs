using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanelCRUD.Models
{
    public class BrandSlider
    {
        public int Id { get; set; }
        public string? ImgUrl { get; set; }

        [NotMapped]
        public IFormFile? ImgFile { get; set; }
    }
}
