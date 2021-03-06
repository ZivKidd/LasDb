using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LasDb
{
    public class LasPointDb
    {
        [Key]
        public int Index { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public ushort Intensity { get; set; }
        public int ScanLineIndex { get; set; }
    }

    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source=D:\\desktop\\a.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LasPointDb>().HasIndex(b => b.ScanLineIndex);
        }

        public DbSet<LasPointDb> LasPointDbs { get; set; }
    }
}

