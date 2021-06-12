namespace QuanLySinhVien.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateObjectDiem : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Diems", "DiemQT", c => c.Int(nullable: false));
            AlterColumn("dbo.Diems", "DiemThi", c => c.Int(nullable: false));
            AlterColumn("dbo.Diems", "DiemTB", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Diems", "DiemTB", c => c.String());
            AlterColumn("dbo.Diems", "DiemThi", c => c.String());
            AlterColumn("dbo.Diems", "DiemQT", c => c.String());
        }
    }
}
