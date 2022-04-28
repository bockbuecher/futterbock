using Futterbock.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;

namespace Futterbock.Context
{
    public class FutterbockContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredients> Ingredients { get; set;}
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
    }
}
