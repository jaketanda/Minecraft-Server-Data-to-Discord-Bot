using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace MCBot.Resources.Database
{
    public class SqliteDbContext : DbContext
    {
        public DbSet<Stone> Stones { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder Options)
        {
            
            string DbLocation = Assembly.GetEntryAssembly().Location.Replace(@"bin\Debug\netcoreapp2.2\MCBot.dll", @"Data\");
            Console.WriteLine($"{DbLocation}Database.sqlite");
            Options.UseSqlite($"DataSource={DbLocation}Database.sqlite");
        }
    }
}
