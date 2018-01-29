namespace Ecommerce01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedConfigurations1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                        ProvinceId = c.Int(nullable: false),
                        DepartamentId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        AddressO = c.String(nullable: false, maxLength: 100),
                        AddressL = c.String(maxLength: 100),
                        Locality = c.String(maxLength: 60),
                        Logo = c.String(),
                        PartitaIva = c.String(maxLength: 15),
                        CodiceFiscale = c.String(maxLength: 15),
                        Phone = c.String(nullable: false, maxLength: 20),
                        PhoneMobil = c.String(maxLength: 20),
                        Fax = c.String(),
                        Email = c.String(nullable: false),
                        http = c.String(),
                    })
                .PrimaryKey(t => t.CompanyId)
                .ForeignKey("dbo.City", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Departament", t => t.DepartamentId, cascadeDelete: true)
                .ForeignKey("dbo.Province", t => t.ProvinceId, cascadeDelete: true)
                .Index(t => t.ProvinceId)
                .Index(t => t.DepartamentId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false, maxLength: 50),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "ProvinceId", "dbo.Province");
            DropForeignKey("dbo.Companies", "DepartamentId", "dbo.Departament");
            DropForeignKey("dbo.Companies", "CityId", "dbo.City");
            DropForeignKey("dbo.Categories", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Categories", new[] { "CompanyId" });
            DropIndex("dbo.Companies", new[] { "CityId" });
            DropIndex("dbo.Companies", new[] { "DepartamentId" });
            DropIndex("dbo.Companies", new[] { "ProvinceId" });
            DropTable("dbo.Categories");
            DropTable("dbo.Companies");
        }
    }
}
