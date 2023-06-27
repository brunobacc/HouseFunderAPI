using housefunder.Models;
using Microsoft.EntityFrameworkCore;

namespace housefunder.Helper
{
    public class DbHelper : DbContext
    {
        public DbHelper() { }
        public DbSet<EditUsers> editusers { get; set; }
        public DbSet<Finances> finances { get; set; }
        public DbSet<Notifications> notifications { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<Projects> projects { get; set; }
        public DbSet<Users> users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Finances>().HasKey(table => new
            {
                table.project_id,
                table.financer_id,
                table.financed_date
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=housefounder.database.windows.net;Initial Catalog=HouseFunderDB;Persist Security Info=True;User ID=sqladmin;Password=123Admin*;Trust Server Certificate=True");
        }
    }
}
