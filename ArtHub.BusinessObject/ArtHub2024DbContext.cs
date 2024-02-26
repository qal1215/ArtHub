using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ArtHub.BusinessObject;

public partial class ArtHub2024DbContext : DbContext
{
    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Artwork> Artworks { get; set; }

    public virtual DbSet<FollowInfo> FollowInfos { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public ArtHub2024DbContext()
    {
    }

    public ArtHub2024DbContext(DbContextOptions<ArtHub2024DbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString());


    private string GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
        var strConn = config.GetConnectionString("DefaultConnection");
        return strConn;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
