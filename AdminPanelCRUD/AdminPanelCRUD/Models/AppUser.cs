using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace AdminPanelCRUD.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        

    }
}
