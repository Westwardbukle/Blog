using Blog.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Database;

public class AppDbContext : DbContext
{
    private DbSet<PostModel> PostModels { get; set; }
    
    private DbSet<CommentModel> CommentModels { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}