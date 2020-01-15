namespace Cs_IssPrefeitura.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 70, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 70, unicode: false),
                        ImportarMas = c.Boolean(nullable: false),
                        FechamentoMes = c.Boolean(nullable: false),
                        AlterarAtos = c.Boolean(nullable: false),
                        AbrirFecharLivro = c.Boolean(nullable: false),
                        ImprimirFechamentoMes = c.Boolean(nullable: false),
                        UsuarioMaster = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuario");
        }
    }
}
