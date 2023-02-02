using System.ComponentModel.DataAnnotations;

namespace AdminPanelCRUD.Models
{
    public class Feature
    {
        public int Id { get; set; }
        public string Icon { get; set; }
        [StringLength(maximumLength:20)]
        public string Header { get; set; }
        [StringLength(maximumLength:20)]
        public string About { get; set; }

    }
}
