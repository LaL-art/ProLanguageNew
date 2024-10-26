using Microsoft.EntityFrameworkCore;
using ProLanguage.Models.Entities;

namespace ProLanguage.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<UserFile> UserFiles { get; set; }
}