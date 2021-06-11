namespace QuanLySinhVien.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diems",
                c => new
                    {
                        MaSV = c.String(nullable: false, maxLength: 9, unicode: false),
                        MaMH = c.String(nullable: false, maxLength: 15, unicode: false),
                        DiemQT = c.String(),
                        DiemThi = c.String(),
                        DiemTB = c.String(),
                    })
                .PrimaryKey(t => new { t.MaSV, t.MaMH })
                .ForeignKey("dbo.MonHocs", t => t.MaMH)
                .ForeignKey("dbo.SinhViens", t => t.MaSV)
                .Index(t => t.MaSV)
                .Index(t => t.MaMH);
            
            CreateTable(
                "dbo.MonHocs",
                c => new
                    {
                        MaMH = c.String(nullable: false, maxLength: 15, unicode: false),
                        TenMH = c.String(nullable: false, maxLength: 30),
                        SoTC = c.Int(nullable: false),
                        MaMHTQ = c.String(nullable: false, maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.MaMH)
                .ForeignKey("dbo.MonHocs", t => t.MaMHTQ)
                .Index(t => t.MaMHTQ);
            
            CreateTable(
                "dbo.LopHPs",
                c => new
                    {
                        MaLHP = c.String(nullable: false, maxLength: 15, unicode: false),
                        MaMH = c.String(nullable: false, maxLength: 15, unicode: false),
                        MaGV = c.String(nullable: false, maxLength: 15, unicode: false),
                        NamHoc = c.Int(nullable: false),
                        HocKy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaLHP)
                .ForeignKey("dbo.GiangViens", t => t.MaGV)
                .ForeignKey("dbo.MonHocs", t => t.MaMH)
                .Index(t => t.MaMH)
                .Index(t => t.MaGV);
            
            CreateTable(
                "dbo.GiangViens",
                c => new
                    {
                        MaGV = c.String(nullable: false, maxLength: 15, unicode: false),
                        TenGV = c.String(nullable: false, maxLength: 30),
                        GioiTinh = c.Int(nullable: false),
                        DiaChi = c.String(maxLength: 150),
                        Sdt = c.String(nullable: false, maxLength: 15, unicode: false),
                        Email = c.String(nullable: false, maxLength: 30, unicode: false),
                        MaKhoa = c.String(nullable: false, maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.MaGV)
                .ForeignKey("dbo.Khoas", t => t.MaKhoa)
                .Index(t => t.MaKhoa);
            
            CreateTable(
                "dbo.Khoas",
                c => new
                    {
                        MaKhoa = c.String(nullable: false, maxLength: 15, unicode: false),
                        TenKhoa = c.String(nullable: false, maxLength: 30),
                        MaTruongKhoa = c.String(nullable: false, maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.MaKhoa)
                .ForeignKey("dbo.GiangViens", t => t.MaKhoa)
                .Index(t => t.MaKhoa);
            
            CreateTable(
                "dbo.SinhViens",
                c => new
                    {
                        MaSV = c.String(nullable: false, maxLength: 9, unicode: false),
                        TenSV = c.String(nullable: false, maxLength: 30),
                        Lop = c.String(nullable: false, maxLength: 10, unicode: false),
                        NgaySinh = c.DateTime(nullable: false),
                        GioiTinh = c.Int(nullable: false),
                        DiaChi = c.String(maxLength: 150),
                        QueQuan = c.String(maxLength: 150),
                        Sdt = c.String(nullable: false, maxLength: 15, unicode: false),
                        Email = c.String(nullable: false, maxLength: 30, unicode: false),
                        MaKhoa = c.String(nullable: false, maxLength: 15, unicode: false),
                        MaKH = c.String(nullable: false, maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.MaSV)
                .ForeignKey("dbo.KhoaHocs", t => t.MaKH)
                .ForeignKey("dbo.Khoas", t => t.MaKhoa)
                .Index(t => t.MaKhoa)
                .Index(t => t.MaKH);
            
            CreateTable(
                "dbo.KhoaHocs",
                c => new
                    {
                        MaKH = c.String(nullable: false, maxLength: 15, unicode: false),
                        NamBatDau = c.DateTime(nullable: false),
                        NamKetThuc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaKH);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MonHocs", "MaMHTQ", "dbo.MonHocs");
            DropForeignKey("dbo.LopHPs", "MaMH", "dbo.MonHocs");
            DropForeignKey("dbo.LopHPs", "MaGV", "dbo.GiangViens");
            DropForeignKey("dbo.Khoas", "MaKhoa", "dbo.GiangViens");
            DropForeignKey("dbo.SinhViens", "MaKhoa", "dbo.Khoas");
            DropForeignKey("dbo.SinhViens", "MaKH", "dbo.KhoaHocs");
            DropForeignKey("dbo.Diems", "MaSV", "dbo.SinhViens");
            DropForeignKey("dbo.GiangViens", "MaKhoa", "dbo.Khoas");
            DropForeignKey("dbo.Diems", "MaMH", "dbo.MonHocs");
            DropIndex("dbo.SinhViens", new[] { "MaKH" });
            DropIndex("dbo.SinhViens", new[] { "MaKhoa" });
            DropIndex("dbo.Khoas", new[] { "MaKhoa" });
            DropIndex("dbo.GiangViens", new[] { "MaKhoa" });
            DropIndex("dbo.LopHPs", new[] { "MaGV" });
            DropIndex("dbo.LopHPs", new[] { "MaMH" });
            DropIndex("dbo.MonHocs", new[] { "MaMHTQ" });
            DropIndex("dbo.Diems", new[] { "MaMH" });
            DropIndex("dbo.Diems", new[] { "MaSV" });
            DropTable("dbo.KhoaHocs");
            DropTable("dbo.SinhViens");
            DropTable("dbo.Khoas");
            DropTable("dbo.GiangViens");
            DropTable("dbo.LopHPs");
            DropTable("dbo.MonHocs");
            DropTable("dbo.Diems");
        }
    }
}
