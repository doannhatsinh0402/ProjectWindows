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
            context.Khoas.AddOrUpdate(
               new Khoa
               {
                   MaKhoa = "CNTT",
                   TenKhoa = "Công nghệ thông tin",
                   MaTruongKhoa = "TK01"
               });
            context.GiangViens.AddOrUpdate(
                new GiangVien
                {
                    MaGV = "TK01",
                    TenGV = "DaoNguyenMinh",
                    GioiTinh = Model.Common.GioiTinh.Nam,
                    DiaChi = "ákdljasdf",
                    Sdt = "01234569",
                    Email = "DaoNguyenMinh@email.com",
                    MaKhoa = "CNTT"
                });
            context.KhoaHocs.AddOrUpdate(
                new KhoaHoc
                {
                    MaKH = "K19",
                    NamBatDau = DateTime.Now,
                    NamKetThuc = DateTime.Now
                });
            context.SinhViens.AddOrUpdate(
                new SinhVien
                {
                    MaSV = "SV01",
                    TenSV = "Nguyen Van A",
                    Lop = "19133",
                    NgaySinh = DateTime.Now,
                    GioiTinh = Model.Common.GioiTinh.Nam,
                    Sdt = "0123423",
                    Email = "nguyenvana@gmail.com",
                    MaKH = "K19",
                    MaKhoa = "CNTT",
                }
                );
            context.SinhViens.AddOrUpdate(
            new SinhVien
            {
                MaSV = "SV02",
                TenSV = "Nguyen Van 2",
                Lop = "19133",
                NgaySinh = DateTime.Now,
                GioiTinh = Model.Common.GioiTinh.Nam,
                Sdt = "01453423",
                Email = "nguyenvanb@gmail.com",
                MaKH = "K19",
                MaKhoa = "CNTT",
            }
            );
        }
    }
}
