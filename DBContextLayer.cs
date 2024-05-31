using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using Project_Curd.Models;

namespace Project_Curd
{
    public class DBContextLayer : DbContext
    {
        public DBContextLayer(DbContextOptions<DBContextLayer>options):base(options) { }
        
        public DbSet<TeacherModel> Teachers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {

            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherModel>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e=>e.Skills).IsRequired().HasMaxLength(250).IsUnicode(false);
                entity.Property(e => e.Salary).IsRequired().HasColumnType("money");
                entity.Property(e => e.AddedOn).HasColumnType("date").HasDefaultValueSql("(getDate())");
            });
        }
        //public class YourDbContextFactory : IDesignTimeDbContextFactory<DBContextLayer>
        //{
        //    public DBContextLayer CreateDbContext(string[] args)
        //    {
        //        var optionsBuilder = new DbContextOptionsBuilder<DBContextLayer>();
        //        optionsBuilder.UseSqlServer("DefaultConnection");

        //        return new DBContextLayer(optionsBuilder.Options);
        //    }
        //}
    }
}
