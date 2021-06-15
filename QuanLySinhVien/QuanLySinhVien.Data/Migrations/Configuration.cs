namespace QuanLySinhVien.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QuanLySinhVien.Data.QLSVDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(QuanLySinhVien.Data.QLSVDbContext context)
        {
            context.Khoas.AddOrUpdate(
                new Model.Khoa
                {
                    MaKhoa = "CNTT",
                    MaTruongKhoa = "MD1",
                    TenKhoa = "Công nghệ thông tin"

                });
            context.GiangViens.AddOrUpdate
                (
                new Model.GiangVien
                {
                    MaGV = "MD01",
                    TenGV = "DaoNguyenMinh",
                    GioiTinh = Model.Common.GioiTinh.Nam,
                    DiaChi = "abcxyz",
                    Sdt = "090092",
                    Email = "fasb@gmail.com",
                    MaKhoa = "CNTT"
                });
            context.GiangViens.AddOrUpdate(
                new Model.GiangVien
                {
                    MaGV = "GV01",
                    TenGV = "NguyenVan A",
                    GioiTinh = Model.Common.GioiTinh.Nam,
                    DiaChi = "ashd",
                    Sdt = "0902399",
                    Email = "nguyenvan@gmail.com",
                    MaKhoa = "CNTT"
                });
            context.KhoaHocs.AddOrUpdate(
                new Model.KhoaHoc
                {
                    MaKH = "K19",
                    NamBatDau = DateTime.Now,
                    NamKetThuc = DateTime.Now
                });
            context.SinhViens.AddOrUpdate(
                new Model.SinhVien
                {
                    MaSV = "SV01",
                    TenSV = "Sinh",
                    Lop = "19133",
                    NgaySinh = DateTime.Now,
                    GioiTinh = Model.Common.GioiTinh.Nam,
                    DiaChi = "sdf",
                    QueQuan = "asdfs",
                    Sdt = "07855",
                    Email = "sdf@gmal.com",
                    MaKhoa = "CNTT",
                    MaKH = "K19"
                }
                );
            context.SinhViens.AddOrUpdate(
              new Model.SinhVien
              {
                  MaSV = "SV02",
                  TenSV = "Sinh2",
                  Lop = "19133",
                  NgaySinh = DateTime.Now,
                  GioiTinh = Model.Common.GioiTinh.Nam,
                  DiaChi = "sdfsdf",
                  QueQuan = "assdfdfs",
                  Sdt = "07866",
                  Email = "sdfsdf@gmal.com",
                  MaKhoa = "CNTT",
                  MaKH = "K19"
              }
              );
            context.MonHocs.AddOrUpdate(
                new Model.MonHoc
                {
                    MaMH = "LTW",
                    TenMH = "Lập trình win",
                    SoTC = 3
                }
                );
            context.MonHocs.AddOrUpdate(
           new Model.MonHoc
           {
               MaMH = "CSDL",
               TenMH = "Cơ sở dữ liệu",
               SoTC = 3
           }
           );
            context.Diems.AddOrUpdate
                (
                new Model.Diem
                {
                    MaSV = "SV01",
                    MaMH = "LTW",
                    DiemThi = 5,
                    DiemQT = 3,
                    DiemTB = 2
                }
                );
            context.Diems.AddOrUpdate
             (
             new Model.Diem
             {
                 MaSV = "SV01",
                 MaMH = "CSDL",
                 DiemThi = 5,
                 DiemQT = 3,
                 DiemTB = 2
             }
             );
        }
    }
}
