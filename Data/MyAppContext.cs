using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Testing_general.Models;

namespace Testing_general.Data;

public partial class MyAppContext : DbContext
{
    public MyAppContext()
    {
    }

    public MyAppContext(DbContextOptions<MyAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Item> Items { get; set; }
    public virtual DbSet<Dish> Dishes { get; set; }

    public virtual DbSet<DishIngredient> DishIngredients { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dish>(entity =>
        {
            entity.HasKey(e => e.DishId).HasName("PK_Dish");

            entity.Property(e => e.DishId).ValueGeneratedNever();
        });

        modelBuilder.Entity<DishIngredient>(entity =>
        {
            entity.HasOne(d => d.Dish).WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DishIngredients_to_Dish");

            entity.HasOne(d => d.Ingredient).WithMany().HasConstraintName("DishIngredients_to_Ingredients");
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.Property(e => e.IngredientId).ValueGeneratedNever();
        });

    }

}
