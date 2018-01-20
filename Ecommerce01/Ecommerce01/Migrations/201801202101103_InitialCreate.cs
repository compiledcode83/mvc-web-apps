namespace Ecommerce01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departaments",
                c => new
                    {
                        DepartamentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Latitud = c.Decimal(precision: 18, scale: 6),
                        Longitud = c.Decimal(precision: 18, scale: 6),
                    })
                .PrimaryKey(t => t.DepartamentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Departaments");
        }
    }
}
