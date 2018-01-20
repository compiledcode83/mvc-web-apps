namespace Ecommerce01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        ProvinceId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        SigCap = c.String(nullable: false, maxLength: 5),
                        TwoInitial = c.String(nullable: false, maxLength: 2),
                        Latitud = c.Decimal(precision: 18, scale: 6),
                        Longitud = c.Decimal(precision: 18, scale: 6),
                        DepartamentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProvinceId)
                .ForeignKey("dbo.Departaments", t => t.DepartamentId, cascadeDelete: true)
                .Index(t => new { t.DepartamentId, t.Name }, unique: true, name: "Province_Name_Index");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Provinces", "DepartamentId", "dbo.Departaments");
            DropIndex("dbo.Provinces", "Province_Name_Index");
            DropTable("dbo.Provinces");
        }
    }
}
