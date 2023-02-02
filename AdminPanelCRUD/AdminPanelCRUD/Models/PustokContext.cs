using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdminPanelCRUD.Models
{
    public class PustokContext : IdentityDbContext
    {
        public PustokContext(DbContextOptions<PustokContext> options) : base(options){}

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<BrandSlider> BrandSliders { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookImages> BookImages { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<AppUser> Users { get; set; }
    }
}
