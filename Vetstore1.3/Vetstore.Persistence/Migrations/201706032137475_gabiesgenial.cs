namespace Vetstore.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gabiesgenial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Atenciones", "MascotaId", c => c.Int(nullable: false));
            AddColumn("dbo.Servicios", "NOMBRESER", c => c.Int());
            CreateIndex("dbo.Atenciones", "MascotaId");
            AddForeignKey("dbo.Atenciones", "MascotaId", "dbo.Mascotas", "MascotaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Atenciones", "MascotaId", "dbo.Mascotas");
            DropIndex("dbo.Atenciones", new[] { "MascotaId" });
            DropColumn("dbo.Servicios", "NOMBRESER");
            DropColumn("dbo.Atenciones", "MascotaId");
        }
    }
}
