using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.EntityFrameworkCore;

namespace HebianGu.Demo.EFCore.MoveDBForSQLite
{
    public class DataContext : DbContext
    { 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //  Do：注册链接字符串   
            //optionsBuilder.UseSqlite("server=localhost;userid=root;pwd=123456;port=3306;database=test;sslmode=none;");
            optionsBuilder.UseSqlite("Data Source=sqliteTest.db;");

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

        public DbSet<LogOperateEntity> LogOperateEntitys { get; set; }
        public DbSet<LogBiochemicalEntiy> LogBiochemicalEntiys { get; set; }
        public DbSet<LogPersonEntity> LogPersonEntitys { get; set; }
    }

    /// <summary>
    /// 操作记录实体
    /// </summary>
    [Table("bhb_log_operate")]
    public class LogOperateEntity
    {
        /// <summary>
        /// 操作记录ID，主键
        /// </summary>
        [Key]
        [Column(name: "operate_id")]
        public string OperateID { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        [Column(name: "operate_date")]
        public DateTime OperateDate { get; set; }
        /// <summary>
        /// 操作账号
        /// </summary>
        [Column(name: "operate_account")]
        public string OperateAccount { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Column(name: "name")]
        public string Name { get; set; }
        /// <summary>
        /// 上传的生化数据项数量
        /// </summary>
        [Column(name: "biochemical_count")]
        public int BiochemicalCount { get; set; }



        /// <summary>
        /// 操作结果，是否上传成功
        /// </summary>
        [Column(name: "operate_result")]
        public bool OperateResult { get; set; }
        /// <summary>
        /// 失败原因（如果失败）
        /// </summary>
        [Column(name: "failure_cause")]
        public string FailureCause { get; set; }


        /// <summary>
        /// 居民ID，用档案号，如果没有则用日期和身份证补齐
        /// 外键
        /// </summary>
        [Column(name: "person_id")]
        public string PersonID { get; set; }
        /// <summary>
        /// 生化数据ID
        /// 外键
        /// </summary>
        [Column(name: "biochemical_id")]
        public string BiochemicalID { get; set; }
    }


    /// <summary>
    /// 生化数据记录实体
    /// </summary>
    [Table("bhb_log_biochemical")]
    public class LogBiochemicalEntiy : BaseBiochemicalEntity
    {
        /// <summary>
        /// 生化数据ID
        /// </summary>
        [Key]
        [Column(name: "biochemical_id")]
        public string BiochemicalID { get; set; }
    }

    /// <summary>
    /// 个人信息实体
    /// </summary>
    [Table("bhb_log_person")]
    public class LogPersonEntity : BasePersonEntity
    {
        /// <summary>
        /// 个人信息ID
        /// 主键
        /// </summary>
        [Key]
        [Column(name: "person_id")]
        public string PersionID { get; set; }
        /// <summary>
        /// 体检表日期
        /// </summary>
        [Column(name: "health_form_date")]
        public DateTime HealthFormDate { get; set; }
        /// <summary>
        /// 体检表ID
        /// </summary>
        [Column(name: "health_form_id")]
        public string HealthFormID { get; set; }

    }

    /// <summary>
    /// 居民个人基础信息实体
    /// </summary>
    public class BasePersonEntity
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Column(name: "name")]
        public string Name { get; set; }
        /// <summary>
        /// 性别 
        /// 0 未知 1 男 2 女 9 未说明的性别
        /// </summary>
        [Column(name: "sex")]
        public byte Sex { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        [Column(name: "age")]
        public int Age { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [Column(name: "tel")]
        public string MemberTel { get; set; }
        /// <summary>
        /// 住址
        /// </summary>
        [Column(name: "address")]
        public string Address { get; set; }
        /// <summary>
        /// 区划信息
        /// </summary>
        [Column(name: "region_code")]
        public string RegionCode { get; set; }
        /// <summary>
        /// 身份证信息
        /// </summary>
        [Column(name: "card_id")]
        public string CardID { get; set; }
    }

    /// <summary>
    /// 生化数据通用实体
    /// </summary>
    public class BaseBiochemicalEntity
    {
        /// <summary>
        /// 血红蛋白 HGB或者hb
        /// g/L
        /// </summary>
        [Column(name: "hb")]
        public string HB { get; set; }
        /// <summary>
        /// 白细胞
        /// x 10^9/L
        /// </summary>
        [Column(name: "wbc")]
        public string WBC { get; set; }
        /// <summary>
        /// 血小板 PLT/BPC
        ///  x 10^9/L
        /// </summary>
        [Column(name: "plt")]
        public string PLT { get; set; }
        /// <summary>
        /// 空腹血糖FPG
        /// mmol/L
        /// </summary>
        [Column(name: "fpg")]
        public string FPG { get; set; }
        /// <summary>
        /// 随机血糖
        /// mmol/L
        /// </summary>
        [Column(name: "glu")]
        public string GLU { get; set; }
        /// <summary>
        /// 尿微量白蛋白（U-MA)
        /// mg/dL
        /// </summary>
        [Column(name: "uma")]
        public string UMA { get; set; }
        /// <summary>
        /// 糖化血红蛋白（HbA1c GHb）
        /// %
        /// </summary>
        [Column(name: "ghb")]
        public string GHB { get; set; }
        /// <summary>
        /// 血清谷丙转氨酶(ALT)
        /// U/L
        /// </summary>
        [Column(name: "alt")]
        public string ALT { get; set; }
        /// <summary>
        /// 血清谷草转氨酶 (AST)
        /// U/L
        /// </summary>
        [Column(name: "ast")]
        public string AST { get; set; }
        /// <summary>
        /// 白蛋白（ALB）
        /// g/L
        /// </summary>
        [Column(name: "alb")]
        public string ALB { get; set; }
        /// <summary>
        /// 总胆红素TBIL
        /// μmol/L
        /// </summary>
        [Column(name: "tbil")]
        public string TBIL { get; set; }
        /// <summary>
        /// 结合胆红素
        /// μmol/L
        /// </summary>
        [Column(name: "sdb")]
        public string SDB { get; set; }
        /// <summary>
        /// 血清肌酐
        /// μmol/L
        /// </summary>
        [Column(name: "scr")]
        public string SCR { get; set; }
        /// <summary>
        /// 血尿素
        /// mmol/L
        /// </summary>
        [Column(name: "bun")]
        public string BUN { get; set; }
        /// <summary>
        /// 血钾浓度
        /// mmol/L
        /// </summary>
        [Column(name: "k")]
        public string K { get; set; }
        /// <summary>
        /// 血钠浓度
        /// mmol/L
        /// </summary>
        [Column(name: "na")]
        public string Na { get; set; }
        /// <summary>
        /// 总胆固醇
        /// mmol/L
        /// </summary>
        [Column(name: "tc")]
        public string TC { get; set; }
        /// <summary>
        /// 甘油三酯
        /// mmol/L
        /// </summary>
        [Column(name: "tg")]
        public string TG { get; set; }
        /// <summary>
        /// 低密度脂蛋白胆固醇（LDL-C）
        /// mmol/L
        /// </summary>
        [Column(name: "ldlc")]
        public string LDLC { get; set; }
        /// <summary>
        /// 高密度脂蛋白胆固醇（HDL-C）
        /// mmol/L
        /// </summary>
        [Column(name: "hdlc")]
        public string HDLC { get; set; }
    }
}
