using Futterbock.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;

namespace Futterbock.Context
{
    public class FutterbockContext : DbContext
    {
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<Ingredients_CategoryInfo> Ingredients_CategoryInfo { get; set;}
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<Tour> Tour { get; set; }
        public DbSet<TourRecipes> TourRecipes { get; set; }
        public DbSet<MealCategory> MealCategories { get; set; }

        public string DbPath { get; private set; }

        public FutterbockContext()
        {
            var path = Environment.CurrentDirectory + @"\Db";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            DbPath = System.IO.Path.Join(path, "futterbock.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@$"DataSource={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredients>().HasKey(k => k.Id);
            modelBuilder.Entity<Recipe>().HasKey(k => k.ID);
            modelBuilder.Entity<Ingredients_CategoryInfo>().HasOne(i => i.Ingredient);
            modelBuilder.Entity<Tour>().HasKey(k => k.Id);
            modelBuilder.Entity<TourRecipes>().HasKey(k => k.Id);
            modelBuilder.Entity<MealCategory>().HasKey(k => k.Id);

        }
    }
}
