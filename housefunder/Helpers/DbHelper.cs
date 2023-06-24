using housefunder.Models;
using Microsoft.EntityFrameworkCore;

namespace housefunder.Helper
{
    public class DbHelper : DbContext
    {
        public DbHelper() { }
        public DbSet<Users> users { get; set; }
        public DbSet<Projects> projects { get; set; }
        public DbSet<Products> products { get; set; }
        public DbSet<Finances> finances { get; set; }
        public DbSet<FinancersQuery> financersquery { get; set; }
        public DbSet<Partnerships> partnerships { get; set; }
        public DbSet<FinancersQuery2> financersQuery2 { get; set; }
        public DbSet<ProjectsFinanced> projectsfinanced { get; set; }
        public DbSet<EditUsers> editusers { get; set; }
        public DbSet<Images> images { get; set; }


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
