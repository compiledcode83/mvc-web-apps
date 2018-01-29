namespace Ecommerce01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompaCateg : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Companies", newName: "Company");
            RenameTable(name: "dbo.Categories", newName: "Category");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Category", newName: "Categories");
            RenameTable(name: "dbo.Company", newName: "Companies");
        }
    }
}
