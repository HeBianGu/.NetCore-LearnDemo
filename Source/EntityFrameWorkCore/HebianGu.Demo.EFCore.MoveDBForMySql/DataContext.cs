using System;
using Microsoft.EntityFrameworkCore;

namespace HebianGu.Demo.EFCore.MoveDBForMySql
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;userid=root;pwd=123456;port=3306;database=test;sslmode=none;");

            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City{Id = 1,Name = "成都"}, new City {Id =5,Name = "北京" });
        }

        public  DbSet<City> Citys { get; set; }    
    }

    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Group { get; set; }


        public int Count { get; set; }
        public DateTime CDate { get; set; }
    }
}
