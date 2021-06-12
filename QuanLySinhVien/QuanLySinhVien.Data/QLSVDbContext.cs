using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.Model;
using QuanLySinhVien.Data.EntityConfigurations;

namespace QuanLySinhVien.Data
{
    public class QLSVDbContext : DbContext
    {
        public QLSVDbContext() : base("name=DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false; 
        }
        public virtual DbSet<Diem> Diems { get; set; }
        public virtual DbSet<GiangVien> GiangViens { get; set; }
        public virtual DbSet<Khoa> Khoas { get; set; }
        public virtual DbSet<KhoaHoc> KhoaHocs { get; set; }
        public virtual DbSet<LopHP> LopHPs { get; set; }
        public virtual DbSet<MonHoc> MonHocs { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DiemConfiguration());
            modelBuilder.Configurations.Add(new GiangVienConfiguration());
            modelBuilder.Configurations.Add(new KhoaConfiguration());
            modelBuilder.Configurations.Add(new KhoaHocConfiguration());
            modelBuilder.Configurations.Add(new LopHPConfiguration());
            modelBuilder.Configurations.Add(new MonHocConfiguration());
            modelBuilder.Configurations.Add(new SinhVienConfiguration());
        }
    }
}
