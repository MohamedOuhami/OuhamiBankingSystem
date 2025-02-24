using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Account-User Relationship
        modelBuilder.Entity<Account>()
        .HasOne(a => a.User)
        .WithMany(u => u.Accounts)
        .HasForeignKey(a => a.UserId)
        .OnDelete(DeleteBehavior.Cascade);

        // Many to One relationship between Transaction and FromAccount and ToAccount
        modelBuilder.Entity<Transaction>()
        .HasOne(t => t.FromAccount)
        .WithMany(a => a.FromTransactions)
        .HasForeignKey(t => t.FromAccountId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Transaction>()
                .HasOne(t => t.ToAccount)
                .WithMany(a => a.ToTransactions)
                .HasForeignKey(t => t.ToAccountId)
                .OnDelete(DeleteBehavior.Restrict);
    }
}