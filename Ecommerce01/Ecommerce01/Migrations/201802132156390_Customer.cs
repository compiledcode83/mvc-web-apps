namespace Ecommerce01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 256),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        DateBirth = c.DateTime(),
                        Phone = c.String(nullable: false, maxLength: 20),
                        Address = c.String(nullable: false, maxLength: 100),
                        DepartmentId = c.Int(nullable: false),
                        ProvinceId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        Departament_DepartamentId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.City", t => t.CityId)
                .ForeignKey("dbo.Departament", t => t.Departament_DepartamentId)
                .ForeignKey("dbo.Province", t => t.ProvinceId)
                .Index(t => t.ProvinceId)
                .Index(t => t.CityId)
                .Index(t => t.Departament_DepartamentId);
            
            CreateTable(
                "dbo.CompanyCustomers",
                c => new
                    {
                        CompanyCustomerId = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyCustomerId)
                .ForeignKey("dbo.Company", t => t.CompanyId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CompanyId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "ProvinceId", "dbo.Province");
            DropForeignKey("dbo.Customers", "Departament_DepartamentId", "dbo.Departament");
            DropForeignKey("dbo.CompanyCustomers", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.CompanyCustomers", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.Customers", "CityId", "dbo.City");
            DropIndex("dbo.CompanyCustomers", new[] { "CustomerId" });
            DropIndex("dbo.CompanyCustomers", new[] { "CompanyId" });
            DropIndex("dbo.Customers", new[] { "Departament_DepartamentId" });
            DropIndex("dbo.Customers", new[] { "CityId" });
            DropIndex("dbo.Customers", new[] { "ProvinceId" });
            DropTable("dbo.CompanyCustomers");
            DropTable("dbo.Customers");
        }
    }
}
