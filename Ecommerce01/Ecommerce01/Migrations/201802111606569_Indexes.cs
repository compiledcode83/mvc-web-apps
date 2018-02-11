namespace Ecommerce01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Indexes : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Category", new[] { "CompanyId" });
            DropIndex("dbo.Company", new[] { "DepartamentId" });
            DropIndex("dbo.City", new[] { "DepartamentId" });
            DropIndex("dbo.Province", new[] { "DepartamentId" });
            RenameIndex(table: "dbo.Users", name: "User_Name_Index", newName: "User_UserName_Index");
            CreateIndex("dbo.Category", new[] { "CompanyId", "Description" }, unique: true, name: "Category_CompanyId_Description_Index");
            CreateIndex("dbo.Company", new[] { "DepartamentId", "Name" }, unique: true, name: "City_Name_Index");
            CreateIndex("dbo.City", new[] { "DepartamentId", "Name" }, unique: true, name: "City_Name_Index");
            CreateIndex("dbo.Departament", "Name", unique: true, name: "Department_Name_Index");
            CreateIndex("dbo.Province", new[] { "DepartamentId", "Name" }, unique: true, name: "Province_Name_Index");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Province", "Province_Name_Index");
            DropIndex("dbo.Departament", "Department_Name_Index");
            DropIndex("dbo.City", "City_Name_Index");
            DropIndex("dbo.Company", "City_Name_Index");
            DropIndex("dbo.Category", "Category_CompanyId_Description_Index");
            RenameIndex(table: "dbo.Users", name: "User_UserName_Index", newName: "User_Name_Index");
            CreateIndex("dbo.Province", "DepartamentId");
            CreateIndex("dbo.City", "DepartamentId");
            CreateIndex("dbo.Company", "DepartamentId");
            CreateIndex("dbo.Category", "CompanyId");
        }
    }
}
