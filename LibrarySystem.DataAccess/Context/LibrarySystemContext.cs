using System;
using System.Collections.Generic;
using LibrarySystem.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.DataAccess.Context;

public partial class LibrarySystemContext : DbContext
{
    public LibrarySystemContext()
    {
    }

    public LibrarySystemContext(DbContextOptions<LibrarySystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<PublishingHouse> PublishingHouses { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=LibrarySystem;User Id=sa;Password=123456;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.ToTable("Author");

            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.AuthorName)
                .HasMaxLength(128)
                .HasColumnName("author_name");
            entity.Property(e => e.AuthorSurname)
                .HasMaxLength(128)
                .HasColumnName("author_surname");
            entity.Property(e => e.LogCreateDate)
                .HasColumnType("datetime")
                .HasColumnName("log_create_date");
            entity.Property(e => e.LogCreateUserId).HasColumnName("log_create_user_id");
            entity.Property(e => e.LogDeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("log_delete_date");
            entity.Property(e => e.LogDeleteUserId).HasColumnName("log_delete_user_id");
            entity.Property(e => e.LogUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("log_update_date");
            entity.Property(e => e.LogUpdateUserId).HasColumnName("log_update_user_id");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("Book");

            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.BookName)
                .HasMaxLength(256)
                .HasColumnName("book_name");
            entity.Property(e => e.BookPage).HasColumnName("book_page");
            entity.Property(e => e.BookPrice)
                .HasColumnType("money")
                .HasColumnName("book_price");
            entity.Property(e => e.LogCreateDate)
                .HasColumnType("datetime")
                .HasColumnName("log_create_date");
            entity.Property(e => e.LogCreateUserId).HasColumnName("log_create_user_id");
            entity.Property(e => e.LogDeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("log_delete_date");
            entity.Property(e => e.LogDeleteUserId).HasColumnName("log_delete_user_id");
            entity.Property(e => e.LogUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("log_update_date");
            entity.Property(e => e.LogUpdateUserId).HasColumnName("log_update_user_id");
            entity.Property(e => e.PublishingHouseId).HasColumnName("publishing_house_id");

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Book_Author");

            entity.HasOne(d => d.PublishingHouse).WithMany(p => p.Books)
                .HasForeignKey(d => d.PublishingHouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Book_PublishingHouse");
        });

        modelBuilder.Entity<PublishingHouse>(entity =>
        {
            entity.ToTable("PublishingHouse");

            entity.Property(e => e.PublishingHouseId).HasColumnName("publishing_house_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.LogCreateDate)
                .HasColumnType("datetime")
                .HasColumnName("log_create_date");
            entity.Property(e => e.LogCreateUserId).HasColumnName("log_create_user_id");
            entity.Property(e => e.LogDeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("log_delete_date");
            entity.Property(e => e.LogDeleteUserId).HasColumnName("log_delete_user_id");
            entity.Property(e => e.LogUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("log_update_date");
            entity.Property(e => e.LogUpdateUserId).HasColumnName("log_update_user_id");
            entity.Property(e => e.PublishingHouseAddress)
                .HasMaxLength(256)
                .IsFixedLength()
                .HasColumnName("publishing_house_address");
            entity.Property(e => e.PublishingHouseName)
                .HasMaxLength(256)
                .IsFixedLength()
                .HasColumnName("publishing_house_name");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("UserInfo");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Email)
                .HasMaxLength(256)
                .HasColumnName("email");
            entity.Property(e => e.LogCreateDate)
                .HasColumnType("datetime")
                .HasColumnName("log_create_date");
            entity.Property(e => e.LogCreateUserId).HasColumnName("log_create_user_id");
            entity.Property(e => e.LogDeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("log_delete_date");
            entity.Property(e => e.LogDeleteUserId).HasColumnName("log_delete_user_id");
            entity.Property(e => e.LogUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("log_update_date");
            entity.Property(e => e.LogUpdateUserId).HasColumnName("log_update_user_id");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(128)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(11)
                .HasColumnName("phone_number");
            entity.Property(e => e.Surname)
                .HasMaxLength(128)
                .IsFixedLength()
                .HasColumnName("surname");
            entity.Property(e => e.UserRoleId).HasColumnName("user_role_id");

            entity.HasOne(d => d.UserRole).WithMany(p => p.UserInfos)
                .HasForeignKey(d => d.UserRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserInfo_UserInfo");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.ToTable("UserRole");

            entity.Property(e => e.UserRoleId).HasColumnName("user_role_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.FullAuthority).HasColumnName("full_authority");
            entity.Property(e => e.LogCreateDate)
                .HasColumnType("datetime")
                .HasColumnName("log_create_date");
            entity.Property(e => e.LogCreateUserId).HasColumnName("log_create_user_id");
            entity.Property(e => e.LogDeleteDate)
                .HasColumnType("datetime")
                .HasColumnName("log_delete_date");
            entity.Property(e => e.LogDeleteUserId).HasColumnName("log_delete_user_id");
            entity.Property(e => e.LogUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("log_update_date");
            entity.Property(e => e.LogUpdateUserId).HasColumnName("log_update_user_id");
            entity.Property(e => e.UserRoleName)
                .HasMaxLength(64)
                .HasColumnName("user_role_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
