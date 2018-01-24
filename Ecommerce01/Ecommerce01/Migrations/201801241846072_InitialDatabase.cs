namespace Ecommerce01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.City",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        SigCap = c.String(nullable: false, maxLength: 5),
                        DepartamentId = c.Int(nullable: false),
                        ProvinceId = c.Int(nullable: false),
                        Latitud = c.Decimal(precision: 18, scale: 6),
                        Longitud = c.Decimal(precision: 18, scale: 6),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.Province", t => t.ProvinceId, cascadeDelete: false)
                .ForeignKey("dbo.Departament", t => t.DepartamentId, cascadeDelete: false)
                .Index(t => t.DepartamentId)
                .Index(t => t.ProvinceId);
            
            CreateTable(
                "dbo.Departament",
                c => new
                    {
                        DepartamentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Latitud = c.Decimal(precision: 18, scale: 6),
                        Longitud = c.Decimal(precision: 18, scale: 6),
                    })
                .PrimaryKey(t => t.DepartamentId);
            
            CreateTable(
                "dbo.Province",
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
                .ForeignKey("dbo.Departament", t => t.DepartamentId, cascadeDelete: false)
                .Index(t => t.DepartamentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.City", "DepartamentId", "dbo.Departament");
            DropForeignKey("dbo.Province", "DepartamentId", "dbo.Departament");
            DropForeignKey("dbo.City", "ProvinceId", "dbo.Province");
            DropIndex("dbo.Province", new[] { "DepartamentId" });
            DropIndex("dbo.City", new[] { "ProvinceId" });
            DropIndex("dbo.City", new[] { "DepartamentId" });
            DropTable("dbo.Province");
            DropTable("dbo.Departament");
            DropTable("dbo.City");
        }
    }
}
