using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace StudentsAvalonia.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Group> Groups => Set<Group>();
    public DbSet<Speciality> Specialities => Set<Speciality>();
    public DbSet<Login> Logins => Set<Login>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=.\\SQLEXPRESS;Database=StudentDB;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Login>(entity =>
        {
            entity.ToTable("Logins");
            entity.HasKey(l => l.IdLogins);
            entity.Property(l => l.IdLogins).HasColumnName("ID_Logins");
            entity.Property(l => l.LoginName).HasColumnName("LoginName");
            entity.Property(l => l.Password).HasColumnName("Password");
        });

        modelBuilder.Entity<Speciality>(entity =>
        {
            entity.ToTable("Speciality");
            entity.HasKey(s => s.IdSpeciality);
            entity.Property(s => s.IdSpeciality).HasColumnName("ID_Speciality");
            entity.Property(s => s.NameSpeciality).HasColumnName("Name_Speciality");
            entity.Property(s => s.Description).HasColumnName("Description");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.ToTable("Group");
            entity.HasKey(g => g.IdGroup);
            entity.Property(g => g.IdGroup).HasColumnName("ID_Group");
            entity.Property(g => g.Number).HasColumnName("Number");
            entity.Property(g => g.Description).HasColumnName("Description");
            entity.Property(g => g.IdSpeciality).HasColumnName("ID_Speciality");

            entity.HasOne(g => g.Speciality)
                .WithMany(s => s.Groups)
                .HasForeignKey(g => g.IdSpeciality)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");
            entity.HasKey(u => u.IdUser);
            entity.Property(u => u.IdUser).HasColumnName("ID_User");
            entity.Property(u => u.Fname).HasColumnName("FName");
            entity.Property(u => u.Name).HasColumnName("Name");
            entity.Property(u => u.Patronumic).HasColumnName("Patronumic");
            entity.Property(u => u.DateBirth).HasColumnName("DateBirth");
            entity.Property(u => u.IdLogPass).HasColumnName("ID_Log_Pass");
            entity.Property(u => u.IdGroup).HasColumnName("ID_Group");

            entity.HasOne(u => u.Group)
                .WithMany(g => g.Users)
                .HasForeignKey(u => u.IdGroup)
                .OnDelete(DeleteBehavior.SetNull);
        });
    }
}