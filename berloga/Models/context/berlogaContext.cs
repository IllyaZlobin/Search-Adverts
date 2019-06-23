using Microsoft.EntityFrameworkCore;

namespace berloga.Models
{
    public partial class berlogaContext : DbContext
    {
        public berlogaContext()
        {
        }

        public berlogaContext(DbContextOptions<berlogaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AllAdverts> AllAdverts { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<TypeOfAdvert> TypeOfAdvert { get; set; }
        public virtual DbSet<TypeOfApartament> TypeOfApartament { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-7MUFD27;Database=berloga;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllAdverts>(entity =>
            {
                entity.HasKey(e => e.IdHome);

                entity.ToTable("All_adverts");

                entity.Property(e => e.IdHome)
                    .HasColumnName("id_home")
                    .ValueGeneratedNever();

                entity.Property(e => e.AboutHome)
                    .HasColumnName("about_home")
                    .HasColumnType("ntext");

                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasColumnName("adress")
                    .HasMaxLength(30);

                entity.Property(e => e.IdAdverts).HasColumnName("id_adverts");

                entity.Property(e => e.IdApartament).HasColumnName("id_apartament");

                entity.Property(e => e.IdUser)
                    .IsRequired()
                    .HasColumnName("id_user")
                    .HasMaxLength(450);

                entity.Property(e => e.NumOfRooms).HasColumnName("num_of_rooms");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Square).HasColumnName("square");

                entity.Property(e => e.TownDistrict)
                    .IsRequired()
                    .HasColumnName("town/district")
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdAdvertsNavigation)
                    .WithMany(p => p.AllAdverts)
                    .HasForeignKey(d => d.IdAdverts)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_All_adverts_Type_of_advert");

                entity.HasOne(d => d.IdApartamentNavigation)
                    .WithMany(p => p.AllAdverts)
                    .HasForeignKey(d => d.IdApartament)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_All_adverts_Type_of_apartament");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.AllAdverts)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_All_adverts_AspNetUsers");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AboutYourstlf).HasColumnName("about_yourstlf");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.Login).HasColumnName("login");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.Parol).HasColumnName("parol");

                entity.Property(e => e.Surname).HasColumnName("surname");

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<TypeOfAdvert>(entity =>
            {
                entity.HasKey(e => e.IdAdvert);

                entity.ToTable("Type_of_advert");

                entity.Property(e => e.IdAdvert)
                    .HasColumnName("id_advert")
                    .ValueGeneratedNever();

                entity.Property(e => e.TypeOfAdvert1)
                    .HasColumnName("type_of_advert")
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<TypeOfApartament>(entity =>
            {
                entity.HasKey(e => e.IdApartament);

                entity.ToTable("Type_of_apartament");

                entity.Property(e => e.IdApartament)
                    .HasColumnName("id_apartament")
                    .ValueGeneratedNever();

                entity.Property(e => e.TypeOfApartament1)
                    .IsRequired()
                    .HasColumnName("type_of_apartament")
                    .HasMaxLength(25);
            });
        }
    }
}