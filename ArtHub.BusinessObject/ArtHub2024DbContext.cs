using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SilverShopBusinessObject;

public partial class ArtHub2024DbContext : DbContext
{
    public ArtHub2024DbContext()
    {
    }

    public ArtHub2024DbContext(DbContextOptions<ArtHub2024DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BranchAccount> BranchAccounts { get; set; }


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
        modelBuilder.Entity<BranchAccount>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__BranchAc__349DA586594E6CF1");

            entity.ToTable("BranchAccount");

            entity.HasIndex(e => e.EmailAddress, "UQ__BranchAc__49A14740928503E3").IsUnique();

            entity.Property(e => e.AccountId)
                .HasColumnName("AccountID");
            entity.Property(e => e.AccountPassword).HasMaxLength(40);
            entity.Property(e => e.EmailAddress).HasMaxLength(60);
            entity.Property(e => e.FullName).HasMaxLength(60);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
