using Microsoft.EntityFrameworkCore;
using ReadTextClient.Models;

namespace ReadTextClient
{
    public class TextContext : DbContext
    {
        public DbSet<TextModel> TextModels { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={Config.DBName}");
    }
}
