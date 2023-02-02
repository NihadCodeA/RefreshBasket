using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPanelCRUD.Models
{
    public class Slider
    {
        public int Id { get; set; }

        public int Order { get; set; }

        [StringLength(maximumLength:25)]
        public string FirstTitle { get; set; }
        [StringLength(maximumLength:25)]
        public string SecondTitle { get; set; }
        [StringLength(maximumLength:250)]
        public string Description { get; set; }
        public string RedirectUrl { get; set; }
        [StringLength(maximumLength:20)]
        public string RedirectUrlText { get; set; }
        public string? ImgUrl { get; set; }


        [NotMapped]
        public IFormFile? ImgFile { get; set; }
    }
}
