namespace Examen_Alvaro.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracion2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cedula = c.String(),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        FechaNacimiento = c.String(),
                        Direccion = c.String(),
                        EstadoCivil = c.String(),
                        Sexo = c.String(),
                        FechaIngreso = c.String(),
                        Tipo = c.String(),
                        Descuento = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.inventarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cantidad = c.String(),
                        CantidadMinima = c.String(),
                        CantidadMaxima = c.String(),
                        Tipo = c.String(),
                        ProductosID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Productos", t => t.ProductosID, cascadeDelete: true)
                .Index(t => t.ProductosID);
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Marca = c.String(),
                        Familia = c.String(),
                        CasaFabricacion = c.String(),
                        TipoUnidad = c.String(),
                        Departamento = c.String(),
                        Activo = c.Boolean(nullable: false),
                        FechaIngreso = c.String(),
                        Unidad = c.String(),
                        Impuesto = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.inventarios", "ProductosID", "dbo.Productos");
            DropIndex("dbo.inventarios", new[] { "ProductosID" });
            DropTable("dbo.Productos");
            DropTable("dbo.inventarios");
            DropTable("dbo.Clientes");
        }
    }
}
