using System.Runtime.InteropServices.ComTypes;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Security;

namespace HebianGu.Demo.EFCore.MoveDBForMySql
{
    public class DataContext : DbContext
    { 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //  Do：注册链接字符串   
            optionsBuilder.UseMySQL("server=localhost;userid=root;pwd=123456;port=3306;database=test;sslmode=none;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 

            //  Do：一对一关系模型
            modelBuilder.Entity<Student>().HasOne(l => l.Desk).WithOne(l => l.Student)
                .HasForeignKey<Student>(l => l.DeskID);  


            //  Do：一对多关系模型
            modelBuilder.Entity<Teacher>().HasOne(l => l.School).WithMany(l => l.Teachers)
                .HasForeignKey(l => l.SchoolID); 


            //  Do：多对多配置联合主键    
            modelBuilder.Entity<RelationShip>().HasKey(l => new {l.ChildID, l.ParentID});

            //  Do：多对多定义关系模型映射（本段代码可有可无）
            modelBuilder.Entity<RelationShip>().HasOne(l => l.Child).WithMany(l => l.RelationShips)
                .HasForeignKey(l => l.ChildID);

            modelBuilder.Entity<RelationShip>().HasOne(l => l.Parent).WithMany(l => l.RelationShips)
                .HasForeignKey(l => l.ParentID); 


            //  Do：设置种子数据
            modelBuilder.Entity<City>().HasData(
                new City{Id = 1,Name = "成都"}, new City {Id =5,Name = "北京" });
        }

        
        public  DbSet<City> Citys { get; set; } 


        public  DbSet<Parent> Parents { get; set; }
        public DbSet<Child> Childs { get; set; }


        public  DbSet<RelationShip> RelationShips { get; set; }
        public  DbSet<Student> Students { get; set; }
        public DbSet<Desk> Desks { get; set; }


        public  DbSet<Teacher> Teachers { get; set; }
        public DbSet<School> Schools { get; set; }
    }
}
