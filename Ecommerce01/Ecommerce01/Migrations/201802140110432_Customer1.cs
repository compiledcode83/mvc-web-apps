namespace Ecommerce01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customer1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Customers", new[] { "Departament_DepartamentId" });
            RenameColumn(table: "dbo.Customers", name: "Departament_DepartamentId", newName: "DepartamentId");
            AlterColumn("dbo.Customers", "DepartamentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "DepartamentId");
            DropColumn("dbo.Customers", "DepartmentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "DepartmentId", c => c.Int(nullable: false));
            DropIndex("dbo.Customers", new[] { "DepartamentId" });
            AlterColumn("dbo.Customers", "DepartamentId", c => c.Int());
            RenameColumn(table: "dbo.Customers", name: "DepartamentId", newName: "Departament_DepartamentId");
            CreateIndex("dbo.Customers", "Departament_DepartamentId");
        }
    }
}
