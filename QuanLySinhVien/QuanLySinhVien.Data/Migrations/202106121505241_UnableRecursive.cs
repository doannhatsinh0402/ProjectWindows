namespace QuanLySinhVien.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnableRecursive : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MonHocs", "MaMHTQ", "dbo.MonHocs");
            DropIndex("dbo.MonHocs", new[] { "MaMHTQ" });
            AddColumn("dbo.MonHocs", "MonHocTQ_MaMH", c => c.String(maxLength: 15, unicode: false));
            AlterColumn("dbo.MonHocs", "MaMHTQ", c => c.String());
            CreateIndex("dbo.MonHocs", "MonHocTQ_MaMH");
            AddForeignKey("dbo.MonHocs", "MonHocTQ_MaMH", "dbo.MonHocs", "MaMH");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MonHocs", "MonHocTQ_MaMH", "dbo.MonHocs");
            DropIndex("dbo.MonHocs", new[] { "MonHocTQ_MaMH" });
            AlterColumn("dbo.MonHocs", "MaMHTQ", c => c.String(nullable: false, maxLength: 15, unicode: false));
            DropColumn("dbo.MonHocs", "MonHocTQ_MaMH");
            CreateIndex("dbo.MonHocs", "MaMHTQ");
            AddForeignKey("dbo.MonHocs", "MaMHTQ", "dbo.MonHocs", "MaMH");
        }
    }
}
