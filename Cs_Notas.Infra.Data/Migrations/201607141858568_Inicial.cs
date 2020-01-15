namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Cpf = c.String(maxLength: 14, unicode: false),
                        Qualificacao = c.String(maxLength: 100, unicode: false),
                        Matricula = c.String(maxLength: 15, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 30, unicode: false),
                        Master = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        AlterarAto = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        ExcluirAto = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        SelarAto = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        LiberarAto = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        ReservarSelo = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        AlterarSelo = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        AlterarEmolumentos = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuario");
        }
    }
}
