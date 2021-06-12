namespace QuanLySinhVien.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using QuanLySinhVien.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<QuanLySinhVien.Data.QLSVDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(QuanLySinhVien.Data.QLSVDbContext context)
        {
            context.KhoaHocs.AddOrUpdate(
                new KhoaHoc
                {
                    MaKH = "K19_CNTT",
                    NamBatDau = DateTime.Now,
                    NamKetThuc = DateTime.Now
                }) ;
            context.MonHocs.AddOrUpdate(
                new MonHoc
                {
                    MaMH = "CSDL35",
                    TenMH = "Cơ Sở Dữ Liệu",
                    SoTC = 3,
                    MaMHTQ = "CTDL15"
                });
            
        }
    }
}
