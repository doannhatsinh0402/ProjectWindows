namespace QuanLySinhVien.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Diems", "MaMH", "dbo.MonHocs");
            DropForeignKey("dbo.Diems", "MaSV", "dbo.SinhViens");
            DropForeignKey("dbo.LopHPs", "MaMH", "dbo.MonHocs");
            DropForeignKey("dbo.LopHPs", "MaGV", "dbo.GiangViens");
            DropForeignKey("dbo.SinhViens", "MaKhoa", "dbo.Khoas");
            DropForeignKey("dbo.SinhViens", "MaKH", "dbo.KhoaHocs");
            DropForeignKey("dbo.GiangViens", "Khoa_MaKhoa", "dbo.Khoas");
            DropForeignKey("dbo.GiangViens", "Khoa_MaKhoa1", "dbo.Khoas");
            DropForeignKey("dbo.GiangViens", "KhoaChuNhiem_MaKhoa", "dbo.Khoas");
            DropIndex("dbo.MonHocs", new[] { "MonHocTQ_MaMH" });
            DropIndex("dbo.GiangViens", new[] { "Khoa_MaKhoa" });
            DropIndex("dbo.GiangViens", new[] { "Khoa_MaKhoa1" });
            DropIndex("dbo.GiangViens", new[] { "KhoaChuNhiem_MaKhoa" });
            DropIndex("dbo.Khoas", new[] { "TruongKhoa_MaGV" });
            DropColumn("dbo.MonHocs", "MaMHTQ");
            DropColumn("dbo.GiangViens", "MaKhoa");
            DropColumn("dbo.GiangViens", "MaKhoa");
            DropColumn("dbo.Khoas", "MaKhoa");
            DropColumn("dbo.Khoas", "MaKhoa");
            RenameColumn(table: "dbo.MonHocs", name: "MonHocTQ_MaMH", newName: "MaMHTQ");
            RenameColumn(table: "dbo.GiangViens", name: "Khoa_MaKhoa1", newName: "MaKhoa");
            RenameColumn(table: "dbo.Khoas", name: "KhoaChuNhiem_MaKhoa", newName: "MaKhoa");
            RenameColumn(table: "dbo.GiangViens", name: "Khoa_MaKhoa", newName: "MaKhoa");
            RenameColumn(table: "dbo.Khoas", name: "TruongKhoa_MaGV", newName: "MaKhoa");
            DropPrimaryKey("dbo.Khoas");
            AlterColumn("dbo.MonHocs", "MaMHTQ", c => c.String(maxLength: 15, unicode: false));
            AlterColumn("dbo.GiangViens", "MaKhoa", c => c.String(nullable: false, maxLength: 15, unicode: false));
            AlterColumn("dbo.GiangViens", "MaKhoa", c => c.String(nullable: false, maxLength: 15, unicode: false));
            AlterColumn("dbo.Khoas", "MaKhoa", c => c.String(nullable: false, maxLength: 15, unicode: false));
            AddPrimaryKey("dbo.Khoas", "MaKhoa");
            CreateIndex("dbo.MonHocs", "MaMHTQ");
            CreateIndex("dbo.GiangViens", "MaKhoa");
            CreateIndex("dbo.Khoas", "MaKhoa");
            AddForeignKey("dbo.Diems", "MaMH", "dbo.MonHocs", "MaMH");
            AddForeignKey("dbo.Diems", "MaSV", "dbo.SinhViens", "MaSV");
            AddForeignKey("dbo.LopHPs", "MaMH", "dbo.MonHocs", "MaMH");
            AddForeignKey("dbo.LopHPs", "MaGV", "dbo.GiangViens", "MaGV");
            AddForeignKey("dbo.SinhViens", "MaKhoa", "dbo.Khoas", "MaKhoa");
            AddForeignKey("dbo.SinhViens", "MaKH", "dbo.KhoaHocs", "MaKH");
            AddForeignKey("dbo.GiangViens", "MaKhoa", "dbo.Khoas", "MaKhoa");
            DropColumn("dbo.GiangViens", "KhoaChuNhiem_MaKhoa");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GiangViens", "KhoaChuNhiem_MaKhoa", c => c.String(maxLength: 15, unicode: false));
            DropForeignKey("dbo.GiangViens", "MaKhoa", "dbo.Khoas");
            DropForeignKey("dbo.SinhViens", "MaKH", "dbo.KhoaHocs");
            DropForeignKey("dbo.SinhViens", "MaKhoa", "dbo.Khoas");
            DropForeignKey("dbo.LopHPs", "MaGV", "dbo.GiangViens");
            DropForeignKey("dbo.LopHPs", "MaMH", "dbo.MonHocs");
            DropForeignKey("dbo.Diems", "MaSV", "dbo.SinhViens");
            DropForeignKey("dbo.Diems", "MaMH", "dbo.MonHocs");
            DropIndex("dbo.Khoas", new[] { "MaKhoa" });
            DropIndex("dbo.GiangViens", new[] { "MaKhoa" });
            DropIndex("dbo.MonHocs", new[] { "MaMHTQ" });
            DropPrimaryKey("dbo.Khoas");
            AlterColumn("dbo.Khoas", "MaKhoa", c => c.String(maxLength: 15, unicode: false));
            AlterColumn("dbo.GiangViens", "MaKhoa", c => c.String(maxLength: 15, unicode: false));
            AlterColumn("dbo.GiangViens", "MaKhoa", c => c.String(maxLength: 15, unicode: false));
            AlterColumn("dbo.MonHocs", "MaMHTQ", c => c.String());
            AddPrimaryKey("dbo.Khoas", "MaKhoa");
            RenameColumn(table: "dbo.Khoas", name: "MaKhoa", newName: "TruongKhoa_MaGV");
            RenameColumn(table: "dbo.GiangViens", name: "MaKhoa", newName: "Khoa_MaKhoa");
            RenameColumn(table: "dbo.Khoas", name: "MaKhoa", newName: "KhoaChuNhiem_MaKhoa");
            RenameColumn(table: "dbo.GiangViens", name: "MaKhoa", newName: "Khoa_MaKhoa1");
            RenameColumn(table: "dbo.MonHocs", name: "MaMHTQ", newName: "MonHocTQ_MaMH");
            AddColumn("dbo.Khoas", "MaKhoa", c => c.String(nullable: false, maxLength: 15, unicode: false));
            AddColumn("dbo.Khoas", "MaKhoa", c => c.String(nullable: false, maxLength: 15, unicode: false));
            AddColumn("dbo.GiangViens", "MaKhoa", c => c.String(nullable: false, maxLength: 15, unicode: false));
            AddColumn("dbo.GiangViens", "MaKhoa", c => c.String(nullable: false, maxLength: 15, unicode: false));
            AddColumn("dbo.MonHocs", "MaMHTQ", c => c.String());
            CreateIndex("dbo.Khoas", "TruongKhoa_MaGV");
            CreateIndex("dbo.GiangViens", "KhoaChuNhiem_MaKhoa");
            CreateIndex("dbo.GiangViens", "Khoa_MaKhoa1");
            CreateIndex("dbo.GiangViens", "Khoa_MaKhoa");
            CreateIndex("dbo.MonHocs", "MonHocTQ_MaMH");
            AddForeignKey("dbo.GiangViens", "KhoaChuNhiem_MaKhoa", "dbo.Khoas", "MaKhoa");
            AddForeignKey("dbo.GiangViens", "Khoa_MaKhoa1", "dbo.Khoas", "MaKhoa");
            AddForeignKey("dbo.GiangViens", "Khoa_MaKhoa", "dbo.Khoas", "MaKhoa");
            AddForeignKey("dbo.SinhViens", "MaKH", "dbo.KhoaHocs", "MaKH", cascadeDelete: true);
            AddForeignKey("dbo.SinhViens", "MaKhoa", "dbo.Khoas", "MaKhoa", cascadeDelete: true);
            AddForeignKey("dbo.LopHPs", "MaGV", "dbo.GiangViens", "MaGV", cascadeDelete: true);
            AddForeignKey("dbo.LopHPs", "MaMH", "dbo.MonHocs", "MaMH", cascadeDelete: true);
            AddForeignKey("dbo.Diems", "MaSV", "dbo.SinhViens", "MaSV", cascadeDelete: true);
            AddForeignKey("dbo.Diems", "MaMH", "dbo.MonHocs", "MaMH", cascadeDelete: true);
        }
    }
}
