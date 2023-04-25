using AuthorizationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationApp.DBContext
{
    public partial class AppDbContext : DbContext
    {
        #region Properties
        public virtual DbSet<Class> Classes { get; set; }

        public virtual DbSet<Grade> Grades { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<User> Users { get; set; }
        #endregion

        #region Constructors
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        #endregion

        #region Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("Grade");

                entity.Property(e => e.Course).HasMaxLength(50);

                entity.HasOne(d => d.Student).WithMany(p => p.Grades)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grade_Student");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.UserRole)
                    .HasMaxLength(50)
                    .HasColumnName("Role");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Address).HasMaxLength(50);
                entity.Property(e => e.DateOfBirth).HasColumnType("date");
                entity.Property(e => e.Email).HasMaxLength(50);
                entity.Property(e => e.FirstName).HasMaxLength(50);
                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.HasOne(d => d.Class).WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Class");

                entity.HasOne(d => d.UserData).WithOne(p => p.Student)
                    .HasForeignKey<Student>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Password).HasMaxLength(50);
                entity.Property(e => e.Email).HasMaxLength(50);

                entity.HasOne(d => d.Role).WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        #endregion
    }
}
