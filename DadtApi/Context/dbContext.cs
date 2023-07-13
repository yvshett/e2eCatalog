using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DadtApi.Models;

namespace DadtApi.Context
{
    public partial class dbContext : DbContext
    {
        public dbContext()
        {
        }

        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemAttribute> ItemAttributes { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(CommonUtility.EncryptionHelper.DecryptString(@"IOr1ODdKIGfNzXwgWid20uxBmBC8GIht8RKBpVfdI5lsZp5m7GGd5SGwiFfS0U9iw41el/fR0bYQiUCbgTGVs4zXgQd3g1QZeYoYR2GBMaoU370zzmdzxlwBF0gCnmtw95GYnhjmxkG6Qz5ylrqm+3mYtZIUdXl3SPO2DNKZTLP6hIA81Fig7uB6eQIt3C2r",CommonUtility.Constants.STR_ENCRYPT_DECRYPT_KEY));
      
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pg_stat_statements");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId).UseIdentityAlwaysColumn();

                entity.Property(e => e.CategoryName).IsRequired();

                entity.Property(e => e.Description).IsRequired();
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.ItemId).UseIdentityAlwaysColumn();

                entity.Property(e => e.ItemCode).IsRequired();

                entity.Property(e => e.ItemImageLink).IsRequired();

                entity.Property(e => e.ItemName).IsRequired();

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.SubCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk");
            });

            modelBuilder.Entity<ItemAttribute>(entity =>
            {
                entity.HasKey(e => e.AttributeId)
                    .HasName("ItemAttributes_pkey");

                entity.Property(e => e.AttributeId).UseIdentityAlwaysColumn();

                entity.Property(e => e.AttributeName).IsRequired();

                entity.Property(e => e.AttributeValue).IsRequired();

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemAttributes)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk");
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.Property(e => e.SubCategoryId).UseIdentityAlwaysColumn();

                entity.Property(e => e.SubCategoryName).IsRequired();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SubCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
