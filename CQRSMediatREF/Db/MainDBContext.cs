using CQRSMediatREF.Db.Model;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediatREF.Db
{
    public class MainDBContext : DbContext
    {

        public MainDBContext(DbContextOptions<MainDBContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

    }
}
