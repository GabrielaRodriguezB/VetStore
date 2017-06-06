namespace Vetstore.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atenciones",
                c => new
                    {
                        AtencionId = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AtencionId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Mascotas",
                c => new
                    {
                        MascotaId = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MascotaId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Especies",
                c => new
                    {
                        EspecieId = c.Int(nullable: false, identity: true),
                        MascotaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EspecieId)
                .ForeignKey("dbo.Mascotas", t => t.MascotaId, cascadeDelete: true)
                .Index(t => t.MascotaId);
            
            CreateTable(
                "dbo.Razas",
                c => new
                    {
                        RazaId = c.Int(nullable: false, identity: true),
                        EspecieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RazaId)
                .ForeignKey("dbo.Especies", t => t.EspecieId, cascadeDelete: true)
                .Index(t => t.EspecieId);
            
            CreateTable(
                "dbo.Vacunas",
                c => new
                    {
                        VacunaId = c.Int(nullable: false, identity: true),
                        MascotaId = c.Int(nullable: false),
                        ServicioClinicoId = c.Int(nullable: false),
                        ServicioClinico_ServicioId = c.Int(),
                        Veterinario_VeterinarioId = c.Int(),
                    })
                .PrimaryKey(t => t.VacunaId)
                .ForeignKey("dbo.Servicios", t => t.ServicioClinico_ServicioId)
                .ForeignKey("dbo.Veterinarios", t => t.Veterinario_VeterinarioId)
                .ForeignKey("dbo.Mascotas", t => t.MascotaId, cascadeDelete: true)
                .Index(t => t.MascotaId)
                .Index(t => t.ServicioClinico_ServicioId)
                .Index(t => t.Veterinario_VeterinarioId);
            
            CreateTable(
                "dbo.Servicios",
                c => new
                    {
                        ServicioId = c.Int(nullable: false, identity: true),
                        TecnicoId = c.Int(nullable: false),
                        AtencionId = c.Int(nullable: false),
                        VeterinarioId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ServicioId)
                .ForeignKey("dbo.Tecnicos", t => t.TecnicoId, cascadeDelete: true)
                .ForeignKey("dbo.Veterinarios", t => t.VeterinarioId, cascadeDelete: true)
                .ForeignKey("dbo.Atenciones", t => t.AtencionId, cascadeDelete: true)
                .Index(t => t.TecnicoId)
                .Index(t => t.AtencionId)
                .Index(t => t.VeterinarioId);
            
            CreateTable(
                "dbo.Tecnicos",
                c => new
                    {
                        TecnicoId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.TecnicoId);
            
            CreateTable(
                "dbo.Veterinarios",
                c => new
                    {
                        VeterinarioId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.VeterinarioId);
            
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        VentaId = c.Int(nullable: false, identity: true),
                        MedioPagoId = c.Int(nullable: false),
                        LocalId = c.Int(nullable: false),
                        AtencionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VentaId)
                .ForeignKey("dbo.Locales", t => t.LocalId, cascadeDelete: true)
                .ForeignKey("dbo.MediosPago", t => t.MedioPagoId, cascadeDelete: true)
                .ForeignKey("dbo.Atenciones", t => t.AtencionId, cascadeDelete: true)
                .Index(t => t.MedioPagoId)
                .Index(t => t.LocalId)
                .Index(t => t.AtencionId);
            
            CreateTable(
                "dbo.Locales",
                c => new
                    {
                        LocalId = c.Int(nullable: false),
                        DireccionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocalId)
                .ForeignKey("dbo.Direcciones", t => t.LocalId)
                .Index(t => t.LocalId);
            
            CreateTable(
                "dbo.Direcciones",
                c => new
                    {
                        DireccionId = c.Int(nullable: false, identity: true),
                        LocalId = c.Int(nullable: false),
                        UbigeoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DireccionId)
                .ForeignKey("dbo.Ubigeos", t => t.UbigeoId, cascadeDelete: true)
                .Index(t => t.UbigeoId);
            
            CreateTable(
                "dbo.Ubigeos",
                c => new
                    {
                        UbigeoId = c.Int(nullable: false, identity: true),
                        ProvinciaId = c.Int(nullable: false),
                        DepartamentoId = c.Int(nullable: false),
                        DistritoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UbigeoId);
            
            CreateTable(
                "dbo.Departamentos",
                c => new
                    {
                        DepartamentoId = c.Int(nullable: false),
                        UbigeoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartamentoId)
                .ForeignKey("dbo.Ubigeos", t => t.DepartamentoId)
                .Index(t => t.DepartamentoId);
            
            CreateTable(
                "dbo.Provincias",
                c => new
                    {
                        ProvinciaId = c.Int(nullable: false),
                        DepartamentoId = c.Int(nullable: false),
                        UbigeoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProvinciaId)
                .ForeignKey("dbo.Departamentos", t => t.DepartamentoId, cascadeDelete: true)
                .ForeignKey("dbo.Ubigeos", t => t.ProvinciaId)
                .Index(t => t.ProvinciaId)
                .Index(t => t.DepartamentoId);
            
            CreateTable(
                "dbo.Distritos",
                c => new
                    {
                        DistritoId = c.Int(nullable: false),
                        ProvinciaId = c.Int(nullable: false),
                        UbigeoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DistritoId)
                .ForeignKey("dbo.Provincias", t => t.ProvinciaId, cascadeDelete: true)
                .ForeignKey("dbo.Ubigeos", t => t.DistritoId)
                .Index(t => t.DistritoId)
                .Index(t => t.ProvinciaId);
            
            CreateTable(
                "dbo.MediosPago",
                c => new
                    {
                        MedioPagoId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.MedioPagoId);
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        ProductoId = c.Int(nullable: false, identity: true),
                        CategoriaProductoId = c.Int(nullable: false),
                        VentaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductoId)
                .ForeignKey("dbo.CategoriasProducto", t => t.CategoriaProductoId, cascadeDelete: true)
                .ForeignKey("dbo.Ventas", t => t.VentaId, cascadeDelete: true)
                .Index(t => t.CategoriaProductoId)
                .Index(t => t.VentaId);
            
            CreateTable(
                "dbo.CategoriasProducto",
                c => new
                    {
                        CategoriaProductoId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CategoriaProductoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ventas", "AtencionId", "dbo.Atenciones");
            DropForeignKey("dbo.Productos", "VentaId", "dbo.Ventas");
            DropForeignKey("dbo.Productos", "CategoriaProductoId", "dbo.CategoriasProducto");
            DropForeignKey("dbo.Ventas", "MedioPagoId", "dbo.MediosPago");
            DropForeignKey("dbo.Ventas", "LocalId", "dbo.Locales");
            DropForeignKey("dbo.Locales", "LocalId", "dbo.Direcciones");
            DropForeignKey("dbo.Provincias", "ProvinciaId", "dbo.Ubigeos");
            DropForeignKey("dbo.Distritos", "DistritoId", "dbo.Ubigeos");
            DropForeignKey("dbo.Direcciones", "UbigeoId", "dbo.Ubigeos");
            DropForeignKey("dbo.Departamentos", "DepartamentoId", "dbo.Ubigeos");
            DropForeignKey("dbo.Provincias", "DepartamentoId", "dbo.Departamentos");
            DropForeignKey("dbo.Distritos", "ProvinciaId", "dbo.Provincias");
            DropForeignKey("dbo.Servicios", "AtencionId", "dbo.Atenciones");
            DropForeignKey("dbo.Mascotas", "ClienteId", "dbo.Clientes");
            DropForeignKey("dbo.Vacunas", "MascotaId", "dbo.Mascotas");
            DropForeignKey("dbo.Vacunas", "Veterinario_VeterinarioId", "dbo.Veterinarios");
            DropForeignKey("dbo.Servicios", "VeterinarioId", "dbo.Veterinarios");
            DropForeignKey("dbo.Vacunas", "ServicioClinico_ServicioId", "dbo.Servicios");
            DropForeignKey("dbo.Servicios", "TecnicoId", "dbo.Tecnicos");
            DropForeignKey("dbo.Especies", "MascotaId", "dbo.Mascotas");
            DropForeignKey("dbo.Razas", "EspecieId", "dbo.Especies");
            DropForeignKey("dbo.Atenciones", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Productos", new[] { "VentaId" });
            DropIndex("dbo.Productos", new[] { "CategoriaProductoId" });
            DropIndex("dbo.Distritos", new[] { "ProvinciaId" });
            DropIndex("dbo.Distritos", new[] { "DistritoId" });
            DropIndex("dbo.Provincias", new[] { "DepartamentoId" });
            DropIndex("dbo.Provincias", new[] { "ProvinciaId" });
            DropIndex("dbo.Departamentos", new[] { "DepartamentoId" });
            DropIndex("dbo.Direcciones", new[] { "UbigeoId" });
            DropIndex("dbo.Locales", new[] { "LocalId" });
            DropIndex("dbo.Ventas", new[] { "AtencionId" });
            DropIndex("dbo.Ventas", new[] { "LocalId" });
            DropIndex("dbo.Ventas", new[] { "MedioPagoId" });
            DropIndex("dbo.Servicios", new[] { "VeterinarioId" });
            DropIndex("dbo.Servicios", new[] { "AtencionId" });
            DropIndex("dbo.Servicios", new[] { "TecnicoId" });
            DropIndex("dbo.Vacunas", new[] { "Veterinario_VeterinarioId" });
            DropIndex("dbo.Vacunas", new[] { "ServicioClinico_ServicioId" });
            DropIndex("dbo.Vacunas", new[] { "MascotaId" });
            DropIndex("dbo.Razas", new[] { "EspecieId" });
            DropIndex("dbo.Especies", new[] { "MascotaId" });
            DropIndex("dbo.Mascotas", new[] { "ClienteId" });
            DropIndex("dbo.Atenciones", new[] { "ClienteId" });
            DropTable("dbo.CategoriasProducto");
            DropTable("dbo.Productos");
            DropTable("dbo.MediosPago");
            DropTable("dbo.Distritos");
            DropTable("dbo.Provincias");
            DropTable("dbo.Departamentos");
            DropTable("dbo.Ubigeos");
            DropTable("dbo.Direcciones");
            DropTable("dbo.Locales");
            DropTable("dbo.Ventas");
            DropTable("dbo.Veterinarios");
            DropTable("dbo.Tecnicos");
            DropTable("dbo.Servicios");
            DropTable("dbo.Vacunas");
            DropTable("dbo.Razas");
            DropTable("dbo.Especies");
            DropTable("dbo.Mascotas");
            DropTable("dbo.Clientes");
            DropTable("dbo.Atenciones");
        }
    }
}
