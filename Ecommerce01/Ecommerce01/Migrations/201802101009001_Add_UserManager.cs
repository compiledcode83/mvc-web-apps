namespace Ecommerce01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_UserManager : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Category", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.Company", "CityId", "dbo.City");
            DropForeignKey("dbo.Company", "DepartamentId", "dbo.Departament");
            DropForeignKey("dbo.Company", "ProvinceId", "dbo.Province");
            DropForeignKey("dbo.City", "DepartamentId", "dbo.Departament");
            DropForeignKey("dbo.City", "ProvinceId", "dbo.Province");
            DropForeignKey("dbo.Province", "DepartamentId", "dbo.Departament");
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 256),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        DateBirth = c.DateTime(),
                        Phone = c.String(nullable: false, maxLength: 20),
                        Address = c.String(nullable: false, maxLength: 100),
                        Photo = c.String(),
                        DepartamentId = c.Int(nullable: false),
                        ProvinceId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.City", t => t.CityId)
                .ForeignKey("dbo.Company", t => t.CompanyId)
                .ForeignKey("dbo.Departament", t => t.DepartamentId)
                .ForeignKey("dbo.Province", t => t.ProvinceId)
                .Index(t => t.UserName, unique: true, name: "User_Name_Index")
                .Index(t => t.DepartamentId)
                .Index(t => t.ProvinceId)
                .Index(t => t.CityId)
                .Index(t => t.CompanyId);
            
            AddColumn("dbo.Category", "User_UserId", c => c.Int());
            AlterColumn("dbo.Company", "AddressO", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Company", "AddressL", c => c.String(maxLength: 200));
            AlterColumn("dbo.Company", "Locality", c => c.String(maxLength: 100));
            CreateIndex("dbo.Category", "User_UserId");
            AddForeignKey("dbo.Category", "User_UserId", "dbo.Users", "UserId");
            AddForeignKey("dbo.Category", "CompanyId", "dbo.Company", "CompanyId");
            AddForeignKey("dbo.Company", "CityId", "dbo.City", "CityId");
            AddForeignKey("dbo.Company", "DepartamentId", "dbo.Departament", "DepartamentId");
            AddForeignKey("dbo.Company", "ProvinceId", "dbo.Province", "ProvinceId");
            AddForeignKey("dbo.City", "DepartamentId", "dbo.Departament", "DepartamentId");
            AddForeignKey("dbo.City", "ProvinceId", "dbo.Province", "ProvinceId");
            AddForeignKey("dbo.Province", "DepartamentId", "dbo.Departament", "DepartamentId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Province", "DepartamentId", "dbo.Departament");
            DropForeignKey("dbo.City", "ProvinceId", "dbo.Province");
            DropForeignKey("dbo.City", "DepartamentId", "dbo.Departament");
            DropForeignKey("dbo.Company", "ProvinceId", "dbo.Province");
            DropForeignKey("dbo.Company", "DepartamentId", "dbo.Departament");
            DropForeignKey("dbo.Company", "CityId", "dbo.City");
            DropForeignKey("dbo.Category", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.Users", "ProvinceId", "dbo.Province");
            DropForeignKey("dbo.Users", "DepartamentId", "dbo.Departament");
            DropForeignKey("dbo.Users", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.Users", "CityId", "dbo.City");
            DropForeignKey("dbo.Category", "User_UserId", "dbo.Users");
            DropIndex("dbo.Users", new[] { "CompanyId" });
            DropIndex("dbo.Users", new[] { "CityId" });
            DropIndex("dbo.Users", new[] { "ProvinceId" });
            DropIndex("dbo.Users", new[] { "DepartamentId" });
            DropIndex("dbo.Users", "User_Name_Index");
            DropIndex("dbo.Category", new[] { "User_UserId" });
            AlterColumn("dbo.Company", "Locality", c => c.String(maxLength: 60));
            AlterColumn("dbo.Company", "AddressL", c => c.String(maxLength: 100));
            AlterColumn("dbo.Company", "AddressO", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Category", "User_UserId");
            DropTable("dbo.Users");
            AddForeignKey("dbo.Province", "DepartamentId", "dbo.Departament", "DepartamentId", cascadeDelete: true);
            AddForeignKey("dbo.City", "ProvinceId", "dbo.Province", "ProvinceId", cascadeDelete: true);
            AddForeignKey("dbo.City", "DepartamentId", "dbo.Departament", "DepartamentId", cascadeDelete: true);
            AddForeignKey("dbo.Company", "ProvinceId", "dbo.Province", "ProvinceId", cascadeDelete: true);
            AddForeignKey("dbo.Company", "DepartamentId", "dbo.Departament", "DepartamentId", cascadeDelete: true);
            AddForeignKey("dbo.Company", "CityId", "dbo.City", "CityId", cascadeDelete: true);
            AddForeignKey("dbo.Category", "CompanyId", "dbo.Company", "CompanyId", cascadeDelete: true);
        }
    }
}
