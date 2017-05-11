using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCodeFirstTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new MyContext())
            {
                var company = new Company()
                {
                    Name = "公司名称",
                    Descript = "公司描述"
                };
                ctx.Company.Add(company);
                ctx.SaveChanges();
            }
        }
    }

    public class MyContext : DbContext
    {
        public MyContext() : base("name=default") { }

        public virtual DbSet<Company> Company { get; set; }

        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public class Company
    {
        [Key]
        public long ID { get; set; }

        [DisplayName("名称"), Required, StringLength(50)]
        public string Name { get; set; }

        [DisplayName("描述")]
        public string Descript { get; set; }
    }

    public class Employee
    {
        [Key]
        public long ID { get; set; }

        public long CompanyID { get; set; }
        public Company Company { get; set; }

        [DisplayName("名称"), Required, StringLength(50)]
        public string Name { get; set; }

        [DisplayName("性别")]
        public int Gender { get; set; }

        [DisplayName("身高")]
        public int Height { get; set; }

        [DisplayName("体重")]
        public decimal Weight { get; set; }
    }
}
