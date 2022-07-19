using fastfood_order.Entity;
using Microsoft.EntityFrameworkCore;

namespace fastfood_order.Data;

public class BotDbContext : DbContext
{
    public DbSet<User>? Users { get; set; }  
    
    public BotDbContext(DbContextOptions<BotDbContext> options)
        : base(options) {}
}