namespace Ecommerce01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Indices : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Departaments", "Name", unique: true, name: "Departament_Name_Index");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Departaments", "Departament_Name_Index");
        }
    }
}
